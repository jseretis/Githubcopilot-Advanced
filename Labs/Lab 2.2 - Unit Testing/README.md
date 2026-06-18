# Lab 2.2 - Aircraft Inspections ✈ Unit Testing with GitHub Copilot

Looking at the code coverage you noticed that the project is below 20%, which can be improved. You plan a meeting with the team to look into the code coverage reporting. After the meeting you all agreed that the project should be better tested. You decide to take the initiative and start writing tests. After you have seen that GitHub Copilot can create new features and can also help you with setting up code coverage reporting, you decide to ask GitHub Copilot to help you with writing tests.

## Estimated time to complete

- 20 min

## Learning objectives

- Use GitHub Copilot to generate robust unit tests for the project
- Use GitHub Copilot to explore edge cases in the code
- Use GitHub Copilot to generate missing tests for the project

## Task 1: Add missing test using GitHub Copilot Completions

Add the missing test cases for the `GetById` method for `PlanesController` class using GitHub Copilot Completions.

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Hint 1</summary>

- Open `PlanesControllerTests.cs` in the editor. Position your cursor after the last test method and type a comment naming the method you want — Copilot Completions will suggest the full test body:

  ```csharp
  //GetById
  ```

> [!NOTE]
> The grey ghost text that appears is Copilot Completions. Press **Tab** to accept it.

</details>

<details>
  <summary>Hint 2</summary>

- Also open `PlanesController.cs` alongside `PlanesControllerTests.cs`. Copilot uses all open editor files as context — having the implementation file open improves the quality of the suggested test.

</details>

<details>
  <summary>Hint 3</summary>

- After accepting the first completion, press `Enter` a couple of times and type another comment to generate the next test case:

  ```csharp
  //GetById_NotFound
  ```

</details>

---

**Expert solution**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution</summary>

<br/>

- Open `PlanesControllerTests.cs` and `PlanesController.cs` side by side in the editor.

- Position your cursor after the last test method in `PlanesControllerTests.cs` and type:

  ```csharp
  //GetById
  ```

- Press `Enter` — Copilot Completions will suggest the full test body as grey ghost text. Press **Tab** to accept.

- Press `Enter` a couple of times and type the next comment to trigger the not-found case:

  ```csharp
  //GetById_NotFound
  ```

- Accept each suggestion with **Tab**, then run the tests to confirm they pass.

> [!NOTE]
> Having both files open at the same time gives Copilot the implementation context it needs to produce accurate assertions and mock setups.

</details>

<br/>

## Task 2: Add all missing tests using GitHub Copilot Agent Mode

Add all the missing tests with edge cases for the `PlanesController` class using GitHub Copilot Agent Mode.

> [!NOTE]
> In Lab 1.2 Task 3 you added input validation to `PlanesController.Post`. Make sure Copilot generates tests that cover those validation paths too — blank name, year out of range, and negative `RangeInKm`.

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Hint 1</summary>

- Use Agent Mode to generate all missing test cases including edge cases for the `PlanesController` class.

> [!NOTE]
> By selecting specific content in your editor, GitHub Copilot will use the selected content as context. Agent Mode will write the changes directly into the file.

- Agent Mode may not generate all tests in a single pass. If it stops, prompt it to continue with any remaining methods.

</details>

<br/>

<details>
  <summary>Hint 2</summary>

- Use Agent Mode to scope the work first — ask it to list what's missing before generating:

  ```
  List all the test method names that are missing for the PlanesController class.
  ```

</details>

<br/>

<details>
  <summary>Hint 3</summary>

- Then follow up in the same Agent Mode session to implement them:

  ```
  In #file:PlanesControllerTests.cs, append tests covering all missing edge cases for the PlanesController class, ensuring they follow the file's existing style.
  ```

</details>

---

**Expert solution**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution</summary>

<br/>

Use Agent Mode with the following prompt:

```
Analyze #file:PlanesController.cs and identify all public action methods. For each method, identify every missing edge case (e.g. not found, invalid input, boundary values, null returns). Append the missing tests to the end of #file:PlanesControllerTests.cs. Follow the existing test style, use NSubstitute for mocking IPlaneRepository, and do not duplicate any tests that already exist.
```

> [!NOTE]
> Copilot reads both files to understand what is already covered before generating anything new. Including the validation cases from Lab 1.2 (blank name, out-of-range year, negative `RangeInKm`) is automatically handled when the controller implementation is referenced.

- Run the tests to verify they pass.

- If any test fails, ask Copilot in the same session to fix it — paste the error output directly as context.

</details>

<br/>


## Task 3: Create new test class based on existing test class

Create a new test class for `FlightsController` using GitHub Copilot Agent Mode, following the same coding style as `PlanesControllerTests`.

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Hint 1</summary>

- Use Agent Mode with `#file` references so Copilot can see both the controller and the existing test style:

  ```
  Generate a test class for #file:FlightsController.cs using the same coding style as #file:PlanesControllerTests.cs
  ```

</details>

<details>
  <summary>Hint 2</summary>

- Use `#file` to include specific files in your Agent Mode prompt

> `#file` works in Agent Mode — it anchors Copilot to the exact files you want it to read and write.

</details>

---

**Expert solution**

<details>
  <summary>Click to open Expert Solution</summary>


<br/>

Use Agent Mode with the following prompt:

```
Create a new test class for #file:FlightsController.cs following the same coding style, structure, and mocking patterns as #file:PlanesControllerTests.cs. Include tests for all public action methods and their edge cases. Save the file as FlightsControllerTests.cs in the wright-brothers-backend/WrightBrothersApi.Tests/Controllers folder.
```

> [!NOTE]
> By referencing `#file:PlanesControllerTests.cs`, Copilot uses the existing class as a style template — picking up the NSubstitute mocking pattern, FluentAssertions assertions, and constructor setup automatically.

- Run the tests to verify the new file compiles and all tests pass.

- If any test fails, ask Copilot in the same session to fix it — paste the error output directly as context.

</details>

<br/>

## Task 4: Run code coverage report again

Run code coverage report again to see if the coverage has improved

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Hint 1</summary>

  ```prompt
  Rerun all the unit tests with coverage and open the HTML report in the VS Code browser.
  ```

</details>

<details>
  <summary>Hint 2</summary>

- Make sure `dotnet-reportgenerator-globaltool` is installed. If not, install it first:

  ```prompt
  Rerun backend code coverage in the Wright Brothers solution and open the HTML report in the VS Code browser.
  ```

</details>

<details>
  <summary>Hint 3</summary>

- Run the test command with coverage collection from the repo root:

  ```
  dotnet test wright-brothers-backend/WrightBrothersApi.Tests/WrightBrothersApi.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
  ```

</details>

After generating the report, compare the coverage percentage to the initial run. Adding tests in Tasks 1 and 2 should produce a substantial improvement.

---

**Expert solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Run the tests with coverage collection:

  ```sh
  dotnet test wright-brothers-backend/WrightBrothersApi.Tests/WrightBrothersApi.Tests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
  ```

- Regenerate the HTML report:

  ```sh
  reportgenerator -reports:wright-brothers-backend/WrightBrothersApi.Tests/coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html
  ```

- Open `coveragereport/index.html` in the browser. Coverage should now be well above the 20% threshold — adding tests in Tasks 1–3 typically lifts it from under 20% to 60%+.

</details>

<br/>

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 3.1 • Frontend Styling](../Lab%203.1%20-%20Frontend%20Styling/README.md)
