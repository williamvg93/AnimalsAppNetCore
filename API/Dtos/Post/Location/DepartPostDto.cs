using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Post.Location;

public class DepartPostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdCountryFk { get; set; }
}
