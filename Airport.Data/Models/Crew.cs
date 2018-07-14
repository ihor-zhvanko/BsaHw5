using System;
using System.Collections.Generic;

namespace Airport.Data.Models
{
  public class Crew : Entity
  {
    public int PilotId { get; set; }
    public IList<Airhostess> Airhostesses { get; set; }
  }
}