using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Location;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Location;

public class CityController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public CityController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Cities in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<City>>> Get()
    {
        var cities = await _unitOfWork.Cities.GetAllAsync();
        return Ok(cities);
    }

    /* Get City By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<City>> Get(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return city;
    }

    /* Add a new City in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(City city)
    {
        this._unitOfWork.Cities.Add(city);
        await _unitOfWork.SaveAsync();
        if (city == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = city.Id }, city);
    }

    /* Update City in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Put(int id, [FromBody] City city)
    {
        if (city.Id == 0)
        {
            city.Id = id;
        }
        if (city.Id != id)
        {
            return BadRequest();
        }
        if (city == null)
        {
            return NotFound();
        }
        _unitOfWork.Cities.Update(city);
        await _unitOfWork.SaveAsync();
        return city;
    }

    /* Delete Country in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Delete(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        _unitOfWork.Cities.Remove(city);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
