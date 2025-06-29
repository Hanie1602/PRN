namespace Repositories.Entities
{
	public class LionType
	{
		public int LionTypeId { get; set; }

		public string? LionTypeName { get; set; }

		public string? Origin { get; set; }

		public string? Description { get; set; }

		public virtual ICollection<LionProfile> LionProfile { get; set; } = new List<LionProfile>();
	}
}
