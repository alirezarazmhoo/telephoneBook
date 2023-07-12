using Telephonebook.Data;
using Telephonebook.DomainService;
using Telephonebook.Interfaces;

namespace Telephonebook.Repositories
{
	public class EditContactFavoritRepository : IEditContactFavoritRepository
	{
		protected readonly TelephonebookContext _Context;
		protected readonly IFavoritRepository _FavoritRepository;
		public EditContactFavoritRepository(TelephonebookContext context, IFavoritRepository favoritRepository)
		{
			_Context = context;
			_FavoritRepository = favoritRepository;
		}

    	public async Task AddToFavorit(int PersonId)
		{
			if(_Context.Person != null)
			{
			var Item = await _Context.Person.FindAsync(PersonId);
				if (Item != null)
				{
				_FavoritRepository.AddToFavorit(Item);
				}
				await	_Context.SaveChangesAsync();
			}

		}
		public async Task RemoveFromFavorit(int PersonId)
		{
			if (_Context.Person != null)
			{
				var Item = await _Context.Person.FindAsync(PersonId);
				if (Item != null)
				{
					_FavoritRepository.RemoveFavorit(Item);
				}
				await _Context.SaveChangesAsync();

			}
		}


	}
}
