using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
using Telephonebook.DomainService;
using Telephonebook.Interfaces;
using Telephonebook.Models;

namespace Telephonebook.Repositories
{
	public class EditContactGroupRepository : IEditContactGroupRepository
	{
		protected readonly TelephonebookContext _Context;
		protected readonly IExecuteEditPersonToContactgroup _ExecuteEditPersonToContactgroup;


		public EditContactGroupRepository(TelephonebookContext context , IExecuteEditPersonToContactgroup executeEditPersonToContactgroup)
		{
			_Context = context;
			_ExecuteEditPersonToContactgroup = executeEditPersonToContactgroup;
		}
		public async Task AddAsync(int GroupId, List<int> PersonIds)
		{
			if (_Context.ContactGroups != null)
			{
			var GroupItem = await _Context.ContactGroups.FindAsync(GroupId);
			if(GroupItem != null)
			{
		if (_Context.PersonToContractGroups != null)
					{
			var oldList = 	await _Context.PersonToContractGroups.Where(s => s.ContactGroupId == GroupId).ToListAsync();
				foreach (var item in oldList)
				{
					_Context.Remove(item);
				}
				foreach (var item in PersonIds)
				{
			
					_Context.PersonToContractGroups.Add(_ExecuteEditPersonToContactgroup.UpdateContactGroup(item, GroupId));
				}
			await	_Context.SaveChangesAsync();
					}
			}
			}

		}

	}
}
