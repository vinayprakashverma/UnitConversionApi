using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using UnitConversionApi.Models;

namespace UnitConversionApi.Tests
{
    [TestClass]
    public class ConversionApiTests
    {
        private static WebApplicationFactory<Program> _factory = null!;
        private static HttpClient _client = null!;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _factory =
                new WebApplicationFactory<Program>();

            _client =
                _factory.CreateClient();
        }

        [TestMethod]
        public async Task Convert_Endpoint_Should_Return_200()
        {
            var request = new ConversionRequest
            {
                Value = 1,
                FromUnit = "meter",
                ToUnit = "feet"
            };

            var response =
                await _client.PostAsJsonAsync(
                    "/api/v1/conversion",
                    request);

            Assert.AreEqual(
                HttpStatusCode.OK,
                response.StatusCode);
        }

        [TestMethod]
        public async Task Units_Endpoint_Should_Return_200()
        {
            var response =
                await _client.GetAsync(
                    "/api/v1/conversion/units");

            Assert.AreEqual(
                HttpStatusCode.OK,
                response.StatusCode);
        }
    }
}
