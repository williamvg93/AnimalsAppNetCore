using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Pets;

public class PetBred : BaseEntity
{
    [Required]
    public string Name { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Pets */
    public Pet Pets { get; set; }

    /* --------------------------------- */

}
