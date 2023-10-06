using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Location;
using API.Dtos.Person;
using API.Dtos.Pets;
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

        CreateMap<City, CityDto>()
        .ReverseMap();

        CreateMap<Client, ClientDto>()
        .ReverseMap();

        CreateMap<ClientAddress, AddressDto>()
        .ReverseMap();

        CreateMap<ClientContact, ContactDto>()
        .ReverseMap();

        CreateMap<Pet, PetDto>()
        .ReverseMap();

        CreateMap<PetBred, BredDto>()
        .ReverseMap();

        CreateMap<Appointment, AppointmentDto>()
        .ReverseMap();

        CreateMap<Service, ServiceDto>()
        .ReverseMap();
    }
}
