# Copilot Advanced Bootcamp

Welcome to the Copilot Advanced Bootcamp, where we embark on an exciting journey into the world of coding, guided by GitHub Copilot, our trusty navigator much like an airplane's copilot. Imagine yourself as a pilot, akin to the pioneering Wright Brothers, stepping into the cockpit of modern software development. GitHub Copilot, your co-pilot, is here to assist you in navigating the vast and often turbulent skies of coding challenges.

Just as the Wright Brothers had to understand their tools and team to build their first airplane, here we will push the boundaries of AI-assisted coding. This Bootcamp is designed for seasoned developers ready to dive deep into GitHub Copilot's most advanced capabilities. Forget the `step-by-step hand-holding`; this is an immersive experience for those who want to explore the full power of GitHub Copilot without guardrails. You will navigate the complexities of modern software development with GitHub Copilot as your co-pilot, ready to tackle any challenge you encounter.

## In this Bootcamp, you’ll get:

Whether you're aiming to boost your productivity, enhance code quality, or explore the cutting-edge of programming tools, this Bootcamp offers an intense, hands-on exploration of GitHub Copilot's advanced features. You'll work with cutting-edge coding tools and techniques to enhance your productivity and refine your development process. This Bootcamp is for those who are ready to challenge themselves and elevate their coding skills to the next level.

## What to expect

- `Advanced Coding Challenges`. Engage in complex coding exercises designed to test your expertise.
- `Minimal Guidance`. Embrace the challenge with minimal instructions—you’re in the driver’s seat. We’ll offer a hint or two if needed, but if you find yourself truly stuck, the "`Expert Solution`" is there to guide you back on track.
- `In-Depth Exploration`. Delve into GitHub Copilot's advanced features with experienced trainers guiding the way.
- `Live Problem-Solving Sessions`. Witness GitHub Copilot's capabilities in action as we solve real-world coding problems together.
- `Skill Enhancement`. Sharpen your programming abilities and integrate AI more deeply into your workflow.

## Goal

The goal of this Bootcamp is to push the limits of what you can achieve with GitHub Copilot. We aim to deepen your understanding of AI-assisted development, empower you to solve complex problems independently, and help you seamlessly integrate these advanced tools into your daily coding practices. 

## Prerequisites

Before starting the labs, make sure the following tools are installed:

| Tool | Version | Notes |
|------|---------|-------|
| [Git](https://git-scm.com/downloads) | Latest | |
| [.NET SDK](https://dotnet.microsoft.com/download/dotnet/10.0) | **10.0** | |
| [Node.js](https://nodejs.org/) | **22 or later** | npm is included; required for Copilot CLI install in Lab 4.3 |
| [Visual Studio Code](https://code.visualstudio.com/) | Latest | |

**Required VS Code Extensions:**

| Extension | ID |
|-----------|----|
| GitHub Copilot | `GitHub.copilot` |
| GitHub Copilot Chat | `GitHub.copilot-chat` |
| C# Dev Kit | `ms-dotnettools.csdevkit` |
| GitHub MCP Server | `github.vscode-github-mcp` |

**Optional but recommended:**

- REST Client — `humao.rest-client`
- Mermaid Preview — `bierner.markdown-mermaid`
- GitHub Pull Requests — `GitHub.vscode-pull-request-github`

See [Lab 0.0 - Boarding](./Labs/Lab%200.0%20-%20Boarding/README.md) for additional onboarding information.

# Table of Contents

## Challenge 0 - Boarding and Environment Setup

### Lab 0.0 - Boarding
This lab will guide you through the process of setting up your environment and getting ready for the Bootcamp.

- Get started here ✈ [Lab 0.0 - Boarding](./Labs/Lab%200.0%20-%20Boarding/README.md)

### Lab 0.1 - Pre-Flight Checklist ✈ Setting up Local Development Environment
This lab walks you through cloning the repository, running the backend and frontend locally, and verifying GitHub Copilot is working.

- Get started here ✈ [Lab 0.1 - Pre-Flight Checklist](./Labs/Lab%200.1%20-%20Pre-Flight%20Checklist/README.md)

### Lab 0.2 - Aerial Surveillance ✈ Project Exploration with GitHub Copilot
This lab introduces exploring the project using GitHub Copilot Ask Mode, including understanding the project structure, frameworks, and how to run each component.

- Get started here ✈ [Lab 0.2 - Project Exploration](./Labs/Lab%200.2%20-%20Project%20Exploration/README.md)

## Challenge 1 - Mastering Advanced Code Completion

### Lab 1.0 - Flight Plan ✈ Planning with GitHub Copilot Plan Mode
This lab introduces Plan Mode — use it to research a feature, generate a structured implementation plan, and iterate before writing any code.

- Get started here ✈ [Lab 1.0 - Planning with Copilot](./Labs/Lab%201.0%20-%20Planning%20with%20Copilot/README.md)

### Lab 1.1 - Retrofit and Upgrade ✈ Feature Development with GitHub Copilot
This lab covers using Copilot Completions and Agent Mode to add new features to the backend.

- Get started here ✈ [Lab 1.1 - Feature Development](./Labs/Lab%201.1%20-%20Feature%20Development/README.md)

### Lab 1.2 - Aviation Incident Analysis ✈ Troubleshooting a Bug with GitHub Copilot
This lab covers discovering and fixing multiple real bugs in the codebase: two data access logic errors (wrong-index lookups in flight and plane repositories) and missing input validation on the planes API.

- Get started here ✈ [Lab 1.2 - Troubleshooting a Bug](./Labs/Lab%201.2%20-%20Troubleshooting%20a%20Bug/README.md)

## Challenge 2 - Proficiency in Unit Testing and Code Refinement

### Lab 2.1 - Operational Coverage ✈ Configuring Test Coverage with GitHub Copilot
This lab sets up visual code coverage reporting for the backend test project using Coverlet and ReportGenerator.

- Get started here ✈ [Lab 2.1 - Configuring Test Coverage](./Labs/Lab%202.1%20-%20Configuring%20Test%20Coverage/README.md)

### Lab 2.2 - Aircraft Inspections ✈ Unit Testing with GitHub Copilot
This lab covers writing missing unit tests for `PlanesController` using Copilot Completions and Agent Mode, then generating a full test class for `FlightsController` from scratch.

- Get started here ✈ [Lab 2.2 - Unit Testing](./Labs/Lab%202.2%20-%20Unit%20Testing/README.md)

## Challenge 3 - Front-End Development and API Integration

### Lab 3.1 - Wing and Tail Design ✈ Frontend Styling with GitHub Copilot
This lab improves the frontend UI: fix an accessibility contrast issue, center banner elements, and convert a list to a responsive grid.

- Get started here ✈ [Lab 3.1 - Frontend Styling](./Labs/Lab%203.1%20-%20Frontend%20Styling/README.md)

### Lab 3.2 - In-Flight Entertainment ✈ Creating Interactable Components with GitHub Copilot
This lab builds new interactive components: an Add Plane button and a full Add Plane form with validation.

- Get started here ✈ [Lab 3.2 - Creating Interactable Components](./Labs/Lab%203.2%20-%20Creating%20Interactable%20Components/README.md)

## Challenge 4 - Streamlining Automation

### Lab 4.1 - Auto-Pilot Mode ✈ Pipeline Automation with GitHub Copilot
This lab extends the existing backend CI pipeline and creates a new frontend build pipeline using GitHub Actions.

- Get started here ✈ [Lab 4.1 - Pipeline Automation](./Labs/Lab%204.1%20-%20Pipeline%20Automation/README.md)

### Lab 4.2 - Advanced Manufacturing ✈ Proof of Concepting with GitHub Copilot
This lab creates PowerShell scripts to query flight data from the OpenSky API (with graceful 401 fallback) and builds a visual Leaflet.js flight tracker.

- Get started here ✈ [Lab 4.2 - Proof of Concepting](./Labs/Lab%204.2%20-%20Proof%20of%20Concepting/README.md)

### Lab 4.3 - Ground Control ✈ Agentic Development with GitHub Copilot CLI
This lab introduces the standalone Copilot CLI: install it, fix bugs from the terminal, and create pull requests without leaving the command line.

- Get started here ✈ [Lab 4.3 - Copilot CLI](./Labs/Lab%204.3%20-%20Copilot%20CLI/README.md)

### Lab 4.4 - Mission Control ✈ Agentic Workflows with GitHub MCP Server
This lab connects Copilot Agent Mode to GitHub via the MCP Server: query issues, create issues from code reviews, and cross-reference findings — all from VS Code.

- Get started here ✈ [Lab 4.4 - MCP Server Integration](./Labs/Lab%204.4%20-%20MCP%20Server%20Integration/README.md)


## License

This work is licensed under the Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License. To view a copy of this license, visit [http://creativecommons.org/licenses/by-nc-nd/4.0/](http://creativecommons.org/licenses/by-nc-nd/4.0/).

## Legal Disclaimer

This repo and its contents, including slide decks, labs, and demonstration code, are strictly for internal use during training and remain the exclusive property of Xebia Group B.V.

All rights are protected under copyright law. No part of these materials may be reproduced, distributed, transmitted, displayed, performed, or used in any manner without prior written permission from Xebia Group B.V.
