import { useEffect, useState } from "react";
import Banner from "../components/Banner";
import PlaneList from "../components/PlaneList";
import PageContent from "../components/PageContent";
import AddPlaneButton from "../components/AddPlaneButton";
import PlaneService from "../services/PlaneService";

function HomePage() {
  const [planes, setPlanes] = useState<{ id: number; name: string; year: number }[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setLoading(true);
    setError(null);
    PlaneService.getPlanes()
      .then((response) => {
        setPlanes(response.data);
      })
      .catch((err) => {
        console.error("Failed to fetch planes:", err);
        setError("Could not load planes. Is the backend running on http://localhost:1903?");
        setPlanes([]);
      })
      .finally(() => setLoading(false));
  }, []);

  return (
    <div>
      <Banner />
      <PageContent>
        <AddPlaneButton />
        {loading && <p className="text-amber-700 font-serif mt-4">Loading planes...</p>}
        {error && <p className="text-red-600 font-serif mt-4">{error}</p>}
        {!loading && !error && <PlaneList planes={planes} />}
      </PageContent>
    </div>
  );
}

export default HomePage;
