namespace Telephonebook.Interfaces
{
	public interface IEditContactFavoritRepository
	{
		Task AddToFavorit(int PersonId);
		Task RemoveFromFavorit(int PersonId);
	}
}
