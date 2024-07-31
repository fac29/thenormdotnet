using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using domain.interfaces;
using infrastructure.repositories;

namespace thenormapi.controllers;

[ApiController]
[Route("api/[controller]")]
public class UserResourcesController : ControllerBase
{
    private readonly IUserResourcesRepository _repository;

    public UserResourcesController(IUserResourcesRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IUserResources>>> GetAll()
    {
        var resources = await _repository.GetAllAsync();
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IUserResources>> GetById(Guid id)
    {
        var resource = await _repository.GetByIdAsync(id);
        if (resource == null)
        {
            return NotFound();
        }
        return Ok(resource);
    }

    [HttpPost]
    public async Task<ActionResult<IUserResources>> Create([FromBody] IUserResources userResource)
    {
        var createdResource = await _repository.CreateAsync(userResource);
        return CreatedAtAction(nameof(GetById), new { id = createdResource.Id }, createdResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] IUserResources userResource)
    {
        if (id != userResource.Id)
        {
            return BadRequest();
        }

        var updatedResource = await _repository.UpdateAsync(userResource);
        if (updatedResource == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}