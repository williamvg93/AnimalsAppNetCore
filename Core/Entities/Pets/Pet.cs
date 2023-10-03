using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Person;
using Core.Entities.ProvidedServices;

namespace Core.Entities.Pets;

public class Pet : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Species { get; set; }

    public DateTime BirthDate { get; set; }


    /* --------- Foreign Keys ---------- */

    /* Foreign Key for Cliente */
    [Required]
    public int IdClientFk { get; set; }
    public Client Clients { get; set; }
    /* Foreign Key for PetBred */
    [Required]
    public int IdPetBredFk { get; set; }
    public PetBred PetBreds { get; set; }
    /* Foreign Key for Appointment */
    public ICollection<Appointment> Appointments { get; set; }
    /* --------------------------------- */



}
