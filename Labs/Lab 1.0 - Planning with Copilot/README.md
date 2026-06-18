# Lab 1.0 - Flight Plan ✈ Planning with GitHub Copilot Plan Mode

Before writing a single line of code, the lead developer reminds you: *"Plan the flight before you fly it."* GitHub Copilot's **Plan Mode** lets you research a feature, generate a structured implementation plan, and iterate on it — all before any code is touched.

## Estimated time to complete

- 15 min

## Learning Objectives

- Understand when to use Plan Mode vs Ask Mode vs Agent Mode
- Use Plan Mode to generate a structured implementation plan for a new feature
- Iterate on a plan with follow-up questions
- Recognize how a good plan reduces back-and-forth during implementation

## How to Switch Modes

In the Copilot Chat panel, click the **mode dropdown** at the bottom left of the input box. You will see three options:

| Mode | When to use |
|------|-------------|
| **Ask** | Explore code, ask questions, understand the codebase |
| **Plan** | Research a feature and generate a step-by-step implementation plan before coding |
| **Agent** | Implement changes autonomously — reads and edits files, runs commands |

> [!NOTE]
> In Plan Mode, GitHub Copilot reads your files and generates a plan — but it does **not** make any changes. You stay in control. When you're satisfied with the plan, you can click **Start Implementation** to hand off to Agent Mode, or copy the plan and implement it yourself.

---

## Task 0: Aerial Surveillance with Ask Mode

Before planning, explore what you're working with.

- Open Copilot Chat and set the mode to **Ask**.
- Ask Copilot the following, one at a time:

  ```
  What endpoints does the PlanesController expose?
  ```

  ```
  What model does the Plane class use? What properties does it have?
  ```

  ```
  Does the backend have any way to filter planes by year?
  ```

- Notice how Ask Mode answers questions and shows references — but does not suggest or make any changes.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If an answer is too brief, follow up with:

  ```
  Are there any gaps in the current API — missing CRUD operations or filtering capabilities?
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Make sure the mode dropdown at the bottom of Copilot Chat shows **Ask** — not Agent or Plan. Ask Mode answers only; it does not modify files.

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Ask Mode should tell you: `PlanesController` exposes `GET /planes`, `GET /planes/{id}`, and `POST /planes`. The `Plane` model has `Id`, `Name`, `Year`, `Description`, `RangeInKm`, and `LastUpdated` properties. There is no year-filter endpoint — that gap is exactly what Task 1's plan will address.

</details>

<br/>

---

## Task 1: Plan a New Feature — Query Planes by Year

The product team has asked for an endpoint that returns planes manufactured in a specific year. Before jumping into Agent Mode, use Plan Mode to structure the work first.

- Open Copilot Chat, switch the mode to **Plan**, click **+** to clear history.

- Enter the following prompt:

  ```
  I need to add a GET endpoint to PlanesController that accepts a year query parameter
  and returns all planes matching that year of manufacture.
  The endpoint should follow the existing patterns in the controller.
  Plan the implementation — list every file that needs to change and what changes are needed.
  ```

- Review the plan Copilot generates. It should identify:
  - `PlanesController.cs` — new `[HttpGet]` method with `[FromQuery] int year`
  - `IPlaneRepository.cs` — new interface method
  - `PlaneRepository.cs` — implementation of the new method
  - Any test file that should be updated

- Iterate on the plan with a follow-up question:

  ```
  Should the endpoint return 404 if no planes match, or an empty list?
  What would be the better API design here?
  ```

- Review Copilot's reasoning. Ask one more follow-up:

  ```
  Update the plan to return an empty list with 200 OK instead of 404.
  ```

> [!WARNING]
> **Do not click Start Implementation yet.** Lab 1.1 is where you implement this feature. The goal here is to understand Plan Mode's output and iteration loop.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If Copilot's plan is too vague, add more context:

  ```
  The existing pattern uses IFlightRepository — follow the same pattern for planes.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- You can ask Plan Mode to explain any part of its plan in more detail before you implement it. For example:

  ```
  Explain why IPlaneRepository needs a new method rather than filtering in the controller.
  ```

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

A well-formed Plan Mode output for this feature should look roughly like:

**Files to change:**
1. `IPlaneRepository.cs` — add `List<Plane> GetPlanesByYear(int year);`
2. `PlaneRepository.cs` — implement `GetPlanesByYear` using LINQ: `Planes.Where(p => p.Year == year).ToList()`
3. `PlanesController.cs` — add endpoint:
   ```csharp
   [HttpGet("year/{year}")]
   public ActionResult<List<Plane>> GetByYear(int year)
   {
       var planes = _planeRepository.GetPlanesByYear(year);
       return Ok(planes);
   }
   ```
4. `PlanesControllerTests.cs` — add test for the new endpoint

**Key design decision:** Return `200 OK` with an empty list rather than `404 Not Found`. Rationale: the resource (the collection of planes for that year) exists — it just happens to be empty. This is standard REST convention for collection endpoints.

</details>

<br/>

---

## Task 2: Plan Input Validation

The team has flagged that `POST /planes` accepts any payload without validation — a plane with no name, a negative year, or zero range would be stored without complaint.

- Stay in **Plan Mode**.
- Enter the following prompt:

  ```
  Plan how to add input validation to the POST /planes endpoint.
  The plane name should be required, year must be between 1900 and 2030,
  and RangeInKm must be greater than zero.
  List every file that needs to change and what the validation approach should be.
  ```

- After reviewing the plan, ask:

  ```
  Should validation live in the controller, in the model using data annotations,
  or in a separate validator class? What are the trade-offs?
  ```

- Copilot will reason through the options. Notice how Plan Mode is useful for **architectural decisions** — not just listing files.

> [!WARNING]
> Again, **Do not click Start Implementation yet.**. The goal is to experience Plan Mode as a design tool. The contrast becomes clear in Lab 1.1 when you use Agent Mode and it just starts editing files immediately.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If you want to see Plan Mode explore multiple approaches, ask:

  ```
  Show me two different ways to implement this validation and compare them.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Push Plan Mode to reason about error responses:

  ```
  Should validation errors be returned as a 400 Bad Request with field-level messages, or as a generic error? What does ASP.NET Core do automatically?
  ```

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

A good plan for this task should recommend **data annotations on the model** as the simplest approach for this codebase:

```csharp
// In Plane.cs
using System.ComponentModel.DataAnnotations;

public class Plane
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Range(1900, 2030)]
    public int Year { get; set; }

    public string Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "RangeInKm must be greater than zero.")]
    public int RangeInKm { get; set; }

    public DateTime LastUpdated { get; set; }
}
```

ASP.NET Core's model binding automatically validates `[Required]` and `[Range]` and returns `400 Bad Request` when validation fails — no controller changes needed. The plan should note that `ModelState.IsValid` is checked automatically when the controller is decorated with `[ApiController]`.

</details>

<br/>

---

## Save Your Plan for Lab 1.1

Now that you have a solid plan, save it so you can use it in the next lab.

- In Copilot Chat, ask:

  ```
  Save the full plan from this conversation — both the year-filter endpoint and the input validation — to a markdown file called plan.md in the root of the wright-brothers-backend folder.
  ```

> [!TIP]
> In Agent Mode you can ask Copilot to execute a saved plan directly. In Lab 1.1, you will open `plan.md`, switch to **Agent Mode**, and implement it step-by-step. This is a powerful way to separate design from implementation and ensure you have a clear roadmap before any code is changed.:

---

<br/>

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 1.1 • Feature Development](../Lab%201.1%20-%20Feature%20Development/README.md)
