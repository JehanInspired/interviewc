using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Roman_Framework.Selenium;

namespace InterviewProject.Selenium.POM_for_Implmentation.XYZBank.Pages
{
    public class AccountDashboardPage : AbstractPage
    {
        private By DepositBtn = By.XPath("//button[contains(text(),'Deposit')]");
        
        private By DepositInput = By.XPath("//label[text()='Amount to be Deposited :']/following-sibling::input");
        private By Deposit = By.XPath("//button[text()='Deposit']");
        private By DepositSuccess = By.XPath("//span[text()='Deposit Successful']");
        private By AccountDetails = By.XPath("//div[contains(text(),'Account Number :')]");
        private By LogoutButton = By.XPath("//button[text()='Logout']");
        private By Withdrawbtn = By.XPath("//button[contains(text(),'Withdrawl')]");
        private By WithdrawInput = By.XPath("//label[text()='Amount to be Withdrawn :']/following-sibling::input");
        private By Withdraw = By.XPath("//button[text()='Withdraw']");
        private By TransactionSuccess = By.XPath("//span[text()='Transaction successful']");
        private By AccountSelector = By.Id("accountSelect");


        private By TransactionBtn = By.XPath("//button[contains(text(),'Transactions')]");

        private IWebDriver Driver {get;set;}


        public AccountDashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public void Logout() 
        {
            Click(LogoutButton);
        }

        public void OpenTransactions() 
        {
            Click(TransactionBtn);
        }

        public bool DepositPerAccount(string amount) 
        {
            List<Tuple<string, bool>> results = new List<Tuple<string, bool>>();

            SelectElement selectElement = new SelectElement(FindOne(AccountSelector));
            var optionElements = selectElement.Options;

            foreach (IWebElement element in optionElements) 
            {
                var outcome = DepositAndValidate(element.Text, amount);
                results.Add(new Tuple<string, bool>(element.Text, outcome));
            }           

            return !results.Any(x => x.Item2 == false);
        }



        public bool WithdrawAndValidate(string amount) 
        {
            Regex regex = new Regex(@"\d+");
            WaitforDisplayed();

            Click(Withdrawbtn);
            string accountBefore = GetText(AccountDetails);
            string balanceBefore = regex.Match(accountBefore.Split(",")[1]).Value;


            SendKeys(WithdrawInput, amount);
            Click(Withdraw);
            ValidateElement_Enabled_Displayed(TransactionSuccess, 15);
            string accountAfter = GetText(AccountDetails);
            string balanceAfter = regex.Match(accountAfter.Split(",")[1]).Value;

            string difference = BalanceDifference(balanceBefore, amount);
            var diff = balanceAfter.Equals(difference);          

            return diff;
        }

        public bool DepositAndValidate(string account, string amount) 
        {
            Regex regex = new Regex(@"\d+");
            WaitforDisplayed();
            SetSelectedItem(AccountSelector, account);

            Click(DepositBtn);

            string accountBefore = GetText(AccountDetails);
            string balanceBefore = regex.Match(accountBefore.Split(",")[1]).Value;


            SendKeys(DepositInput, amount);
            Click(Deposit);
            ValidateElement_Enabled_Displayed(DepositSuccess, 15);

            string accountAfter = GetText(AccountDetails);
            string balanceAfter = regex.Match(accountAfter.Split(",")[1]).Value;


            string difference = BalanceDifference(balanceAfter, balanceBefore);
            var diff = amount.Equals(difference);


            return diff;
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
