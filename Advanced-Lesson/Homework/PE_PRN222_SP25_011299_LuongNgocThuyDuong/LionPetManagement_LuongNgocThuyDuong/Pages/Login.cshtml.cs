using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;
using Services.IService;

namespace LionPetManagement_LuongNgocThuyDuong.Pages
{
	public class LoginModel : PageModel
    {
		private readonly ILionAccountService _accountService;

		public LoginModel(ILionAccountService accountService)
		{
			_accountService = accountService;
		}

		public async Task<IActionResult> OnGet()
		{
			//Đọc Cookie để kiểm tra xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] != null)
			{
				return RedirectToPage("/LionProfiles/Index");
			}

			return Page();
		}

		[BindProperty]
		public LionAccount LionAccount { get; set; } = default!;
		public string ErrorMessage { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPost()
		{
			if (string.IsNullOrEmpty(LionAccount.Email) || string.IsNullOrEmpty(LionAccount.Password))
			{
				ErrorMessage = "Email and Password are required!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			LionAccount account = _accountService.GetAccountByEmail(LionAccount.Email);

			if (account == null)
			{
				ErrorMessage = "Invalid email or password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);

				return Page();
			}

			//Check mật khẩu
			if (account.Password != LionAccount.Password)
			{
				ErrorMessage = "Invalid password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			//Check role
			if (account.RoleId != 2 && account.RoleId != 3)
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

			Response.Cookies.Append("Account", account.RoleId.ToString(), options);
			Response.Cookies.Append("Username", account.UserName.ToString(), options);
			Response.Cookies.Append("Email", account.Email, options);

			return RedirectToPage("/LionProfiles/Index");
		}
	}
}
