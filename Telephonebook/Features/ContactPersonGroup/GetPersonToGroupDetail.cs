using MediatR;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;
using Telephonebook.Specifications;
using System.Text.RegularExpressions;

namespace Telephonebook.Features.ContactPersonGroup
{
	public class GetPersonToGroupDetail
	{
		public class Query : IRequest<IEnumerable<PersonToContractGroup>>
		{
			public int GroupId { get; set; }
		}
		public class QueryHandler : IRequestHandler<Query, IEnumerable<PersonToContractGroup>>
		{

			public readonly IGenericRepository<PersonToContractGroup> _Repository;
			public QueryHandler(IGenericRepository<PersonToContractGroup> repository)
			{
				_Repository = repository;
			}


			public async Task<IEnumerable<PersonToContractGroup>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specification = new PersonToContactGroupSpecifications(request.GroupId);
				var personItem = await _Repository.FindWithSpecificationPattern(specification);
				var data = personItem.Where(s => s.ContactGroupId == request.GroupId).ToList();
				return data;
			}
		}
	}
}
