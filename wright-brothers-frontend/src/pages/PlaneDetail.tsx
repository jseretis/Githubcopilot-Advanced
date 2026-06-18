import { useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import gsap from "gsap";
import MotionPathPlugin from "gsap/MotionPathPlugin";
import PlaneService from "../services/PlaneService";
import FlightService from "../services/FlightService";
import PageContent from "../components/PageContent";
import FlightDetails from "../components/FlightDetails";
import Card from "../components/Card";
import PlaneSpinner from "../components/PlaneSpinner";

gsap.registerPlugin(MotionPathPlugin);

const PlaneDetail = () => {
  const { planeId } = useParams();
  const [crashed, setCrashed] = useState(false);
  const [landed, setLanded] = useState(false);
  const hasRunEffect = useRef(false);

  const [planeDetails, setPlaneDetails] = useState<any>(null);
  const [flightDetails, setFlightDetails] = useState<any>({});
  const [planeError, setPlaneError] = useState<string | null>(null);
  const [planeLoading, setPlaneLoading] = useState(true);
  useEffect(() => {
    setPlaneLoading(true);
    setPlaneError(null);
    async function getPlaneDetails() {
      try {
        const response = await PlaneService.getPlaneById(planeId as string);
        setPlaneDetails(response.data);
      } catch (error) {
        console.error("Failed to load plane details:", error);
        setPlaneError("Could not load plane details. Make sure the backend is running at http://localhost:1903.");
      } finally {
        setPlaneLoading(false);
      }
    }
    async function getFlightDetails() {
      try {
        const response = await FlightService.getFlightById(planeId as string);
        setFlightDetails(response.data);
      } catch (error) {
        console.error("Failed to load flight details:", error);
      }
    }
    getPlaneDetails();
    getFlightDetails();
  }, [planeId]);

  useEffect(() => {
    if (hasRunEffect.current == true) {
      return;
    }
    hasRunEffect.current = true;

    FlightService.calculateAerodynamics(planeId as string)
      .then(() => {
        setTimeout(() => {
          setLanded(true); // Simulate safe landing
        });
      })
      .catch(() => {
        setTimeout(() => {
          setCrashed(true); // Simulate crash
        });
      });
  }, [planeId]);

  if (planeLoading)
    return <PageContent><div className="text-amber-900 text-xl p-8">Loading plane details...</div></PageContent>;

  if (planeError)
    return <PageContent><div className="text-red-600 text-xl p-8">{planeError}</div></PageContent>;

  if (!planeDetails)
    return <PageContent><div className="text-amber-900 text-xl p-8">Plane not found.</div></PageContent>;

  return (
    <PageContent>
      <div className="max-w-screen-xl mx-auto px-4 sm:px-6 lg:px-8">
        <h2 className="text-3xl font-bold text-amber-900">
          {planeDetails.name}
        </h2>
        <p className="text-xl text-amber-800">{planeDetails.year}</p>
        <p className="mt-4 mb-8 text-amber-700">
          {planeDetails.description}
        </p>
        <h3 className="text-2xl text-amber-900 mb-4">
          Flight Details
        </h3>
        <div className="relative w-2/3">
          <Card>
            <div className="min-h-96">
              <PlaneSpinner
                isError={crashed}
                isLoading={!landed && !crashed}
                isSuccess={landed}
              />
              {landed && flightDetails?.flightNumber && (
                <FlightDetails flight={flightDetails} />
              )}
              {landed && !flightDetails?.flightNumber && (
                <p className="text-amber-700 font-serif mt-4">No flight data available for this plane.</p>
              )}
            </div>
          </Card>
        </div>
      </div>
    </PageContent>
  );
};

export default PlaneDetail;
