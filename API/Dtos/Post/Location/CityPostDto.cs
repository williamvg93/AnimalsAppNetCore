using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Post.Location;

public class CityPostDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdDepartFk { get; set; }
}
