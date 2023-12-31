﻿using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
namespace Telephonebook.Models
{
	public class Person
	{
		public int Id { get; set; }	
		public string FullName { get; set; } = string.Empty;
		public long Mobile { get; set; }
		public string Address { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public bool IsFavorit { get; set; } = false;

	}
}
