using MediatR;
using Telephonebook.Data;
using Telephonebook.Models;
using static Telephonebook.Interfaces.IGenericRepository;

namespace Telephonebook.Features.Persons
{
	public class RemovePerson
	{
		public class Command : IRequest
		{
			public int Id { get; set; }
		}
		public class CommandHandler : IRequestHandler<Command, Unit>
		{
			public readonly IGenericRepository<Person> _Repository;
			public CommandHandler(IGenericRepository<Person> repository)
			{
				_Repository = repository;
			}
			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var person = await _Repository.GetByIdAsync(request.Id);
				if (person == null) return Unit.Value;
				_Repository.Delete(person);
				return Unit.Value;
			}
		}

	}
}
