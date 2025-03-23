using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;
using Services.IService;

namespace Equipments.Pages
{
	public class LoginModel : PageModel
	{
		private readonly IAccountService _accountService;

		public LoginModel(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public async Task<IActionResult> OnGet()
		{
			//Đọc Cookie để kiểm tra xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] != null)
			{
				return RedirectToPage("/Equipmentes/Index");
			}

			return Page();
		}

		[BindProperty]
		public Account Account { get; set; } = default!;
		public string ErrorMessage { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPost()
		{
			if (string.IsNullOrEmpty(Account.Email) || string.IsNullOrEmpty(Account.Password))
			{
				ErrorMessage = "Email and Password are required!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			Account account = _accountService.GetAccountByEmail(Account.Email);

			if (account == null)
			{
				ErrorMessage = "Invalid email or password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);

				return Page();
			}

			//Check mật khẩu
			if (account.Password != Account.Password)
			{
				ErrorMessage = "Invalid password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			//Check role
			if (account.RoleID != 1 && account.RoleID != 2)
			{
				ErrorMessage = "You do not have permission to do this function!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			//Lưu thông tin User vào Cookie
			CookieOptions options = new CookieOptions
			{
				HttpOnly = true,
				Expires = DateTime.UtcNow.AddDays(7) //Thời gian 7 ngày
			};

			Response.Cookies.Append("Account", account.RoleID.ToString(), options);
			Response.Cookies.Append("FullName", account.FullName.ToString(), options);
			Response.Cookies.Append("Email", account.Email, options);

			return RedirectToPage("/Equipmentes/Index");
		}
	}
}
