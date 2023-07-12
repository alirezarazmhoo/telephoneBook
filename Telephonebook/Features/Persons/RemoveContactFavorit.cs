using MediatR;
using Telephonebook.Interfaces;

namespace Telephonebook.Features.Persons
{
	public class RemoveContactFavorit
	{
		public class RemoveContactFavoritCommand : IRequest<Unit>
		{
			public int PersonId { get; set; }

		}

		public class CommandHandler : IRequestHandler<RemoveContactFavoritCommand, Unit>
		{
			public readonly IEditContactFavoritRepository _Repository;
			public CommandHandler(IEditContactFavoritRepository repository)
			{
				_Repository = repository;
			}
			public async Task<Unit> Handle(RemoveContactFavoritCommand request, CancellationToken cancellationToken)
			{

				await _Repository.RemoveFromFavorit(request.PersonId);
				return Unit.Value;
			}
		}
	}
}
