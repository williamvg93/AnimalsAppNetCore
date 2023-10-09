using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Entities.Person;
using Core.Entities.Pets;
using Core.Entities.ProvidedServices;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data;

public class AnimalsContext : DbContext
{
    public AnimalsContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientAddress> ClientAddresses { get; set; }
    public DbSet<ClientContact> ClientContacts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<PetBred> PetBreds { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
