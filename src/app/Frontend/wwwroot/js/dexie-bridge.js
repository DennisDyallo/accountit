(function () {
  "use strict";

  let db = null;

  const dexie = {
    // Initialize database
    init: function (name, version, schema) {
      db = new Dexie(name);
      db.version(version).stores(schema);
      return db.open();
    },

    deleteDatabase: async function (name) {
      if (db) {
        db.close();
        db = null;
      }
      return await Dexie.delete(name);
    },

    // Generic table operations
    table: {
      add: async function (tableName, item) {
        if (!db) throw new Error("Database not initialized");
        //debugger;
        await db.table(tableName).add(item);
      },

      get: async function (tableName, id) {
        if (!db) throw new Error("Database not initialized");
        return await db.table(tableName).get(id);
      },

      put: async function (tableName, item) {
        if (!db) throw new Error("Database not await ");
        return await db.table(tableName).put(item);
      },

      delete: async function (tableName, id) {
        if (!db) throw new Error("Database not initialized");
        await db.table(tableName).delete(id);
      },

      // Query operations
      getAll: async function (tableName) {
        // debugger;
        if (!db) throw new Error("Database not initialized");
        return await db.table(tableName).toArray();
      },

      where: async function (tableName, key, value) {
        if (!db) throw new Error("Database not initialized");
        return await db.table(tableName).where(key).equals(value).toArray();
      },

      between: async function (tableName, key, lower, upper) {
        if (!db) throw new Error("Database not initialized");
        return await db
          .table(tableName)
          .where(key)
          .between(lower, upper)
          .toArray();
      },

      // Bulk operations
      bulkAdd: async function (tableName, items) {
        if (!db) throw new Error("Database not initialized");
        await db.table(tableName).bulkAdd(items);
      },

      bulkPut: async function (tableName, items) {
        if (!db) throw new Error("Database not initialized");
        await db.table(tableName).bulkPut(items);
      },

      bulkDelete: async function (tableName, ids) {
        if (!db) throw new Error("Database not initialized");
        await db.table(tableName).bulkDelete(ids);
      },
    },
  };

  // Expose to window object
  window.dexie = dexie;
})();
