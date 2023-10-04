using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Pets;

public class PetBredRepo : GenericRepository<PetBred>
{
    private readonly AnimalsContext _context;

    public PetBredRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
