using AutoMapper;

namespace FullStackSample.Server.DomainLayer
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration()
		{
			CreateMap<Entities.Client, Api.Models.Client>();
		}
	}
}
