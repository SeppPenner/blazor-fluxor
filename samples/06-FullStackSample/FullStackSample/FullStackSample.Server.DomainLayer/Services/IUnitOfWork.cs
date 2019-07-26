using System.Threading;
using System.Threading.Tasks;

namespace FullStackSample.Server.DomainLayer.Services
{
	public interface IUnitOfWork
	{ 
		Task<UnitOfWorkResult> CommitAsync(CancellationToken cancellationToken = default);
	}
}
