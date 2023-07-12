using MediatR;
using static Telephonebook.Features.ContactPersonGroup.AddContactGroup;
using static Telephonebook.Interfaces.IGenericRepository;
using Telephonebook.Models;
using Telephonebook.Interfaces;

namespace Telephonebook.Features.Persons
{
    public class AddContactFavorit
    {
        public class ContactFavoritCommand : IRequest<Unit>
        {
            public int PersonId { get; set; }

        }

        public class CommandHandler : IRequestHandler<ContactFavoritCommand, Unit>
        {
            public readonly IEditContactFavoritRepository _Repository;
            public CommandHandler(IEditContactFavoritRepository repository)
            {
                _Repository = repository;
            }
            public async Task<Unit> Handle(ContactFavoritCommand request, CancellationToken cancellationToken)
            {
              
                await _Repository.AddToFavorit(request.PersonId);
                return Unit.Value;
            }
        }



    }
}
