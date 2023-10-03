using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Location;

public class Department : BaseEntity
{
    [Required]
    public string Name { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Country */
    [Required]
    public int IdCountryFk { get; set; }
    public Country Countries { get; set; }

    /* --------------------------------- */

    public ICollection<City> Cities { get; set; }



}
