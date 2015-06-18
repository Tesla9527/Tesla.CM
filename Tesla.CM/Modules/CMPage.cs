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
        IWebDriver driver;       
        public IWebDriver getDriver()
        {
            return driver;
        }

        public void setDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        UIMapHelper uiMapper = new UIMapHelper();

        /// <summary>
        /// Add a new contact
        /// </summary>
        public void AddContact()
        {
            uiMapper.setDriver(driver);
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

            var addContactLink = uiMapper.GetElement("CMPage", "addContactLink");
            addContactLink.Click();

            // Get the page elements          
            var nameField = uiMapper.GetElement("CMPage", "nameField");
            var addressField = uiMapper.GetElement("CMPage", "addressField");
            var cityField = uiMapper.GetElement("CMPage", "cityField");
            var stateField = uiMapper.GetElement("CMPage", "stateField");
            var zipField = uiMapper.GetElement("CMPage", "zipField");
            var emailField = uiMapper.GetElement("CMPage", "emailField");
            var createButton = uiMapper.GetElement("CMPage", "createButton");

            // Input value in the fields and save 
            nameField.SendKeys(name);
            addressField.SendKeys(address);
            cityField.SendKeys(city);
            stateField.SendKeys(state);
            zipField.SendKeys(zip);
            emailField.SendKeys(email);
            createButton.Click();
        }
    }
}
