using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Entities;
using Services.IService;

namespace PharmaceuticalManagement.Pages
{
    public class LoginModel : PageModel
    {
		private readonly IStoreAccountService _accountService;

		public LoginModel(IStoreAccountService accountService)
		{
			_accountService = accountService;
		}

		public async Task<IActionResult> OnGet()
		{
			//Đọc Cookie để kiểm tra xem User đã đăng nhập chưa
			if (Request.Cookies["Account"] != null)
			{
				return RedirectToPage("/MedicineInformations/Index");
			}

			return Page();
		}

		[BindProperty]
		public StoreAccount StoreAccount { get; set; } = default!;
		public string ErrorMessage { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPost()
		{
			if (string.IsNullOrEmpty(StoreAccount.EmailAddress) || string.IsNullOrEmpty(StoreAccount.StoreAccountPassword))
			{
				ErrorMessage = "Email and Password are required!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			StoreAccount account = _accountService.GetAccountByEmail(StoreAccount.EmailAddress);

			if (account == null)
			{
				ErrorMessage = "Invalid email or password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);

				return Page();
			}

			//Check mật khẩu
			if (account.StoreAccountPassword != StoreAccount.StoreAccountPassword)
			{
				ErrorMessage = "Invalid password!";
				ModelState.AddModelError(string.Empty, ErrorMessage);
				return Page();
			}

			//Check role
			if (account.Role != 2 && account.Role != 3)
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

			Response.Cookies.Append("Account", account.Role.ToString(), options);
			Response.Cookies.Append("UserId", account.StoreAccountId.ToString(), options);
			Response.Cookies.Append("Email", account.EmailAddress, options);

			return RedirectToPage("/MedicineInformations/Index");
		}
	}
}
