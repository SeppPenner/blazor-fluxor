using FullStackSample.Api.Requests;
using FullStackSample.Client.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FullStackSample.Client.Services
{
	public class ApiService : IApiService
	{
		private readonly HttpClient HttpClient;
		private readonly IUriHelper UriHelper;
		private readonly ReadOnlyDictionary<Type, Uri> UriByRequestType;

		public ApiService(HttpClient httpClient, IUriHelper uriHelper)
		{
			HttpClient = httpClient;
			UriHelper = uriHelper;
			UriByRequestType = CreateUrlsByRequestTypeLookup();
		}

		public async Task<TResponse> Execute<TRequest, TResponse>(TRequest request)
			where TRequest : IRequest<TResponse>
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			Type requestType = request.GetType();
			if (!UriByRequestType.TryGetValue(requestType, out Uri uri))
				throw new ApiEndpointNotFoundException(requestType);

			string jsonResponse = await ExecuteHttpRequest(request, uri);
			return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
		}

		private async Task<string> ExecuteHttpRequest(object request, Uri uri)
		{
			var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
			var httpMessage = new HttpRequestMessage(HttpMethod.Post, uri)
			{
				Content = httpContent
			};
			using (httpMessage)
			{
				HttpResponseMessage httpResponse = await HttpClient.SendAsync(httpMessage);
				using (httpResponse)
				{
					string jsonResponse = await httpResponse.Content.ReadAsStringAsync();
					return jsonResponse;
				}
			}
		}

		private const string ServerApiVersion = ""; //None yet
		private class ClientUrls
		{
			const string Base = ServerApiVersion + "client/";
			public const string Search = Base + "search";
		}

		private ReadOnlyDictionary<Type, Uri> CreateUrlsByRequestTypeLookup()
		{
			var lookup = new Dictionary<Type, Uri>
			{
				[typeof(ClientsSearchQuery)] = new Uri(UriHelper.GetBaseUri() + ClientUrls.Search)
			};
			return new ReadOnlyDictionary<Type, Uri>(lookup);
		}
	}
}
