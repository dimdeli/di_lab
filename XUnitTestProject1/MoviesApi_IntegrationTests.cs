using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RestEase;
using Xunit;

namespace XUnitTestProject1
{
    public interface IMoviesApi
    {
        [Get("/api/Movies")]
        Task<IList<Movie>> GetAllAsync();

        [Get("/api/Movies/1?code=10xxx")]
        Task<Movie> GetAsync(int id, string code);
    }

    public class MoviesApi_IntegrationTests
    {
        private readonly IMoviesApi api_;
        private readonly TestServer testServer_;

        public MoviesApi_IntegrationTests()
        {
            //var mockPricingService = new Mock<IPricingService>();

            //mockPricingService
            //    //.SetReturnsDefault(0M);
            //    .Setup(a => a.DiscountPercentage(It.IsAny<string>()))
            //    .Returns(0M);

            var webHostBuilder = new WebHostBuilder()
                .UseStartup<MoviesApi.Startup>()
                .ConfigureTestServices(services =>
                    {
                        services.AddTransient<IPricingService, FakePricingService>();
                    });

            testServer_ = new TestServer(webHostBuilder);
            api_ = RestClient.For<IMoviesApi>(testServer_.CreateClient());
        }

        [Fact]
        public async void GetAllAsync()
        {
            var movies = await api_.GetAllAsync();
        }

        [Fact]
        public async void GetAsync()
        {
            var movie = await api_.GetAsync(1, "10xxx");
        }
    }
}
