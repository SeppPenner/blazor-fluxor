using FullStackSample.Api.Requests;
using MediatR;
using System.Threading.Tasks;

namespace FullStackSample.Client.Services
{
	public interface IApiService
	{
		Task<TResponse> Execute<TRequest, TResponse>(TRequest request)
			where TRequest : IRequest<TResponse>
			where TResponse : ApiResponse, new();
	}
}
