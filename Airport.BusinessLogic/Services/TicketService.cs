using System;
using System.Linq;
using System.Collections.Generic;
using Airport.BusinessLogic.Models;

using Airport.Data.Models;
using Airport.Data.UnitOfWork;

using AutoMapper;

namespace Airport.BusinessLogic.Services
{
  public interface ITicketService : IService<TicketModel>
  {
    IList<TicketDetails> GetAllDetails();
    TicketDetails GetDetails(int id);
  }

  public class TicketService : BaseService<TicketModel, Ticket>, ITicketService
  {
    IFlightService _flightService;
    public TicketService(
      IUnitOfWork unitOfWork,
      IFlightService flightService
    )
      : base(unitOfWork)
    {
      _flightService = flightService;
    }

    public IList<TicketDetails> GetAllDetails()
    {
      var tickets = GetAll();
      var flights = _flightService.GetAll();

      var joined = from ticket in tickets
                   join flight in flights
                    on ticket.FlightId equals flight.Id
                   select TicketDetails.Create(ticket, flight);

      return joined.ToList();
    }

    public TicketDetails GetDetails(int id)
    {
      var ticket = GetById(id);
      var flight = _flightService.GetById(ticket.FlightId);

      return TicketDetails.Create(ticket, flight);
    }
  }
}