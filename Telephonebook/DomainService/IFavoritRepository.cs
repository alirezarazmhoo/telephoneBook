using Telephonebook.Models;

namespace Telephonebook.DomainService
{
	public interface IFavoritRepository
	{
		void AddToFavorit(Person person);
		void RemoveFavorit(Person person);

	}
}
