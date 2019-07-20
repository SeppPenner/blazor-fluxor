using AutoMapper;

namespace FullStackSample.DomainLayer
{
	public class AutoMapperConfiguration : Profile
	{
		public AutoMapperConfiguration()
		{
			CreateMap<Entities.Client, Api.Models.Client>();
		}
	}
}
