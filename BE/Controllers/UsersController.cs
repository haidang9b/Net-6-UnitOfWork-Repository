using BE.Infrastructure.Contracts;
using BE.Models;
using BE.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
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

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<ApiResult>> Get()
        {
            var result = new ApiResult();
            try
            {
                result.Data = await _userService.GetUsers();
                result.Message = "Get users is successfully";
                result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                result.InternalError();
                result.Message = ex.Message;
            }
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult>> Get(long id)
        {
            var result = new ApiResult();
            try
            {
                result.Data = await _userService.GetUser(id);
                result.Message = "Get user by id is successfully";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.InternalError();
                result.Message = ex.Message;
            }
            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Post([FromBody] User value)
        {
            var result = new ApiResult();
            try
            {
                result.Data = await _userService.Adduser(value);
                result.Message = "Add user is successfully";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.InternalError();
                result.Message = ex.Message;
            }
            return Ok(result);
        }

        [HttpPost("add-range")]
        public async Task<ActionResult<ApiResult>> Post([FromBody] List<User> value)
        {
            var result = new ApiResult();
            try
            {
                result.Data = await _userService.AddUserRange(value);
                result.Message = "Add users is successfully";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.InternalError();
                result.Message = ex.Message;
            }
            return Ok(result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult>> Put(long id, [FromBody] User value)
        {
            var result = new ApiResult();
            try
            {
                value.Id = id;
                result.Data = await _userService.UpdateUser(value);
                result.Message = "Update user is successfully";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.InternalError();
                result.Message = ex.Message;
            }
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult>> Delete(long id)
        {
            var result = new ApiResult();
            try
            {

                await _userService.DeleteUser(id);
                result.Message = "Delete user is successfully";
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.InternalError();
                result.Message = ex.Message;
            }
            return Ok(result);
        }
    }
}
