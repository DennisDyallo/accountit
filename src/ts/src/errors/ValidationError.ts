import { BridgeError } from "./BridgeError";

// src/errors/validation.ts

export class ValidationError extends BridgeError {
  constructor(message: string, cause?: unknown) {
    super(message, cause);
    this.name = "ValidationError";

    Object.setPrototypeOf(this, ValidationError.prototype);
  }
}
