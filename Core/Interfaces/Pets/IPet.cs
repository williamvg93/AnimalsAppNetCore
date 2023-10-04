using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;

namespace Core.Interfaces.Pets;

public interface IPet : IGenericRepository<Pet>
{

}
