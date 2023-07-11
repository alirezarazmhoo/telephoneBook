using MediatR;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;

namespace Telephonebook.Features.ContactPersonGroup
{
	public class GetAllContactPersonGroup
	{
		public class Query : IRequest<IEnumerable<ContactGroup>> { }
		public class QueryHandler : IRequestHandler<Query, IEnumerable<ContactGroup>>
		{

			public readonly IGenericRepository<ContactGroup> _Repository;

			public QueryHandler(IGenericRepository<ContactGroup> repository)
			{
				_Repository = repository;
			}
			public async Task<IEnumerable<ContactGroup>> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _Repository.GetAllAsync();
			}
		}


	}
}
