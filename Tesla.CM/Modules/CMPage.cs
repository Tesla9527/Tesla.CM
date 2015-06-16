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
    public class CMPage
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
        public void AddContact()
        {
            String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            String folderName = Report.getreportname();
            Report.UpdateTestLogTitle(methodName);

            // Test Data
            DataTable dt = ExcelHelper.GetXlsDataSource(folderName, "AddContact.xls");
            string name = dt.Rows[0]["Name"].ToString();
            string address = dt.Rows[0]["Address"].ToString();
            string city = dt.Rows[0]["City"].ToString();
            string state = dt.Rows[0]["State"].ToString();
            string zip = dt.Rows[0]["Zip"].ToString();
            string email = dt.Rows[0]["Email"].ToString();

            var addContactLink = driver.FindElement(By.XPath("html/body/div[2]/p/a"));
            addContactLink.Click();

            // Get the page elements          
            var nameField = driver.FindElement(By.Id("Name"));
            var addressField = driver.FindElement(By.Id("Address"));
            var cityField = driver.FindElement(By.Id("City"));
            var stateField = driver.FindElement(By.Id("State"));
            var zipField = driver.FindElement(By.Id("Zip"));
            var emailField = driver.FindElement(By.Id("Email"));

            // Input value in the fields and save 
            nameField.SendKeys(name);
            addressField.SendKeys(address);
            cityField.SendKeys(city);
            stateField.SendKeys(state);
            zipField.SendKeys(zip);
            emailField.SendKeys(email);

            var createButton = driver.FindElement(By.XPath("html/body/div[2]/form/div/div[7]/div/input"));
            createButton.Click();
        }
    }
}
