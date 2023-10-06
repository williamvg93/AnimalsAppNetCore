using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.ProvidedServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProvidedServices;

public class ServiceController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public ServiceController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Services in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Service>>> Get()
    {
        var service = await _unitOfWork.Services.GetAllAsync();
        return Ok(service);
    }

    /* Get Service By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Service>> Get(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service == null)
        {
            return NotFound();
        }
        return service;
    }

    /* Add a new Service in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Service>> Post(Service service)
    {
        this._unitOfWork.Services.Add(service);
        await _unitOfWork.SaveAsync();
        if (service == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = service.Id }, service);
    }

    /* Update Service in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Service>> Put(int id, [FromBody] Service service)
    {
        if (service.Id == 0)
        {
            service.Id = id;
        }
        if (service.Id != id)
        {
            return BadRequest();
        }
        if (service == null)
        {
            return NotFound();
        }
        _unitOfWork.Services.Update(service);
        await _unitOfWork.SaveAsync();
        return service;
    }

    /* Delete Service in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Service>> Delete(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service == null)
        {
            return NotFound();
        }
        _unitOfWork.Services.Remove(service);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
