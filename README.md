# Currency Converter

A full-stack currency converter application that converts numeric currency values into written words.

The application supports:

* English and German languages
* Multiple currencies (USD, EUR, GBP)
* Dollar/euro/cent formatting
* Input validation
* Automated unit testing

## Technology Stack

### Backend

* C# .NET 10
* ASP.NET Core Web API
* Dependency Injection
* xUnit testing

### Frontend

* React
* Vite
* JavaScript
* CSS

## Architecture

```
CurrencyConverter
│
├── CurrencyConverter.API
│   ├── Controllers
│   ├── Services
│   ├── Converters
│   └── Models
│
├── CurrencyConverter.Tests
│   └── Unit tests
│
└── currency-converter-client
    └── React frontend
```

## Features

Examples:

Input:

```
25,10
English
USD
```

Output:

```
twenty-five USDs and ten cents
```

Input:

```
25,25
German
EUR
```

Output:

```
fünfundzwanzig Euro und fünfundzwanzig Cent
```

## Running the Backend

Navigate to:

```
CurrencyConverter.API
```

Run:

```bash
dotnet run
```

The API starts on:

```
http://localhost:5062
```

## Running the Frontend

Navigate to:

```
currency-converter-client
```

Install dependencies:

```bash
npm install
```

Start React:

```bash
npm run dev
```

The frontend runs on:

```
http://localhost:5173
```

## Testing

Run all backend tests:

```bash
dotnet test
```

Current tests cover:

* English conversion
* German conversion
* Maximum supported value
* Invalid input handling

## Purpose

This project was developed as a software engineering exercise demonstrating backend API development, frontend integration, validation, and automated testing using modern .NET and React technologies.
