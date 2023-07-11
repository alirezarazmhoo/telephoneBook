using Telephonebook.Models;
using static Telephonebook.Features.Persons.SearchPerson;

namespace Telephonebook.Specifications
{
	public class FindPersonByDetailSpecification  : BaseSpecifcation<Person>
	{
		public FindPersonByDetailSpecification(Query request)
		{
			AddFirstOrDefault(s => s.Address.Contains(request.Title) || s.FullName.Contains(request.Title) || s.Email.Contains(request.Title) || s.Mobile == request.Mobile);
		}
	}
}
