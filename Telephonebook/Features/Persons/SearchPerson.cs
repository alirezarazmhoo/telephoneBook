using MediatR;
using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
using Telephonebook.Models;

namespace Telephonebook.Features.Persons
{
	public class SearchPerson
	{
		public class Query : IRequest<Person>
		{
			public string title { get; set; }
			public long mobile { get; set; }
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

				return await _db.Person.FirstOrDefaultAsync(s => s.Address.Contains(request.title) || s.FullName.Contains(request.title) || s.Email.Contains(request.title) || s.Mobile == request.mobile);

			}
			}
		}
	}
