Real Estate Scrape 

Description:

This project is a real estate data scraper designed to extract property information from a real estate website (https://www.joehaydenrealtor.com/) for properties in central Kentucky counties. 
It utilizes web scraping techniques to gather listing URLs and property details such as address, price, square footage, lot size, and county. 
The scraped data is then stored in a database for further analysis or use. This scraper (if properly expanded) could have such use cases as: real estate market analysis, property valuation, or any other applications that requires real estate data. 

Additionally, the project includes an MVC frontend to search and visualize the scraped data and provide a user-friendly interface.

Project Dependencies: 
  - Scraper 
    1. HtmlAgilityPack
  - RES.Tests
    1. MSTest 
  - RES.DAL
    1. Microsoft.EntityFrameworkCore.Design
    2. Microsoft.EntityFrameworkcore.Sqlite
  - RealEstateScrapeMVC
    1. Microsoft.EntityFrameworkCore.Design
    2. Microsoft.EntityFrameworkcore.Sqlite
User Instructions:

1. Clone the application to your local machine.
2. Open in your IDE
3. In the RES.DAL directory run "dotnet ef database update" in the command line.
3. Run the Scraper Project. I recommend selecting all counties, a larger database will enhance the experience. 
   It will likely take roughly 30mins to scrape all the counties available and populate the database.
4. After the database is populated, run the MVC project and search the database.
