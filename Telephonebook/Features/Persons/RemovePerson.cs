using MediatR;
using Telephonebook.Data;
using Telephonebook.Models;

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
			private readonly TelephonebookContext _db;

			public CommandHandler(TelephonebookContext db)
			{
				_db = db;

			}
			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var person = await _db.Person.FindAsync(request.Id);
				if (person == null) return Unit.Value;
				_db.Person.Remove(person);
				await _db.SaveChangesAsync();
				return Unit.Value;
			}
		}

	}
}
