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

public class ClientController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Clients in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        return _mapper.Map<List<ClientDto>>(clients);
    }

    /* Get Client By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClientDto>> Get(int id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return _mapper.Map<ClientDto>(client);
    }

    /* Add a new Client in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Client>> Post(ClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);
        this._unitOfWork.Clients.Add(client);
        await _unitOfWork.SaveAsync();
        if (client == null)
        {
            return BadRequest();
        }
        clientDto.Id = client.Id;
        return CreatedAtAction(nameof(Post), new { id = clientDto.Id }, clientDto);
    }

    /* Update Client in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);
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
        clientDto.Id = client.Id;
        _unitOfWork.Clients.Update(client);
        await _unitOfWork.SaveAsync();
        return clientDto;
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


