import React from "react";
import { useNavigate } from "react-router-dom";

interface AddPlaneButtonProps {
  disabled?: boolean;
}

const AddPlaneButton: React.FC<AddPlaneButtonProps> = ({ disabled = false }) => {
  const navigate = useNavigate();

  const handleClick = () => {
    if (!disabled) navigate("/add-plane");
  };

  return (
    <button
      onClick={handleClick}
      disabled={disabled}
      className="flex items-center justify-center bg-amber-100 text-amber-900 font-serif text-lg leading-6 rounded-lg shadow-lg py-3 px-6 my-4 hover:bg-amber-200 active:bg-amber-300 active:shadow-inner focus:outline-none focus:ring-2 focus:ring-amber-500 focus:ring-offset-2 transition-colors duration-150 disabled:opacity-50 disabled:cursor-not-allowed disabled:hover:bg-amber-100 disabled:active:bg-amber-100"
      aria-label="Add Plane"
    >
      <span className="mr-2 text-xl font-bold" aria-hidden="true">+</span>
      Add Plane
    </button>
  );
};

export default AddPlaneButton;
