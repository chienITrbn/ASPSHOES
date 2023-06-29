using Microsoft.AspNetCore.Mvc;
using ShoesShoppingOnline.Interface;
using ShoesShoppingOnline.Models.DataModel;
using ShoesShoppingOnline.Repository;
using ShoesShoppingOnline.Models;
using DemoWebFirstMVCCore;
using ShoesShoppingOnline.Models.ManagerAccountClient;
using Newtonsoft.Json;
namespace ShoesShoppingOnline.Controllers.ClientUser
{
    public class RegisterController : Controller
    {
        private readonly IAccountRepository _accountRepository;
		private readonly IEmailSender _emailSender;

		public RegisterController(IAccountRepository accountRepository , IEmailSender emailSender) {
            _accountRepository = accountRepository;
			_emailSender = emailSender;

		}
        [HttpGet]
        public IActionResult Register()
        {
            return View(new CombineAccountModel());
        }
        [HttpPost]
		public async Task<ActionResult> Register(CombineAccountModel reModel)
        {
			var validator = new RegisterValidator();
			var validationResult = await validator.ValidateAsync(reModel.Register);
            if (!validationResult.IsValid)
            {
				foreach (var error in validationResult.Errors)
				{
					ModelState.AddModelError("", error.ErrorMessage);
				}
				return View(reModel);
			}
            var checkEixtsEmail = _accountRepository.isExitsEmail(reModel.Register.Email);
            if (checkEixtsEmail)
            {
                ModelState.AddModelError("Register.Email", "Email already exists! Please try another email.");
                return View(reModel);

            }
            var NewAccount = new AccountModel(reModel.Register.Password, reModel.Register.Name, reModel.Register.PhoneNumber,1,true,reModel.Register.Email, reModel.Register.Address);
            string accountJson = JsonConvert.SerializeObject(NewAccount);
            HttpContext.Session.SetString("NewAccount", accountJson);
            var NewCustomer = new CustomerModel(NewAccount.Name,NewAccount.Address,NewAccount.Phonenumber);
            string customerJson = JsonConvert.SerializeObject(NewCustomer);
            HttpContext.Session.SetString("NewCustomer", customerJson);
            string code = new RandomCode().GetRandomCode();
            HttpContext.Session.SetString("codeEmail", code);
            await _emailSender.SendEmailAsync(NewAccount.Email, code);
            TempData["codeEmail"] = code;
            return RedirectToAction("ConfirmEmailCode");
        }

        [HttpGet]
        public ActionResult ConfirmEmailCode()
        {
            string codeEmail = TempData["codeEmail"] as string;
            HttpContext.Session.SetString("SaveCodeEmail", codeEmail);
            return View();
        }        
        [HttpPost]
        public ActionResult ConfirmEmailCode(string Code)
        {
            string codeEmail = HttpContext.Session.GetString("SaveCodeEmail");
            string accountJson = HttpContext.Session.GetString("NewAccount");
            var account = JsonConvert.DeserializeObject<AccountModel>(accountJson);
            string customerJson = HttpContext.Session.GetString("NewCustomer");
            var customer = JsonConvert.DeserializeObject<CustomerModel>(customerJson);
            if (codeEmail != null && codeEmail.Equals(Code))
            {
                _accountRepository.AddAccount(account, customer);
                TempData["SuccessMessage"] = "Create Successfully! Login now go to shopping";
                return RedirectToAction("Login", "Login");
            }
            else
            {
                TempData["ErrorMessage"] = "Code does not match! Please try again.";
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
                return View();
            }
        }

    }
}