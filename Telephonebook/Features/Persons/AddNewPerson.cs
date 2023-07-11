using MediatR;
using System.Diagnostics.Eventing.Reader;
using Telephonebook.Data;
using Telephonebook.Models;
using static Telephonebook.Interfaces.IGenericRepository;

namespace Telephonebook.Features.Persons
{
	public class AddNewPerson
	{
		public class Command : IRequest<int>
		{
			public string FullName { get; set; } = string.Empty;
			public long Mobile { get; set; }
			public string Address { get; set; } = string.Empty;
			public string Email { get; set; } = string.Empty;
		}
		public class CommandHandler : IRequestHandler<Command, int>
		{
			public readonly IGenericRepository<Person> _Repository;
			public CommandHandler(IGenericRepository<Person> repository)
			{
				_Repository = repository;
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
			await	_Repository.Insert(entity);
				return entity.Id;
			}
		}
	}
}
