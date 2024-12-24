import { DatabaseError } from "./DatabaseError";

// src/errors/schema.ts

export class SchemaError extends DatabaseError {
  constructor(message: string, cause?: unknown) {
    super(message, cause);
    this.name = "SchemaError";

    Object.setPrototypeOf(this, SchemaError.prototype);
  }
}
