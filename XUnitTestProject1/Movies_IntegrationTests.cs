using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace XUnitTestProject1
{
    public class Movies_IntegrationTests
    {
        [Fact]
        public async Task Movies_Index()
        {
            var builder = new WebHostBuilder()
              .UseContentRoot(
                      @"C:\github\dimdeli\di_lab\MoviesHubNew")
              .UseEnvironment("Development")
              .UseStartup<MoviesHubNew.Startup>();

            TestServer testServer = new TestServer(builder);

            HttpClient client = testServer.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/Movies");

            // Assert on correct content
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
