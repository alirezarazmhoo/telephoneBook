using MediatR;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;

namespace Telephonebook.Features.ContactPersonGroup
{
	public class GetContactGroupById
	{
		public class Query : IRequest<ContactGroup>
		{
			public int Id { get; set; }
		}
		public class QueryHandler : IRequestHandler<Query, ContactGroup>
		{

			public readonly IGenericRepository<ContactGroup> _Repository;
			public QueryHandler(IGenericRepository<ContactGroup> repository)
			{
				_Repository = repository;
			}


			public async Task<ContactGroup> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _Repository.GetByIdAsync(request.Id);

			}
		}
	}
}
