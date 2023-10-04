using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Exceptions.User;
using SEDC.Lamazon.ViewModels.Models.User;
using System.Security.Claims;

namespace SEDC.Lamazon.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            var users = _userService.GetAllUsers(userId);
            return View(users);
        }

        public IActionResult Create()
        {
            var user = new RegisterUserViewModel();
            var roles = _roleService.GetAllRoles();
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegisterUserViewModel registerUserViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _userService.RegisterUser(registerUserViewModel);
                    return RedirectToAction("Index");
                }
                var roles = _roleService.GetAllRoles();
                ViewBag.Roles = new SelectList(roles, "Id", "Name");

                return View(registerUserViewModel);

            }
            catch
            {
                return View("Index");
            }
        }
    
        public IActionResult Edit(int? id)
        {
            if(id.HasValue)
            {
                var user =  _userService.GetUserForUpdate(id.Value);
                var roles = _roleService.GetAllRoles();
                ViewBag.Roles = new SelectList(roles, "Id", "Name");

                return View(user);
            }

            return View(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateUserViewModel updateUserViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _userService.UpdateUser(updateUserViewModel);
                    return RedirectToAction(nameof(Index));
                }
                var roles = _roleService.GetAllRoles();
                ViewBag.Roles = new SelectList(roles, "Id", "Name");
                return View(updateUserViewModel);
            }
            catch
            {
                return View("Index");
            }
        }

        public IActionResult Delete(int? id)
        {
          if(id.HasValue)
            {
                var user = _userService.GetUserById(id.Value);
                return View(user);
            }

            return View("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(UserViewModel userViewModel)
        {
            _userService.DeleteUserById(userViewModel.Id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var user = new LoginUserViewModel();
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
           try
            {
                if(ModelState.IsValid)
                {
                    var user = _userService.LoginUser(loginUserViewModel);

                    if (user == null)
                    {
                        ModelState.AddModelError("Email", "User not found");
                        return View(loginUserViewModel);
                    }

                    SignInUser(user, loginUserViewModel.RememberMe);

                    return Redirect("/");
                }

                return View(loginUserViewModel);
            
            }
            catch(UserNotFoundExcpetion ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return View(loginUserViewModel);
            }
            catch
            {
                return View("Error");
            }
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            var user = new RegisterUserViewModel();
            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterUserViewModel registerUserViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.RegisterUser(registerUserViewModel);

                    return RedirectToAction("Login");
                }

                return View(registerUserViewModel);
            }
            catch(UserException ex)
            {
                ModelState.AddModelError("Password", ex.Message);
                return View(registerUserViewModel);
            }
            catch
            {
                return View(registerUserViewModel);
            }

        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        private async void SignInUser(UserViewModel userViewModel, bool rememberMe)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, userViewModel.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, userViewModel.Email));
            claims.Add(new Claim(ClaimTypes.Name, userViewModel.FullName));
            claims.Add(new Claim(ClaimTypes.Role, userViewModel.Role.Key));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                   IsPersistent = rememberMe,
                });
        }
    }
}
