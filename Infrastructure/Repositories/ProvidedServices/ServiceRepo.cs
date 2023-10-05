using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.ProvidedServices;
using Core.Interfaces.ProvidedServices;
using Infrastructure.Data;

namespace Infrastructure.Repositories.ProvidedServices;

public class ServiceRepo : GenericRepository<Service>, IService
{
    private readonly AnimalsContext _context;

    public ServiceRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
