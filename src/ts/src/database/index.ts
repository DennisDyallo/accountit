// src/database/index.ts
import { GenericDatabase, createDatabase } from "./database";

// Re-export types from database
export type { DatabaseOptions, StoreSchema, StoredObject } from "./database";

// Re-export the database class and factory
export { GenericDatabase, createDatabase };

// Export common store types that can be extended
export interface BaseEntity {
  id?: number;
  created?: Date;
  modified?: Date;
}

export interface VersionedEntity extends BaseEntity {
  version: number;
  isDeleted?: boolean;
}

export interface AuditedEntity extends VersionedEntity {
  createdBy?: string;
  modifiedBy?: string;
}

// Export common index types
export interface IndexDefinition {
  name: string;
  keyPath: string | string[];
  unique?: boolean;
  multiEntry?: boolean;
}

// Export database utilities
export function isInitialized(db: GenericDatabase): boolean {
  return db.isOpen();
}
