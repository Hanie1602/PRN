﻿namespace PRN222.Lab1.Repositories.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }

		public string CategoryName { get; set; } = null!;

		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
