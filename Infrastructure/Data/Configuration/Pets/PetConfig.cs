using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.Pets;

public class PetConfig : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        /* Assign Table name */
        builder.ToTable("pet");
        /* Assign Primary Key */
        builder.HasKey(k => k.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(bd => bd.BirthDate)
        .HasColumnType("datetime");

        /* Assign Foreign Key */
        builder.HasOne(f => f.Clients)
        .WithMany(f => f.Pets)
        .HasForeignKey(f => f.IdClientFk);

        builder.HasOne(f => f.PetBreds)
        .WithMany(f => f.Pets)
        .HasForeignKey(f => f.IdPetBredFk);
    }
}
