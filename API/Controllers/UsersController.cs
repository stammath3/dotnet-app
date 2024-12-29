using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // api/users
//[controller] is a token that will be replaced by the name of the controller, in this case, Users (anything before the word "Controller")

//using primary constructor to inject DataContext
public class UsersController(DataContext context) : ControllerBase
{

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = context.Users.ToList();

        return users;
    }

    [HttpGet("{id:int}")] // e.g. api/users/1
    public ActionResult<AppUser> GetUser(int id)
    {
        var user = context.Users.Find(id);

        if(user ==  null) return NotFound();
        
        return user;
    }
}