using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UserProject.API.Filters;
using UserProject.Core.DTOs;
using UserProject.Core.Models;
using UserProject.Core.Services;

namespace UserProject.API.Controllers
{
    [ValidateFilterAttribute]
    public class UsersController : CustomBaseController
    {
        private readonly IService<User> _userService;

        public UsersController(IService<User> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var addedUser = await _userService.AddAsync(user);
            return CreateActionResult(CustomResponseDto<User>.Success(201, addedUser));
        }
    }
}
