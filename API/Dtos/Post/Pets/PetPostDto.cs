using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Post.Pets;

public class PetPostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public DateTime BirthDate { get; set; }
    public int IdClientFk { get; set; }
    public int IdPetBredFk { get; set; }
}
