# Zeil Project

## Overview

The Zeil project is a .NET application that includes a web API for validating credit card numbers using the Luhn algorithm

## Project Structure
Follows clean architecture design
- **Zeil.Domain**: Contains the domain logic, including the `CreditCard` record and the `CreditCardUseCases` class.
- **Zeil.Domain.Tests**: Contains unit tests for the domain logic.
- **Zeil.WebApi**: Contains the web API project

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- VS Code (Optional)

### Building and Running the Application

1. Clone the repository:
    ```sh
    git clone https://github.com/KijongHan/Zeil_Test/zeil.git
    cd zeil
    ```

2. Build and run the application:
    ```sh
    dotnet build
    dotnet run --project Zeil.WebApi
    ```

3. The Swagger API will be available at `http://localhost:5135/swagger/index.html`.

4. Or optionally, you can run the `Zeil.WebApi` launch configuration from VS Code

## API Endpoints

### Weather Forecast

- **GET /weatherforecast**
    - Returns a list of weather forecasts.

### Credit Card Validation

- **POST /creditcard/validate**
    - Validates a credit card number using the Luhn algorithm.
    - Request body:
        ```json
        {
            "CardNumber": 49927398716
        }
        ```
    - Response:
        ```json
        {
            "isValid": true,
            "calculatedChecksum": 6,
            "actualChecksum": 6
        }
        ```

## Testing

To run the unit tests, use the following command:
```sh
dotnet test
```