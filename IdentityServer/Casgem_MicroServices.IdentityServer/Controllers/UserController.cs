using Casgem_MicroServices.IdentityServer.DTOs;
using Casgem_MicroServices.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Casgem_MicroServices.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO) //kayıt ol
        {
            var user = new ApplicationUser
            {
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Mail,
                City = signUpDTO.City
            };
            var result = await _userManager.CreateAsync(user, signUpDTO.Password);
            if (result.Succeeded)
            {
                return Ok("Kayıt oluştu.");
            }
            return BadRequest("Bir hata oluştu.");
        }
    }
}