import { DatabaseError } from "./DatabaseError";

// src/errors/transaction.ts

export class TransactionError extends DatabaseError {
  constructor(message: string, cause?: unknown) {
    super(message, cause);
    this.name = "TransactionError";

    Object.setPrototypeOf(this, TransactionError.prototype);
  }
}
