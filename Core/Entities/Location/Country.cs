using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Location;

public class Country : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public ICollection<Department> Departments { get; set; }
}
