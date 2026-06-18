# Lab 4.3 - Ground Control ✈ Agentic Development with GitHub Copilot CLI

The team lead has a challenge: can you fix the `FlightRepository` bug and open a pull request — without ever leaving the terminal? GitHub Copilot CLI brings the same agentic capabilities you know from VS Code directly into your command line, letting you explore code, fix bugs, and interact with GitHub from one interactive session.

## Estimated time to complete

- 20 min

## Learning Objectives

- Install and authenticate the GitHub Copilot CLI
- Use the interactive `copilot` session to explore a codebase
- Fix a bug directly from the terminal using Copilot CLI
- Create a GitHub pull request from the terminal using Copilot CLI
- Use CLI Plan Mode to plan a feature before implementing it

---

## Install Copilot CLI

Before starting the tasks, install the GitHub Copilot CLI.

**Prerequisites:** Node.js 22+, active GitHub Copilot subscription

**Windows (winget):**
```bash
winget install GitHub.Copilot
```

**macOS (Homebrew):**
```bash
brew install copilot-cli
```

**All platforms (npm — requires Node.js 22+):**
```bash
npm install -g @github/copilot
```

**Authenticate:**
```bash
copilot
```
In the interactive session, type `/login` and follow the prompts to sign in with your GitHub account.

**Verify installation:**
```bash
copilot --version
```

You should see a version number printed. If the command is not found, restart your terminal and try again.

---

## Task 0: Aerial Surveillance with Copilot CLI

Get familiar with the Copilot CLI interactive session.

- Open a terminal in VS Code (**Terminal > New Terminal**).
- Navigate to the repo root:

  ```bash
  cd <your-local-clone-path>
  ```

  For example: `cd ~/source/repos/Copilot-Bootcamp-ForAdvancedUsers`

- Start an interactive session:

  ```bash
  copilot
  ```

- Ask Copilot to orient you to the project:

  ```
  What is this project? Describe the overall architecture and the main components.
  ```

  ```
  What backend framework is used and how are controllers structured?
  ```

  ```
  What frontend framework is used?
  ```

- Notice how Copilot CLI reads the workspace files in the background — similar to how Agent Mode in VS Code works.

- Type `/exit` or press `Ctrl+C` to leave the session when you're done exploring.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- The Copilot CLI session is context-aware of the directory you started it from. Start it from the repo root for best results.

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- You can ask Copilot to explore a specific file:

  ```
  Summarize wright-brothers-backend/WrightBrothersApi/Controllers/PlanesController.cs
  ```

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Start the session from the repo root and use natural language questions just like you would in Copilot Chat. The main difference is that CLI sessions are more terminal-focused — you can chain tasks (explore → fix → commit) in one session.

</details>

<br/>

---

## Task 1: Fix a Bug from the Terminal

In Task 0 you explored the project. Now use Copilot CLI to find and fix the `FlightRepository.GetFlightById` bug.

> [!NOTE]
> If you already fixed this bug in Lab 1.2, Copilot CLI will confirm it's fixed. That's still a valid exercise — CLI can verify the state of the codebase the same way it can find bugs.

- Start a new Copilot CLI session from the repo root.
- Enter the following prompt:

  ```
  Find any bugs in wright-brothers-backend/WrightBrothersApi/Repositories/FlightRepository.cs
  and fix them. Explain the bug and the fix before making any changes.
  ```

- Copilot CLI will identify the `Flights.ElementAt(id)` issue (index-based rather than Id-based lookup) and propose a fix.
- Review the proposed change. Type `yes` or `approve` to accept it.
- Verify the fix was applied by opening `FlightRepository.cs`.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If Copilot CLI asks for clarification, provide it:

  ```
  The bug is that GET /flights/2 returns a flight with ID 3. The fix should use FirstOrDefault instead of ElementAt.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- If Copilot applies the fix but you want to verify it's correct, ask:

  ```
  Explain exactly why ElementAt(id) causes the wrong result and confirm the FirstOrDefault fix is correct.
  ```

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- The correct fix is:

  ```csharp
  public Flight GetFlightById(int id)
  {
      return Flights.FirstOrDefault(f => f.Id == id);
  }
  ```

- Copilot CLI will find this automatically. It reads the file, identifies that `ElementAt(id)` treats `id` as a zero-based index (so `id=2` returns the element at index 2, which is ID 3), and proposes `FirstOrDefault(f => f.Id == id)` as the fix.

</details>

<br/>

---

## Task 2: Create a Pull Request from the Terminal

Now commit your fix and open a pull request — all from the Copilot CLI session.

- In the Copilot CLI session, enter:

  ```
  Stage my changes, commit them with a descriptive message, and create a pull request
  titled "Fix FlightRepository GetFlightById index bug".
  ```

- Copilot CLI will run `git add`, `git commit`, and use the GitHub API to create the pull request.
- Review the PR URL that Copilot prints. Open it in your browser to verify the PR was created.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- Make sure you are on a branch other than `main` before asking Copilot to create a PR. If needed, ask:

  ```
  Create a new branch called fix/flight-repository-bug and switch to it first.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- If Copilot CLI needs GitHub permissions for the PR, it will prompt you. Follow the authentication steps it provides.

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- The full workflow in one CLI session:

  1. `"Create a branch called fix/flight-repository-bug"` — creates and checks out the branch
  2. `"Stage all changes and commit with message: Fix GetFlightById to use FirstOrDefault instead of ElementAt"` — stages and commits
  3. `"Push this branch and open a pull request titled Fix FlightRepository GetFlightById index bug"` — pushes and creates PR

- Copilot CLI orchestrates the `git` and `gh` commands on your behalf. The PR will appear in the repository's **Pull Requests** tab.

</details>

<br/>

---

## Task 3: Use CLI Plan Mode

Copilot CLI has its own Plan Mode. Use it to plan a pagination feature for `GET /planes`.

- In the Copilot CLI session, press **Shift+Tab** to switch to Plan Mode (or type `/plan`).
- Enter the following prompt:

  ```
  Plan how to add pagination to the GET /planes endpoint.
  The endpoint should accept `page` and `pageSize` query parameters.
  List every file that needs to change and what changes are needed.
  ```

- Review the plan output. Notice how it mirrors the Plan Mode experience in VS Code.
- Do **not** implement the plan — the goal is to understand how Plan Mode works in the CLI context.
- Press **Shift+Tab** again or type `/agent` to switch back to Agent Mode.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If you can't find CLI Plan Mode, try typing `/plan` directly in the session prompt.

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Compare the CLI plan output to what Plan Mode in VS Code produces for the same feature. The reasoning should be identical — only the surface (terminal vs. chat panel) is different.

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

A good CLI Plan Mode output for pagination should identify:

1. `IPlaneRepository.cs` — add `List<Plane> GetPlanesPaged(int page, int pageSize);`
2. `PlaneRepository.cs` — implement using `.Skip((page - 1) * pageSize).Take(pageSize).ToList()`
3. `PlanesController.cs` — update `GetAll` to accept `[FromQuery] int page = 1, [FromQuery] int pageSize = 10`
4. `PlanesControllerTests.cs` — add tests for pagination edge cases (page 0, page > total, etc.)

The Plan Mode output in CLI is equivalent to what you'd see in VS Code — the key insight is that **the same agentic reasoning works across surfaces**.

</details>

<br/>

---

## Optional - Bonus Tasks

1. Use Copilot CLI to explain the `UpdateFlightStatus` method in `FlightsController.cs` and identify any edge cases it doesn't handle.

2. Ask Copilot CLI to write and run the unit tests for the `calculateAerodynamics` endpoint you added in Lab 1.2.

3. Use Copilot CLI to generate a `CHANGELOG.md` entry summarizing all changes made during this Bootcamp.

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 4.4 • MCP Server Integration](../Lab%204.4%20-%20MCP%20Server%20Integration/README.md)
