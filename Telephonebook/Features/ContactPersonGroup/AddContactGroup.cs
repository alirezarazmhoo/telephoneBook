using MediatR;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;

namespace Telephonebook.Features.ContactPersonGroup
{
	public class AddContactGroup
	{
		public class ContactGroupCommand : IRequest<int>
		{
			public string Name { get; set; } = string.Empty;
		
		}
		public class CommandHandler : IRequestHandler<ContactGroupCommand, int>
		{
			public readonly IGenericRepository<ContactGroup> _Repository;
			public CommandHandler(IGenericRepository<ContactGroup> repository)
			{
				_Repository = repository;
			}
			public async Task<int> Handle(ContactGroupCommand request, CancellationToken cancellationToken)
			{
				var entity = new ContactGroup
				{
					Name = request.Name,
				};
				await _Repository.Insert(entity);
				return entity.Id;
			}
		}

	}
}
