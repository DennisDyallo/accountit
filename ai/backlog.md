# Feature Backlog

## P0 - Critical/Must Have

### 1. Initial Database Schema Setup
- Implement IndexedDB stores as defined in app-spec.md:
  ```javascript
  stores: {
    accounts: { keyPath: "number" },
    transactions: { keyPath: "id", autoIncrement: true },
    invoices: { keyPath: "id", autoIncrement: true },
    attachments: { keyPath: "id", autoIncrement: true },
    settings: { keyPath: "id" },
    fiscalYears: { keyPath: "year" }
  }
  ```
- Complete DexieStore.cs implementation
- Set up proper database versioning

### 2. Basic CRUD Operations
- Complete missing methods in DexieStore.cs
- Implement bulk operations for transactions
- Add proper error handling with retries
- Ensure proper TypeScript typings for Dexie operations

## P1 - High Priority

### 1. Data Validation Layer
- Swedish format validation (dates, amounts)
- Business rule validation using AccountClassHelper.cs
- Data integrity checks
- Transaction validation rules

### 2. Data Migration Support
- Version migration handling
- Schema upgrade support
- Data backup before migrations
- Safe schema evolution

### 3. Transaction Management
- Proper transaction scope handling
- Rollback support for failed operations
- ACID compliance for critical operations
- Bulk operation transaction support

## P2 - Medium Priority

### 1. Cache Management
- Smart caching for frequent queries
- Cache invalidation strategies
- Bulk operation cache updates
- Cache warmup for common queries

### 2. Performance Optimizations
- Index optimization
- Pagination support
- Bulk operation optimizations
- Query performance monitoring

### 3. Data Export Features
- SIE format export implementation
- PDF report generation
- Excel/CSV export functionality
- Backup/restore functionality

## P3 - Nice to Have

### 1. Offline Support
- Offline data synchronization
- Conflict resolution
- Offline queue management
- Background sync

### 2. Data Compression
- Attachment compression
- Storage optimization
- Large dataset management
- Binary data handling

### 3. Development Tools
- Debug helpers
- Logging implementation
- Development utilities
- Performance monitoring tools

## Technical Dependencies
- Dexie.js v4.0.10
- TypeScript support
- Vite for building
- Jest for testing
- .NET 8.0 Blazor WebAssembly

## Integration Points
- Frontend.csproj (Blazor WASM)
- Backend.csproj (Domain logic)
- dexie-interop.iife.js (Dexie integration)
- AccountClassHelper.cs (Business logic)

## Notes
- All features should align with the project structure defined in app-spec.md
- Must maintain compatibility with Swedish accounting standards
- Focus on proper error handling and data integrity
- Consider browser storage limitations