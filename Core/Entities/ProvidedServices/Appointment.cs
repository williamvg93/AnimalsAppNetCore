using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Entities.Pets;

namespace Core.Entities.ProvidedServices;

public class Appointment : BaseEntity
{
    [Required]
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Client */
    [Required]
    public int IdClientFk { get; set; }
    public Client Clients { get; set; }
    /* Foreign Key for Pet */
    [Required]
    public int IdPetFk { get; set; }
    public Pet Pets { get; set; }
    /* Foreign Key for Service */
    [Required]
    public int IdServiceFk { get; set; }
    public Service Services { get; set; }

    /* --------------------------------- */
}
