using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Person;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Person;

public class ClientController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Clients in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Client>>> Get()
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        return Ok(clients);
    }

    /* Get Client By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Client>> Get(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return client;
    }

    /* Add a new Client in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Client>> Post(Client client)
    {
        this._unitOfWork.Clients.Add(client);
        await _unitOfWork.SaveAsync();
        if (client == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = client.Id }, client);
    }

    /* Update Client in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Client>> Put(int id, [FromBody] Client client)
    {
        if (client.Id == 0)
        {
            client.Id = id;
        }
        if (client.Id != id)
        {
            return BadRequest();
        }
        if (client == null)
        {
            return NotFound();
        }
        _unitOfWork.Clients.Update(client);
        await _unitOfWork.SaveAsync();
        return client;
    }

    /* Delete Client in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Client>> Delete(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        _unitOfWork.Clients.Remove(client);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}


