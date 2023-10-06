using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Person;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Person;

public class ContactController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Contacts in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientContact>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        return Ok(contacts);
    }

    /* Get Contact By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientContact>> Get(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return contact;
    }

    /* Add a new Contact in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientContact>> Post(ClientContact contact)
    {
        this._unitOfWork.Contacts.Add(contact);
        await _unitOfWork.SaveAsync();
        if (contact == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = contact.Id }, contact);
    }

    /* Update Contact in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientContact>> Put(int id, [FromBody] ClientContact contact)
    {
        if (contact.Id == 0)
        {
            contact.Id = id;
        }
        if (contact.Id != id)
        {
            return BadRequest();
        }
        if (contact == null)
        {
            return NotFound();
        }
        _unitOfWork.Contacts.Update(contact);
        await _unitOfWork.SaveAsync();
        return contact;
    }

    /* Delete Contact in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientContact>> Delete(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        _unitOfWork.Contacts.Remove(contact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
