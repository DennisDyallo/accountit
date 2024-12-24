// src/database.ts
import Dexie, { Table } from "dexie";
import { DatabaseError, ValidationError } from "../errors";

/**
 * Represents the schema for a single store
 */
export interface StoreSchema {
  name: string;
  indexes: string[];
  options?: {
    multiEntry?: boolean;
    unique?: boolean;
  };
}

/**
 * Database configuration options
 */
export interface DatabaseOptions {
  name: string;
  version?: number;
  schema: StoreSchema[];
  enableLogging?: boolean;
}

/**
 * Base interface for all stored objects
 */
export interface StoredObject {
  id?: number;
  created?: Date;
  modified?: Date;
}

/**
 * Generic database class built on top of Dexie
 */
export class GenericDatabase extends Dexie {
  private _stores: Map<string, Table<any, any>> = new Map();
  private _options: DatabaseOptions;

  constructor(options: DatabaseOptions) {
    super(options.name);
    this._options = options;
    this.configureDatabase();
  }

  /**
   * Configures the database schema and hooks
   */
  private configureDatabase(): void {
    const { schema, version = 1 } = this._options;

    // Validate schema
    this.validateSchema(schema);

    // Create store definitions
    const storeDefinitions = this.createStoreDefinitions(schema);

    // Initialize version
    this.version(version).stores(storeDefinitions);

    // Set up stores map
    schema.forEach((store) => {
      this._stores.set(store.name, this.table(store.name));
    });

    // Add hooks for all stores
    this.setupHooks();
  }

  /**
   * Returns a store by name
   */
  getStore<T extends StoredObject>(name: string): Table<T, number> {
    const store = this._stores.get(name);
    if (!store) {
      throw new DatabaseError(`Store '${name}' not found`);
    }
    return store;
  }

  /**
   * Returns all store names
   */
  get stores(): Map<string, Table<any, any>> {
    return this._stores;
  }

  /**
   * Creates a new store at runtime
   */
  async createStore(schema: StoreSchema): Promise<void> {
    const version = this.verno + 1;
    const newStores = { ...this.createStoreDefinitions([schema]) };

    this.version(version).stores(newStores);
    await this.open();

    this._stores.set(schema.name, this.table(schema.name));
  }

  // Private utility methods

  private validateSchema(schema: StoreSchema[]): void {
    if (!Array.isArray(schema) || schema.length === 0) {
      throw new ValidationError("At least one store schema is required");
    }

    const storeNames = new Set<string>();
    schema.forEach((store) => {
      if (!store.name) {
        throw new ValidationError("Store name is required");
      }
      if (storeNames.has(store.name)) {
        throw new ValidationError(`Duplicate store name: ${store.name}`);
      }
      storeNames.add(store.name);

      if (!Array.isArray(store.indexes)) {
        throw new ValidationError(
          `Indexes must be an array for store: ${store.name}`
        );
      }
    });
  }

  private createStoreDefinitions(schema: StoreSchema[]): {
    [key: string]: string;
  } {
    const definitions: { [key: string]: string } = {};

    schema.forEach((store) => {
      // Always include id as primary key
      const indexes = ["++id", ...store.indexes];

      // Handle unique and multi-entry indexes
      const processedIndexes = indexes.map((index) => {
        if (store.options?.unique && !index.startsWith("++")) {
          return `&${index}`;
        }
        if (store.options?.multiEntry) {
          return `*${index}`;
        }
        return index;
      });

      definitions[store.name] = processedIndexes.join(",");
    });

    return definitions;
  }

  private setupHooks(): void {
    // Add hooks for all stores
    this._stores.forEach((store, name) => {
      // Creating hook
      store.hook("creating", (primKey, obj) => {
        const now = new Date();
        return {
          ...obj,
          created: now,
          modified: now,
        };
      });

      // Updating hook
      store.hook("updating", (modifications, primKey, obj) => {
        return {
          ...modifications,
          modified: new Date(),
        };
      });

      if (this._options.enableLogging) {
        // Debug hooks
        store.hook("reading", (obj) => {
          console.debug(`Reading from ${name}:`, obj);
          return obj;
        });
      }
    });
  }

  /**
   * Helper to check if a store exists
   */
  hasStore(name: string): boolean {
    return this._stores.has(name);
  }

  /**
   * Clean up resources
   */
  async dispose(): Promise<void> {
    if (this.isOpen()) {
      this.close();
    }
  }
}

// Export a factory function for creating database instances
export function createDatabase(options: DatabaseOptions): GenericDatabase {
  return new GenericDatabase(options);
}
