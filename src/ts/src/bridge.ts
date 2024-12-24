// src/bridge.ts
import {
  GenericDatabase,
  DatabaseOptions,
  StoreSchema,
} from "./database/database";
import { BridgeError, ValidationError, DatabaseError } from "./errors";

/**
 * Type guard for error handling
 */
function isError(error: unknown): error is Error {
  return error instanceof Error;
}

/**
 * Main interop class for Blazor communication
 */
export class DexieInterop {
  private static db: GenericDatabase | null = null;
  private static isInitialized = false;

  /**
   * Initializes the database with the given configuration
   */
  static async initialize(options: DatabaseOptions): Promise<void> {
    if (this.isInitialized) {
      console.warn("Database already initialized");
      return;
    }

    try {
      this.validateDatabaseOptions(options);
      this.db = new GenericDatabase(options.name, options.schema);
      await this.db.open();
      this.isInitialized = true;

      if (options.enableLogging) {
        console.info(
          `Database ${options.name} initialized with stores:`,
          options.schema.map((s) => s.name).join(", ")
        );
      }
    } catch (error) {
      const message = isError(error)
        ? error.message
        : "Unknown error during initialization";
      throw new DatabaseError(
        "Failed to initialize database: " + message,
        error
      );
    }
  }

  /**
   * Adds an item to a store
   */
  static async add<T>(storeName: string, item: T): Promise<number> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      // Add created timestamp if not present
      const itemWithTimestamp = {
        ...item,
        created: item.hasOwnProperty("created") ? item.created : new Date(),
      };

      return await store.add(itemWithTimestamp);
    } catch (error) {
      throw this.handleError(error, `Failed to add item to ${storeName}`);
    }
  }

  /**
   * Retrieves an item by ID
   */
  static async get<T>(storeName: string, id: number): Promise<T | undefined> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      return await store.get(id);
    } catch (error) {
      throw this.handleError(
        error,
        `Failed to get item ${id} from ${storeName}`
      );
    }
  }

  /**
   * Updates an existing item
   */
  static async update<T>(
    storeName: string,
    id: number,
    changes: Partial<T>
  ): Promise<boolean> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      // Add modified timestamp
      const changesWithTimestamp = {
        ...changes,
        modified: new Date(),
      };

      await store.update(id, changesWithTimestamp);
      return true;
    } catch (error) {
      throw this.handleError(
        error,
        `Failed to update item ${id} in ${storeName}`
      );
    }
  }

  /**
   * Deletes an item by ID
   */
  static async delete(storeName: string, id: number): Promise<void> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      await store.delete(id);
    } catch (error) {
      throw this.handleError(
        error,
        `Failed to delete item ${id} from ${storeName}`
      );
    }
  }

  /**
   * Retrieves items by an index value
   */
  static async getByIndex<T>(
    storeName: string,
    indexName: string,
    value: any
  ): Promise<T[]> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      return await store.where(indexName).equals(value).toArray();
    } catch (error) {
      throw this.handleError(
        error,
        `Failed to get items from ${storeName} where ${indexName} equals ${value}`
      );
    }
  }

  /**
   * Bulk operation to add multiple items
   */
  static async bulkAdd<T>(storeName: string, items: T[]): Promise<number[]> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      const timestamp = new Date();
      const itemsWithTimestamp = items.map((item) => ({
        ...item,
        created: timestamp,
      }));

      return await store.bulkAdd(itemsWithTimestamp, { allKeys: true });
    } catch (error) {
      throw this.handleError(error, `Failed to bulk add items to ${storeName}`);
    }
  }

  /**
   * Clears all data from a store
   */
  static async clear(storeName: string): Promise<void> {
    this.ensureInitialized();

    try {
      const store = this.db!.getStore(storeName);
      await store.clear();
    } catch (error) {
      throw this.handleError(error, `Failed to clear store ${storeName}`);
    }
  }

  /**
   * Gets database status information
   */
  static async getStatus(): Promise<{
    isOpen: boolean;
    stores: string[];
    version: number;
    size?: number;
  }> {
    this.ensureInitialized();

    try {
      return {
        isOpen: this.db!.isOpen(),
        stores: Array.from(this.db!.stores.keys()),
        version: this.db!.verno,
        // Estimate size if possible
        size: await this.estimateDatabaseSize(),
      };
    } catch (error) {
      throw this.handleError(error, "Failed to get database status");
    }
  }

  // Private utility methods

  private static validateDatabaseOptions(options: DatabaseOptions): void {
    if (!options.name) {
      throw new ValidationError("Database name is required");
    }
    if (!Array.isArray(options.schema) || options.schema.length === 0) {
      throw new ValidationError("At least one store schema is required");
    }
  }

  private static ensureInitialized(): void {
    if (!this.isInitialized || !this.db) {
      throw new DatabaseError(
        "Database not initialized. Call initialize() first."
      );
    }
  }

  private static handleError(error: unknown, context: string): Error {
    if (error instanceof ValidationError || error instanceof DatabaseError) {
      return error;
    }

    const message = isError(error) ? error.message : "Unknown error";
    return new BridgeError(`${context}: ${message}`, error);
  }

  private static async estimateDatabaseSize(): Promise<number | undefined> {
    try {
      const stats = await navigator.storage.estimate();
      return stats.usage;
    } catch {
      return undefined;
    }
  }
}

// Register for Blazor interop
declare global {
  interface Window {
    DexieInterop: typeof DexieInterop;
  }
}

window.DexieInterop = DexieInterop;
