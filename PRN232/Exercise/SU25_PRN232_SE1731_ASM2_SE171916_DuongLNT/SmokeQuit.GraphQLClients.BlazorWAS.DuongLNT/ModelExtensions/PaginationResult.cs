﻿namespace SmokeQuit.GraphQLClients.BlazorWAS.DuongLNT.ModelExtensions
{
	public class PaginationResult<T> where T : class
	{
		public int TotalItems { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public T Items { get; set; }
		//public ICollection<T> Items { get; set; } = new List<T>();
	}
}
