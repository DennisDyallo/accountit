// src/errors/base.ts
export class BridgeError extends Error {
  public cause?: unknown;

  constructor(message: string, cause?: unknown) {
    super(message);
    this.name = "BridgeError";
    this.cause = cause;

    // Ensure proper prototype chain for instanceof
    Object.setPrototypeOf(this, BridgeError.prototype);
  }

  toJSON() {
    return {
      name: this.name,
      message: this.message,
      cause: this.cause,
      stack: this.stack,
    };
  }
}
