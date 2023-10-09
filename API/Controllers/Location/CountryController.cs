using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Location;
using AutoMapper;
using Core.Entities;
using Core.Entities.Location;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Location;

public class CountryController : BaseController
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all countries in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        /* return Ok(countries); */
        return _mapper.Map<List<CountryDto>>(countries);
    }

    /* Get countrie by the ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        return _mapper.Map<CountryDto>(country);
    }

    /* Add a new Country in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto countryDto)
    {
        var country = _mapper.Map<Country>(countryDto);
        this._unitOfWork.Countries.Add(country);
        await _unitOfWork.SaveAsync();
        if (country == null)
        {
            return BadRequest();
        }
        countryDto.Id = country.Id;
        return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
    }

    /* Update Country in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
    {
        if (countryDto.Id == 0)
        {
            countryDto.Id = id;
        }
        if (countryDto.Id != id)
        {
            return BadRequest();
        }
        if (countryDto == null)
        {
            return NotFound();
        }
        var country = _mapper.Map<Country>(countryDto);
        _unitOfWork.Countries.Update(country);
        await _unitOfWork.SaveAsync();
        return countryDto;
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