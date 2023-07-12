using Telephonebook.Models;

namespace Telephonebook.DomainService
{
	public interface IExecuteEditPersonToContactgroup
	{
		 PersonToContractGroup UpdateContactGroup( int PersonId, int GroupId);
	}
}
