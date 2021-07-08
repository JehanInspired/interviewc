using OpenQA.Selenium;
using InterviewProject.Selenium.POM_for_Implmentation.XYZBank.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace roman_example.Applications
{
    public class Way2AutomationApplication
    {
        public CustomerLoginPage customerLoginPage;
        public AccountDashboardPage accountDashboardPage;

        public Way2AutomationApplication(IWebDriver driver) 
        {
            customerLoginPage = new CustomerLoginPage(driver);
            accountDashboardPage = new AccountDashboardPage(driver);
        }
    }
}
