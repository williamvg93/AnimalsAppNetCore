using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.ProvidedServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.ProvidedServices;

public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        /* Assign Table name */
        builder.ToTable("appointment");
        /* Assign Primary Key */
        builder.HasKey(k => k.Id);

        /* Assign Colums */
        builder.Property(d => d.Date)
        .HasColumnType("datetime");

        builder.Property(d => d.Time)
        .HasColumnType("time");

        /* Assign Foreign Key */
        builder.HasOne(f => f.Clients)
        .WithMany(f => f.Appointments)
        .HasForeignKey(f => f.IdClientFk);

        builder.HasOne(f => f.Pets)
        .WithMany(f => f.Appointments)
        .HasForeignKey(f => f.IdPetFk);

        builder.HasOne(f => f.Services)
        .WithMany(f => f.Appointments)
        .HasForeignKey(f => f.IdServiceFk);

    }
}
