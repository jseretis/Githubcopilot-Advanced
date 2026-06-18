# Lab 4.1 - Auto-Pilot Mode ✈ Pipeline Automation with GitHub Copilot

After finishing up the frontend changes locally on your machine, you are wondering how these changes will be deployed to the production website. When you ask your team members about this, they will tell you that they just build the frontend locally, created a zip file and uploaded it to the server, exactly like the deployment manual describes. You are not satisfied with this manual process, because it's prone to errors and takes at least 1 hour to complete everytime the team wants to deploy a new version of the application. You are confident that GitHub Copilot can create code for pipelines and automation.

## Estimated time to complete

- 20 min

## Learning objectives

- Use GitHub Copilot to explain the goal of automatically building the frontend and backend projects.
- Use GitHub Copilot to explain rules for GitHub Actions.
- Use GitHub Copilot to create a GitHub Actions workflow for automating the build process.
- Understand how to integrate automated tests into the GitHub Actions workflow to ensure code quality before deployment.
- Learn how to set up continuous deployment to automatically deploy successful builds to the production server.


## Task 1: Extend the backend CI pipeline with code coverage

The repository already has a minimal CI pipeline in `.github/workflows/backend-ci.yml` that builds and runs tests. Your task is to **extend** it with the following:

- Collect code coverage during the test run (Coverlet / Cobertura format)
- Fail the build if coverage drops below 20%
- Upload the coverage report as a GitHub Actions artifact so the team can download it

Consider using GitHub Actions and the existing `backend-ci.yml` as your starting point.

<br/>

---

<br/>

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Open `.github/workflows/backend-ci.yml` and ask Copilot in Agent Mode to extend it:

  ```
  Extend .github/workflows/backend-ci.yml to collect code coverage during the test run,
  fail if coverage drops below 20%, and upload the report as a GitHub Actions artifact.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Use `CollectCoverage=true` and `CoverletOutputFormat=cobertura` flags with `dotnet test`.

- Use the `actions/upload-artifact@v4` action to publish the coverage report.

</details>

<br/>

<details>
  <summary>Click to open Hint 3</summary>

- Push your changes to GitHub and watch the pipeline run in the **Actions** tab of the repository.

</details>

<br/>

---

<br/>

**Expert solution**

Below you can find an expert solution to the task at hand.

> [!IMPORTANT]
> GitHub Copilot may suggest outdated Action versions. Always use the latest: `actions/checkout@v4`, `actions/setup-dotnet@v4`, `actions/upload-artifact@v4`.

<details>
  <summary>Click to open Expert Solution</summary>

<br/>

- Open `.github/workflows/backend-ci.yml` and use Copilot Agent Mode with this prompt:

  ```
  Extend .github/workflows/backend-ci.yml to:
  1. Collect code coverage during dotnet test using Coverlet in Cobertura format
  2. Fail the build if line coverage is below 20%
  3. Upload the coverage XML as a GitHub Actions artifact named "coverage-report"

  Use actions/checkout@v4, actions/setup-dotnet@v4, and actions/upload-artifact@v4.
  ```

- The extended `dotnet test` step should look like:

  ```yaml
  - name: Run tests with coverage
    run: >
      dotnet test --no-build
      wright-brothers-backend/WrightBrothersApi.Tests/WrightBrothersApi.Tests.csproj
      /p:CollectCoverage=true
      /p:CoverletOutputFormat=cobertura
      /p:Threshold=20
      /p:ThresholdType=line

  - name: Upload coverage report
    uses: actions/upload-artifact@v4
    with:
      name: coverage-report
      path: wright-brothers-backend/WrightBrothersApi.Tests/coverage.cobertura.xml
  ```

- Push your changes and observe the pipeline run in the **Actions** tab on GitHub.

</details>

<br/>

---

<br/>


## Task 2: Automate the build process for the frontend application

In this task, you will create another build pipeline for the frontend application. This pipeline contain some additional steps compared to the backend pipeline.

Create a build pipeline for the frontend application using GitHub Copilot. The build pipeline should do the following:
- Install dependencies
- Install Playwright
- Install Playwright dependencies
- Run the playwright tests
- Build the frontend project for production

<br/>

---

<br/>

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Ask GitHub Copilot to use `GitHub Actions` to create a build pipeline for the frontend project:

  ```
  Create a GitHub Actions workflow for the frontend application that installs dependencies,
  installs Playwright, runs Playwright tests, and builds the project for production.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- GitHub Copilot will suggest to create a `.github/workflows` directory with a YAML file in it.

- Make sure to commit the `.github/workflows` directory to the `main` branch in order to run the pipeline.

</details>

<br/>

<details>
  <summary>Click to open Hint 3</summary>

- Push your changes to GitHub and check the **Actions** tab to watch the pipeline run.

</details>

<br/>

---

<br/>

**Expert solution**

Below you can find an expert solution to the task at hand.

> [!IMPORTANT]
> GitHub Copilot will likely suggest old versions of Actions. Make sure to update the versions to the latest ones. You can find the latest versions on the [GitHub Actions Marketplace](https://github.com/marketplace?type=actions)

<details>
  <summary>Click to open Expert Solution</summary>

<br/>

- Open GitHub Copilot Chat (Agent Mode) and enter the following prompt:

  ```
  Create a GitHub Actions build pipeline for the frontend application. The pipeline should:
  - Install Node.js 22 dependencies
  - Install Playwright and its dependencies
  - Run the Playwright component tests
  - Build the frontend for production

  Use actions/checkout@v4 and actions/setup-node@v4.
  ```

- GitHub Copilot will suggest a YAML file similar to this:

  ```yaml
  name: Frontend Build Pipeline

  on:
    push:
      branches:
        - main
    pull_request:
      branches:
        - main

  jobs:
    build:
      runs-on: ubuntu-latest

      steps:
        - name: Checkout code
          uses: actions/checkout@v4

        - name: Set up Node.js
          uses: actions/setup-node@v4
          with:
            node-version: '22'

        - name: Install dependencies
          run: npm install
          working-directory: wright-brothers-frontend

        - name: Playwright Install
          run: npx playwright install
          working-directory: wright-brothers-frontend

        - name: Install Playwright dependencies
          run: npx playwright install-deps
          working-directory: wright-brothers-frontend

        - name: Run Playwright tests
          run: npm run test-ct
          working-directory: wright-brothers-frontend

        - name: Build frontend for production
          run: npm run build:prod
          working-directory: wright-brothers-frontend
  ```

- Create `.github/workflows/frontend-build.yml` with this content.

- Push your changes to GitHub and watch the pipeline run in the **Actions** tab.

</details>

<br/>

---

<br/>


## Optional - Bonus Tasks

> [!CAUTION]
> Please be aware that this challenge does not include guardrails or provided solutions. You are encouraged to navigate and solve the tasks independently, which will help enhance your problem-solving skills and deepen your understanding of the frameworks and technologies involved.

For if you have time left and full of curiosity, you can try these bonus tasks:

1. Add a step to the frontend pipeline that runs a linter to check the code quality of the frontend project.

2. Add a step to the frontend pipeline to host the build files on GitHub Pages.

3. Anything else you can think of that would be interesting to explore with the build pipelines.

<br/>
<br/>

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 4.2 • Proof of Concepting](../Lab%204.2%20-%20Proof%20of%20Concepting/README.md)
