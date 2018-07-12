using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System;
using System.Configuration;
using System.Data.SqlClient;
using TechTalk.SpecFlow;

namespace SignUp.EndToEndTests
{
    [Binding]
    public class ViewerSignUpSteps
    {
        private static IWebDriver _Driver;
        private string _emailAddress;

        [BeforeFeature]
        public static void Setup()
        {
            _Driver = new SimpleBrowserDriver();
        }

        [AfterFeature]
        public static void TearDown()
        {
            _Driver.Close();
            _Driver.Dispose();
        }

        [Given(@"I browse to the Sign Up Page at ""(.*)""")]
        public void GivenIBrowseToTheSignUpPageAt(string url)
        {
            url = url.Replace("{TARGET_HOST}", GetTargetHost());
            _Driver.Navigate().GoToUrl(url);
        }

        [Given(@"I enter details '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenIEnterDetails(string firstName, string lastName, string emailAddress,
                                       string country, string role)
        {
            _Driver.FindElement(By.Id("MainContent_txtFirstName")).SendKeys(firstName);
            _Driver.FindElement(By.Id("MainContent_txtLastName")).SendKeys(lastName);
            _Driver.FindElement(By.Id("MainContent_txtEmail")).SendKeys(emailAddress);

            new SelectElement(_Driver.FindElement(By.Id("MainContent_ddlCountry"))).SelectByText(country);
            new SelectElement(_Driver.FindElement(By.Id("MainContent_ddlRole"))).SelectByText(role);

            _emailAddress = emailAddress;
        }

        [When(@"I press Go")]
        public void WhenIPressGo()
        {
            var goButton = _Driver.FindElement(By.Id("MainContent_btnGo"));
            goButton.Click();
        }

        [Then(@"I am shown the Thank You page")]
        public void ThenIShouldSeeTheThankYouPage()
        {
            Assert.AreEqual("Ta", _Driver.Title.Trim());
        }

        [Then(@"my details are saved")]
        public void ThenMyDetailsShouldBeSaved()
        {
            AssertHelper.RetryAssert(100, 50, $"Email address: {_emailAddress} not found", () =>
            {
                var count = 0;
                var connectionString = ConfigurationManager.ConnectionStrings["WebinarContext"].ConnectionString;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"SELECT COUNT(*) FROM Viewers WHERE EmailAddress = '{_emailAddress}'";
                        count = (int)command.ExecuteScalar();
                    }
                }
                return count == 1;
            });
         }

        private string GetTargetHost()
        {
            const string key = "TARGET_HOST";
            var value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);
            if (string.IsNullOrEmpty(value))
            {
                value = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
            }
            if (string.IsNullOrEmpty(value))
            {
                value = "localhost";
            }
            return value;
        }
    }
}
