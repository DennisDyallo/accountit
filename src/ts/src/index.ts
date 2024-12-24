// src/index.ts
export * from "./database";
export * from "./errors";
export { DexieInterop } from "./bridge";

// Export version information
export const VERSION = "1.0.0";

// Export default factory function
export { createDatabase } from "./database";
