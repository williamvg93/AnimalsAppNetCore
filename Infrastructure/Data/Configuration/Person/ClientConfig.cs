using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.Person;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        /* Assign Table name */
        builder.ToTable("client");
        /* Assign Primary Key */
        builder.HasKey(k => k.Id);

        /* Assign Colums */
        builder.Property(n => n.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(ln => ln.LastName)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Email)
        .IsRequired()
        .HasMaxLength(50);

    }
}
