# Swedish Sole Proprietor Accounting Application Specification

## 1. Core Technical Requirements

### 1.1 Technology Stack
- Blazor WebAssembly (.NET 8)
- IndexedDB for client-side storage
- PWA capabilities for offline use
- No server requirements - fully client-side
- GitHub Pages for hosting

### 1.2 Data Model Foundation
```csharp
Core Entities:
- Account (Based on BAS Kontoplan)
- Transaction
- Invoice
- Customer
- Expense
- Asset
- YearEndReport
- NEBilaga
```

### 1.3 Essential Features

#### Expense Tracking
- Direct expense entry with receipt upload
- Automatic VAT (MOMS) calculation
- Categorization according to BAS Kontoplan
- Support for both cash and accrual methods
- Private/business expense allocation tracking (important for NE-bilaga)

#### Invoice Management
- Invoice generation with Swedish invoice requirements:
  - Organizational number (organisationsnummer)
  - F-skatt status
  - MOMS registration number
  - Required payment information
- Invoice tracking (paid/unpaid)
- Support for partial payments
- Automatic bookkeeping entries on invoice creation/payment

#### Year-end Reporting
- Automated generation of:
  - Resultaträkning (Income Statement)
  - Balansräkning (Balance Sheet)
- Support for:
  - Yearly depreciation calculations
  - Accrual adjustments
  - Period-end verifications

#### NE-bilaga Specific Features
- Automatic calculation of:
  - R1-R7 (Income sections)
  - R8-R16 (Cost sections)
  - B1-B13 (Balance sheet items)
  - Periodic adjustments (periodiseringar)
- Tax adjustment calculations
- Private withdrawal tracking

## 2. Application Architecture

### 2.1 Project Structure
```
App/
├── Pages/
│   ├── Index.razor
│   ├── Expenses/
│   ├── Invoices/
│   ├── Reports/
│   └── Settings/
├── Components/
│   ├── Shared/
│   ├── Forms/
│   └── Reports/
├── Services/
│   ├── Storage/
│   ├── Calculation/
│   └── Export/
├── Models/
│   ├── Domain/
│   ├── Dto/
│   └── Validation/
└── Infrastructure/
    ├── Storage/
    ├── Export/
    └── Validation/
```

### 2.2 Key Components
1. IndexedDB Service
   - Handle all data persistence
   - Manage data versioning
   - Handle migrations

2. Calculation Service
   - VAT calculations
   - Financial statements
   - NE-bilaga calculations
   - Tax calculations

3. Export Service
   - PDF generation
   - SIE file export
   - Excel/CSV export

4. Validation Service
   - Swedish format validation
   - Business rule validation
   - Data integrity checks

## 3. User Interface Requirements

### 3.1 Main Views
1. Dashboard
   - Quick overview of financials
   - Recent transactions
   - Due invoices
   - VAT status

2. Transaction Entry
   - Quick expense entry
   - Invoice creation
   - Bank transaction import

3. Reports
   - Monthly reports
   - VAT reports
   - Year-end reports
   - NE-bilaga preview

4. Settings
   - Business information
   - Chart of accounts
   - Tax settings

### 3.2 UI Components
1. Custom Input Components
   - Account selector
   - Amount input with VAT
   - Date picker (Swedish format)
   - Receipt uploader

2. Report Components
   - Balance sheet view
   - Income statement view
   - VAT report view
   - NE-bilaga preview

## 4. Data Storage

### 4.1 IndexedDB Stores
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

### 4.2 Data Export
- SIE format support
- PDF reports
- Excel/CSV export
- Backup/restore functionality

## 5. Business Rules

### 5.1 Accounting Rules
- Double-entry bookkeeping
- Swedish accounting standards
- BAS Kontoplan compliance
- VAT handling rules

### 5.2 Tax Rules
- Private/business separation
- Asset depreciation
- Car expense calculations
- Home office deductions

## 6. Development Phases

### Phase 1: Core Functionality
- Basic transaction entry
- Account management
- Simple reporting

### Phase 2: Advanced Features
- Invoice management
- VAT reporting
- Receipt handling

### Phase 3: Reporting
- Financial statements
- NE-bilaga generation
- Tax calculations

### Phase 4: Export & Integration
- SIE export
- PDF generation
- Data backup

## 7. Technical Constraints
- All processing must be client-side
- No server dependencies
- Must work offline
- Data must be secure in browser storage
- Must handle large datasets efficiently
