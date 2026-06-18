# Lab 0.1 - Pre-Flight Checklist ✈ Setting up Development Environment

It's your first day on the Wright Brothers team. The lead developer has sent you a link to the Wright Brothers project repository and asked you to get the project running locally before the first sprint begins.

## Estimated time to complete

- 10 min

## Learning Objectives

- Clone the repository and run both the backend and frontend locally
- Verify GitHub Copilot is working in VS Code

## Prerequisites

Make sure the following are installed before starting:

| Tool | Version | Notes |
|------|---------|-------|
| [Git](https://git-scm.com/downloads) | Latest | |
| [.NET SDK](https://dotnet.microsoft.com/download/dotnet/10.0) | 10.0 | |
| [Node.js](https://nodejs.org/) | 22 or later | npm is included |
| [Visual Studio Code](https://code.visualstudio.com/) | Latest | |

**Required VS Code extensions** (install before the lab):

- **GitHub Copilot** — `GitHub.copilot`
- **GitHub Copilot Chat** — `GitHub.copilot-chat`
- **C# Dev Kit** — `ms-dotnettools.csdevkit`
- **GitHub MCP Server** — `github.vscode-github-mcp`

**Optional but recommended:**

- **REST Client** — `humao.rest-client`

## Setting up the Development Environment

### Step 1: Clone the Repository

- Open a terminal.
- Clone the repository and navigate into the project directory:

    ```bash
    git clone https://github.com/xebia/Copilot-Bootcamp-ForAdvancedUsers.git
    cd Copilot-Bootcamp-ForAdvancedUsers
    ```

### Step 2: Open in Visual Studio Code

- Open VS Code from the project folder:

    ```bash
    code .
    ```

  Or go to **File > Open Folder** and select the `Copilot-Bootcamp-ForAdvancedUsers` folder.

### Step 3: Run the Backend API

- Open a terminal in VS Code (**Terminal > New Terminal**).
- Navigate to the backend project and start it:

    ```bash
    cd wright-brothers-backend/WrightBrothersApi
    dotnet run
    ```

- You should see output like:

> Now listening on: http://localhost:1903

- Verify the API is running by opening [http://localhost:1903/scalar/v1](http://localhost:1903/scalar/v1) in your browser. You should see the Scalar API UI.

```
http://localhost:1903/scalar/v1
```

### Step 4: Run the Frontend

- Open a **second terminal** in VS Code (**Terminal > New Terminal**).
- Navigate to the frontend project and start it:

    ```bash
    cd wright-brothers-frontend
    npm install
    npm run frontend
    ```

- You should see output like:

> ➜  Local:   http://localhost:5173/


- Open [http://localhost:5173](http://localhost:5173) in your browser. You should see the Wright Brothers application homepage.

```
http://localhost:5173
```

> [!NOTE]
> The backend runs on **http://localhost:1903** and the frontend runs on **http://localhost:5173**. Keep both terminals open throughout the Bootcamp — they both need to be running for the app to work correctly.

## Goal

By the end of this lab, you will have the project running locally and GitHub Copilot verified in VS Code.

## Hints

A few tips to keep in mind throughout the Bootcamp:

- Use the `/help` command in Copilot Chat to see available slash commands.
- Use `#file` to reference a specific file in your prompt. For example: `#file:FlightsController.cs What does this controller do?`
- Use `#editor` to include the currently open file in your prompt automatically.

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 0.2 • Project Exploration](../Lab%200.2%20-%20Project%20Exploration/README.md)

