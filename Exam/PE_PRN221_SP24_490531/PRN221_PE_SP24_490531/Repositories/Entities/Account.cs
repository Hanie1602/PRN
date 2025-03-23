namespace Repositories.Entities
{
	public class Account
	{
		public string Email { get; set; } = null!;

		public string? UserName { get; set; }

		public string? Password { get; set; }

		public string? FullName { get; set; }

		public DateTime? Birthday { get; set; }

		public string? Status { get; set; }

		public int? RoleID { get; set; }
	}
}
