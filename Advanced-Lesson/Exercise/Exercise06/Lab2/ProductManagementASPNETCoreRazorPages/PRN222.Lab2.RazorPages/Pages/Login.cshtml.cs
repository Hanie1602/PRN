using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN222.Lab2.Repositories.Entities;
using PRN222.Lab2.Services.IService;

namespace PRN222.Lab2.RazorPages.Pages
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
				return RedirectToPage("/Products/Index");
			}

			return Page();
		}

		[BindProperty]
		public AccountMember AccountMember { get; set; } = default!;
		public string ErrorMessage { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPost()
		{
			//Đọc Cookie để kiểm tra xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] != null)
			{
				return RedirectToPage("/Products/Index");
			}

			if (string.IsNullOrEmpty(AccountMember.EmailAddress) || string.IsNullOrEmpty(AccountMember.MemberPassword))
			{
				ErrorMessage = "Email and Password are required!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			AccountMember memberAccount = _accountService.GetAccountByEmail(AccountMember.EmailAddress);

			if (memberAccount == null)
			{
				ErrorMessage = "Invalid email or password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);

				return Page();
			}

			//Check mật khẩu
			if (memberAccount.MemberPassword != AccountMember.MemberPassword)
			{
				ErrorMessage = "Invalid password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			//Check role
			if (memberAccount.MemberRole != 1 && memberAccount.MemberRole != 2)
			{
				ErrorMessage = "You do not have permission to access!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			//Lưu thông tin User vào Cookie
			CookieOptions options = new CookieOptions
			{
				HttpOnly = true,
				Expires = DateTime.UtcNow.AddDays(7) //Thời gian 7 ngày
			};

			Response.Cookies.Append("Account", memberAccount.MemberRole.ToString(), options);
			Response.Cookies.Append("UserId", memberAccount.MemberId.ToString(), options);
			Response.Cookies.Append("Username", memberAccount.FullName, options);

			return RedirectToPage("/Products/Index");
		}

	}
}
	