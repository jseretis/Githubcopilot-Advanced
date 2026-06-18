# Lab 3.2 - In-Flight Entertainment ✈ Creating Interactable Components with GitHub Copilot

Besides the style changes, there is also a feature proposed for adding new planes to the application. You need to create an interactive button component that allows users to add new planes. The button should have appropriate visual states (default, hover, and active) to provide good user feedback. When clicking the button, users should be navigated to a form page where they can add a new plane.

## Estimated time to complete

- 20 min

## Learning objectives

- Generate components by describing to GitHub Copilot how they should look and behave

- Achieve a task by breaking it down into smaller tasks and solving them one by one

## Task 1: Create an interactive button

Use GitHub Copilot to create an Add Plane button component with the following requirements:

- Create a button that is in the same style as the Planes List component
- Button text is "Add Plane"
- Add a plus icon left of the text
- Spacing on the top and bottom of the button
- Include appropriate visual states (hover, active)
- The button respects the accessibility guidelines

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- Use `#file` to reference the `PlaneList.tsx` component to make GitHub Copilot understand the style of the button

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Ask GitHub Copilot to create a button component with appropriate interactive states (hover, active) that matches the existing design style:

  ```
  Create a button component in the same style as #file:PlaneList.tsx with text "Add Plane",
  a plus icon on the left, hover and active states, and accessibility support.
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 3</summary>

- Ask GitHub Copilot to add the button component to the homepage of the application:

  ```
  Add the AddPlaneButton component to the homepage below the Banner component.
  ```

</details>

---

<br/>

**Expert solutions**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<br/>

<details>
  <summary>Click to open Expert Solution 1</summary>

<br/>

- Open GitHub Copilot Chat (Agent Mode) and enter the following prompt:

  ```
  Create a button component and route the button to the add new plane page

  - Create a button that is in the same style as #file:PlaneList.tsx
  - Button text is "Add Plane"
  - Add a plus icon left of the text
  - Spacing on the top and bottom of the button
  - The button respects the accessibility guidelines
  ```

- GitHub Copilot will suggest to create a button component with appropriate interactive states (hover, focus, etc.):

  ```tsx
  import React from "react";
  import { useNavigate } from "react-router-dom";

  const AddPlaneButton: React.FC = () => {
    const navigate = useNavigate();

    const handleClick = () => {
      navigate("/add-plane");
    };

    return (
      <button
        onClick={handleClick}
        className="flex items-center justify-center bg-amber-100 text-amber-900 font-serif text-lg leading-6 rounded-lg shadow-lg py-2 px-4 mt-4 mb-4 hover:bg-amber-200 focus:outline-none focus:ring-2 focus:ring-amber-500"
        aria-label="Add Plane"
      >
        <span className="mr-2">+</span>
        Add Plane
      </button>
    );
  };

  export default AddPlaneButton;
  ```

- Create a new file `AddPlaneButton.tsx` in the `wright-brothers-frontend/src/components` folder and paste the generated code

- Open the `HomePage.tsx` component and import the `AddPlaneButton` component

  ```tsx
  import Banner from "../components/Banner";
  import PlaneList from "../components/PlaneList";
  import PageContent from "../components/PageContent";
  import AddPlaneButton from "../components/AddPlaneButton";

  function HomePage() {
    const planes = [
      // List of planes
    ];

    return (
      <div>
        <Banner />
        <PageContent>
          <AddPlaneButton />
          <PlaneList planes={planes} />
        </PageContent>
      </div>
    );
  }

  export default HomePage;
  ```


- Open the browser and check if the button component is displayed correctly

- Hover over the button to check if the button is elevated when hovered

- Make the button disabled and check if the button is grayed out and not interactable

  ```tsx
  <AddPlaneButton disabled />
  ```

</details>

<br/>

<details>
  <summary>Click to open Expert Solution 2</summary>

<br/>

- Use Copilot Agent mode with the following prompt:

    ```
    Create a new button component called AddPlaneButton and route the button to the "/add-plane" page

    ## Design
    - Create new component named "AddPlaneButton.tsx" in the src/components folder.
    - Create a button that is in the same style as #file:PlaneList.tsx
    - Button text is "Add Plane"
    - Add a plus icon left of the text
    - Spacing on the top and bottom of the button
    - Elevate the button when hovered
    - Update the HomePage.tsx file by adding the following:
      - a new import statement near the top of the file to import the AddPlaneButton component.
      - Add the AddPlaneButton component below the Banner component inside the PageContent component.

    ## Technical Requirements
    - Create a new button component
    - use "@heroicons/react/24/solid" for the plus icon
    ```

- Review the proposed changes and accept them to complete the task.

</details>

---

<br/>

## Task 2: Create an Add Plane Form

Create a new page for adding a new plane to the application:

- The page should contain a form to add a new plane.
- The form should contain validation and the user should be able to submit the form.
- The page should be styled to match the design of the application.

---

**Hints**

Below you can find hints that can help you to solve the task at hand.

<details>
  <summary>Click to open Hint 1</summary>

- This single task is too much to ask GitHub Copilot to generate in one go. Break it down into smaller tasks and solve them one by one.

- First, ask GitHub Copilot to create a new empty page for adding a new plane and make it accessible via the /add-plane route:

  ```
  Create a new empty page for adding a new plane and make it accessible via the /add-plane route. #file:App.tsx
  ```

</details>

<br/>

<details>
  <summary>Click to open Hint 2</summary>

- Follow the instructions of GitHub Copilot to create the new page accessible via the /add-plane route

- Make sure to run the frontend application and check if the new page is accessible via the /add-plane route

</details>

<br/>

<details>
  <summary>Click to open Hint 3</summary>

- After adding the empty page, ask GitHub Copilot to create a form in the add plane page. The form fields are based on the plane model. Also include validation and submit button:

  ```
  Create a form in AddPlanePage.tsx based on the plane model for a POST to http://localhost:1903/planes.
  Include validation and a submit button. #file:Plane.ts
  ```

</details>

---

**Expert solutions**

Below you can find the solution to the task. The expert solution is a step-by-step guide on how the expert would solve the task.

<details>
  <summary>Click to open Expert Solution 1</summary>

<br/>

- Important: break the task into smaller steps.

- Start by creating an empty page for adding a new plane and making it accessible via the /add-plane route.

- Open GitHub Copilot Chat (Agent Mode) and enter:

  ```
  Create a new empty page for adding a new plane and make it accessible via the /add-plane route. #file:App.tsx
  ```

- GitHub Copilot will provide a step-by-step guide on how to create the new page accessible via the /add-plane route:

  1. Create the New Page Component: Create a new file named `AddPlanePage.tsx` in the wright-brothers-frontend/src/pages/ directory. This file will contain the component for the new page.

  2. Implement the AddPlanePage Component: In the AddPlanePage.tsx file, implement the basic structure of the page component.

     ```tsx
     // File: wright-brothers-frontend/src/pages/AddPlanePage.tsx

     import React from "react";

     function AddPlanePage() {
       return (
         <div>
           <h1>Add New Plane</h1>
           {/* Add form and necessary components here */}
         </div>
       );
     }

     export default AddPlanePage;
     ```

     3. Update the App Component to Include the New Route: Modify the App.tsx file to include a new route for the /add-plane path that renders the AddPlanePage component.

     ```tsx
     // Update in App.tsx

     import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
     import HomePage from "./pages/HomePage";
     import PlaneDetail from "./pages/PlaneDetail";
     import AddPlanePage from "./pages/AddPlanePage"; // Import the new page component

     function App() {
       return (
         <Router>
           <Routes>
             <Route path="/" element={<HomePage />} />
             <Route path="/planes/:planeId" element={<PlaneDetail />} />
             <Route path="/add-plane" element={<AddPlanePage />} />{" "}
             {/* Add this line */}
           </Routes>
         </Router>
       );
     }

     export default App;
     ```

- Now, run the frontend application and navigate to the /add-plane route to check if the new page is accessible via the /add-plane route

- Ask GitHub Copilot to create a form in the add plane page. The form fields are based on the plane model. Also include validation and submit button

  ```
  Create a form in the add plane page. The form fields are based on #file:Plane.ts model. Validate the form fields and display the error messages below the input fields. On submit, POST the form data to http://localhost:1903/planes and redirect to the home page on success.
  ```

- Make sure to reference `#file:Plane.ts` in the prompt. This tells GitHub Copilot to use the plane model defined in the `Plane.ts` file to generate the form fields.

- GitHub Copilot will suggest to create a form in the `AddPlanePage.tsx` file based on the plane model:

  ```tsx
  import React, { useState } from "react";

  interface PlaneFormState {
    id: number;
    name: string;
    year: number;
    description: string;
    rangeInKm: number;
  }

  const initialFormState: PlaneFormState = {
    id: 0,
    name: "",
    year: new Date().getFullYear(),
    description: "",
    rangeInKm: 0,
  };

  function AddPlanePage() {
    const [formState, setFormState] =
      useState<PlaneFormState>(initialFormState);
    const [formErrors, setFormErrors] = useState<PlaneFormState>({
      id: 0,
      name: "",
      year: 0,
      description: "",
      rangeInKm: 0,
    });

    const validateForm = () => {
      const errors: PlaneFormState = {
        id: 0,
        name: "",
        year: 0,
        description: "",
        rangeInKm: 0,
      };
      let isValid = true;

      if (!formState.name) {
        errors.name = "Name is required";
        isValid = false;
      }
      if (formState.year < 1900 || formState.year > new Date().getFullYear()) {
        errors.year = "Year must be between 1900 and the current year";
        isValid = false;
      }
      if (!formState.description) {
        errors.description = "Description is required";
        isValid = false;
      }
      if (formState.rangeInKm <= 0) {
        errors.rangeInKm = "Range must be greater than 0";
        isValid = false;
      }

      setFormErrors(errors);
      return isValid;
    };

    const handleChange = (
      e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
    ) => {
      const { name, value } = e.target;
      setFormState({
        ...formState,
        [name]:
          name === "year" || name === "rangeInKm" ? parseInt(value) : value,
      });
    };

    const handleSubmit = (e: React.FormEvent) => {
      e.preventDefault();
      if (validateForm()) {
        console.log("Form is valid, submitted:", formState);
        // Placeholder for submit logic
      } else {
        console.log("Form is invalid:", formErrors);
      }
    };

    return (
      <div>
        <h1>Add New Plane</h1>
        <form onSubmit={handleSubmit}>
          {/* Form fields */}
          <div>
            <label htmlFor="name">Name:</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formState.name}
              onChange={handleChange}
              required
            />
            {formErrors.name && (
              <div style={{ color: "red" }}>{formErrors.name}</div>
            )}
          </div>
          <div>
            <label htmlFor="year">Year:</label>
            <input
              type="number"
              id="year"
              name="year"
              value={formState.year}
              onChange={handleChange}
              required
            />
            {formErrors.year && (
              <div style={{ color: "red" }}>{formErrors.year}</div>
            )}
          </div>
          <div>
            <label htmlFor="description">Description:</label>
            <textarea
              id="description"
              name="description"
              value={formState.description}
              onChange={handleChange}
              required
            />
            {formErrors.description && (
              <div style={{ color: "red" }}>{formErrors.description}</div>
            )}
          </div>
          <div>
            <label htmlFor="rangeInKm">Range (in Km):</label>
            <input
              type="number"
              id="rangeInKm"
              name="rangeInKm"
              value={formState.rangeInKm}
              onChange={handleChange}
              required
            />
            {formErrors.rangeInKm && (
              <div style={{ color: "red" }}>{formErrors.rangeInKm}</div>
            )}
          </div>
          <button type="submit">Submit</button>
        </form>
      </div>
    );
  }

  export default AddPlanePage;
  ```

- Replace the content of the `AddPlanePage.tsx` file with the generated code

- Run the frontend application and navigate to the /add-plane route to check if the new page is accessible via the /add-plane route

- Check if the form is displayed correctly and if the validation works as expected by filling in the form fields

- Lastly, style the form to match the design of the `PlaneList.tsx` component

  ```
  Give me the styled html for the add plane form to match the design of the #file:PlaneList.tsx component
  ```

- Sometimes Copilot does not generate the complete form. In that case, try to ask Copilot to generate the form again.

- GitHub Copilot will suggest to style the form to match the design of the `PlaneList.tsx` component:

  ```tsx
  function AddPlanePage() {
    // Form state and validation logic
    return (
      <div className="flex flex-col items-center p-8 bg-amber-100 rounded-lg shadow-lg">
        <h1 className="text-amber-900 text-2xl leading-6 font-serif mb-4">
          Add New Plane
        </h1>
        <form onSubmit={handleSubmit} className="w-full max-w-lg">
          <div className="mb-4">
            <label htmlFor="name" className="block text-amber-900 font-serif">
              Name:
            </label>
            <input
              type="text"
              id="name"
              name="name"
              value={formState.name}
              onChange={handleChange}
              required
              className="mt-1 p-2 w-full rounded-md border-amber-200"
            />
            {formErrors.name && (
              <div style={{ color: "red" }}>{formErrors.name}</div>
            )}
          </div>
          <div className="mb-4">
            <label htmlFor="year" className="block text-amber-900 font-serif">
              Year:
            </label>
            <input
              type="number"
              id="year"
              name="year"
              value={formState.year}
              onChange={handleChange}
              required
              className="mt-1 p-2 w-full rounded-md border-amber-200"
            />
            {formErrors.year && (
              <div style={{ color: "red" }}>{formErrors.year}</div>
            )}
          </div>
          <div className="mb-4">
            <label
              htmlFor="description"
              className="block text-amber-900 font-serif"
            >
              Description:
            </label>
            <textarea
              id="description"
              name="description"
              value={formState.description}
              onChange={handleChange}
              required
              className="mt-1 p-2 w-full rounded-md border-amber-200"
            />
            {formErrors.description && (
              <div style={{ color: "red" }}>{formErrors.description}</div>
            )}
          </div>
          <div className="mb-4">
            <label
              htmlFor="rangeInKm"
              className="block text-amber-900 font-serif"
            >
              Range (in Km):
            </label>
            <input
              type="number"
              id="rangeInKm"
              name="rangeInKm"
              value={formState.rangeInKm}
              onChange={handleChange}
              required
              className="mt-1 p-2 w-full rounded-md border-amber-200"
            />
            {formErrors.rangeInKm && (
              <div style={{ color: "red" }}>{formErrors.rangeInKm}</div>
            )}
          </div>
          <button
            type="submit"
            className="px-4 py-2 bg-amber-900 text-white rounded-md hover:bg-amber-800"
          >
            Submit
          </button>
        </form>
      </div>
    );
  }
  ```

- Replace the HTML content of the `AddPlanePage.tsx` file with the generated code

- Run the frontend application to check if the form is styled to match the design of the `PlaneList.tsx` component

</details>

---

<details>
  <summary>Click to open Expert Solution 2</summary>

- Use Copilot Agent mode with the following prompt:

    ```
    Create a form in the AddPlanePage.tsx file based on the plane model for a POST to http://localhost:1903/planes
    
    ## Design
    - New input fields should be in file AddPlanePage.tsx
    - Apply tailwind classes to match the design of #file:PlaneList.tsx
    - Every input should have a label

    ## Technical Requirements

    - Create all the fields based on file #file:Plane.cs
    - Use Formik for form handling
    - Use Yup for validations
    - Every input should have an ID
    - Redirect back to the home page after successful submission
    - Give me a complete solution. Do not skip any form fields.

    ```

- Review the proposed changes and accept them to complete the task.

</details>

<br/>

---

<br/>

## Optional - Bonus Tasks

> [!CAUTION]
> Please be aware that this challenge does not include guardrails or provided solutions. You are encouraged to navigate and solve the tasks independently, which will help enhance your problem-solving skills and deepen your understanding of the frameworks and technologies involved.

1. Add a new feature to the frontend application that allows users to delete a plane from the application

2. Add a new feature to the frontend application that allows users to edit a plane in the application

3. Add a new feature to the frontend application that allows users to view the details of a plane

4. Any other features you would like to add to the frontend application


### Congratulations you've made it to the end! &#9992;

#### And with that, you've now concluded this module. We hope you enjoyed it! &#x1F60A;

---

➡️ Continue to [Lab 4.1 • Pipeline Automation](../Lab%204.1%20-%20Pipeline%20Automation/README.md)
