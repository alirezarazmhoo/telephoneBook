using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Telephonebook.Models;

namespace Telephonebook.DomainService
{
	public class ExecuteEditPersonToContactgroupRepository : IExecuteEditPersonToContactgroup
	{
		public PersonToContractGroup UpdateContactGroup( int PersonId , int GroupId)
		{
		
				var entity = new PersonToContractGroup();
				entity.PersonId = PersonId;
				entity.ContactGroupId = GroupId;
			    return entity;
			
		}
	}
}
