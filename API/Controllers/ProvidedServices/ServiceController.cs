using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Post.ProvidedServices;
using API.Dtos.ProvidedServices;
using AutoMapper;
using Core.Entities;
using Core.Entities.ProvidedServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ProvidedServices;

public class ServiceController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Services in the Database */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> Get()
    {
        var services = await _unitOfWork.Services.GetAllAsync();
        return _mapper.Map<List<ServiceDto>>(services);
    }

    /* Get Service By ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServiceDto>> Get(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service == null)
        {
            return NotFound();
        }
        return _mapper.Map<ServiceDto>(service);
    }

    /* Add a new Service in the Database */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Service>> Post(ServicePostDto serviceDto)
    {
        var service = _mapper.Map<Service>(serviceDto);
        this._unitOfWork.Services.Add(service);
        await _unitOfWork.SaveAsync();
        if (service == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = serviceDto.Id }, serviceDto);
    }

    /* Update Service in the DataBase By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServicePostDto>> Put(int id, [FromBody] ServicePostDto serviceDto)
    {
        var service = _mapper.Map<Service>(serviceDto);
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
        serviceDto.Id = service.Id;
        _unitOfWork.Services.Update(service);
        await _unitOfWork.SaveAsync();
        return serviceDto;
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
