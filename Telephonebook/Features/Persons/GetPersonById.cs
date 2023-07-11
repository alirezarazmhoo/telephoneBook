using MediatR;
using Telephonebook.Data;
using Telephonebook.Models;
using static Telephonebook.Interfaces.IGenericRepository;

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
		
			public readonly IGenericRepository<Person> _Repository;
			public QueryHandler(IGenericRepository<Person> repository)
			{
				_Repository = repository;
			}
			
			
			public async Task<Person> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _Repository.GetByIdAsync(request.Id);
	
			}
			}
		
		
	}
}
