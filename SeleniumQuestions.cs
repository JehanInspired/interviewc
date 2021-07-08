using InterviewProject.Selenium.Failing_Tests;
using NUnit.Framework;
using Roman_Framework;

namespace InterviewProject
{
    public class SeleniumQuestions : RomanBase
    {
        [Test]
        public void Deposit()
        {
            FailingApplication app = new FailingApplication(roman.Selenium.GetChromeDriver());
            app.CustomerLoginPage.Login("Harry Potter");
            app.AccountDashboardPage.DepositAndValidate("1004","2121");
        }

        [Test]
        public void Withdraw()
        {
            FailingApplication app = new FailingApplication(roman.Selenium.GetChromeDriver());
            app.CustomerLoginPage.Login("Harry Potter");
            app.AccountDashboardPage.DepositAndValidate("1004","2121");
            app.AccountDashboardPage.WithdrawAndValidate("2121");
        }
    }
}