using System;
using System.Linq;
using System.Collections.Generic;
using Airport.BusinessLogic.Models;

using Airport.Data.Models;
using Airport.Data.UnitOfWork;

using AutoMapper;

namespace Airport.BusinessLogic.Services
{
  public interface ICrewService : IService<CrewModel>
  {
    IList<CrewDetails> GetAllDetails();
    CrewDetails GetDetails(int id);
  }

  public class CrewService : BaseService<CrewModel, Crew>, ICrewService
  {
    IPilotService _pilotService;
    IAirhostessService _airhostessService;

    public CrewService(
      IUnitOfWork unitOfWork,
      IPilotService pilotService,
      IAirhostessService airhostessService
    )
      : base(unitOfWork)
    {
      this._pilotService = pilotService;
      this._airhostessService = airhostessService;
    }

    public IList<CrewDetails> GetAllDetails()
    {
      var crews = GetAll();
      var pilots = _pilotService.GetAll();
      var airhostesses = _airhostessService.GetAll();

      var joined = from crew in crews
                   join pilot in pilots on crew.PilotId equals pilot.Id
                   join airhostess in airhostesses
                     on crew.Id equals airhostess.CrewId into crewAirhostesses
                   select CrewDetails.Create(crew, pilot, crewAirhostesses);

      return joined.ToList();
    }

    public CrewDetails GetDetails(int id)
    {
      var crew = GetById(id);
      var pilot = _pilotService.GetById(crew.PilotId);
      var airhostesses = _airhostessService.GetByCrewId(id);

      return CrewDetails.Create(crew, pilot, airhostesses);
    }
  }
}