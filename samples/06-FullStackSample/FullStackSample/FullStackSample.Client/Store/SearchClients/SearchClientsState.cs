using System;
using System.Collections.Generic;

namespace FullStackSample.Client.Store.SearchClients
{
	public class SearchClientsState
	{
		public bool IsSearching { get; private set; }
		public string ErrorMessage { get; private set; }
		public IEnumerable<Api.Models.Client> Clients { get; private set; }
		public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

		public SearchClientsState(
			bool isSearching,
			string errorMessage,
			IEnumerable<Api.Models.Client> clients)
		{
			IsSearching = isSearching;
			ErrorMessage = errorMessage;
			Clients = clients ?? Array.Empty<Api.Models.Client>();
		}
	}
}
