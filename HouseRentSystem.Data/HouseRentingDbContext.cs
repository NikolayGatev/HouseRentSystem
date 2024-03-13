namespace HouseRentSystem.Data;

using HouseRentSystem.Data.Models;
using HouseRentSystem.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class HouseRentingDbContext : IdentityDbContext
{
    public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new AgentConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new HouseConfiguration());

        base.OnModelCreating(builder);
    }

    public DbSet<Agent> Agents { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<House> Hauses { get; set; }
}
