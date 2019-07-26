using FullStackSample.Server.DomainLayer.Entities;

namespace FullStackSample.Server.DomainLayer.Services
{
	public interface IClientRepository : IClientReadRepository
	{
		void Add(Client client);
		void Delete(Client client);
		void Update(Client client);
	}
}
