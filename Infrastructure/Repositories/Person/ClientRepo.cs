using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class ClientRepo : GenericRepository<Client>, IClient
{
    private readonly AnimalsContext _context;

    public ClientRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
