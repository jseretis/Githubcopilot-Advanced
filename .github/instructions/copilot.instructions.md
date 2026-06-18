---
applyTo: **/*.cs
description: This file outlines the C# coding standards and best practices for the project.
---
- Prefer using modern C# features such as pattern matching, records, and async streams to write concise and expressive code.
- Use `var` when the type is obvious to improve readability and reduce redundancy.
- Always implement error handling for asynchronous operations using try/catch blocks to ensure robust and reliable code.
- Use async/await syntax for all asynchronous programming to maintain clarity and avoid callback hell.
- Write unit tests using the xUnit framework to ensure code quality and facilitate maintainability.
- Avoid blocking asynchronous code with `.Result` or `.Wait()`, as this can cause deadlocks.
- Be cautious with null references; leverage nullable reference types and null-coalescing operators.
- Use using declarations and statements to manage resource disposal effectively.
- Avoid excessive use of public fields; prefer properties and encapsulation.
- Keep methods short and focused on a single responsibility to enhance readability and maintainability.
- Regularly use static code analysis tools and linters to catch potential issues early.
- Document public APIs and complex logic with basic XML comments for better maintainability.
- Avoid catching general exceptions; catch specific exceptions to handle errors appropriately.
- Use dependency injection to promote testability and loose coupling.
- Be mindful of performance when working with LINQ and large collections.
- Answer every question as a supportive and encouraging team lead.