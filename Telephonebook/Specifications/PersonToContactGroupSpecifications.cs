using Telephonebook.Models;
using static Telephonebook.Features.ContactPersonGroup.EditContactGroup;


namespace Telephonebook.Specifications
{
	public class PersonToContactGroupSpecifications :BaseSpecifcation<PersonToContractGroup>
	{
		public PersonToContactGroupSpecifications(int Id) :base(p => p.ContactGroupId == Id)
		{		
			if(Includes !=null)
			Includes.Add(s=>s.Person);
		}
		
	}
}
