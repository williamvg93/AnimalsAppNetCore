using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Person;
using AutoMapper;
using Core.Entities;
using Core.Entities.Person;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Person;

public class ContactController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Contacts in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactDto>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    /* Get Contact By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactDto>> Get(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContactDto>(contact);
    }

    /* Add a new Contact in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientContact>> Post(ContactDto contactDto)
    {
        var contact = _mapper.Map<ClientContact>(contactDto);
        this._unitOfWork.Contacts.Add(contact);
        await _unitOfWork.SaveAsync();
        if (contact == null)
        {
            return BadRequest();
        }
        contactDto.Id = contact.Id;
        return CreatedAtAction(nameof(Post), new { id = contactDto.Id }, contactDto);
    }

    /* Update Contact in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactDto>> Put(int id, [FromBody] ContactDto contactDto)
    {
        var contact = _mapper.Map<ClientContact>(contactDto);
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
        contactDto.Id = contact.Id;
        _unitOfWork.Contacts.Update(contact);
        await _unitOfWork.SaveAsync();
        return contactDto;
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
