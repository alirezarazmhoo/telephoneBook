using Telephonebook.Models;

namespace Telephonebook.ViewModel
{
	public class PersonInContactGroupViewModel
	{
		public ContactGroup?  ContactGroup { get; set; }
		public ICollection< PersonViewModel>? PersonViewModel { get; set; }
	}
	


}
