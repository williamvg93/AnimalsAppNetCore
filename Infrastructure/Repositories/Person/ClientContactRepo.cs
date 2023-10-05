using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Interfaces.Person;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Person;

public class ClientContactRepo : GenericRepository<ClientContact>, IClientContact
{
    private readonly AnimalsContext _context;

    public ClientContactRepo(AnimalsContext context) : base(context)
    {
        _context = context;
    }
}
