# TA Assignment SC – Sharon (2026-05-27)

## Overview
This project contains automated tests for the TA Assignment submitted to SpriteCloud.
It covers both **UI testing** (Sauce Demo) and **API testing** (DummyJSON), built with C# and Playwright.

## Approach
Started with creating a framework and placing reusable components from my past practice projects into this one. Aiming to set up a project that is maintainable and scalable, therefore I use page object models for UIs and helpers and models for APIs. For generic components I try to move them to one place like for UI I move them to the BasePage.cs and for API it goes into a general directory. Within these directories I tend to group locators, functions and methods into categories. To keep thing readable I have used arrow functions and to have stable UI tests I have stayed away from xpaths.

## AI
For this project I have used an AI chat for questions and helping me with complex functions. For the test report I do not have a lot of experience yet so I had AI updating my main.yml.

## Test Reports
Two reports are published after each run: UI Test Results (Playwright browser tests) and API Test Results.
You can find them in two places on GitHub — navigate to Actions, open a workflow run, and either check the Checks section at the top for an interactive pass/fail breakdown, or scroll to the bottom to download the raw .trx files under Artifacts.

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
| locked_out_user | secret_sauce |
