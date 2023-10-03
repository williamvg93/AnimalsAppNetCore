using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Pets;
using Core.Entities.ProvidedServices;


namespace Core.Entities.Person;

public class Client : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }

    /* --------- Foreign Keys ---------- */

    /* Foreign Key for ClientAddress */
    public ClientAddress ClientAddresses { get; set; }
    /* Foreign Key for Client Contacts */
    public ICollection<ClientContact> ClientContacts { get; set; }
    /* Foreign Key for Pets */
    public ICollection<Pet> Pets { get; set; }
    /* Foreign Key for Services */
    public ICollection<Service> Services { get; set; }

    /* --------------------------------- */

}
