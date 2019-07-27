using AutoMapper;

namespace FullStackSample.Server.DomainLayer
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration()
		{
			CreateMap<Entities.Client, Api.Models.ClientSummary>();
			CreateMap<Api.Models.ClientCreateOrUpdate, Entities.Client>().ReverseMap();
		}
	}
}
