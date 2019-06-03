using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace trademeTesting
{
    [TestClass]
    public class UnitTest1
    {
        String userName = "searchString"; //Element id for the userName.
        String search = "//*[@id='generalSearch']/div[2]/button"; //Element Xpath for the search.
        String errMsg = "//*[@id='FiltersContainer']/h1"; //Element Xpath for the Error message.
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver(); //Open the browser
            driver.Navigate().GoToUrl("https://www.trademe.co.nz/"); //Navigate to trade me page
            driver.FindElement(By.Id(userName)).SendKeys("2054034666100"); //Type invaild listing number
            driver.FindElement(By.XPath(search)).Click(); // Click on the search button.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Add an implicit wait.

            String expectMessage = "No results matching '2054034666100'"; // Save the expected message for invaild search.
            var actualMessage = driver.FindElement(By.XPath(errMsg)); // Get the actual message. 
            Assert.AreEqual(actualMessage.Text.ToLower(), expectMessage.ToLower()); // Use assert to compare expected and actual result.

            driver.Quit(); //close the browser.
            
        }
    }
}
