import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import PlaneService from "../services/PlaneService";
import PageContent from "../components/PageContent";

interface PlaneFormState {
  name: string;
  year: number;
  description: string;
  rangeInKm: number;
}

interface FormErrors {
  name?: string;
  year?: string;
  description?: string;
  rangeInKm?: string;
}

const initialFormState: PlaneFormState = {
  name: "",
  year: new Date().getFullYear(),
  description: "",
  rangeInKm: 0,
};

function AddPlanePage() {
  const navigate = useNavigate();
  const [formState, setFormState] = useState<PlaneFormState>(initialFormState);
  const [formErrors, setFormErrors] = useState<FormErrors>({});
  const [submitting, setSubmitting] = useState(false);

  const validate = (): boolean => {
    const errors: FormErrors = {};
    if (!formState.name.trim()) errors.name = "Name is required";
    if (formState.year < 1900 || formState.year > new Date().getFullYear())
      errors.year = `Year must be between 1900 and ${new Date().getFullYear()}`;
    if (!formState.description.trim()) errors.description = "Description is required";
    if (formState.rangeInKm <= 0) errors.rangeInKm = "Range must be greater than 0";
    setFormErrors(errors);
    return Object.keys(errors).length === 0;
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormState((prev) => ({
      ...prev,
      [name]: name === "year" || name === "rangeInKm" ? parseInt(value) || 0 : value,
    }));
    setFormErrors((prev) => ({ ...prev, [name]: undefined }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!validate()) return;
    setSubmitting(true);
    try {
      await PlaneService.createPlane(formState);
      navigate("/");
    } catch {
      setFormErrors({ name: "Failed to save plane. Please try again." });
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <div>
      <div className="bg-amber-600 p-8 text-center">
        <h1 className="text-4xl font-bold text-amber-100 font-serif">Add New Plane</h1>
        <p className="text-white mt-2 text-lg">Register a new aircraft to the Wright Brothers collection</p>
      </div>
      <PageContent>
        <div className="flex flex-col items-center">
          <div className="w-full max-w-lg bg-amber-100 rounded-lg shadow-lg p-8 my-4">
            <form onSubmit={handleSubmit} noValidate>
              {/* Name */}
              <div className="mb-5">
                <label htmlFor="name" className="block text-amber-900 font-serif font-semibold mb-1">
                  Name
                </label>
                <input
                  type="text"
                  id="name"
                  name="name"
                  value={formState.name}
                  onChange={handleChange}
                  placeholder="e.g. Wright Flyer I"
                  className="w-full p-2 rounded-md border border-amber-300 bg-white text-amber-900 focus:outline-none focus:ring-2 focus:ring-amber-500"
                />
                {formErrors.name && (
                  <p className="text-red-600 text-sm mt-1">{formErrors.name}</p>
                )}
              </div>

              {/* Year */}
              <div className="mb-5">
                <label htmlFor="year" className="block text-amber-900 font-serif font-semibold mb-1">
                  Year
                </label>
                <input
                  type="number"
                  id="year"
                  name="year"
                  value={formState.year}
                  onChange={handleChange}
                  min={1900}
                  max={new Date().getFullYear()}
                  className="w-full p-2 rounded-md border border-amber-300 bg-white text-amber-900 focus:outline-none focus:ring-2 focus:ring-amber-500"
                />
                {formErrors.year && (
                  <p className="text-red-600 text-sm mt-1">{formErrors.year}</p>
                )}
              </div>

              {/* Description */}
              <div className="mb-5">
                <label htmlFor="description" className="block text-amber-900 font-serif font-semibold mb-1">
                  Description
                </label>
                <textarea
                  id="description"
                  name="description"
                  value={formState.description}
                  onChange={handleChange}
                  rows={3}
                  placeholder="Describe the aircraft..."
                  className="w-full p-2 rounded-md border border-amber-300 bg-white text-amber-900 focus:outline-none focus:ring-2 focus:ring-amber-500"
                />
                {formErrors.description && (
                  <p className="text-red-600 text-sm mt-1">{formErrors.description}</p>
                )}
              </div>

              {/* Range */}
              <div className="mb-6">
                <label htmlFor="rangeInKm" className="block text-amber-900 font-serif font-semibold mb-1">
                  Range (km)
                </label>
                <input
                  type="number"
                  id="rangeInKm"
                  name="rangeInKm"
                  value={formState.rangeInKm}
                  onChange={handleChange}
                  min={1}
                  placeholder="e.g. 120"
                  className="w-full p-2 rounded-md border border-amber-300 bg-white text-amber-900 focus:outline-none focus:ring-2 focus:ring-amber-500"
                />
                {formErrors.rangeInKm && (
                  <p className="text-red-600 text-sm mt-1">{formErrors.rangeInKm}</p>
                )}
              </div>

              {/* Buttons */}
              <div className="flex gap-3">
                <button
                  type="submit"
                  disabled={submitting}
                  className="flex-1 py-2 px-4 bg-amber-600 text-white font-serif text-lg rounded-lg shadow hover:bg-amber-700 active:bg-amber-800 focus:outline-none focus:ring-2 focus:ring-amber-500 focus:ring-offset-2 transition-colors duration-150 disabled:opacity-50 disabled:cursor-not-allowed"
                  aria-label="Submit new plane"
                >
                  {submitting ? "Saving..." : "Add Plane"}
                </button>
                <button
                  type="button"
                  onClick={() => navigate("/")}
                  className="flex-1 py-2 px-4 bg-amber-100 text-amber-900 font-serif text-lg rounded-lg shadow border border-amber-300 hover:bg-amber-200 active:bg-amber-300 focus:outline-none focus:ring-2 focus:ring-amber-500 focus:ring-offset-2 transition-colors duration-150"
                  aria-label="Cancel and go back"
                >
                  Cancel
                </button>
              </div>
            </form>
          </div>
        </div>
      </PageContent>
    </div>
  );
}

export default AddPlanePage;
