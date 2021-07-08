using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Roman_Framework.Selenium;
using NUnit.Framework;

namespace InterviewProject.Selenium.Failing_Tests.Pages
{
    public class AccountDashboardPage : AbstractPage
    {
        private By DepositBtn = By.XPath("//button[contains(text(),'Deposit')]");
        
        private By DepositInput = By.XPath("//input[@type='number']");
        private By Deposit = By.XPath("//button[text()='Deposit']");
        private By DepositSuccess = By.XPath("//span[text()='Deposit Successful']");
        private By AccountDetails = By.XPath("//div[contains(text(),'Account Number :')]");
        private By LogoutButton = By.XPath("//button[text()='Logout']");
        private By Withdrawbtn = By.XPath("//button[contains(text(),'Withdrawl')]");
        private By WithdrawInput = By.XPath("//label[text()='Amount to be Withdrawn :']/following-sibling::input");
        private By Withdraw = By.XPath("//button[text()='Withdraw']");
        private By TransactionSuccess = By.XPath("//span[text()='Transaction ???']");
        private By AccountSelector = By.Id("accountSelect");


        private By TransactionBtn = By.XPath("//button[contains(text(),'Transactions')]");
        public override string _uri {get {return "";}}

        private IWebDriver Driver {get;set;}


        public AccountDashboardPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public void Logout() 
        {
            Click(LogoutButton);
            StepPassedWithScreenshot("Logout complete");
        }

        public void OpenTransactions() 
        {
            Click(TransactionBtn);
        }     

        public void WithdrawAndValidate(string amount) 
        {
            Regex regex = new Regex(@"\d+");
            WaitforDisplayed();
            StepPassedWithScreenshot("Account Page Loaded");

            Click(Withdrawbtn);
            string accountBefore = GetText(AccountDetails);
            string balanceBefore = regex.Match(accountBefore.Split(",")[1]).Value;
            LogInfo("Balance Before: " + balanceBefore);


            SendKeys(WithdrawInput, amount);
            Click(Withdraw);
            Assert.That(ValidateElement_Enabled_Displayed(TransactionSuccess, 15), "Failed to find Transaction success message");
            StepPassedWithScreenshot("Deposit Success");
            string accountAfter = GetText(AccountDetails);
            string balanceAfter = regex.Match(accountAfter.Split(",")[1]).Value;
            LogInfo("Balance After: " + balanceAfter);

            string difference = BalanceDifference(balanceBefore, amount);
            var diff = balanceAfter.Equals(difference);

            if (diff)
            {
                StepPassedWithScreenshot("Withdrawal Difference validated successfully");
            }

            Assert.That(!diff, "Withdrawal Difference was not valid, expected - "+difference+", but found "+amount);
        }

        public void DepositAndValidate(string account, string amount) 
        {
            Regex regex = new Regex(@"\d+");
            WaitforDisplayed();
            SetSelectedItem(AccountSelector, account);

            StepPassedWithScreenshot("Account Page Loaded");
            Click(DepositBtn);

            string accountBefore = GetText(AccountDetails);
            string balanceBefore = regex.Match(accountBefore.Split(",")[1]).Value;

            LogInfo("Balance Before: "+balanceBefore);

            SendKeys(DepositInput, amount);
            Click(Deposit);
            ValidateElement_Enabled_Displayed(DepositSuccess, 15);
            StepPassedWithScreenshot("Deposit Success");

            string accountAfter = GetText(AccountDetails);
            string balanceAfter = regex.Match(accountAfter.Split(",")[1]).Value;

            LogInfo("Balance After: " + balanceAfter);

            string difference = BalanceDifference(balanceAfter, balanceBefore);
            var diff = amount.Equals(difference);

            if (diff) 
            {
                StepPassedWithScreenshot("Deposit Difference validated successfully");
            }

            Assert.That(diff, "Deposit Difference was not valid, expected - "+difference+", but found "+amount);

        }

        private string BalanceDifference(string balanceAfter, string balanceBefore) 
        {
            int diff = Convert.ToInt32(balanceAfter) - Convert.ToInt32(balanceBefore);
            return diff.ToString();
        }

        private string BalanceSum(string balanceAfter, string balanceBefore)
        {
            int diff = Convert.ToInt32(balanceAfter) + Convert.ToInt32(balanceBefore);
            return diff.ToString();
        }

        public override bool WaitforDisplayed()
        {
            return ValidateElement_Enabled_Displayed(DepositBtn, 15);
        }
    }
}
