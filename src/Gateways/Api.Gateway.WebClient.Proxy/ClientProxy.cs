namespace Api.Gateway.WebClient.Proxy
{
    #region Using

    using Api.Gateway.Models.Customer.DTOs;
    using Api.Gateway.WebClient.Proxy.Config;
    using Microsoft.AspNetCore.Http;
    using Service.Common.Collection;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    #endregion

    public interface IClientProxy
    {
        Task<DataCollection<ClientDto>> GetAllAsync(int page, int take);
    }

    public class ClientProxy : IClientProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public ClientProxy(
            HttpClient httpClient,
            ApiGatewayUrl apiGatewayUrl,
            IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DataCollection<ClientDto>> GetAllAsync(int page, int take)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}clients?page={page}&take={take}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DataCollection<ClientDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
