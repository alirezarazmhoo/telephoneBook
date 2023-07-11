using System.Text.RegularExpressions;

namespace Telephonebook.Models
{
	public class PersonToContractGroup
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public int ContactGroupId { get; set; }
		public  Person? Person { get; set; }
		public  ContactGroup? ContactGroup { get; set; }


	}
}
