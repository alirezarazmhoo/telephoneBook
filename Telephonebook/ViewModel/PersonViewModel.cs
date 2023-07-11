﻿namespace Telephonebook.ViewModel
{
	public class PersonViewModel
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public long Mobile { get; set; }
		public string Address { get; set; } = string.Empty;		
		public string Email { get; set; } = string.Empty;
	}
}
