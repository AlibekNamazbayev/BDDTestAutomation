using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace BDDTestAutomation.StepDefinitions
{
    [Binding]
    public class NavigationSteps
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public NavigationSteps()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Given(@"I navigate to the EPAM homepage")]
        public void GivenINavigateToTheEPAMHomepage()
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [When(@"I click on the ""(.*)"" link in the main navigation menu")]
        public void WhenIClickOnTheLinkInTheMainNavigationMenu(string linkText)
        {
            IWebElement servicesLink = wait.Until(d => d.FindElement(By.XPath($"//nav//a[text()='{linkText}']")));
            servicesLink.Click();
        }

        [When(@"I select the ""(.*)"" category from the dropdown")]
        public void WhenISelectTheCategoryFromTheDropdown(string category)
        {
            IWebElement categoryElement = wait.Until(d => d.FindElement(By.XPath($"//a[contains(text(), '{category}')]")));
            categoryElement.Click();
        }

        [Then(@"the page title should be correct")]
        public void ThenThePageTitleShouldBeCorrect()
        {
            string expectedTitle = "Services | EPAM";
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Expected title '{expectedTitle}', but got '{actualTitle}'");
        }

        [Then(@"the ""(.*)"" section should be displayed")]
        public void ThenTheSectionShouldBeDisplayed(string sectionName)
        {
            IWebElement section = wait.Until(d => d.FindElement(By.XPath($"//h2[contains(text(), '{sectionName}')]")));
            Assert.That(section.Displayed, Is.True, $"Expected section '{sectionName}' to be displayed.");
        }

        [AfterScenario]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
