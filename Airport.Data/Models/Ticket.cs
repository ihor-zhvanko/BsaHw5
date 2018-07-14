using System;

namespace Airport.Data.Models
{
  public class Ticket : Entity
  {
    public double Price { get; set; }
    public int FlightId { get; set; }

    public Flight Flight { get; set; }
  }
}