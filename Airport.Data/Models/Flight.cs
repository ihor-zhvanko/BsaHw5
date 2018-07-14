using System;

namespace Airport.Data.Models
{
  public class Flight : Entity
  {
    public string Number { get; set; }
    public string DeparturePlace { get; set; }
    public DateTime DepartureTime { get; set; }
    public string ArrivalPlace { get; set; }
    public DateTime ArrivalTime { get; set; }
  }
}