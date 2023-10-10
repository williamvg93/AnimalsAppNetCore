using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Post.Person;

public class ContactPostDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int IdClientFk { get; set; }
}
