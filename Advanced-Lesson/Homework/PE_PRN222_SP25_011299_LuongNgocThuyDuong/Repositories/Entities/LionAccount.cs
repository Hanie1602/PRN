namespace Repositories.Entities
{
	public class LionAccount
	{
		public int AccountID { get; set; }

		public string UserName { get; set; } = null!;

		public string? Password { get; set; }

		public string FullName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Phone {  get; set; } = null!;

		public int RoleId { get; set; }
	}
}
