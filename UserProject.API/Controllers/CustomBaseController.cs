using Microsoft.AspNetCore.Mvc;
using UserProject.Core.DTOs;

namespace UserProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction] //declaring that the method is not an endpoint
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null) 
                { 
                    StatusCode = response.StatusCode
                };
            }
            return new ObjectResult(response) 
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
