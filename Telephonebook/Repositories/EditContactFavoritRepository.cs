using Telephonebook.Data;
using Telephonebook.Interfaces;

namespace Telephonebook.Repositories
{
	public class EditContactFavoritRepository : IEditContactFavoritRepository
	{
		protected readonly TelephonebookContext _Context;
		public EditContactFavoritRepository(TelephonebookContext context)
		{
			_Context = context;
		}

    	public async Task AddToFavorit(int PersonId)
		{
			if(_Context.Person != null)
			{
			var Item = await _Context.Person.FindAsync(PersonId);
				if(Item != null)
				{
				Item.IsFavorit = true;

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
					Item.IsFavorit = false;

				}
				await _Context.SaveChangesAsync();

			}
		}


	}
}
