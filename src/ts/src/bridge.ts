// bridge.ts
import Dexie from "dexie";

let db: Dexie | null = null;

let dexie = {
  // Initialize database
  init: (name: string, version: number, schema: { [key: string]: string }) => {
    db = new Dexie(name);
    db.version(version).stores(schema);
    return db.open();
  },

  deleteDatabase: async (name: string) => {
    if (db) {
      db.close();
      db = null;
    }
    return await Dexie.delete(name);
  },

  // Generic table operations
  table: {
    add: (tableName: string, item: any) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).add(item);
    },

    get: (tableName: string, id: number) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).get(id);
    },

    put: (tableName: string, item: any) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).put(item);
    },

    delete: (tableName: string, id: number) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).delete(id);
    },

    // Query operations
    getAll: (tableName: string) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).toArray();
    },

    where: (tableName: string, key: string, value: any) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).where(key).equals(value).toArray();
    },

    between: (tableName: string, key: string, lower: any, upper: any) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).where(key).between(lower, upper).toArray();
    },

    // Bulk operations
    bulkAdd: (tableName: string, items: any[]) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).bulkAdd(items);
    },

    bulkPut: (tableName: string, items: any[]) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).bulkPut(items);
    },

    bulkDelete: (tableName: string, ids: number[]) => {
      if (!db) throw new Error("Database not initialized");
      return db.table(tableName).bulkDelete(ids);
    },
  },
};

window.dexie = dexie;

declare global {
  interface Window {
    dexie: {
      init: typeof dexie.init;
      deleteDatabase: typeof dexie.deleteDatabase;
      table: typeof dexie.table;
    };
  }
}
