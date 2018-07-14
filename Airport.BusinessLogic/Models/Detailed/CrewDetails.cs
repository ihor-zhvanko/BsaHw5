using System;
using System.Linq;
using System.Collections.Generic;

using Airport.Data.Models;

namespace Airport.BusinessLogic.Models
{
  public class CrewDetails
  {
    public int Id { get; set; }
    public PilotModel Pilot { get; set; }
    public IList<AirhostessModel> Airhostesses { get; set; }

    public static CrewDetails Create(CrewModel crew, PilotModel pilot, IEnumerable<AirhostessModel> airhostesses)
    {
      return new CrewDetails
      {
        Id = crew.Id,
        Pilot = pilot,
        Airhostesses = airhostesses.ToList()
      };
    }
  }
}