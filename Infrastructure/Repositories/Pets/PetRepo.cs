using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Pets;

public class PetRepo : GenericRepository<Pet>
{
    private readonly AnimalsContext _context;

    public PetRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
