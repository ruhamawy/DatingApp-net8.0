using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route ("api/[controller]")]// /api/user
public class UserController(DataContext context) : ControllerBase
{


    [HttpGet]
public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
{
    var users=await context.Users.ToListAsync();
    return users;
}

    [HttpGet("{id}")]//aip/user/id
public async Task<ActionResult<AppUser>>GetUsers(int id )
{
    var user=await context.Users.FindAsync(id);//frrom db 

    if(user==null) return NotFound();

    return user;
}
}

