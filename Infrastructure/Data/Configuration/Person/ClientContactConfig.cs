using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.Person;

public class ClientContactConfig : IEntityTypeConfiguration<ClientContact>
{
    public void Configure(EntityTypeBuilder<ClientContact> builder)
    {
        /* Assign Table name */
        builder.ToTable("contact");
        /* Assign Primary Key */
        builder.HasKey(k => k.Id);

        /* Assign Colums */
        builder.Property(n => n.Number)
        .IsRequired()
        .HasMaxLength(20);

        /* Assign Foreign Key */
        builder.HasOne(f => f.Clients)
        .WithMany(f => f.ClientContacts)
        .HasForeignKey(f => f.IdClientFk);
    }
}
