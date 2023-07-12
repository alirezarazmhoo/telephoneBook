using Telephonebook.Models;

namespace Telephonebook.Specifications
{
	public class GetPersonsBasedOnFavoritSpecification : BaseSpecifcation<Person>
	{
		public GetPersonsBasedOnFavoritSpecification()
		{
			AddOrderByDescending(S=>S.IsFavorit);
		}
	}
}
