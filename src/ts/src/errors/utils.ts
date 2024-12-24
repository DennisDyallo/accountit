import { DatabaseError, SchemaError, ValidationError, BridgeError } from ".";

// src/errors/utils.ts
export function isIndexedDBError(error: unknown): boolean {
  return (
    error instanceof Error &&
    "name" in error &&
    [
      "ConstraintError",
      "VersionError",
      "AbortError",
      "QuotaExceededError",
    ].includes(error.name)
  );
}

export function wrapIndexedDBError(
  error: unknown,
  context: string
): BridgeError {
  if (error instanceof BridgeError) {
    return error;
  }

  if (error instanceof DOMException) {
    switch (error.name) {
      case "ConstraintError":
        return new ValidationError(
          `${context}: Constraint violation - ${error.message}`,
          error
        );
      case "QuotaExceededError":
        return new DatabaseError(
          `${context}: Storage quota exceeded - ${error.message}`,
          error
        );
      case "VersionError":
        return new SchemaError(
          `${context}: Version mismatch - ${error.message}`,
          error
        );
      default:
        return new DatabaseError(`${context}: ${error.message}`, error);
    }
  }

  return new BridgeError(
    `${context}: ${error instanceof Error ? error.message : "Unknown error"}`,
    error
  );
}

// Usage example:
try {
  // Database operation
} catch (error) {
  throw wrapIndexedDBError(error, "Failed to perform operation");
}

// Example C# error handling:
/*
  public class OfflineStorageException : Exception
  {
      public string Context { get; }
      public string ErrorType { get; }
  
      public OfflineStorageException(
          string message,
          string context,
          string errorType,
          Exception innerException = null)
          : base(message, innerException)
      {
          Context = context;
          ErrorType = errorType;
      }
  
      public static OfflineStorageException FromJSError(JSException error)
      {
          try
          {
              var jsError = JsonSerializer.Deserialize<BridgeErrorDTO>(
                  error.Message,
                  new JsonSerializerOptions
                  {
                      PropertyNameCaseInsensitive = true
                  });
  
              return new OfflineStorageException(
                  jsError.Message,
                  jsError.Context,
                  jsError.Name,
                  error);
          }
          catch
          {
              return new OfflineStorageException(
                  error.Message,
                  "Unknown",
                  "UnknownError",
                  error);
          }
      }
  }
  
  private class BridgeErrorDTO
  {
      public string Name { get; set; }
      public string Message { get; set; }
      public string Context { get; set; }
      public string Stack { get; set; }
  }
  */
