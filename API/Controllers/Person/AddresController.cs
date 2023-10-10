using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Person;
using API.Dtos.Post.Person;
using AutoMapper;
using Core.Entities;
using Core.Entities.Person;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Person;

public class AddresController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddresController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Addresses in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
    {
        var addresses = await _unitOfWork.Addresses.GetAllAsync();
        return _mapper.Map<List<AddressDto>>(addresses);
    }

    /* Get Address By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressDto>> Get(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        return _mapper.Map<AddressDto>(address);
    }

    /* Add a new Address in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientAddress>> Post(AddressPostDto addressDto)
    {
        var address = _mapper.Map<ClientAddress>(addressDto);
        this._unitOfWork.Addresses.Add(address);
        await _unitOfWork.SaveAsync();
        if (address == null)
        {
            return BadRequest();
        }
        addressDto.Id = address.Id;
        return CreatedAtAction(nameof(Post), new { id = addressDto.Id }, addressDto);
    }

    /* Update Address in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressPostDto>> Put(int id, [FromBody] AddressPostDto addressDto)
    {
        var address = _mapper.Map<ClientAddress>(addressDto);
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
        addressDto.Id = address.Id;
        _unitOfWork.Addresses.Update(address);
        await _unitOfWork.SaveAsync();
        return addressDto;
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




