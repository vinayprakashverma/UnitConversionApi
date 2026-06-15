# Unit Conversion API

A RESTful ASP.NET Core 8 Web API that performs unit conversions across multiple measurement categories such as Length, Weight, Temperature, and Volume.

## Features

- ASP.NET Core 8 Web API
- Clean Architecture principles
- Dependency Injection
- Swagger/OpenAPI support
- Global Exception Handling
- Input Validation
- Unit Tests using MSTest
- Easily extensible for additional conversion types

---

## Supported Conversions

### Length
- Meter ↔ Kilometer
- Meter ↔ Centimeter
- Kilometer ↔ Mile
- Inch ↔ Centimeter
- Foot ↔ Meter

### Weight
- Gram ↔ Kilogram
- Kilogram ↔ Pound
- Pound ↔ Ounce

### Temperature
- Celsius ↔ Fahrenheit
- Celsius ↔ Kelvin
- Fahrenheit ↔ Kelvin

### Volume
- Liter ↔ Milliliter
- Liter ↔ Gallon
- Gallon ↔ Liter

---

## Technology Stack

- .NET 8
- ASP.NET Core Web API
- MSTest
- Swagger/OpenAPI
- Dependency Injection
- xUnit/MSTest (depending on implementation)

---

## Project Structure

```text
UnitConversionApi
│
├── Controllers
│   └── ConversionController.cs
│
├── Models
│   ├── ConversionRequest.cs
│   └── ConversionResponse.cs
│
├── Services
│   ├── IConversionService.cs
│   └── ConversionService.cs
│
├── Middleware
│   └── ExceptionMiddleware.cs
│
├── Program.cs
│
└── UnitConversionApi.Tests
    ├── ConversionServiceTests.cs
    └── ConversionControllerTests.cs
```

---

## API Endpoint

### Convert Units

**POST**

```http
/api/conversion/convert
```

### Request

```json
{
  "category": "Length",
  "fromUnit": "Meter",
  "toUnit": "Kilometer",
  "value": 1500
}
```

### Response

```json
{
  "originalValue": 1500,
  "fromUnit": "Meter",
  "toUnit": "Kilometer",
  "convertedValue": 1.5
}
```

---

## Validation Rules

- Category is required.
- FromUnit is required.
- ToUnit is required.
- Value must be a valid numeric value.
- Source and target units must belong to the same category.
- Unsupported conversions return a validation error.

---

## Running the Application

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 / VS Code

### Clone Repository

```bash
git clone <repository-url>
cd UnitConversionApi
```

### Restore Packages

```bash
dotnet restore
```

### Build Application

```bash
dotnet build
```

### Run Application

```bash
dotnet run
```

Application will be available at:

```text
https://localhost:5001
http://localhost:5000
```

---

## Swagger Documentation

After running the application, open:

```text
https://localhost:5001/swagger
```

Swagger UI provides interactive API testing.

---

## Running Unit Tests

Execute all tests:

```bash
dotnet test
```

Example output:

```text
Passed! - Failed: 0, Passed: 25, Skipped: 0
```

---

## Sample Test Scenarios

### Positive Cases

- Meter to Kilometer conversion
- Celsius to Fahrenheit conversion
- Kilogram to Pound conversion

### Negative Cases

- Invalid category
- Unsupported unit
- Null request
- Same source and target unit validation
- Invalid numeric value

---

## Error Response Example

```json
{
  "message": "Unsupported conversion from Meter to Celsius."
}
```

---

## Future Enhancements

- Currency Conversion
- Area Conversion
- Time Conversion
- Mass Conversion
- Conversion History
- Authentication & Authorization
- API Versioning

---

## Coding Standards

- SOLID Principles
- Dependency Injection
- Clean Code Practices
- Consistent Naming Conventions
- Unit Test Coverage

---

## Author

Vinay Prakash Verma

Senior .NET Developer
