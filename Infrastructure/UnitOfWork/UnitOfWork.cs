using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Location;
using Core.Interfaces.Person;
using Core.Interfaces.Pets;
using Core.Interfaces.ProvidedServices;
using Infrastructure.Data;
using Infrastructure.Repositories.Location;
using Infrastructure.Repositories.Person;
using Infrastructure.Repositories.Pets;
using Infrastructure.Repositories.ProvidedServices;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AnimalsContext _context;
    private ICountry _countries;
    private IDepartment _departments;
    private ICity _cities;
    private IClient _clients;
    private IClientAddress _addresses;
    private IClientContact _contacts;
    private IPet _pets;
    private IPetBred _petbreds;
    private IAppointment _appointments;
    private IService _services;

    public UnitOfWork(AnimalsContext context)
    {
        _context = context;
    }

    public ICountry Contries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepo(_context);
            }
            return _countries;
        }
    }
    public IDepartment Departments
    {
        get
        {
            if (_departments == null)
            {
                _departments = new DepartmentRepo(_context);
            }
            return _departments;
        }
    }
    public ICity Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepo(_context);
            }
            return _cities;
        }
    }
    public IClient Clients
    {
        get
        {
            if (_clients == null)
            {
                _clients = new ClientRepo(_context);
            }
            return _clients;
        }
    }
    public IClientAddress Addresses
    {
        get
        {
            if (_addresses == null)
            {
                _addresses = new ClientAddressRepo(_context);
            }
            return _addresses;
        }
    }
    public IClientContact Contacts
    {
        get
        {
            if (_contacts == null)
            {
                _contacts = new ClientContactRepo(_context);
            }
            return _contacts;
        }
    }
    public IPet Pets
    {
        get
        {
            if (_pets == null)
            {
                _pets = new PetRepo(_context);
            }
            return _pets;
        }
    }
    public IPetBred PetBreds
    {
        get
        {
            if (_petbreds == null)
            {
                _petbreds = new PetBredRepo(_context);
            }
            return _petbreds;
        }
    }
    public IAppointment Appointments
    {
        get
        {
            if (_appointments == null)
            {
                _appointments = new AppointmentRepo(_context);
            }
            return _appointments;
        }
    }
    public IService Services
    {
        get
        {
            if (_services == null)
            {
                _services = new ServiceRepo(_context);
            }
            return _services;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
