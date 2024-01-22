using Microsoft.AspNetCore.Mvc;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services.UserService;

namespace ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public IActionResult GetUsers() 
        {
            var users = _userService.GetUsers();

            if (users == null)
                return NotFound();
            
            return Ok(users);
            
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);

        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpPost]
        public IActionResult AddUser(User user )
        {
            
            if (user == null)
                return BadRequest();

            _userService.AddUser(user);

            return Ok(user);
        }

        /// <summary>
        /// Update an existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {

            if (user == null)
                return BadRequest();

            _userService.UpdateUser(user);

            return Ok(user);
        }

        /// <summary>
        /// Deletes and existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User</returns>
        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {

            if (user == null)
                return BadRequest();

            _userService.DeleteUser(user);

            return Ok(user);
        }

    }
}
