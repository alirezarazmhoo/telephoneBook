using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
using Telephonebook.Interfaces;
using Telephonebook.Models;

namespace Telephonebook.Repositories
{
	public class EditContactGroupRepository : IEditContactGroupRepository
	{
		protected readonly TelephonebookContext _Context;
		public EditContactGroupRepository(TelephonebookContext context)
		{
			_Context = context;
		}
		public async Task AddAsync(int GroupId, List<int> PersonIds)
		{
			var GroupItem = await _Context.ContactGroups.FindAsync(GroupId);
			if(GroupItem != null)
			{
			var oldList = 	await _Context.PersonToContractGroups.Where(s => s.ContactGroupId == GroupId).ToListAsync();
				foreach (var item in oldList)
				{
					_Context.Remove(item);
				}
				foreach (var item in PersonIds)
				{
					var entity = new PersonToContractGroup();
					entity.PersonId = item;
					entity.ContactGroupId = GroupId;
					_Context.PersonToContractGroups.Add(entity);
				}
			await	_Context.SaveChangesAsync();
			}

		}

	}
}
