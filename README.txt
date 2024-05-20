Real Estate Scrape 

IMPORTANT -------------------------------------------------------------------------------------------------------------------------------

   I wrote this application as capstone project for c# bootcamp. I utilized a local real estate agency's website to scrape data from. They agreed to allow me to use their site, strictly for the purposes
of the project. Now that the bootcamp has concluded, I have scrubbed the their website from the code to prevent the slim possibility that this program could be used to abuse their generousity. Thus, rendering this 
program inoperable. However, If you are a programmer or someone interested in scraping. It should be fairly easy to glean the effectiveness of this code by reviewing it. 

__________________________________________________________________________________________________________________________________________
Description:

This project is a real estate data scraper designed to extract property information from a real estate website for properties in central Kentucky counties. 
It utilizes web scraping techniques to gather listing URLs and property details such as address, price, square footage, lot size, and county. 
The scraped data is then stored in a database for further analysis or use. This scraper (if properly expanded) could have such use cases as: real estate market analysis, property valuation, or any other applications that requires real estate data. 
Additionally, the project includes an MVC frontend to search and visualize the scraped data and provide a user-friendly interface for interacting with it

Required Integrated Features:

1. Created Unit Tests for several Methods.
2. Created a list, populated it with several values, retrieved at least one value, and used it in the program.
3. Made a class generic and used it in the program.
4. Made the application asynchronous.
5. Added Comments to code to point out areas that adhere to the SOLID principals.
6. Utilized REGEX but not in the way required*

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
