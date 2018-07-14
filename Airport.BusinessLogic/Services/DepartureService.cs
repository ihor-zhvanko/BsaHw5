using System;
using System.Linq;
using System.Collections.Generic;
using Airport.BusinessLogic.Models;

using Airport.Data.Models;
using Airport.Data.UnitOfWork;

using AutoMapper;

namespace Airport.BusinessLogic.Services
{
  public interface IDepartureService : IService<DepartureModel>
  {
    IList<DepartureDetails> GetAllDetails();
    DepartureDetails GetDetails(int id);
    IList<DepartureModel> GetByCrewId(int crewId);
  }

  public class DepartureService : BaseService<DepartureModel, Departure>, IDepartureService
  {
    IFlightService _flightService;
    ICrewService _crewService;
    IPlaneService _planeService;

    public DepartureService(
      IUnitOfWork unitOfWork,
      IFlightService flightService,
      ICrewService crewService,
      IPlaneService planeService
      )
      : base(unitOfWork)
    {
      _flightService = flightService;
      _crewService = crewService;
      _planeService = planeService;
    }

    public IList<DepartureDetails> GetAllDetails()
    {
      var depatures = GetAll();
      var flights = _flightService.GetAll();
      var crews = _crewService.GetAllDetails();
      var planes = _planeService.GetAllDetails();

      var joined = from departure in depatures
                   join flight in flights on departure.FlightId equals flight.Id
                   join crew in crews on departure.CrewId equals crew.Id
                   join plane in planes on departure.PlaneId equals plane.Id
                   select DepartureDetails.Create(departure, flight, plane, crew);

      return joined.ToList();
    }

    public DepartureDetails GetDetails(int id)
    {
      var departure = GetById(id);
      var flight = _flightService.GetById(departure.FlightId);
      var crew = _crewService.GetDetails(departure.CrewId);
      var plane = _planeService.GetDetails(departure.PlaneId);

      return DepartureDetails.Create(departure, flight, plane, crew);
    }

    public IList<DepartureModel> GetByCrewId(int crewId)
    {
      var departures = _unitOfWork.Set<Departure>().Get(x => x.CrewId == crewId).ToList();
      return Mapper.Map<IList<DepartureModel>>(departures);
    }
  }
}
