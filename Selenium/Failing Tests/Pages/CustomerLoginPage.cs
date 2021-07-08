using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Roman_Framework.Selenium;
using NUnit.Framework;
using System.Data;

namespace InterviewProject.Selenium.Failing_Tests.Pages
{
    public class CustomerLoginPage : AbstractPage
    {
        private By CustomerLoginBtn = By.XPath("//button[text()='Customer Login']");
        private By NameSelect = By.Id("userSelect");
        private By LoginBtn = By.XPath("");
        public CustomerLoginPage(IWebDriver driver) : base(driver)
        {

        }

        public override string _uri { get { return "http://www.way2automation.com/angularjs-protractor/banking/#/login"; } }

        public void Login(string customerName)
        {
            NavigateTo();
            WaitforDisplayed();
            Click(CustomerLoginBtn);            
            SetSelectedItem(NameSelect, customerName);
            Click(LoginBtn);

        }



        public override bool WaitforDisplayed()
        {
            return ValidateElement_Enabled_Displayed(CustomerLoginBtn, 15);
        }
    }
}
