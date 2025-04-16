using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new User { Id = 2, Name = "Bob", Email = "bob@example.com" }
        };

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Returns validation errors
        }

        user.Id = users.Count + 1; // Simple auto-increment logic
        users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Returns validation errors
        }

        var user = users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.Find(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        users.Remove(user);
        return NoContent();
    }


}
