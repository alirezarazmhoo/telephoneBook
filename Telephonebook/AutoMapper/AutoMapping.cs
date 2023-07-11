using AutoMapper;
using Telephonebook.Models;
using Telephonebook.ViewModel;
using static Telephonebook.Features.Persons.AddNewPerson;

namespace Telephonebook.AutoMapper
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			CreateMap<Person, PersonViewModel>().ReverseMap();
			CreateMap<Command, PersonViewModel> ().ReverseMap();
		}
	}
}
