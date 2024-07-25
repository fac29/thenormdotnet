using System;
using domain.entities;
using domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace thenormapi.controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var bob = await Task.FromResult("All Users found.");
        return Ok(bob);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IUser>> Get(Guid id)
    {
        var bob = await Task.FromResult("User found");
        return Ok(bob);
    }

    [HttpPost]
    public async Task<ActionResult<IUser>> CreateUser(User user)
    {

        return Ok("User Created");
    }

}
