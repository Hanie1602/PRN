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
			//Đọc Cookie để kiểm tra xem user đã đăng nhập chưa
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
			if (string.IsNullOrEmpty(AccountMember.EmailAddress))
			{
				ErrorMessage = "Email is required!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			AccountMember memberAccount = _accountService.GetAccountByEmail(AccountMember.EmailAddress);

			if (memberAccount == null)
			{
				ErrorMessage = "You do not have permission to do this function!";
				ModelState.AddModelError(string.Empty, ErrorMessage);

				return Page();
			}
			else if (memberAccount.MemberRole == 1 || memberAccount.MemberRole == 2)
			{
				CookieOptions options = new CookieOptions
				{
					HttpOnly = true,  //Cookie chỉ đọc được từ server
					Expires = DateTime.UtcNow.AddDays(7) //Thời hạn cookie 7 ngày
				};

				//Lưu thông tin User vào Cookie (role, id, name)
				Response.Cookies.Append("Account", memberAccount.MemberRole.ToString(), options);
				Response.Cookies.Append("UserId", memberAccount.MemberId.ToString(), options);
				Response.Cookies.Append("Username", memberAccount.FullName, options);

				return RedirectToPage("/Products/Index");
			}
			else
			{
				ErrorMessage = "You do not have permission to do this function!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}
		}

	}
}
	