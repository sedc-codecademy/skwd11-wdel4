using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.Lamazon.Services;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Exceptions.User;
using SEDC.Lamazon.ViewModels.Models.Email;
using SEDC.Lamazon.ViewModels.Models.User;
using System.Security.Claims;

namespace SEDC.Lamazon.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly EmailTemplateGenerator _emailTemplateGenerator;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, IRoleService roleService, EmailTemplateGenerator emailTemplateGenerator, IEmailService emailService)
        {
            _userService = userService;
            _roleService = roleService;
            _emailTemplateGenerator = emailTemplateGenerator;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
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
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = new LoginUserViewModel();
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel, string? returnUrl)
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
                    if(user.EmailConfirmed == false)
                    {
                        return RedirectToAction(nameof(ConfirmEmail), new { userId = user.Id});
                    }

                    SignInUser(user, loginUserViewModel.RememberMe);

                    TempData["success"] = $"Welcome back {user.FullName}";

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
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
        public async Task<IActionResult> ConfirmEmail(int userId)
        {
            var user = _userService.GetUserById(userId);
            if(user.EmailConfirmed == true) 
            {
                return RedirectToAction("Index", "Home");
            }
            int code = _userService.GenerateConfirmationCode(user.Id);

            string content = await _emailTemplateGenerator.RenderViewToStringAsync("Shared/Email/_ConfirmationEmail", code);
            var email = new EmailViewModel
            {
                To = user.Email,
                Subject = "Confirmation Email",
                Body = content
            };
            _emailService.SendEmail(email);

            var confirmationViewModel = new ConfirmUserEmailViewModel
            {
                Id = user.Id,
                codeParts = new string[6],
            };

            return View(confirmationViewModel);
           
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ConfirmEmail(ConfirmUserEmailViewModel confirmUserEmailViewModel)
        {
            string fullCode = string.Join("", confirmUserEmailViewModel.codeParts);
            var user = _userService.GetUserById(confirmUserEmailViewModel.Id);
            if(user.ConformationCode != int.Parse(fullCode))
            {
                return RedirectToAction(nameof(ConfirmEmail), new { userId = user.Id });
            }
            _userService.ValidateUserEmail(user.Id);

            return RedirectToAction(nameof(Login));
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

        #region API_CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdString);

            var users = _userService.GetAllUsers(userId);
            return Json(new { data = users });
        }
        #endregion
    }
}
