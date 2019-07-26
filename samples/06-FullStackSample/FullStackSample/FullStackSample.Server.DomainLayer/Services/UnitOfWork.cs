using System.Threading;
using System.Threading.Tasks;

namespace FullStackSample.Server.DomainLayer.Services
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly FullStackDbContext DbContext;

		public UnitOfWork(FullStackDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public async Task<UnitOfWorkResult> CommitAsync(CancellationToken cancellationToken = default)
		{
			await DbContext.SaveChangesAsync(cancellationToken);
			//TODO: Catch unique index violation and return it as an error
			return UnitOfWorkResult.Success;
		}
	}
}
