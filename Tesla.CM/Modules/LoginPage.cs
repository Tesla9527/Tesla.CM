using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.CM.CommonHelper;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Tesla.CM.Modules
{
    public class LoginPage
    {
        FirefoxDriver driver;
        public FirefoxDriver getDriver()
        {
            return driver;
        }

        public void setDriver(FirefoxDriver driver)
        {
            this.driver = driver;
        }	 	
        public void LoginCM()
        {
            String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            String folderName = Report.getreportname();
            Report.UpdateTestLogTitle(methodName);

            // Test Data
            DataTable dt = ExcelHelper.GetXlsDataSource(folderName, "LoginCM.xls");
            string email = dt.Rows[0]["Email"].ToString();
            string password = dt.Rows[0]["Password"].ToString();

            // Go to the home page
            driver.Navigate().GoToUrl("https://contactmanager9527.azurewebsites.net/");

            var loginLink = driver.FindElement(By.Id("loginLink"));
            loginLink.Click();

            // Get the page elements          
            var emailField = driver.FindElement(By.Id("Email"));
            var passwordField = driver.FindElement(By.Id("Password"));
            var loginButtonField = driver.FindElement(By.XPath(".//*[@id='loginForm']/form/div[4]/div/input"));

            // Type email and password and click the login button        
            emailField.SendKeys(email);
            passwordField.SendKeys(password);
            loginButtonField.Click();
        }
    }
}
