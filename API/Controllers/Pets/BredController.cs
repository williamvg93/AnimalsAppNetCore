using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Pets;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Pets;

public class BredController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public BredController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Breds in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PetBred>>> Get()
    {
        var breds = await _unitOfWork.PetBreds.GetAllAsync();
        return Ok(breds);
    }

    /* Get Bred By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PetBred>> Get(int id)
    {
        var bred = await _unitOfWork.PetBreds.GetByIdAsync(id);
        if (bred == null)
        {
            return NotFound();
        }
        return bred;
    }

    /* Add a new Pet in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetBred>> Post(PetBred bred)
    {
        this._unitOfWork.PetBreds.Add(bred);
        await _unitOfWork.SaveAsync();
        if (bred == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = bred.Id }, bred);
    }

    /* Update Pet in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetBred>> Put(int id, [FromBody] PetBred bred)
    {
        if (bred.Id == 0)
        {
            bred.Id = id;
        }
        if (bred.Id != id)
        {
            return BadRequest();
        }
        if (bred == null)
        {
            return NotFound();
        }
        _unitOfWork.PetBreds.Update(bred);
        await _unitOfWork.SaveAsync();
        return bred;
    }

    /* Delete Pet in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetBred>> Delete(int id)
    {
        var bred = await _unitOfWork.PetBreds.GetByIdAsync(id);
        if (bred == null)
        {
            return NotFound();
        }
        _unitOfWork.PetBreds.Remove(bred);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
