using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;

namespace Core.Entities.Location;

public class City : BaseEntity
{
    [Required]
    public string Name { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Department */
    [Required]
    public int IdDepartFk { get; set; }
    public Department Departments { get; set; }
    /* --------------------------------- */
    public ClientAddress ClientAddresses { get; set; }
}
