using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class ClientRepo : GenericRepository<Client>
{
    private readonly AnimalsContext _context;

    public ClientRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
