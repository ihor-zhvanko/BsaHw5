using System;

namespace Airport.BusinessLogic.Models
{
  public class DepartureDetails
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public FlightModel Flight { get; set; }
    public PlaneDetails Plane { get; set; }
    public CrewDetails Crew { get; set; }

    public static DepartureDetails Create(
      DepartureModel depature, FlightModel flight, PlaneDetails plane, CrewDetails crew
    )
    {
      return new DepartureDetails
      {
        Id = depature.Id,
        Date = depature.Date,
        Flight = flight,
        Plane = plane,
        Crew = crew
      };
    }

  }
}