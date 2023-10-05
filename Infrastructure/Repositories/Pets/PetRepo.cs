using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;
using Core.Interfaces.Pets;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Pets;

public class PetRepo : GenericRepository<Pet>, IPet
{
    private readonly AnimalsContext _context;

    public PetRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
