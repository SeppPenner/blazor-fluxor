using System;
using FullStackSample.Server.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullStackSample.Server.DomainLayer.Services
{
	public class ClientRepository : ClientReadRepository, IClientRepository
	{
		public ClientRepository(FullStackDbContext dbContext)
			: base(dbContext)
		{
			DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
		}

		public void Add(Client client)
		{
			EnsureClient(client);
			DbContext.Clients.Add(client);
		}

		public void Delete(Client client)
		{
			EnsureClient(client);
			DbContext.Remove(client);
		}


		public void Update(Client client)
		{
			EnsureClient(client);
			DbContext.Clients.Attach(client);
		}

		private void EnsureClient(Client client)
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
		}
	}
}
