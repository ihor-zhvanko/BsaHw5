using System;

namespace Airport.Data.Models
{
  public class Pilot : Entity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public double Experience { get; set; }
  }
}