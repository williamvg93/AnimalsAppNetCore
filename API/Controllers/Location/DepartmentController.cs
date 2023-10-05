using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Location;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Location;

public class DepartmentController : BaseController
{

    private readonly IUnitOfWork _unitOfWork;

    public DepartmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all department in the database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Department>>> Get()
    {
        var departments = await _unitOfWork.Departments.GetAllAsync();
        return Ok(departments);
    }

    /* Get countrie by the iD */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Department>> Get(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return department;
    }
    /* Add a new department in the database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Department>> Post(Department department)
    {
        this._unitOfWork.Departments.Add(department);
        await _unitOfWork.SaveAsync();
        if (department == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = department.Id }, department);
    }

    /* Update department in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Department>> Put(int id, [FromBody] Department department)
    {
        if (department.Id == 0)
        {
            department.Id = id;
        }
        if (department.Id != id)
        {
            return BadRequest();
        }
        if (department == null)
        {
            return NotFound();
        }
        _unitOfWork.Departments.Update(department);
        await _unitOfWork.SaveAsync();
        return department;
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