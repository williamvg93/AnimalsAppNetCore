using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Person;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Person;

public class AddresController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    public AddresController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Addresses in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientAddress>>> Get()
    {
        var addresses = await _unitOfWork.Addresses.GetAllAsync();
        return Ok(addresses);
    }

    /* Get Address By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientAddress>> Get(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        return address;
    }

    /* Add a new Address in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientAddress>> Post(ClientAddress address)
    {
        this._unitOfWork.Addresses.Add(address);
        await _unitOfWork.SaveAsync();
        if (address == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = address.Id }, address);
    }

    /* Update Address in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientAddress>> Put(int id, [FromBody] ClientAddress address)
    {
        if (address.Id == 0)
        {
            address.Id = id;
        }
        if (address.Id != id)
        {
            return BadRequest();
        }
        if (address == null)
        {
            return NotFound();
        }
        _unitOfWork.Addresses.Update(address);
        await _unitOfWork.SaveAsync();
        return address;
    }

    /* Delete Client in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientAddress>> Delete(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        _unitOfWork.Addresses.Remove(address);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}




