using System;

namespace Airport.Data.Models
{
  public class Departure : Entity
  {
    public int FlightId { get; set; }
    public DateTime Date { get; set; }
    public int CrewId { get; set; }
    public int PlaneId { get; set; }

    public Flight Flight { get; set; }
    public Crew Crew { get; set; }
    public Plane Plane { get; set; }
  }
}