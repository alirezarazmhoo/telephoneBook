using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Telephonebook.Data;
using Telephonebook.Models;
using Telephonebook.Specifications;
using static Telephonebook.Interfaces.IGenericRepository;

namespace Telephonebook.Features.Persons
{
	public class SearchPerson
	{
		public class Query : IRequest<Person>
		{
			public string Title { get; set; } = string.Empty;
			public long Mobile { get; set; }
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
				var specification = new FindPersonByDetailSpecification(request);
				var personItem = await _Repository.FindWithSpecificationPattern(specification);

				return personItem.FirstOrDefault();


			}
			}
		}
	}
