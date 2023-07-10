using MediatR;
using System.Diagnostics.Eventing.Reader;
using Telephonebook.Data;
using Telephonebook.Models;

namespace Telephonebook.Features.Persons
{
	public class AddNewPerson
	{
		public class Command : IRequest<int>
		{
			public string FullName { get; set; }
			public long Mobile { get; set; }
			public string Address { get; set; }
			public string Email { get; set; }
		}
		public class CommandHandler : IRequestHandler<Command, int>
		{
			private readonly TelephonebookContext _db;

			public CommandHandler(TelephonebookContext db) 
			{ 
				_db = db;
			
			}
			public async Task<int> Handle(Command request, CancellationToken cancellationToken)
			{
				var entity = new Person
				{
					FullName = request.FullName,
					Mobile = request.Mobile,
					Address = request.Address,
					Email = request.Email,

				};
				await _db.Person.AddAsync(entity, cancellationToken);
				await _db.SaveChangesAsync(cancellationToken);
				return entity.Id;
			}
		}
	}
}
