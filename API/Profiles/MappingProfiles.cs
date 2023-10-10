using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Location;
using API.Dtos.Person;
using API.Dtos.Pets;
using API.Dtos.Post.Location;
using API.Dtos.Post.Person;
using API.Dtos.Post.Pets;
using API.Dtos.Post.ProvidedServices;
using API.Dtos.ProvidedServices;
using AutoMapper;
using Core.Entities.Location;
using Core.Entities.Person;
using Core.Entities.Pets;
using Core.Entities.ProvidedServices;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CountryDto>()
        .ReverseMap();

        CreateMap<Department, DepartmentDto>()
        .ReverseMap();

        CreateMap<Department, DepartPostDto>()
        .ReverseMap();

        CreateMap<City, CityDto>()
        .ReverseMap();

        CreateMap<City, CityPostDto>()
        .ReverseMap();

        CreateMap<Client, ClientDto>()
        .ReverseMap();

        CreateMap<ClientAddress, AddressDto>()
        .ReverseMap();

        CreateMap<ClientAddress, AddressPostDto>()
        .ReverseMap();

        CreateMap<ClientContact, ContactDto>()
        .ReverseMap();

        CreateMap<ClientContact, ContactPostDto>()
        .ReverseMap();

        CreateMap<Pet, PetDto>()
        .ReverseMap();

        CreateMap<Pet, PetPostDto>()
        .ReverseMap();

        CreateMap<PetBred, BredDto>()
        .ReverseMap();

        CreateMap<Appointment, AppointmentDto>()
        .ReverseMap();

        CreateMap<Service, ServiceDto>()
        .ReverseMap();

        CreateMap<Service, ServicePostDto>()
        .ReverseMap();
    }
}
