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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var (message, status, list) = await _auth.LoginAsync(model);
            if (list.UserId > 0)
            {
                TempData["Error"] = "Invalid username or password";
                return RedirectToAction("Index");
            }

            if (!status) // password hash verify
            {
                // ✅ Save info in session
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, list.DispalyName??""),
                        new Claim("UserId", list.UserId.ToString()),
                        new Claim("EmployeeId", list.EmployeeeId.ToString()),
                        new Claim("RoleName", list.RoleName ?? ""),
                        new Claim("RoleId", list.RoleId.ToString()),
                        new Claim("ImageName", list.ImageName ?? "/images/default.png"),
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.Now.AddHours(8)
                    });

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            TempData["Error"] = "Invalid username or password";
            return RedirectToAction("Index");
        }


       

        
    }
}
