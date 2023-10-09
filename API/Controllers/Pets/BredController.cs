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

public class BredController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BredController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Breds in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BredDto>>> Get()
    {
        var breds = await _unitOfWork.PetBreds.GetAllAsync();
        return _mapper.Map<List<BredDto>>(breds);
    }

    /* Get Bred By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BredDto>> Get(int id)
    {
        var bred = await _unitOfWork.PetBreds.GetByIdAsync(id);
        if (bred == null)
        {
            return NotFound();
        }
        return _mapper.Map<BredDto>(bred);
    }

    /* Add a new Pet in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PetBred>> Post(BredDto bredDto)
    {
        var bred = _mapper.Map<PetBred>(bredDto);
        this._unitOfWork.PetBreds.Add(bred);
        await _unitOfWork.SaveAsync();
        if (bred == null)
        {
            return BadRequest();
        }
        bredDto.Id = bred.Id;
        return CreatedAtAction(nameof(Post), new { id = bredDto.Id }, bredDto);
    }

    /* Update Pet in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BredDto>> Put(int id, [FromBody] BredDto bredDto)
    {
        if (bredDto.Id == 0)
        {
            bredDto.Id = id;
        }
        if (bredDto.Id != id)
        {
            return BadRequest();
        }
        if (bredDto == null)
        {
            return NotFound();
        }
        var bred = _mapper.Map<PetBred>(bredDto);
        _unitOfWork.PetBreds.Update(bred);
        await _unitOfWork.SaveAsync();
        return bredDto;
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
