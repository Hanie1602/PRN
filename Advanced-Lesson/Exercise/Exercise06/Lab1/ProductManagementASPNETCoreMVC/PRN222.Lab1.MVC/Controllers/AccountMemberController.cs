using Microsoft.AspNetCore.Mvc;
using PRN222.Lab1.Repositories.Entities;
using PRN222.Lab1.Services;

namespace PRN222.Lab1.MVC.Controllers
{
	public class AccountMemberController : Controller
    {
		private readonly IAccountService _accountService;

		public AccountMemberController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(AccountMember model)
		{

			AccountMember? user = _accountService.GetAccountByEmail(model.EmailAddress);

			if (user != null && user.MemberPassword == model.MemberPassword)
			{
				CookieOptions options = new CookieOptions();
				options.Expires = DateTime.Now.AddDays(7); //Cookie tồn tại 7 ngày

				//Lưu trữ thông tin người dùng trong Cookie
				Response.Cookies.Append("UserId", user.MemberId.ToString(), options);
				Response.Cookies.Append("Username", user.FullName, options);

				//Store user information in session
				//HttpContext.Session.SetString("UserId", user.MemberId);
				//HttpContext.Session.SetString("Username", user.FullName);

				return RedirectToAction("Index", "Products"); //Chuyển đến trang chủ
			}
			else
			{
				ModelState.AddModelError("", "Invalid username or password.");
			}


			return View(model);
		}

		public IActionResult Logout()
		{
			//Xóa Cookie
			Response.Cookies.Delete("UserId");
			Response.Cookies.Delete("Username");

			return RedirectToAction("Login");
		}
	}
}
