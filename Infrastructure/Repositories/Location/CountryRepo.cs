using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Location;
using Core.Interfaces.Location;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Location;

public class CountryRepo : GenericRepository<Country>, ICountry
{
    private readonly AnimalsContext _context;

    public CountryRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Countries
        .Include(c => c.Departments)
        .ThenInclude(d => d.Cities)
        .ToListAsync();
    }

    public override async Task<(int dataCount, IEnumerable<Country> data)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Countries as IQueryable<Country>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var dataCount = await query.CountAsync();
        var data = await query
            .Include(d => d.Departments)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (dataCount, data);
    }

}
