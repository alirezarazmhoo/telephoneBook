using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telephonebook.Models;

namespace Telephonebook.Data
{
    public class TelephonebookContext : DbContext
    {
        public TelephonebookContext (DbContextOptions<TelephonebookContext> options)
            : base(options)
        {
        }

        public DbSet<Telephonebook.Models.Person>? Person { get; set; } = default!;
		public DbSet<Telephonebook.Models.ContactGroup>?  ContactGroups { get; set; } = default!;

		public DbSet<Telephonebook.Models.PersonToContractGroup>?  PersonToContractGroups { get; set; } 

		
	}
}
