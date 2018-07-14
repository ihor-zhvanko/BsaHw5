using System;
using Microsoft.EntityFrameworkCore;

using Airport.Data.Models;

namespace Airport.Data.DatabaseContext
{
  public class AirportDbContext : DbContext
  {
    public DbSet<Airhostess> Airhostesses { get; set; }
    public DbSet<Crew> Crews { get; set; }
    public DbSet<Departure> Departures { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Pilot> Pilots { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<PlaneType> PlaneTypes { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public AirportDbContext(DbContextOptions<AirportDbContext> options)
      : base(options)
    {
      Database.EnsureCreated();
    }
  }
}