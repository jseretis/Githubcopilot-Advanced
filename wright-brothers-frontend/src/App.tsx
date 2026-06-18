import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import HomePage from "./pages/HomePage"; // Import your page components
import PlaneDetail from "./pages/PlaneDetail";
import AddPlanePage from "./pages/AddPlanePage";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/planes/:planeId" element={<PlaneDetail />} />
        <Route path="/add-plane" element={<AddPlanePage />} />
      </Routes>
    </Router>
  );
}

export default App;
