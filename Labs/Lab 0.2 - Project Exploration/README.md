# Lab 0.2 - Aerial surveillance ✈ Project Exploration with GitHub Copilot

a.k.a. gathering information.

You start looking around in the project and notice that you have no idea what the project is about, coming from a different technology background. You remember what the lead developer told you about GitHub Copilot and decide to ask GitHub Copilot to help you understand what the project is about.

## Estimated time to complete

- 15 min

## Learning objectives

- A good way of approaching GitHub Copilot

- Explore a project in the way you would do normally to get a good understanding how much effort this simple task usually takes.

- Afterwards use GitHub Copilot to get the same information and compare the effort and time it took to get the same information.

## Disclaimer

> [!WARNING]
> For those who are new to the frameworks used in this project, it's perfectly normal to feel a bit out of your comfort zone. Take the time to explore and familiarize yourself with these technologies. This challenge is designed to guide you through the learning process. As a bonus, you'll gain valuable knowledge and skills in new frameworks and technologies. Happy learning!

## Task 1: Explore the project

In this task, you will explore the project manually **without** using GitHub Copilot. This is intentional because the focus is on understanding the structure and components of the project.

Find the answer to the following questions by exploring the project:

- What projects are there and what are their purposes?
- What programming languages / frameworks are used for the backend?
- What programming languages / frameworks are used for the frontend?
- How to run the backend project?
- How to run the frontend project?

<br/>

---

<br/>

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Look for `README.md` files in the project root and in both the `wright-brothers-backend` and `wright-brothers-frontend` directories that might contain information about the project structure, technology used and tools needed to run the project.

</details>

<br/>

---

<br/>

**Expert solution**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution</summary>

The following are the answers to the questions:

- What projects are there and what are their purposes?

  - There are two projects in the repository: `wright-brothers-backend` and `wright-brothers-frontend`. The purpose of the `wright-brothers-backend` project is to provide an API for managing planes. The purpose of the `wright-brothers-frontend` project is to provide a user interface for managing planes.

- What programming languages / frameworks are used for the backend?

  - The programming language used for the backend is C# and the framework used is ASP.NET Core.

- What programming languages / frameworks are used for the frontend?

  - The programming language used for the frontend is Typescript and the framework used is React.

- How to run the backend project?

  - To run the backend project, you need to navigate to the `wright-brothers-backend` directory and run the following command:
    ```sh
    dotnet restore
    dotnet run
    ```

- How to run the frontend project?
  - To run the frontend project, you need to navigate to the `wright-brothers-frontend` directory and run the following command:
    ```sh
    npm install
    npm run frontend
    ```

</details>

<br/>

## Task 2: Explore the project using GitHub Copilot

Find the answer to the same questions, but now by using GitHub Copilot.

- What projects are there and what are their purposes?
- What programming languages / frameworks are used for the backend?
- What programming languages / frameworks are used for the frontend?
- How to run the backend project?
- How to run the frontend project?

<br/>

---

<br/>

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Open GitHub Copilot Chat and make sure the mode is set to **Ask** (select from the dropdown at the bottom of the chat panel).

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Ask questions in plain English — no special prefixes needed. For example:

  ```
  What projects are in this repository and what is each one for?
  ```

  Copilot will search the workspace automatically.

</details>

<br/>

<details>
  <summary>Click to open Hint 3</summary>

- Ask the questions one by one to get more detailed answers for each topic.

</details>

<br/>

---

<br/>

**Expert solution**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution</summary>

- Open GitHub Copilot Chat. Make sure the mode dropdown (bottom of the chat panel) is set to **Ask**.

- Type each question in plain English, one at a time:

  ```
  What projects are in this repository and what is each one for?
  ```

  ```
  What programming language and framework does the backend use?
  ```

  ```
  What programming language and framework does the frontend use?
  ```

  ```
  How do I run the backend project?
  ```

  ```
  How do I run the frontend project?
  ```

- Copilot searches the workspace automatically and shows the source references it used in the **Used References** section. Compare the time and effort it took to get answers manually (Task 1) vs. using Ask Mode (Task 2).

</details>

<br/>

---

<br/>

## Optional - Bonus Tasks

> [!CAUTION]
> Please be aware that this challenge does not include guardrails or provided solutions. You are encouraged to navigate and solve the tasks independently, which will help enhance your problem-solving skills and deepen your understanding of the frameworks and technologies involved.

For if you have time left and full of curiosity, you can try these bonus tasks:

1. Use GitHub Copilot to find the answers to the following questions.
- What are the main features of the project?
- What are the key dependencies and libraries used in the project?
- How does the current deployment process work?
  
2. Any other questions you can think of that would be useful to understand the project better.
- What are the potential performance issues in `#FlightsController.cs`?
- Are there any known security vulnerabilities or concerns in file `#PlanesController.cs`?

### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 1.0 • Planning with Copilot](../Lab%201.0%20-%20Planning%20with%20Copilot/README.md)
