using Api.Gateway.Proxy;
using Microsoft.Extensions.Options;

namespace Api.Gateway.WebClient
{
    public interface ITestService
    {
        string GetUrlOrder();
    }

    public class TestService : ITestService
    {
        private readonly ApiUrls _apiUrls;

        public TestService(IOptions<ApiUrls> apiUrls)
        {
            _apiUrls = apiUrls.Value;
        }

        public string GetUrlOrder()
        {
            return _apiUrls.OrderUrl;
        }
    }
}
