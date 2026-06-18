import React from "react";

const RemovePlaneButton: React.FC = () => {
  const handleClick = () => {
    // Navigate or trigger remove logic
  };

  return (
    <button
      onClick={handleClick}
      className="flex items-center justify-center bg-amber-100 text-amber-900 font-serif text-lg leading-6 rounded-lg shadow-lg py-3 px-6 my-4 hover:bg-amber-200 active:bg-amber-300 active:shadow-inner focus:outline-none focus:ring-2 focus:ring-amber-500 focus:ring-offset-2 transition-colors duration-150"
      aria-label="Remove Plane"
    >
      <span className="mr-2 text-xl font-bold" aria-hidden="true">−</span>
      Remove Plane
    </button>
  );
};

export default RemovePlaneButton;
