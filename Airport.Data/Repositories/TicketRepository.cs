using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Airport.Common.Exceptions;

using Airport.Data.MockData;
using Airport.Data.Models;
using Airport.Data.DatabaseContext;

namespace Airport.Data.Repositories
{
  public class TicketRepository : Repository<Ticket>, IRepository<Ticket>
  {
    private AirportDbContext _dbContext;
    public TicketRepository(AirportDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public override IEnumerable<Ticket> Details(Expression<Func<Ticket, bool>> filter = null)
    {
      var tickets = _dbContext.Ticket.Include(x => x.Flight);
      if (filter != null)
        return tickets.Where(filter);

      return tickets;
    }
  }
}