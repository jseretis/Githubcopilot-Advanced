# Lab 4.4 - Mission Control ✈ Agentic Workflows with GitHub MCP Server

GitHub Copilot works best when it can act on the things your team cares about most — issues, pull requests, and code all in one place. The **GitHub MCP Server** connects Copilot Agent Mode directly to your GitHub repository, letting you query issues, create PRs, draft comments, and cross-reference code findings with open work items — all without leaving VS Code.

## Estimated time to complete

- 20 min

## Learning Objectives

- Set up the GitHub MCP Server in VS Code
- Verify the MCP server is connected and understand the available tools
- Use Agent Mode + MCP to query and filter GitHub issues
- Create a GitHub issue from a code review using Agent Mode
- Cross-reference open issues with source code and draft a comment

---

## Setup: GitHub MCP Server

Complete this setup before starting the tasks.

### Step 1: Generate a Personal Access Token (PAT)

1. Go to [https://github.com/settings/tokens](https://github.com/settings/tokens)
2. Click **Generate new token (classic)**
3. Give it a descriptive name: `Copilot MCP Bootcamp`
4. Set expiration to **7 days** (enough for this Bootcamp)
5. Under **Select scopes**, check **`repo`** (full control of private repositories)
6. Click **Generate token**
7. **Copy the token immediately** — you won't be able to see it again

### Step 2: Install the GitHub MCP Server Extension

1. Open VS Code
2. Press `Ctrl+Shift+X` to open the Extensions panel
3. Search for `GitHub MCP Server`
4. Install the extension with ID: **`github.vscode-github-mcp`**

### Step 3: Connect to Your GitHub Account

1. Press `Ctrl+Shift+P` and type `MCP: Add Server`
2. Select **GitHub MCP Server** from the list
3. When prompted, paste your PAT from Step 1

### Step 4: Verify the Connection

1. Press `Ctrl+Shift+P` and type `MCP: List Servers`
2. You should see **`github/github-mcp-server`** with status **Running**

### Step 5: Test in Agent Mode

1. Open Copilot Chat and switch to **Agent** mode
2. Type: `What GitHub MCP tools are available to me right now?`
3. Copilot will list the available tools (list issues, create issues, search code, manage PRs, etc.)

> [!NOTE]
> If the server status shows **Stopped** or **Error**, try restarting VS Code. If the problem persists, regenerate your PAT and repeat Step 3.

---

## Task 0: Aerial Surveillance with MCP

Get oriented with what the MCP server can do.

- Ensure Agent Mode is selected in the Copilot Chat panel.
- Enter the following prompts one at a time:

  ```
  What GitHub MCP tools are available to me right now?
  ```

  ```
  What can I use the GitHub MCP server to do in this project?
  ```

- Notice how Copilot describes tools like `list_issues`, `create_issue`, `get_pull_request`, `search_code`, etc. These are MCP tool calls that Copilot makes automatically when you ask it to perform a task.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If Copilot doesn't mention any MCP tools, verify the server is running: `Ctrl+Shift+P → MCP: List Servers`.

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- If Copilot lists tools but you want to confirm MCP is involved (not just built-in Copilot knowledge), ask:

  ```
  Which of those tools come from the GitHub MCP server versus your built-in capabilities?
  ```

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- A healthy MCP server will surface tools including: `list_issues`, `get_issue`, `create_issue`, `list_pull_requests`, `get_pull_request`, `search_code`, `create_pull_request_review_comment`, `add_issue_comment`.

- Copilot will automatically invoke these tools when it determines they're needed — you don't have to name them explicitly in your prompt.

</details>

<br/>

---

## Task 1: Explore the Repository via MCP

Use Agent Mode + MCP to query issues and pull requests without leaving VS Code.

- In Agent Mode, ask:

  ```
  List all open issues in xebia/Copilot-Bootcamp-ForAdvancedUsers
  ```

- Then filter by label:

  ```
  Show me only the open issues labeled "bug"
  ```

  > [!NOTE]
  > If no issues with that label exist yet, the result will be empty — that's fine. Try a different label or ask Copilot to list all available labels first.

- Then look at recent work:

  ```
  Summarize the most recently merged pull request in this repository
  ```

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If Copilot can't find the repository, make sure you typed the exact owner/repo format: `xebia/Copilot-Bootcamp-ForAdvancedUsers`.

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- You can follow up with:

  ```
  Which of those issues are related to the backend?
  ```

  Copilot will reason over the issue titles and descriptions to filter them for you.

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Copilot uses `list_issues` MCP tool with filters (owner, repo, state=open, labels) automatically. The result is a structured list of issues with titles, numbers, labels, and assignees.

- For the PR summary, Copilot uses `list_pull_requests` (state=closed, sort=updated) and `get_pull_request` to fetch the description and diff summary of the most recent merge.

- The key insight: **you describe what you want in natural language — Copilot selects and calls the right MCP tools automatically**.

</details>

<br/>

---

## Task 2: Create a GitHub Issue from a Code Review

Use Agent Mode to review a source file and automatically create a GitHub issue for any improvement it finds.

- In Agent Mode, enter:

  ```
  Review PlanesController.cs and create a GitHub issue for any code quality improvements you find.
  Use the repository xebia/Copilot-Bootcamp-ForAdvancedUsers.
  Label the issue "enhancement".
  ```

- Copilot will read `PlanesController.cs`, identify potential improvements (e.g., missing error handling, validation gaps, missing tests), draft an issue title and body, and create the issue via the MCP `create_issue` tool.

- Open the repository's Issues tab in your browser to verify the issue was created.

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If you want Copilot to focus on a specific aspect, refine the prompt:

  ```
  Focus only on missing input validation and error handling in PlanesController.cs.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- You can ask Copilot to preview the issue body before creating it:

  ```
  Show me the issue title and body before you create it.
  ```

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Copilot reads `PlanesController.cs` (using the `read_file` tool), identifies findings, composes an issue body with code references, and calls `create_issue` with owner=`xebia`, repo=`Copilot-Bootcamp-ForAdvancedUsers`, title, body, and labels.

- Example issue Copilot might create: *"PlanesController: POST /planes lacks input validation for Year range and empty Name — add `[Range]` and `[Required]` data annotations to the Plane model."*

</details>

<br/>

---

## Task 3: Cross-Reference Issues with Source Code

Use Agent Mode to bridge open issues with the codebase and draft a comment.

- In Agent Mode, ask:

  ```
  Find all open issues in xebia/Copilot-Bootcamp-ForAdvancedUsers and identify
  which ones relate to the backend source code. For each match, cite the relevant file.
  ```

- After reviewing the results, pick one issue number from the list. Ask:

  ```
  Draft a comment on issue #[number] that explains the root cause based on the
  current source code and proposes a fix with a code snippet.
  ```

  Replace `[number]` with an actual issue number from the previous step.

- Review the drafted comment. If it looks correct, ask Copilot to post it:

  ```
  Post this comment to the issue.
  ```

<br/>

---

<br/>

**Hints**

<details>
  <summary>Click to open Hint 1</summary>

- If Copilot lists too many issues to be useful, add a filter:

  ```
  Focus only on issues that mention controller, endpoint, or API in their title or description.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- You don't have to post the comment — reviewing and revising the draft is a valid outcome for this task. The goal is to understand how MCP enables **code + issue context** to flow into the same Agent Mode conversation.

</details>

<br/>

---

<br/>

**Expert Solution**

<details>
  <summary>Click to open Expert Solution</summary>

- Copilot uses `list_issues` to fetch all open issues, then `search_code` or `read_file` to cross-reference. When drafting a comment, it uses `get_issue` to read the full issue context and `add_issue_comment` to post.

- The key teaching moment: **Agent Mode with MCP lets Copilot act across GitHub and the codebase simultaneously** — reading code, reading issues, and writing back to GitHub in a single conversation without switching contexts.

</details>

<br/>

---

## Optional - Bonus Tasks

1. Ask Agent Mode to identify all open issues that have no assignee and assign them to yourself via MCP.

2. Use Agent Mode to search the codebase for any `TODO` comments and create a GitHub issue for each one found.

3. Ask Copilot: *"Generate a weekly status summary for this repository: open issues by label, PRs merged this week, and any blocked items."*

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;
