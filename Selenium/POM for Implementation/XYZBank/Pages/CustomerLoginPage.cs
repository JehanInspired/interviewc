using OpenQA.Selenium;


namespace InterviewProject.Selenium.POM_for_Implmentation.XYZBank.Pages
{
    public class CustomerLoginPage : AbstractPage
    {
        private By CustomerLoginBtn = By.XPath("//button[text()='Customer Login']");
        private By NameSelect = By.Id("userSelect");
        private By LoginBtn = By.XPath("//button[text()='Login']");
        public CustomerLoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string _uri { get { return "http://www.way2automation.com/angularjs-protractor/banking/#/login"; } }

        public void Login(string customerName)
        {
            NavigateTo(_uri);
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
