# Lab 2.1 - Operational Coverage ✈ Configuring Test Coverage with GitHub Copilot

In your previous project, you focused heavily on testing and ensured at least 80% code coverage. However, in your current project, you notice limited test coverage and feel uneasy about making changes without tests, fearing potential production issues. Despite the lead developer's focus on rapid feature delivery over testing, you decide to take the initiative and start writing tests using the existing testing framework. To better understand the current coverage and identify untested code, you seek help from GitHub Copilot to set up visual test coverage reporting.

## Estimated time to complete

- 20 min

## Learning objectives

- Configuring a new feature inside an existing project following steps provided by GitHub Copilot

- Use GitHub Copilot to help with no coding tasks

## Task 1: Gather coverage reporting for the backend project

Your task is to gather coverage reporting for the backend project and display the code coverage in the browser to see which parts of the code are not being tested.

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Open Copilot Chat in **Agent Mode** and ask it to set up coverage reporting for you:

  ```
  Set up test coverage reporting for the .NET backend project. Use Coverlet and ReportGenerator to collect coverage in Cobertura format and generate an HTML report I can open in the browser.
  ```

</details>

<details>
  <summary>Click to open Hint 2</summary>

- Follow GitHub Copilot's guidance on how to add a code coverage tool to your project.

</details>

<details>
  <summary>Click to open Hint 3</summary>

- The code coverage report output is saved to a folder in the test project directory (e.g., `wright-brothers-backend/WrightBrothersApi.Tests/coveragereport`). The exact path will be shown after running the coverage tool.

- You can use the following command to serve the code coverage report in the browser (if you have Python installed):

  ```sh
  npm install -g http-server
  http-server <coveragereport_directory>
  ```

- You can also open the `index.html` file in the browser to see the code coverage report

</details>

---

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Expert Solution 1</summary>

<br/>

- Open GitHub Copilot Chat and ask for insights on code coverage for the backend project (Ask Mode):

```
How do I get insights on test coverage for my .NET backend project and display the results in the browser? Use the cobertura format.
```

- GitHub Copilot will provide a step by step guide that you can follow to gather coverage reporting for the WebApi project:

  1. Add a Code Coverage Tool: For a .NET project like your backend (`wright-brothers-backend/WrightBrothersApi/WrightBrothersApi.csproj`), you can use a tool like Coverlet. Coverlet is a cross-platform code coverage library for .NET 10.0, which can integrate with the test framework and generate coverage reports.

  3. Run Tests with Coverage: After installing Coverlet, you can run your tests with coverage collection by using the following command:

     > [!NOTE]
     > When we run tests normally, we know whether the tests passed. When we run tests with coverage, we also see how much of the production code those tests actually exercised.

     ```sh
     dotnet test wright-brothers-backend/WrightBrothersApi.Tests/WrightBrothersApi.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
     ```

     This command tells dotnet test to collect code coverage and output the results in the Cobertura format, which is compatible with many tools for further analysis and reporting.

  4. Generate a Coverage Report: To generate a human-readable report and serve it in the browser, you can use ReportGenerator. First, install ReportGenerator globally:

     ```sh
     dotnet tool install -g dotnet-reportgenerator-globaltool
     ```

  5. Convert Coverage Data and Serve: After running your tests with coverage collection, use ReportGenerator to convert the coverage data into an HTML report and then serve it using any simple HTTP server. For example:

     ```
     reportgenerator -reports:wright-brothers-backend/WrightBrothersApi.Tests/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html
     ```

     Then, to serve the report, if you have Python installed, you can use:

     ```sh
     python3 -m http.server --directory coveragereport
     ```

     Or you can open the `index.html` file in the browser directly.

     Now open `coveragereport/index.html` in the browser to see the code coverage report.

</details>

<br/>

<details>
  <summary>Expert Solution 2</summary>

- Use Copilot Agent Mode with one of these prompts:

  **Option 1** — let Copilot run it and give you a clickable link:

  ```
  Show me a code coverage HTML report for my backend project unit tests and display it in the browser. Print the URL so I can click to view the report.
  ```

  **Option 2** — let Copilot handle the full setup end-to-end:

  ```
  Install any required .NET tools for code coverage (like Coverlet and ReportGenerator), run the backend tests with coverage enabled, generate a browser-friendly report, and open it for me.
  ```

- Once the HTML file is generated, you can also **right-click** it in the Explorer and select **Show Preview** to view it directly in VS Code.

</details>

<br/>

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 2.2 • Unit Testing](../Lab%202.2%20-%20Unit%20Testing/README.md)
