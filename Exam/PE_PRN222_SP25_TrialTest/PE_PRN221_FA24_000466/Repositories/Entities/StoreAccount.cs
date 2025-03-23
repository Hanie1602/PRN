namespace Repositories.Entities
{
	public class StoreAccount
	{
		public int StoreAccountId { get; set; }

		public string StoreAccountPassword { get; set; } = null!;

		public string EmailAddress { get; set; } = null!;

		public string StoreAccountDescription { get; set; } = null!;

		public int Role { get; set; }
	}
}
