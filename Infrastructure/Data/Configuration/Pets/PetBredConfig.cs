using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.Pets;

public class PetBredConfig : IEntityTypeConfiguration<PetBred>
{
    public void Configure(EntityTypeBuilder<PetBred> builder)
    {
        /* Assign Table name */
        builder.ToTable("petbred");
        /* Assign Primary Key */
        builder.HasKey(k => k.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);
    }
}
