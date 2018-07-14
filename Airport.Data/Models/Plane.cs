using System;

namespace Airport.Data.Models
{
  public class Plane : Entity
  {
    public string Name { get; set; }
    public int PlaneTypeId { get; set; }
    public DateTime ReleaseDate { get; set; }
    public TimeSpan ServiceLife { get; set; }

    public PlaneType PlaneType { get; set; }

  }
}