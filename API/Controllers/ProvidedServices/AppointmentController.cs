using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.ProvidedServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProvidedServices;

public class AppointmentController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /* Get all Appointments in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Appointment>>> Get()
    {
        var appointments = await _unitOfWork.Appointments.GetAllAsync();
        return Ok(appointments);
    }

    /* Get Appointment By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Appointment>> Get(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return appointment;
    }

    /* Add a new Appointment in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Appointment>> Post(Appointment appointment)
    {
        this._unitOfWork.Appointments.Add(appointment);
        await _unitOfWork.SaveAsync();
        if (appointment == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = appointment.Id }, appointment);
    }

    /* Update Appointment in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Appointment>> Put(int id, [FromBody] Appointment appointment)
    {
        if (appointment.Id == 0)
        {
            appointment.Id = id;
        }
        if (appointment.Id != id)
        {
            return BadRequest();
        }
        if (appointment == null)
        {
            return NotFound();
        }
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.SaveAsync();
        return appointment;
    }

    /* Delete Appointment in database By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Appointment>> Delete(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        _unitOfWork.Appointments.Remove(appointment);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
