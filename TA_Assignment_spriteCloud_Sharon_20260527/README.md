# TA Assignment SpriteCloud – Sharon (2026-05-27)

## Overview
This project contains automated tests for the TA Assignment submitted to SpriteCloud.
It covers both **UI testing** (Sauce Demo) and **API testing** (DummyJSON), built with C# and Playwright.

## Tech Stack
- C# / .NET
- Playwright and NUnit for testing

## Project Structure
To create a project that is maintainable and scalable, we have organized the code into the following structure:

- **APITest** – API test fixtures and helpers for DummyJSON
- **UITest** – Page Object Models and test fixtures for Sauce Demo
- **Models** – Request and response models for API testing
- **GlobalSetup / ApiSetup / Setup** – Shared configuration and setup logic

## Test Coverage
| Area | Tests |
|---|---|
| Sauce Demo UI | Login, Sort Products, Full Checkout |
| DummyJSON API | GET/POST/DELETE happy flow + error validation |

## How to Run

### Prerequisites
- .NET SDK installed
- Playwright browsers installed:
```bash
pwsh bin/Debug/net8.0/playwright.ps1 install
```

### Run all tests
```bash
dotnet test --settings test.runsettings
```

## Test Credentials (Sauce Demo)
| Username | Password |
|---|---|
| standard_user | secret_sauce |