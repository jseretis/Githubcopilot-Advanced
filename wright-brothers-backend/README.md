# Wright Brothers API

Welcome to the Wright Brothers API project! This document provides you with all the necessary information to get started with running and understanding the project.

## Pre-requisites

Before running the Wright Brothers API, you'll need to have the following installed on your machine:

- **.NET 10.0**: The project is built using the .NET 10.0 framework, so you'll need to have it installed on your machine. You can download it from the [.NET website](https://dotnet.microsoft.com/download/dotnet/10.0).

## Running the backend API

Follow these steps to get the backend API project up and running:

1. **Run the Project**: Start the project.

    ```sh
    cd wright-brothers-api/WrightBrothersApi
    dotnet run
    ```

The API should now be running locally on your machine. You can access it by navigating to `http://localhost:1903` in your web browser.

## Building the Project

To build the project, run the following command:

```sh
dotnet build
```

This will build the project and output the build artifacts to the `bin` directory.

## Running Tests

To run the tests for the project, run the following command:

```sh
dotnet test
```

This will run all the tests in the project and output the results to the console.

## Tools and Technologies Used

This project makes use of several tools and technologies:

- **.NET 10.0**: The project is built using the .NET 10.0 framework, which provides a robust platform for developing high-performance web applications.

- **Swagger**: Swagger has been integrated to automatically generate an OpenAPI document for the API. This allows for easy testing and exploration of the API endpoints. You can access the Swagger UI by navigating to `/swagger` on your running API instance.

- **Health Checks**: The project includes health checks to monitor the health of the application, including database connectivity. If the SQL Server is not available, the project will report as unhealthy.

- **Docker**: For containerization, the project includes a Dockerfile located in the `.devcontainer` directory. This allows for easy deployment and scaling of the application.

## Contributing

We welcome contributions! Please read the `CONTRIBUTING.md` file for guidelines on how to contribute to the project.

## License

This project is licensed under the MIT License - see the `LICENSE` file for details.
