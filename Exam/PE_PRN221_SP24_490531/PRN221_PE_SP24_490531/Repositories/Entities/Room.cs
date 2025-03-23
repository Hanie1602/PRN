namespace Repositories.Entities
{
	public class Room
	{
		public int RoomID { get; set; }

		public string RoomName { get; set; } = null!;

		public string? Location { get; set; }

		public string? Status { get; set; }

		public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
	}
}
