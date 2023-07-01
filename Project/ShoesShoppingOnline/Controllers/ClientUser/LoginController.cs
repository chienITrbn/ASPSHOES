using Microsoft.AspNetCore.Mvc;
using ShoesShoppingOnline.Interface;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace ShoesShoppingOnline.Controllers.ClientUser
{
    public class LoginController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public LoginController(IAccountRepository accountRepository) {
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new AccountModel());
        }
        [HttpPost]
        public IActionResult Login(AccountModel accountModel)
        {
            var checkExitsAcc = _accountRepository.isExitsAccount(accountModel);
            if (checkExitsAcc != null)
            {
                string userJson = JsonConvert.SerializeObject(checkExitsAcc);
                HttpContext.Session.SetString("User", userJson);
                if(checkExitsAcc.Role == 1) { return RedirectToAction("Index", "Home"); }
                return RedirectToAction("Dashboard", "Home", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Username or password is incorrect");
            }

            return View(accountModel);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

    }
}
