using Telephonebook.Models;
using static Telephonebook.Features.ContactPersonGroup.EditContactGroup;


namespace Telephonebook.Specifications
{
	public class PersonToContactGroupSpecifications :BaseSpecifcation<PersonToContractGroup>
	{
		public PersonToContactGroupSpecifications()
		{
			
			if(Includes !=null)
			Includes.Add(s=>s.Person);
		}
		
	}
}
