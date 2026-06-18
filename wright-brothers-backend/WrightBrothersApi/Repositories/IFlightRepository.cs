namespace WrightBrothersApi.Repositories
{
    public interface IFlightRepository
    {
        List<Flight> GetAllFlights();

        Flight GetFlightById(int id);

        Flight AddFlight(Flight flight);

        Flight UpdateFlight(Flight flight);
    }
}