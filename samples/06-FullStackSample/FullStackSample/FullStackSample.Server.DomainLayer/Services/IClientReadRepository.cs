using FullStackSample.Server.DomainLayer.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackSample.Server.DomainLayer.Services
{
	public interface IClientReadRepository
	{
		ValueTask<Client> GetAsync(int id);
		IQueryable<Client> CreateQuery();
	}
}
