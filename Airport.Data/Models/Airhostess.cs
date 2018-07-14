using System;

namespace Airport.Data.Models
{
  public class Airhostess : Entity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int? CrewId { get; set; }
    public Crew Crew { get; set; }
  }
}