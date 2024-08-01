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
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        var userDtos = users.Select(MapToResponseDto);
        return Ok(userDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetUser(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(MapToResponseDto(user));
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUser(UserDto userDto)
    {
        var user = MapToUser(userDto);
        var createdUser = await _userRepository.CreateAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, MapToResponseDto(createdUser));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UserDto userDto)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        if (existingUser == null)
        {
            return NotFound();
        }

        UpdateUserFromDto(existingUser, userDto);
        await _userRepository.UpdateAsync(existingUser);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        await _userRepository.DeleteAsync(id);
        return NoContent();
    }

    private static UserResponseDto MapToResponseDto(IUser user)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            SummaryParagraph = user.SummaryParagraph,
            UserResourceIds = user.UserResourceIds,
            Created = user.Created
        };
    }

    private static IUser MapToUser(UserDto dto)
    {
        return new User
        {
            Name = dto.Name,
            Email = dto.Email,
            SummaryParagraph = dto.SummaryParagraph
            // UserResourceIds will be initialized to an empty list by default
        };
    }

    private static void UpdateUserFromDto(IUser user, UserDto dto)
    {
        user.Name = dto.Name;
        user.Email = dto.Email;
        user.SummaryParagraph = dto.SummaryParagraph;
    }
}