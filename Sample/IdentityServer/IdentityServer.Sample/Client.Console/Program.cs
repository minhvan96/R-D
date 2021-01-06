using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Console
{
    public class Program
    {
        private async static Task Main(string[] args)
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            // Nếu không tìm thấy Identity Server sẽ báo lỗi
            var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (discoveryDocument.IsError)
            {
                System.Console.WriteLine(discoveryDocument.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client_console",
                ClientSecret = "client_console_secret",

                Scope = "Api.One"
            });

            if (tokenResponse.IsError)
            {
                System.Console.WriteLine(tokenResponse.Error);
                return;
            }

            System.Console.WriteLine(tokenResponse.Json);
            System.Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:6001/api/identity");
            if (!response.IsSuccessStatusCode)
            {
                System.Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}