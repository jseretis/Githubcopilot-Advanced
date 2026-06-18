# Lab 1.1 - Retrofit and Upgrade ✈ Feature Development with GitHub Copilot

You've been assigned your first task on the Wright Brothers team — add new features to the API using GitHub Copilot Completions and Agent Mode.

## Estimated time to complete

- 20 min

## Learning objectives

- By using comments in the code editor, GitHub Copilot Completions can generate code for you that corresponds to what is described in the comment.

- By describing a feature to GitHub Copilot Chat, it can generate code for you in all the necessary places.

## Task 0: Bring Your Plan Forward

In Lab 1.0 you used Plan Mode to design the query-by-year feature and saved it to `wright-brothers-backend/plan.md`. Now execute that plan with Agent Mode.

### Option A:
If you're still in Plan mode with the plan visible in the chat, you can switch modes to **Agent** and click **Start Implementation** to have Agent Mode read the plan and propose changes. Review each proposed change before accepting.

### Option B:
If you saved `plan.md` in Lab 1.0, then:

- Open Copilot Chat, switch the mode to **Agent**, click **+** to clear history.
- Enter the following prompt:

  ```
  Review the plan in plan.md and execute it.
  ```

Agent Mode will read the file and propose file edits — review each one before accepting.

> [!TIP]
> Saving a plan to a markdown file and then asking Agent Mode to execute it is a powerful workflow. The plan acts as a precise, reusable specification that keeps Agent Mode focused and prevents unnecessary changes.

> [!NOTE]
> If you did not save `plan.md` in Lab 1.0, you can still copy the plan text from your Lab 1.0 chat session and paste it directly into Agent Mode here — or switch to **Plan Mode**, regenerate the plan, and save it before continuing.

---

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If you did not save `plan.md` in Lab 1.0, switch to **Plan Mode** and enter:

  ```
  Plan the implementation of a GET endpoint on PlanesController that accepts a year query parameter and returns all matching planes. List every file that needs to change.
  ```

  Then ask Copilot to save it: `Save this plan to plan.md in the wright-brothers-backend folder.`

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Make sure the mode dropdown shows **Agent** before sending the prompt. Agent Mode will propose file edits — review each one before accepting.

</details>

---

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Agent Mode reads `plan.md` and should confirm it will change: `IPlaneRepository.cs`, `PlaneRepository.cs`, `PlanesController.cs`, and optionally `PlanesControllerTests.cs`.

- This is the **Plan → Save → Agent** workflow. Plan Mode designs the solution, saving to a file makes the plan portable and reusable, and Agent Mode executes it. Using `plan.md` as the source gives Agent Mode precise scope and prevents unnecessary changes.

</details>

---

## Task 1: Adding a new feature using GitHub Copilot Completions

Add a new feature to `PlanesController` that filters planes by minimum range.

The feature is described in a user story below:

```markdown
As a user, I want to filter planes by minimum range, so that I can see all planes capable of flying at least a certain distance.

Acceptance Criteria:
- The user can input a minimum range in kilometers.
- The system returns a list of planes whose range meets or exceeds that value.
- If no planes are found, the system should inform the user appropriately.
```

> [!IMPORTANT]
> You must use **GitHub Copilot Completions** to implement this feature — write a comment in the editor and let Copilot suggest the code.

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- GitHub Copilot Completions generates inline code suggestions as you type. The grey ghost text that appears is a suggestion — press **Tab** to accept it.

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Open `PlanesController.cs` and position your cursor after the `GetByYear` method that Agent Mode added in Task 0. Because a similar filtering method is already above it, Copilot will strongly predict the pattern for range filtering.

</details>

<br/>

<details>
  <summary>Click to open Hint 3</summary>

- Write a block comment describing the feature, then place your cursor immediately after it and wait for Copilot Completions to suggest the method:

  ```csharp
  /* **As a user**, **I want** to filter planes by minimum range,
   * **so that** I can see all planes capable of flying at least a certain distance.
   *
   * Acceptance Criteria:
   * - The user can input a minimum range in kilometers.
   * - The system returns a list of planes whose range meets or exceeds that value.
   * - If no planes are found, return NotFound.
   */
  <---- Place your cursor here and wait for GitHub Copilot Completions to generate the code
  ```

</details>

---

**Expert solution**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution</summary>

<br/>

- Open `PlanesController.cs` and add a block comment after `GetByYear`, then wait for Copilot Completions to suggest the method:

  ```csharp
  /* **As a user**, **I want** to filter planes by minimum range,
   * **so that** I can see all planes capable of flying at least a certain distance.
   *
   * Acceptance Criteria:
   * - The user can input a minimum range in kilometers.
   * - The system returns a list of planes whose range meets or exceeds that value.
   * - If no planes are found, return NotFound.
   */
  // GitHub Copilot Completions will generate:
  [HttpGet("range/{minRange}")]
  public ActionResult<List<Plane>> GetByRange(int minRange)
  {
      var planes = _planeRepository.GetAllPlanes()
          .Where(p => p.RangeInKm >= minRange)
          .ToList();

      if (planes.Count == 0)
      {
          return NotFound();
      }

      return Ok(planes);
  }
  ```

- Press **Tab** to accept the completion, then test with `GET /planes/range/500`.

</details>

---

## Task 2: Updating a plane using GitHub Copilot Agent Mode

Add a new feature to the project that allows for updating a plane.

The feature is described in a user story below:

```markdown
**As a user**,
**I want** to be able to update a plane in the project,
**so that** I can keep the information up to date.

Acceptance Criteria

- The user can update the plane's name, description, range.
- The date and time of the last update should be recorded and displayed for the plane.
- The system should validate the inputs to ensure data integrity before updating the plane information.
- The user should receive a confirmation message upon successful update.
```

> [!IMPORTANT]
> You must use **Agent Mode** to implement this feature — paste the user story directly into a Copilot Chat set to **Agent**.

<br/>

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Copy the user story and paste it into Copilot Chat with the mode set to **Agent**.

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Agent Mode will search the project, identify the relevant files, and propose changes across `Plane.cs`, `PlanesController.cs`, and potentially `IPlaneRepository.cs`. Review each change before accepting.

</details>

---

**Expert solution**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution</summary>

<br/>

- Switch Copilot Chat to **Agent** mode and paste the user story directly:

  ```
  As a user,
    I want to be able to update a plane in the project,
    so that I can keep the information up to date.

  Acceptance Criteria
  - The user can update the plane's name, description, range.
  - The date and time of the last update should be recorded and displayed for the plane.
  - The system should validate the inputs to ensure data integrity before updating the plane information.
  - The user should receive a confirmation message upon successful update.
  ```

- Agent Mode will search the project, identify the relevant files, and implement the feature. Review each proposed change before accepting. GitHub Copilot will provide the following implementation:

  1. Update the `Plane` Model: Add a property to record the last update timestamp.

    ```csharp
    namespace WrightBrothersApi.Models
    {
        public class Plane
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public string Description { get; set; }
            public int RangeInKm { get; set; }
            public DateTime LastUpdated { get; set; } // New property
        }
    }
    ```

  2. Add Update Method in `PlanesController`: Implement an endpoint to update the plane's information.

    ```csharp
    [HttpPut("{id}")]
    public ActionResult Update(int id, Plane updatedPlane)
    {
        var plane = _planeRepository.GetPlaneById(id);
        if (plane == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(updatedPlane.Name) || string.IsNullOrWhiteSpace(updatedPlane.Description))
        {
            return BadRequest("Name and Description are required.");
        }

        updatedPlane.Id = id;
        var updated = _planeRepository.UpdatePlane(updatedPlane);

        return Ok(new { message = "Plane updated successfully", plane = updated });
    }
    ```

  3. GitHub Copilot will also suggest changes to unit test the feature in the `PlanesControllerTests.cs` file. And it also suggested changes to the frontend project to display the last update timestamp for the plane.

  4. NOTE: GitHub Copilot will vary in the generated code. Make sure to review the generated code and adjust it to fit the project.

</details>

---

## Optional - Bonus Tasks

> [!CAUTION]
> Please be aware that this challenge does not include guardrails or provided solutions. You are encouraged to navigate and solve the tasks independently, which will help enhance your problem-solving skills and deepen your understanding of the frameworks and technologies involved.

For if you have time left and full of curiosity, you can try these bonus tasks:

1. Add a new feature to the project that allows users to filter planes by various criteria (e.g., year, RangeInKm).

2. Add a new feature to the project that allows users to delete a plane.

3. Any other feature you can think of that would be useful for the project.


### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 1.2 • Troubleshooting a Bug](../Lab%201.2%20-%20Troubleshooting%20a%20Bug/README.md)
