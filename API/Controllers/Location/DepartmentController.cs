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

public class DepartmentController : BaseController
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all department in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
    {
        var departments = await _unitOfWork.Departments.GetAllAsync();
        return _mapper.Map<List<DepartmentDto>>(departments);

    }

    /* Get countrie by the iD */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartmentDto>> Get(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return _mapper.Map<DepartmentDto>(department);
    }

    /* Add a new department in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Department>> Post(DepartmentDto departmentDto)
    {
        var department = _mapper.Map<Department>(departmentDto);
        this._unitOfWork.Departments.Add(department);
        await _unitOfWork.SaveAsync();
        if (department == null)
        {
            return BadRequest();
        }
        departmentDto.Id = department.Id;
        return CreatedAtAction(nameof(Post), new { id = departmentDto.Id }, departmentDto);
    }

    /* Update department in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartmentDto>> Put(int id, [FromBody] DepartmentDto departmentDto)
    {
        if (departmentDto.Id == 0)
        {
            departmentDto.Id = id;
        }
        if (departmentDto.Id != id)
        {
            return BadRequest();
        }
        if (departmentDto == null)
        {
            return NotFound();
        }
        var department = _mapper.Map<Department>(departmentDto);
        _unitOfWork.Departments.Update(department);
        await _unitOfWork.SaveAsync();
        return departmentDto;
    }

    /* Delete department in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Department>> Delete(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        _unitOfWork.Departments.Remove(department);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}