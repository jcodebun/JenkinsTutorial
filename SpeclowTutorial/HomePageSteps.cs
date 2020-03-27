using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpeclowTutorial
{
    [Binding]
    public sealed class HomePageSteps
    {
        IWebDriver Driver;
       public HomePageSteps()
        {
            Driver = new ChromeDriver();
        }



        [Given(@"I navigate to URl")]
        public void GivenINavigateToURl()
        {
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/");
        }

        [Given(@"I click to Input form")]
        public void GivenIClickToInputForm()
        {
            Driver.FindElement(By.XPath("//*[@id='navbar-brand-centered']/ul[1]/li[1]/a")).Click();
            
        }


        [Given(@"User is on the input form Page")]
        public void GivenUserIsOnTheInputFormPage()
        {
            Task.Delay(5000).Wait();
            Driver.FindElement(By.XPath("//*[@id='navbar-brand-centered']/ul[1]/li[1]/ul/li[1]/a")).Click();
        }

        [When(@"User enter Msg in input")]
        public void WhenUserEnterMsgInInput(Table table)
        {

            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
               
                Console.WriteLine(dictionary["Hello"]);
            }
            foreach (TableRow row in table.Rows){

                foreach(string value in row.Values)
                {
                    Driver.FindElement(By.XPath("//*[@id='user-message']")).SendKeys(value);

                    Driver.FindElement(By.XPath("//*[@id='get-input']/button")).Click();

                    Driver.FindElement(By.XPath("//*[@id='user-message']")).Clear();
                    Task.Delay(5000).Wait();

                }
            }
            
        }

        [When(@"User enter ""(.*)"" in input")]
        public void WhenUserEnterInInput(string msg)
        {
            ScenarioContext.Current.Add("msg",msg);
            Driver.FindElement(By.XPath("//*[@id='user-message']")).SendKeys(msg);
        }




        [When(@"User click to Show button")]
        public void WhenUserClickToShowButton()
        {
           Driver.FindElement(By.XPath("//*[@id='get-input']/button")).Click();
            Task.Delay(5000).Wait();

        }

        [Then(@"User can see the text")]
        public void ThenUserCanSeeTheText()
        {
           string msg = ScenarioContext.Current["msg"].ToString();
            string msg1 = Driver.FindElement(By.XPath("//*[@id='display']")).Text.ToString();
            Console.WriteLine("msg coming form the above step : " + msg);
            Assert.IsTrue(msg.Contains(msg1));
        }

    }
}
