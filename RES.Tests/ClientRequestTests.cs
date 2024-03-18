using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES.Tests
{
    [TestClass]
    public class ClientRequestTests
    {
        [TestMethod]
        public async Task MakeHttpRequestAsyncTest()
        {
            //Arrange 

            string url = "https://testurl.com";
            string htmlContent = "<html><body>Test Content</body></html>;";

            var mockHttpClient = new Mock<HttpClient>();
        }
    }
}
