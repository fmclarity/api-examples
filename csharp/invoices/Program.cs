using System;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace api_examples
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string EndpointUrl = "https://api.staging.fmclarity.com/graphql";

        public static async Task Main(string[] args)
        { 
            var tokenValue = await GetTokenAsync();
            Console.WriteLine(tokenValue);
            var invoices = await GetInvoicesAsync(tokenValue);
            Console.WriteLine(invoices);
        }

        private static async Task<string> GetTokenAsync()
        {
            var tokenPost = new { query = GraphqlQueries.GetTokenMutation };
            var tokenStringContent = new StringContent(
                JsonSerializer.Serialize(tokenPost),
                Encoding.UTF8,
                "application/json");
            var tokenResponse = await client.PostAsync(EndpointUrl, tokenStringContent);

            tokenResponse.EnsureSuccessStatusCode();
            var responseStream = await tokenResponse.Content.ReadAsStreamAsync();
            
            var tokenJsonDocument = await JsonDocument.ParseAsync(responseStream);
            var tokenValue = tokenJsonDocument.RootElement.GetProperty("data").GetProperty("loginWithPassword").GetProperty("token").GetString();
            return tokenValue;
        }

        private static async Task<JsonElement> GetInvoicesAsync(string tokenValue)
        {
            var invoicesPost = new { query = GraphqlQueries.GetWorkOrdersQuery };
            var invoicesStringContent = new StringContent(
                JsonSerializer.Serialize(invoicesPost),
                Encoding.UTF8,
                "application/json");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", tokenValue);
            var invoicesResponse = await client.PostAsync(EndpointUrl, invoicesStringContent);
            invoicesResponse.EnsureSuccessStatusCode();
            var invoicesResponseStream = await invoicesResponse.Content.ReadAsStreamAsync();
            
            var invoicesJsonDocument = await JsonDocument.ParseAsync(invoicesResponseStream);
            var invoicesValue = invoicesJsonDocument.RootElement.GetProperty("data").GetProperty("requests");

            return invoicesValue;
        }
    }
}
