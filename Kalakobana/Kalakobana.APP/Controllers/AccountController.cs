using Kalakobana.Application.Account;
using Kalakobana.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kalakobana.APP.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator) => _mediator = mediator;

        public IActionResult Login()
        {
            return View(new LoginUserCommand());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = await _mediator.Send(request);
                return RedirectToAction("Index", "Events");
            }
            catch
            {
                TempData["Error"] = "Sorry, Email or password is not correct!";
                return View(request);
            }
        }
        public IActionResult Register()
        {
            return View(new CreateUserCommand());
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserCommand request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = await _mediator.Send(request);
                return View("RegisterCompleted");
            }
            catch
            {
                TempData["Error"] = "User with this credentials Already";
                return View(request);
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _mediator.Logout().ConfigureAwait(false);
        //    return RedirectToAction("Index", "Events");
        //}

    }
}
