using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Interfaces.Location;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Location;

public class CountryRepo : GenericRepository<Country>, ICountry
{
    private readonly AnimalsContext _context;

    public CountryRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
