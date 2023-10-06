using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Pets;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Pets;

public class PetController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public PetController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Pets in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pet>>> Get()
    {
        var pets = await _unitOfWork.Pets.GetAllAsync();
        return Ok(pets);
    }

    /* Get Pet By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Pet>> Get(int id)
    {
        var pet = await _unitOfWork.Pets.GetByIdAsync(id);
        if (pet == null)
        {
            return NotFound();
        }
        return pet;
    }

    /* Add a new Pet in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
        this._unitOfWork.Pets.Add(pet);
        await _unitOfWork.SaveAsync();
        if (pet == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = pet.Id }, pet);
    }

    /* Update Pet in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pet>> Put(int id, [FromBody] Pet pet)
    {
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
        _unitOfWork.Pets.Update(pet);
        await _unitOfWork.SaveAsync();
        return pet;
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
