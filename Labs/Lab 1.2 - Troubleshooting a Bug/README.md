# Lab 1.2 - Aviation Incident Analysis ✈ Troubleshooting bugs with GitHub Copilot

When you are testing the new feature and exploring other features in the project, you discovered a bug. You reach out to your team members, but they are all finishing up their days and are not available to help you. You noticed that there is a bug in the same file where you added the new feature. You decided to use GitHub Copilot Chat to help you fix the bug.

## Learning objectives

- Fix issues using GitHub Copilot Chat by explaining the issue and reproduction steps

## Estimated time to complete

- 20 min

## Task 1: Troubleshooting and fixing a bug

You discovered a bug in the project where it returns the wrong flight by id.
Your task is to fix the bug in the project.

Here are the reproduction steps:

1. Run the backend project locally
2. Go to the browser and navigate to `http://localhost:1903/flights/2`

  ```
  http://localhost:1903/flights/2
  ```

3. Notice that it returned the flight with the id of `3` instead of `2`

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Hint 1</summary>

- First, reproduce the bug by following the reproduction steps.

</details>

<details>
  <summary>Hint 2</summary>

- Run the backend locally by running the following command:

  ```sh
  cd wright-brothers-backend/WrightBrothersApi
  dotnet run
  ```

</details>

<details>
  <summary>Hint 3</summary>

- Open GitHub Copilot Chat (Ask Mode) and describe the bug with the exact symptoms:

  ```
  I found a bug: GET /flights/2 returns the flight with ID 3 instead of ID 2.
  Find and explain the root cause in the repository code, then patch the bug.
  ```

</details>

<details>
  <summary>Expert Solution</summary>

<br/>

- Open GitHub Copilot Chat (Ask Mode or Agent Mode) and describe the bug with reproduction steps:

  ```
  I found a bug in the project where it returns the wrong flight by id.
  Here are the reproduction steps:
  1. Run the backend project locally
  2. Navigate to http://localhost:1903/flights/2
  3. It returns the flight with id 3 instead of 2

  Can you help me find and fix this bug?
  ```

- GitHub Copilot will identify the root cause in `FlightRepository.cs`. The `GetFlightById` method uses `Flights.ElementAt(id)` which retrieves by **index** (zero-based) rather than by the `Id` property. Flight ID 2 is at index 1 — so `/flights/1` is fine, but `/flights/2` returns the element at index 2, which has ID 3.

- The fix:

  ```csharp
  // In wright-brothers-backend/WrightBrothersApi/Repositories/FlightRepository.cs
  public Flight GetFlightById(int id)
  {
      return Flights.FirstOrDefault(f => f.Id == id);
  }
  ```

- After applying the fix, run the backend and verify `GET /flights/2` now returns the flight with ID 2.

</details>

---

## Task 2: The Wrong Plane Bug

After fixing the flight bug, a colleague reports that the planes API has the same problem. When they request a plane by ID, the wrong plane comes back.

Your task is to reproduce the bug, identify the root cause, and fix it.

**Reproduction steps:**

1. Run the backend project locally
2. Navigate to `http://localhost:1903/planes/2`

  ```
  http://localhost:1903/planes/2
  ```

3. Notice that it returned the plane with ID `3` instead of ID `2`

---

<details>
  <summary>Hint 1</summary>

- First, reproduce the bug by following the reproduction steps.

</details>

<br/>

<details>
  <summary>Hint 2</summary>

- Open Copilot Chat (Ask Mode) and describe the bug:

  ```
  I found a bug: GET /planes/2 returns the plane with ID 3 instead of ID 2.
  Find and explain the root cause in the repository code, then patch the bug.
  ```

</details>

<br/>

<details>
  <summary>Hint 3</summary>

- Look at `PlaneRepository.cs` and compare `GetPlaneById` to `GetAllPlanes`. Does it retrieve by **ID** or by **index position**?

</details>

---

  <details>
  <summary>Expert Solution</summary>

- Use Copilot Agent Mode with the following prompt:

  ```
  There's a bug in the planes API. GET /planes/2 returns the plane with ID 3 instead of ID 2.
  Please investigate PlaneRepository and fix the root cause.
  ```

- **Root cause:** `PlaneRepository.GetPlaneById` uses `Planes.ElementAt(id)` which retrieves by **zero-based index**, not by the `Id` property. `/planes/2` fetches the element at index 2, which has ID 3.

- **Fix:**

  ```csharp
  public Plane GetPlaneById(int id)
  {
      return Planes.FirstOrDefault(p => p.Id == id);
  }
  ```

- After applying the fix, verify `GET /planes/2` returns the plane with ID 2.

> [!NOTE]
> Notice this is the **exact same root cause** as the flight bug in Task 1. The same class of mistake — index vs. ID confusion — appeared in two separate repositories. This is a common off-by-one pattern that Copilot can both introduce and fix. Keep this in mind when reviewing Copilot-generated code.

</details>

---

## Task 3: Missing Input Validation Bug

After fixing the ID bugs, you notice that the planes API accepts completely invalid data without complaint. Sending a plane with a blank name, a year of `0`, and a negative range returns `201 Created` — and the bad data is stored.

Your task is to reproduce this, identify where validation is missing, and fix it.

**Reproduction steps:**

1. Run the backend project locally
2. Call `POST /planes` with invalid data:

    ```json
    {
      "id": 99,
      "name": "",
      "year": 0,
      "description": "",
      "rangeInKm": -500
    }
    ```

3. Notice you receive `201 Created` — the API accepted it with no complaint
4. Call `GET /planes` and confirm the invalid plane is now in the list

---

<details>
  <summary>Hint 1</summary>

To reproduce the bug using Scalar:

1. Open `http://localhost:1903/scalar/v1` in your browser
2. In the left sidebar, find and expand the **Planes** section
3. Click **POST /planes**
4. Click **Test Request**
5. Replace the request body with the invalid payload:

    ```json
    {
      "id": 99,
      "name": "",
      "year": 0,
      "description": "",
      "rangeInKm": -500
    }
    ```

6. Click **Send** — you should see `201 Created` returned, confirming the bug

</details>

<details>
  <summary>Hint 2</summary>

- Open Copilot Chat (Ask Mode) and describe the problem:

  ```
  POST /planes accepts invalid data — empty name, year of 0, and negative rangeInKm — and returns 201 Created.
  Where should input validation be added and what rules should it enforce?
  ```

</details>

<details>
  <summary>Hint 3</summary>

- Look at `PlanesController.cs` — the `Post` method only checks if the request body is `null`. It does not validate any individual fields. That's where the fix belongs.

</details>

---

<details>
  <summary>Expert Solution</summary>

- Use Copilot Agent Mode with the following prompt:

  ```
  POST /planes accepts invalid data: empty name, year 0, and negative rangeInKm all return 201 Created.
  Add input validation to the Post method in PlanesController so that:
  - Name and Description cannot be blank
  - Year must be between 1900 and the current year
  - RangeInKm must be greater than 0
  Return a 400 Bad Request with a descriptive message for each violation.
  ```

- **Root cause:** `PlanesController.Post` only guards against a null body — no field-level validation exists.

- **Fix:**

  ```csharp
  [HttpPost]
  public ActionResult<Plane> Post(Plane plane)
  {
      if (plane == null)
          return BadRequest("Plane data is required.");

      if (string.IsNullOrWhiteSpace(plane.Name))
          return BadRequest("Name is required.");

      if (string.IsNullOrWhiteSpace(plane.Description))
          return BadRequest("Description is required.");

      if (plane.Year < 1900 || plane.Year > DateTime.UtcNow.Year)
          return BadRequest($"Year must be between 1900 and {DateTime.UtcNow.Year}.");

      if (plane.RangeInKm <= 0)
          return BadRequest("RangeInKm must be greater than 0.");

      _planeRepository.AddPlane(plane);

      return CreatedAtAction(nameof(GetById), new { id = plane.Id }, plane);
  }
  ```

- After applying the fix, re-send the invalid payload — you should receive `400 Bad Request` with a clear message.

</details>

<br/>

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 2.1 • Configuring Test Coverage](../Lab%202.1%20-%20Configuring%20Test%20Coverage/README.md)
