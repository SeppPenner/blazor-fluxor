using Blazor.Fluxor;
using FullStackSample.Api.Requests;
using FullStackSample.Client.Exceptions;
using FullStackSample.Client.Store.Main;
using MediatR;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Json = Newtonsoft.Json.JsonConvert;

namespace FullStackSample.Client.Services
{
	public class ApiService : IApiService
	{
		private readonly HttpClient HttpClient;
		private readonly IUriHelper UriHelper;
		private readonly ReadOnlyDictionary<Type, Uri> UriByRequestType;
		private readonly JsonSerializerSettings JsonOptions;

		public ApiService(HttpClient httpClient, IUriHelper uriHelper)
		{
			HttpClient = httpClient;
			UriHelper = uriHelper;
			UriByRequestType = CreateUrlsByRequestTypeLookup();
			JsonOptions = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
		}

		public async Task<TResponse> Execute<TRequest, TResponse>(TRequest request)
			where TRequest : IRequest<TResponse>
			where TResponse : ApiResponse, new()
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

			Type requestType = request.GetType();
			if (!UriByRequestType.TryGetValue(requestType, out Uri uri))
				throw new ApiEndpointNotFoundException(requestType);

			try
			{
				string jsonResponse = await ExecuteHttpRequest(request, uri);
				return Json.DeserializeObject<TResponse>(jsonResponse, JsonOptions);
			}
#if DEBUG
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.ToString());
				throw;
			}
#endif
			catch
			{
				throw;
			}
		}

		private async Task<string> ExecuteHttpRequest(object request, Uri uri)
		{
			var httpContent = new StringContent(Json.SerializeObject(request, JsonOptions), Encoding.UTF8, "application/json");
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
			public const string Search = Base + "search/";
			public const string Create = Base + "create/";
		}

		private ReadOnlyDictionary<Type, Uri> CreateUrlsByRequestTypeLookup()
		{
			string baseUrl = UriHelper.GetBaseUri();
			var lookup = new Dictionary<Type, Uri>
			{
				[typeof(ClientsSearchQuery)] = new Uri(baseUrl + ClientUrls.Search),
				[typeof(ClientCreateCommand)] = new Uri(baseUrl + ClientUrls.Create)
			};
			return new ReadOnlyDictionary<Type, Uri>(lookup);
		}
	}
}
