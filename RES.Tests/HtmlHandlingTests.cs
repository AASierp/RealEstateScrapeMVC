using HtmlAgilityPack;
using Scraper;

namespace RES.Tests
{
    [TestClass]
    public class HtmlHandlingTests
    {
        [TestMethod]
        public void CreateHtmlDocTest()
        {
            //Arrange
            string htmlContent = "Test Content";

            HtmlHandling<string> htmlHandling = new HtmlHandling<string>();

            //Act
            
            HtmlDocument doc = htmlHandling.CreateHtmlDoc(htmlContent);

            //Assert
            Assert.IsNotNull(doc);
            
        }

        [TestMethod]
        public void ParseHtmlForListingUrlsTest()
        {
            //Arrange
            string HtmlContent = @"
                <html>
                    <body>
                        <div data-url=""/homes/100-kensington-place-richmond-ky/""></div>
                        <div data-url=""/homes/123-old-farm-rd-richmond-ky/""></div>
                    </body>
                </html>";

            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(HtmlContent);

            //Act
            HtmlHandling<string> htmlHandling = new HtmlHandling<string>();

            List<string> listingUrls = htmlHandling.ParseHtmlForListingUrls(doc);

            //Assert
            Assert.IsNotNull(listingUrls);
            Assert.AreEqual(2, listingUrls.Count);
            Assert.IsTrue(listingUrls.Contains("REAL ESTATE LISTING COMPLETE ADDRESS"));
            Assert.IsTrue(listingUrls.Contains("REAL ESTATE LISTING COMPLETE ADDRESS"));
        }
    }
}