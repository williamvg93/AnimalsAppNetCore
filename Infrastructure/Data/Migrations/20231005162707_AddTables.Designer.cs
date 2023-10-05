﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AnimalsContext))]
    [Migration("20231005162707_AddTables")]
    partial class AddTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Location.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartFk");

                    b.ToTable("city", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Location.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("country", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Location.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCountryFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountryFk");

                    b.ToTable("department", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Person.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("client", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Person.ClientAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bis")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Cardinal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Complement")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstLetter")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<int>("FirstNumber")
                        .HasColumnType("int");

                    b.Property<int>("IdCityFk")
                        .HasColumnType("int");

                    b.Property<int>("IdClientFk")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SecondCardinal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("SecondLetter")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<int>("SecondNumber")
                        .HasColumnType("int");

                    b.Property<string>("ThirdLetter")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("ThirdNumber")
                        .HasColumnType("int");

                    b.Property<string>("TypeRoad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCityFk")
                        .IsUnique();

                    b.HasIndex("IdClientFk")
                        .IsUnique();

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Person.ClientContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdClientFk")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdClientFk");

                    b.ToTable("contact", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pets.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdClientFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPetBredFk")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdClientFk");

                    b.HasIndex("IdPetBredFk");

                    b.ToTable("pet", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pets.PetBred", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("petbred", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProvidedServices.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("IdClientFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPetFk")
                        .HasColumnType("int");

                    b.Property<int>("IdServiceFk")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("IdClientFk");

                    b.HasIndex("IdPetFk");

                    b.HasIndex("IdServiceFk");

                    b.ToTable("appointment", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProvidedServices.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("service", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Location.City", b =>
                {
                    b.HasOne("Core.Entities.Location.Department", "Departments")
                        .WithMany("Cities")
                        .HasForeignKey("IdDepartFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Core.Entities.Location.Department", b =>
                {
                    b.HasOne("Core.Entities.Location.Country", "Countries")
                        .WithMany("Departments")
                        .HasForeignKey("IdCountryFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("Core.Entities.Person.ClientAddress", b =>
                {
                    b.HasOne("Core.Entities.Location.City", "Cities")
                        .WithOne("ClientAddresses")
                        .HasForeignKey("Core.Entities.Person.ClientAddress", "IdCityFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Person.Client", "Clients")
                        .WithOne("ClientAddresses")
                        .HasForeignKey("Core.Entities.Person.ClientAddress", "IdClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Core.Entities.Person.ClientContact", b =>
                {
                    b.HasOne("Core.Entities.Person.Client", "Clients")
                        .WithMany("ClientContacts")
                        .HasForeignKey("IdClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Core.Entities.Pets.Pet", b =>
                {
                    b.HasOne("Core.Entities.Person.Client", "Clients")
                        .WithMany("Pets")
                        .HasForeignKey("IdClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Pets.PetBred", "PetBreds")
                        .WithMany("Pets")
                        .HasForeignKey("IdPetBredFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");

                    b.Navigation("PetBreds");
                });

            modelBuilder.Entity("Core.Entities.ProvidedServices.Appointment", b =>
                {
                    b.HasOne("Core.Entities.Person.Client", "Clients")
                        .WithMany("Appointments")
                        .HasForeignKey("IdClientFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Pets.Pet", "Pets")
                        .WithMany("Appointments")
                        .HasForeignKey("IdPetFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ProvidedServices.Service", "Services")
                        .WithMany("Appointments")
                        .HasForeignKey("IdServiceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clients");

                    b.Navigation("Pets");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("Core.Entities.Location.City", b =>
                {
                    b.Navigation("ClientAddresses");
                });

            modelBuilder.Entity("Core.Entities.Location.Country", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Core.Entities.Location.Department", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Core.Entities.Person.Client", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("ClientAddresses");

                    b.Navigation("ClientContacts");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Core.Entities.Pets.Pet", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Core.Entities.Pets.PetBred", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Core.Entities.ProvidedServices.Service", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
