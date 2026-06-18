# Wright Brothers Frontend

Welcome to the Wright Brothers Frontend project! This document provides you with all the necessary information to get started with running, building, and testing the project.

## Pre-requisites

Before you can run the Wright Brothers Frontend project, you'll need to have the following tools installed on your machine:

- **Node.js**: The project is built using Node.js, so you'll need to have it installed on your machine. You can download Node.js from the official website: [https://nodejs.org/](https://nodejs.org/).

## Getting Started

To run the Wright Brothers Frontend, you'll need to have Node.js installed on your machine. Follow these steps to get the project up and running:

1. **Navigate to the Frontend Directory**: Change into the frontend project directory.

    ```sh
    cd wright-brothers-frontend
    ```

2. **Install Dependencies**: Install the project dependencies using npm.

    ```sh
    npm install
    ```

3. **Run the Project**: Start the development server.

    ```sh
    npm run frontend
    ```

The frontend application should now be running locally on your machine. You can access it by navigating to `http://localhost:5173` in your web browser.

## Building the Project

To build the frontend project for production, use the following command:

```sh
npm run build:prod
```

This will create an optimized build of the project in the `wright-brothers-frontend/dist` directory.

## Running Tests

Make sure that have playwright installed:

```sh
npx playwright install   
```

To run the tests for the frontend project, use the following command:

```sh
npm run test-ct
```

This will run the Playwright tests for the project.

## Tools and Technologies Used

This project makes use of several tools and technologies:

- **React**: The project is built using the React framework, which provides a robust platform for developing modern web applications.
- **Vite**: Vite is used as the build tool for fast and efficient development.
- **ESLint**: ESLint is used to enforce coding standards and catch common coding errors.
- **Playwright**: Playwright is used for running the tests.

## Contributing

We welcome contributions! Please read the CONTRIBUTING.md file for guidelines on how to contribute to the project.

## License

This project is licensed under the MIT License - see the LICENSE file for details.


