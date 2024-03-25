using Scraper;

namespace RES.Tests
{
	[TestClass]
    public class ClientRequestTests
    {
        [TestMethod]
        public async Task MakeHttpRequestAsyncTest()
        {
            //Arrange 

            string url = "https://www.wikipedia.org/";

            string expectedHtmlContent = "<meta name=\"description\" content=\"Wikipedia is a free online encyclopedia, created and edited by volunteers around the world and hosted by the Wikimedia Foundation.\">";

            Random random = new Random();

            HttpClient httpClient = new HttpClient();

            //Act

            var htmlContent = await ClientRequest.MakeHttpRequestAsync(url);

            //Assert

            Assert.IsTrue(htmlContent.Contains(expectedHtmlContent));
            
        }
    }
}
