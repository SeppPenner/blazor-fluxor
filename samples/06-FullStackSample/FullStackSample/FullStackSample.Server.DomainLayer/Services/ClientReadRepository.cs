using FullStackSample.Server.DomainLayer.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackSample.Server.DomainLayer.Services
{
	public class ClientReadRepository : IClientReadRepository
	{
		protected readonly FullStackDbContext DbContext;

		public ClientReadRepository(FullStackDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public IQueryable<Client> CreateQuery() => DbContext.Clients.AsQueryable();

		public ValueTask<Client> GetAsync(int id)
		{
			return DbContext.Clients.FindAsync(id);
		}

	}
}
