using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Location;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Location;

public class CountryController : BaseController
{

    private readonly IUnitOfWork _unitOfWork;

    public CountryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all countries in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Country>>> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        return Ok(countries);
    }

    /* Get countrie by the iD */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Country>> Get(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        return country;
    }
    /* Add a new Country in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(Country country)
    {
        this._unitOfWork.Countries.Add(country);
        await _unitOfWork.SaveAsync();
        if (country == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = country.Id }, country);
    }

    /* Update Country in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Put(int id, [FromBody] Country country)
    {
        if (country.Id == 0)
        {
            country.Id = id;
        }
        if (country.Id != id)
        {
            return BadRequest();
        }
        if (country == null)
        {
            return NotFound();
        }
        _unitOfWork.Countries.Update(country);
        await _unitOfWork.SaveAsync();
        return country;
    }

    /* Delete Country in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Delete(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        _unitOfWork.Countries.Remove(country);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}