using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.Person;

public class ClientAddressConfig : IEntityTypeConfiguration<ClientAddress>
{
    public void Configure(EntityTypeBuilder<ClientAddress> builder)
    {
        /* Assign Table name */
        builder.ToTable("address");
        /* Assign Primary Key */
        builder.HasKey(k => k.Id);
        /* Assign Colums */
        builder.Property(r => r.TypeRoad)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(fn => fn.FirstNumber)
        .HasColumnType("int");

        builder.Property(fl => fl.FirstLetter)
        .IsRequired()
        .HasMaxLength(1);

        builder.Property(b => b.Bis)
        .IsRequired()
        .HasMaxLength(3);

        builder.Property(sl => sl.SecondLetter)
        .IsRequired()
        .HasMaxLength(2);

        builder.Property(c => c.Cardinal)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(sn => sn.SecondNumber)
        .HasColumnType("int");

        builder.Property(tl => tl.ThirdLetter)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(tn => tn.ThirdNumber)
        .HasColumnType("int");

        builder.Property(sc => sc.SecondCardinal)
        .IsRequired()
        .HasMaxLength(10);

        builder.Property(com => com.Complement)
        .HasMaxLength(50);

        builder.Property(pos => pos.PostalCode)
        .HasMaxLength(10);

        /* Assign Foreign Key */
        builder.HasOne(f => f.Clients)
        .WithOne(f => f.ClientAddresses)
        .HasForeignKey<ClientAddress>(f => f.IdClientFk);

        /* Assign Foreign Key */
        builder.HasOne(f => f.Cities)
        .WithOne(f => f.ClientAddresses)
        .HasForeignKey<ClientAddress>(f => f.IdCityFk);
    }
}