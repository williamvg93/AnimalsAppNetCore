using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Post.ProvidedServices;

public class ServicePostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int IdClientFk { get; set; }
    public int IdPetFk { get; set; }
    public int IdServiceFk { get; set; }
}
