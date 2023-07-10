using MediatR;
using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
using Telephonebook.Models;

namespace Telephonebook.Features.Persons
{
	public class GetPerson 
	{
		public class Query : IRequest<IEnumerable<Person>> { }
		public class QueryHandler : IRequestHandler<Query, IEnumerable<Person>>
		{
			private readonly TelephonebookContext _db;
			public QueryHandler(TelephonebookContext db)
			{
			this._db = db;
			}
			public async Task<IEnumerable<Person>> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _db.Person.ToListAsync(cancellationToken);
			}
		}

	}
}
