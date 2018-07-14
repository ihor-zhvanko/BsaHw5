using System;

namespace Airport.BusinessLogic.Models
{
  public class TicketDetails
  {
    public int Id { get; set; }
    public double Price { get; set; }
    public FlightModel Flight { get; set; }

    public static TicketDetails Create(TicketModel ticket, FlightModel flight)
    {
      return new TicketDetails
      {
        Id = ticket.Id,
        Price = ticket.Price,
        Flight = flight
      };
    }
  }
}