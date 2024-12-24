import { BridgeError } from "./BridgeError";

// src/errors/database.ts

export class DatabaseError extends BridgeError {
  constructor(message: string, cause?: unknown) {
    super(message, cause);
    this.name = "DatabaseError";

    Object.setPrototypeOf(this, DatabaseError.prototype);
  }
}
