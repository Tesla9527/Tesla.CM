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
        DriverHelper driverHelper;
        public CMPage(DriverHelper _driverHelper)
        {
            driverHelper = _driverHelper;
        }
        /// <summary>
        /// Add a new contact
        /// </summary>
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

            var addContactLink = driverHelper.GetElement("CMPage", "addContactLink");
            addContactLink.Click();

            // Get the page elements          
            var nameField = driverHelper.GetElement("CMPage", "nameField");
            var addressField = driverHelper.GetElement("CMPage", "addressField");
            var cityField = driverHelper.GetElement("CMPage", "cityField");
            var stateField = driverHelper.GetElement("CMPage", "stateField");
            var zipField = driverHelper.GetElement("CMPage", "zipField");
            var emailField = driverHelper.GetElement("CMPage", "emailField");
            var createButton = driverHelper.GetElement("CMPage", "createButton");

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
