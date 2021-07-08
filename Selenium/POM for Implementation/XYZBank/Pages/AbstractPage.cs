using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InterviewProject.Selenium.POM_for_Implmentation.XYZBank.Pages
{
    public abstract class AbstractPage
    {
        public IWebDriver _driver {get;set;}

        public AbstractPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public abstract bool WaitforDisplayed();

        public IWebElement FindOne(By by, int timeout = 5)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(drv => drv.FindElement(by));
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void Click(By by)
        {
            FindOne(by).Click();
        }

        public void SendKeys(By by, string text)
        {
            FindOne(by).SendKeys(text);
        }

        public bool ValidateElement_Enabled_Displayed(By by, int timeout =5)
        {
           try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
                wait.Until(drv => drv.FindElement(by));
                wait.Until(drv => drv.FindElement(by).Displayed);
                wait.Until(drv => drv.FindElement(by).Enabled);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SetSelectedItem(By select, string option, bool partialMatch = false)
        {
            SelectElement selectElement = new SelectElement(FindOne(select));
            selectElement.SelectByText(option, partialMatch);
            return selectElement.SelectedOption.Text.Equals(option);
        }

        public string GetText(By by)
        {
            return FindOne(by).Text.Trim();;
        }
    }
}