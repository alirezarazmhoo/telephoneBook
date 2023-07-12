using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
using Telephonebook.Models;
using Telephonebook.Specifications;
using static Telephonebook.Interfaces.IGenericRepository;

namespace Telephonebook.Features.Persons
{
	public class GetPerson 
	{
		public class Query : IRequest<IEnumerable<Person>> { }
		public class QueryHandler : IRequestHandler<Query, IEnumerable<Person>>
		{
		
			public readonly IGenericRepository<Person> _Repository;
	
			public QueryHandler(IGenericRepository<Person> repository)
			{
				_Repository = repository;
			}
			public async Task<IEnumerable<Person>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specification = new GetPersonsBasedOnFavoritSpecification();
				return  await _Repository.FindWithSpecificationPattern(specification);
			
			}
		}

	}
}
