using MediatR;
using Telephonebook.Data;
using Telephonebook.Models;

namespace Telephonebook.Features.Persons
{
	public class GetPersonById
	{
		public class Query : IRequest <Person>
		{
			public int Id { get; set; }
		}
		public class QueryHandler : IRequestHandler<Query, Person>
		{
			private readonly TelephonebookContext _db;
			public QueryHandler(TelephonebookContext db)
			{
				this._db = db;
			}
			public async Task<Person> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _db.Person.FindAsync(request.Id);
			}
		}
	}
}
