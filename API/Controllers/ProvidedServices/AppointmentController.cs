using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.ProvidedServices;
using AutoMapper;
using Core.Entities;
using Core.Entities.ProvidedServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProvidedServices;

public class AppointmentController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AppointmentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Appointments in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get()
    {
        var appointments = await _unitOfWork.Appointments.GetAllAsync();
        return _mapper.Map<List<AppointmentDto>>(appointments);
    }

    /* Get Appointment By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppointmentDto>> Get(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return _mapper.Map<AppointmentDto>(appointment);
    }

    /* Add a new Appointment in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Appointment>> Post(AppointmentDto appointmentDto)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        this._unitOfWork.Appointments.Add(appointment);
        await _unitOfWork.SaveAsync();
        if (appointment == null)
        {
            return BadRequest();
        }
        appointmentDto.Id = appointment.Id;
        return CreatedAtAction(nameof(Post), new { id = appointmentDto.Id }, appointmentDto);
    }

    /* Update Appointment in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AppointmentDto>> Put(int id, [FromBody] AppointmentDto appointmentDto)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDto);

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
        appointmentDto.Id = appointment.Id;
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.SaveAsync();
        return appointmentDto;
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
