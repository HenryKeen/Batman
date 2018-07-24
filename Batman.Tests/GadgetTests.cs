using System;
using System.Linq;
using System.Threading.Tasks;
using Batman.API;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Batman.Tests
{
    public class GadgetTests
    {
        [Fact]
        public async Task CanGetAllGadgets()
        {
            var testServer = new TestServer(
                new WebHostBuilder()
                    .UseStartup<Startup>());

            var client = testServer.CreateClient();

            var response = await client.GetAsync("/gadgets");
            var responseString = await response.Content.ReadAsStringAsync();
            
            var responseObject = JsonConvert.DeserializeObject<JObject>(responseString);

            var gadgets = responseObject["items"].Select(x => (string)x).ToArray();
            gadgets.Should().Contain(s => s == "Sonar");
            gadgets.Should().Contain(s => s == "Grappling hook");
            gadgets.Should().Contain(s => s == "Batarangs");
            gadgets.Should().Contain(s => s == "Batcall");
        }
    }
}