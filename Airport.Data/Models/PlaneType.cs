using System;

namespace Airport.Data.Models
{
  public class PlaneType : Entity
  {
    public string Model { get; set; }
    public int Seats { get; set; }
    public double Carrying { get; set; }
  }
}