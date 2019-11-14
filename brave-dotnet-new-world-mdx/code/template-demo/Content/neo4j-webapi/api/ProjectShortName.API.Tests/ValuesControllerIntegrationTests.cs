using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ProjectShortName.API.Tests
{
    /// <summary>
    /// This assumes you have the neo4j database running and that
    /// the initial cypher query to load the data has run
    /// </summary>
    public class ValuesControllerIntegrationTests
    {
        private readonly HttpClient _client;

        public ValuesControllerIntegrationTests()
        {
            var server = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseStartup<Startup>()
                    .UseEnvironment("IntegrationTests")
            );
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Neo4jRequestReturnsExpectedString()
        {
            _client.CancelPendingRequests();
            var result = await _client.GetStringAsync("api/values/neo4j");
            result.Should().Be("Sean Killeen works with Excella Consulting and loves it! Join him at: http://Excella.com/careers");
        }
    }
}
