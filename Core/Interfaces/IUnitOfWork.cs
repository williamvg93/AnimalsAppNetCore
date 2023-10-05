using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Location;
using Core.Interfaces.Person;
using Core.Interfaces.Pets;
using Core.Interfaces.ProvidedServices;

namespace Core.Entities;

public interface IUnitOfWork
{
    ICountry Contries { get; }
    IDepartment Departments { get; }
    ICity Cities { get; }
    IClient Clients { get; }
    IClientAddress Addresses { get; }
    IClientContact Contacts { get; }
    IPet Pets { get; }
    IPetBred PetBreds { get; }
    IAppointment Appointments { get; }
    IService Services { get; }
    Task<int> SaveAsync();
}
