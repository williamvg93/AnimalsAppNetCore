using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.ProvidedServices;

public class Service : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public double Price { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Appointment */
    public ICollection<Appointment> Appointments { get; set; }

    /* --------------------------------- */
}
