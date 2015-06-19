using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.CM.CommonHelper;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tesla.CM.Modules
{
    public class LoginPage
    {
        DriverHelper driverHelper;
        public LoginPage(DriverHelper _driverHelper)
        {
            driverHelper = _driverHelper;
        }

        /// <summary>
        /// Login contact manager
        /// </summary>
        public void LoginCM()
        {
            try
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String folderName = Report.getreportname();
                Report.UpdateTestLogTitle(methodName);

                // Test Data
                DataTable dt = ExcelHelper.GetXlsDataSource(folderName, "LoginCM.xls");
                string email = dt.Rows[0]["Email"].ToString();
                string password = dt.Rows[0]["Password"].ToString();

                // Go to the home page
                driverHelper.Navigate().GoToUrl("https://contactmanager9527.azurewebsites.net/");

                var loginLink = driverHelper.GetElement("LoginPage", "LoginLink");
                loginLink.Click();

                // Get the page elements          
                var emailField = driverHelper.GetElement("LoginPage", "EmailField");
                var passwordField = driverHelper.GetElement("LoginPage", "PasswordField");
                var loginButtonField = driverHelper.GetElement("LoginPage", "LoginButtonField");

                // Type email and password and click the login button        
                emailField.SendKeys(email);
                passwordField.SendKeys(password);
                loginButtonField.Click();

                Assert.AreEqual(true, driverHelper.GetElement("HomePage", "UserLink").Displayed);
                Report.UpdateTestLog("Login contact manager", "Login contact manager successfully", Report.Status.PASS);
            }
            catch(Exception e)
            {
                Report.UpdateTestLog("Login contact manager", "Login contact manager failed", Report.Status.FAIL);
                throw new Exception(e.Message);  
            }
        }
    }
}
