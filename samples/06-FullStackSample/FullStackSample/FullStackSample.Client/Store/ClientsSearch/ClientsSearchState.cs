using System;
using System.Collections.Generic;

namespace FullStackSample.Client.Store.ClientsSearch
{
	public class ClientsSearchState
	{
		public bool IsSearching { get; private set; }
		public string ErrorMessage { get; private set; }
		public IEnumerable<Api.Models.ClientSummary> Clients { get; private set; }
		public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

		public ClientsSearchState(
			bool isSearching,
			string errorMessage,
			IEnumerable<Api.Models.ClientSummary> clients)
		{
			IsSearching = isSearching;
			ErrorMessage = errorMessage;
			Clients = clients ?? Array.Empty<Api.Models.ClientSummary>();
		}
	}
}
