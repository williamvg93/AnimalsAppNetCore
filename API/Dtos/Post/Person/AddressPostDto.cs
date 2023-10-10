using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Post.Person
{
    public class AddressPostDto
    {
        public int Id { get; set; }
        public int FirstNumber { get; set; }
        public string FirstLetter { get; set; }
        public int IdClientFk { get; set; }
        public int IdCityFk { get; set; }
    }
}