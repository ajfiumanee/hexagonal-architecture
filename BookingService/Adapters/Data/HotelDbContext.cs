using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
}