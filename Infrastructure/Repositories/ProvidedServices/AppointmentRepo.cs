using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.ProvidedServices;
using Infrastructure.Data;

namespace Infrastructure.Repositories.ProvidedServices;

public class AppointmentRepo : GenericRepository<Appointment>
{
    private readonly AnimalsContext _context;

    public AppointmentRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
