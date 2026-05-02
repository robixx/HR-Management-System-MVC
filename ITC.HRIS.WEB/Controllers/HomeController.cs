using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using ITC.HRIS.WEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ITC.HRIS.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuth _auth;

        public HomeController(ILogger<HomeController> logger, IAuth auth)
        {
            _logger = logger;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = false, message = "Invalid input data" });
            }

            var (message, status, user) = await _auth.LoginAsync(model);

            if (status && user != null)
            {

                HttpContext.Session.SetInt32("EmployeeId", Convert.ToInt32( user.EmployeeId));
                HttpContext.Session.SetInt32("RoleId", user.RoleId);
                HttpContext.Session.SetString("RoleName", user.RoleName ?? "Guest");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.DisplayName ?? "User"),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("EmployeeId", user.EmployeeId.ToString() ?? "0"),
                    new Claim("RoleName", user.RoleName ?? "Guest"),
                    new Claim("RoleId", user.RoleId.ToString() ?? "0"),
                    new Claim("ImageName", user.ImageName ?? "/images/default.png"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) 
                    });

                return Ok(new
                {
                    status = true,
                    message = "Login successful",
                    redirectUrl = Url.Action("Index", "Dashboard", new { area = "Admin" })
                });
            }

            return Ok(new
            {
                status = false,
                message = message, // Use the message returned from the service
                redirectUrl = Url.Action("Index")
            });
        }


       

        
    }
}
