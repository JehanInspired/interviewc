using InterviewProject.Selenium.Failing_Tests.Pages;
using OpenQA.Selenium;

namespace InterviewProject.Selenium.Failing_Tests
{
    public class FailingApplication
    {
        public AccountDashboardPage AccountDashboardPage {get;set;}
        public CustomerLoginPage CustomerLoginPage {get;set;}
        public FailingApplication(IWebDriver driver)
        {
            CustomerLoginPage = new CustomerLoginPage(null);
            AccountDashboardPage = new AccountDashboardPage(driver);
        }
    }
}