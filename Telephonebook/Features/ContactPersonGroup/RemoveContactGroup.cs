using MediatR;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;

namespace Telephonebook.Features.ContactPersonGroup
{
	public class RemoveContactGroup
	{
		public class Command : IRequest
		{
			public int Id { get; set; }
		}
		public class CommandHandler : IRequestHandler<Command, Unit>
		{
			public readonly IGenericRepository<ContactGroup> _Repository;
			public CommandHandler(IGenericRepository<ContactGroup> repository)
			{
				_Repository = repository;
			}
			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var item = await _Repository.GetByIdAsync(request.Id);
				if (item == null) return Unit.Value;
				_Repository.Delete(item);
				return Unit.Value;
			}
		}
	}
}
