using System;
using System.Net.Http;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {

        string baseurl = "http://localhost:5001/api/";
        HttpClient client = new HttpClient();
        [Fact]
        public void getValidPostAsync()
        {

            var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri(baseurl + "post/19") };
            HttpResponseMessage message =  client.SendAsync(request).Result;
            Assert.Contains("200 ok", message.ToString());
            
            
        }
    }
}
