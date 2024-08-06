using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using domain.interfaces;
using infrastructure.repositories;
using thenormapi.dtos;
using domain.entities;


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
    public async Task<ActionResult<IEnumerable<UserResourceResponseDto>>> GetAll()
    {
        var resources = await _repository.GetAllAsync();
        var responseDtos = resources.Select(MapToResponseDto);
        return Ok(responseDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResourceResponseDto>> GetById(Guid id)
    {
        var resource = await _repository.GetByIdAsync(id);
        if (resource == null)
        {
            return NotFound();
        }
        return Ok(MapToResponseDto(resource));
    }

    [HttpPost]
    public async Task<ActionResult<UserResourceResponseDto>> Create([FromBody] UserResourceDto userResourceDto)
    {
        var userResource = MapToUserResource(userResourceDto);
        var createdResource = await _repository.CreateAsync(userResource);
        var responseDto = MapToResponseDto(createdResource);
        return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserResourceDto userResourceDto)
    {
        var existingResource = await _repository.GetByIdAsync(id);
        if (existingResource == null)
        {
            return NotFound();
        }

        UpdateUserResourceFromDto(existingResource, userResourceDto);
        var updatedResource = await _repository.UpdateAsync(existingResource);
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

    private UserResourceResponseDto MapToResponseDto(IUserResources userResource)
    {
        return new UserResourceResponseDto
        {
            Id = userResource.Id,
            Title = userResource.Title,
            Author = userResource.Author,
            Type = userResource.Type,
            Content = userResource.Content,
            ExternalReference = userResource.ExternalReference,
            ResourcePicture = userResource.ResourcePicture,
            Created = userResource.Created,
            Updated = userResource.Updated
        };
    }

    private IUserResources MapToUserResource(UserResourceDto dto)
    {
        return new UserResources
        {
            Title = dto.Title,
            Author = dto.Author,
            Type = dto.Type,
            Content = dto.Content,
            ExternalReference = dto.ExternalReference,
            ResourcePicture = dto.ResourcePicture,

        };
    }

    private void UpdateUserResourceFromDto(IUserResources resource, UserResourceDto dto)
    {
        resource.Title = dto.Title;
        resource.Author = dto.Author;
        resource.Type = dto.Type;
        resource.Content = dto.Content;
        resource.ExternalReference = dto.ExternalReference;
        resource.ResourcePicture = dto.ResourcePicture;
        resource.Updated = DateTime.UtcNow;
    }
}