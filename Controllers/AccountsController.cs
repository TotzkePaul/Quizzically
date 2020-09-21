using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Quizzically.Data;
using Quizzically.Models;

namespace Quizzically.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public UserManager<ApplicationUser> userManager { get; set; }
        public RoleManager<IdentityRole> roleManager { get; set; }
        public SignInManager<ApplicationUser> signInManager { get; set; }
        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return Ok(new { Status = "Success", Message = "User logged in successfully!" });
                } else
                {
                    return Unauthorized("Invalid password doesn't exist");
                }
            }

            return Unauthorized("User doesn't exist");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser model)
        {
            var userExists = await userManager.FindByNameAsync(model.UserName);
            

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = System.Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);


            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        [Route("whoami")]
        public async Task<IActionResult> Whoami()
        {
            var userExists = await userManager.FindByNameAsync( User?.Identity?.Name ?? string.Empty);

            if (userExists == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User not logged it" });

            return Ok(userExists);
        }

    }
}
