using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Location;
using AutoMapper;
using Core.Entities;
using Core.Entities.Location;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Location;

public class CityController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Cities in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CityDto>>> Get()
    {
        var cities = await _unitOfWork.Cities.GetAllAsync();
        return _mapper.Map<List<CityDto>>(cities);
    }

    /* Get City By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CityDto>> Get(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
        {
            return NotFound();
        }
        return _mapper.Map<CityDto>(city);
    }

    /* Add a new City in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(CityDto cityDto)
    {
        var city = _mapper.Map<City>(cityDto);
        this._unitOfWork.Cities.Add(city);
        await _unitOfWork.SaveAsync();
        if (city == null)
        {
            return BadRequest();
        }
        cityDto.Id = city.Id;
        return CreatedAtAction(nameof(Post), new { id = cityDto.Id }, cityDto);
    }

    /* Update City in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Put(int id, [FromBody] CityDto cityDto)
    {
        var city = _mapper.Map<City>(cityDto);
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
        cityDto.Id = city.Id;
        _unitOfWork.Cities.Update(city);
        await _unitOfWork.SaveAsync();
        return cityDto;
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
