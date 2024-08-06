using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using thenormapi.dtos;
using domain.entities;

namespace thenormapi.controllers;

[ApiController]
[Route("api/[controller]")]
public class WheelSegmentController : ControllerBase
{
    private readonly IWheelSegmentRepository _wheelSegmentRepository;

    public WheelSegmentController(IWheelSegmentRepository wheelSegmentRepository)
    {
        _wheelSegmentRepository = wheelSegmentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WheelSegmentRespponseDto>>> GetAllWheelSegments()
    {
        var wheelSegments = await _wheelSegmentRepository.GetAllAsync();
        var wheelSegmentDtos = wheelSegments.Select(MapToResponseDto);
        return Ok(wheelSegmentDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WheelSegmentRespponseDto>> GetWheelSegment(Guid id)
    {
        var wheelSegment = await _wheelSegmentRepository.GetByIdAsync(id);
        if (wheelSegment == null)
        {
            return NotFound();
        }
        return Ok(MapToResponseDto(wheelSegment));
    }

    [HttpPost]
    public async Task<ActionResult<WheelSegmentRespponseDto>> CreateWheelSegment(WheelSegmentDto createDto)
    {
        var wheelSegment = new WheelSegment
        {
            Title = createDto.Title,
            SegmentResult = createDto.SegmentResult,
            UserId = createDto.UserId,
            UserResourceId = createDto.UserResourceId,

        };

        var createdWheelSegment = await _wheelSegmentRepository.CreateAsync(wheelSegment);
        return CreatedAtAction(nameof(GetWheelSegment), new { id = createdWheelSegment.Id }, MapToResponseDto(createdWheelSegment));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWheelSegment(Guid id, WheelSegmentDto updateDto)
    {
        var existingWheelSegment = await _wheelSegmentRepository.GetByIdAsync(id);
        if (existingWheelSegment == null)
        {
            return NotFound();
        }

        existingWheelSegment.Title = updateDto.Title;
        existingWheelSegment.SegmentResult = updateDto.SegmentResult;
        existingWheelSegment.UserResourceId = updateDto.UserResourceId;
        existingWheelSegment.Updated = DateTime.UtcNow;

        await _wheelSegmentRepository.UpdateAsync(existingWheelSegment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWheelSegment(Guid id)
    {
        var wheelSegment = await _wheelSegmentRepository.GetByIdAsync(id);
        if (wheelSegment == null)
        {
            return NotFound();
        }

        await _wheelSegmentRepository.DeleteAsync(id);
        return NoContent();
    }

    private static WheelSegmentRespponseDto MapToResponseDto(IWheelSegment wheelSegment)
    {
        return new WheelSegmentRespponseDto
        {
            Id = wheelSegment.Id,
            Title = wheelSegment.Title,
            SegmentResult = wheelSegment.SegmentResult,
            UserId = wheelSegment.UserId,
            UserResourceId = wheelSegment.UserResourceId,
            Created = wheelSegment.Created,
            Updated = wheelSegment.Updated
        };
    }
}