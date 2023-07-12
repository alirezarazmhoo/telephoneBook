using Telephonebook.Models;

namespace Telephonebook.DomainService
{
	public class FavoritRepository : IFavoritRepository
	{

		public void AddToFavorit(Person person)
		{	
			person.IsFavorit = true;

		}
		public void RemoveFavorit(Person person)
		{
		person.IsFavorit = false;

		}


	}
}
