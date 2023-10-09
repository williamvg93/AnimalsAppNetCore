using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Pets;
using AutoMapper;
using Core.Entities;
using Core.Entities.Pets;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Pets;

public class PetController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PetController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Pets in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PetDto>>> Get()
    {
        var pets = await _unitOfWork.Pets.GetAllAsync();
        return _mapper.Map<List<PetDto>>(pets);
    }

    /* Get Pet By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PetDto>> Get(int id)
    {
        var pet = await _unitOfWork.Pets.GetByIdAsync(id);
        if (pet == null)
        {
            return NotFound();
        }
        return _mapper.Map<PetDto>(pet);
    }

    /* Add a new Pet in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pet>> Post(PetDto petDto)
    {
        var pet = _mapper.Map<Pet>(petDto);
        this._unitOfWork.Pets.Add(pet);
        await _unitOfWork.SaveAsync();
        if (pet == null)
        {
            return BadRequest();
        }
        petDto.Id = pet.Id;
        return CreatedAtAction(nameof(Post), new { id = petDto.Id }, petDto);
    }

    /* Update Pet in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetDto>> Put(int id, [FromBody] PetDto petDto)
    {
        var pet = _mapper.Map<Pet>(petDto);
        if (pet.Id == 0)
        {
            pet.Id = id;
        }
        if (pet.Id != id)
        {
            return BadRequest();
        }
        if (pet == null)
        {
            return NotFound();
        }
        petDto.Id = pet.Id;
        _unitOfWork.Pets.Update(pet);
        await _unitOfWork.SaveAsync();
        return petDto;
    }

    /* Delete Pet in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pet>> Delete(int id)
    {
        var pet = await _unitOfWork.Pets.GetByIdAsync(id);
        if (pet == null)
        {
            return NotFound();
        }
        _unitOfWork.Pets.Remove(pet);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }


}
