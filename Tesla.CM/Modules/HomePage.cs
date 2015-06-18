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
    public class HomePage
    {
        DriverHelper driverHelper;
        public HomePage(DriverHelper _driverHelper)
        {
            driverHelper = _driverHelper;
        }

        /// <summary>
        /// Navigate to contact manager page
        /// </summary>
        public void NavigateToCMPage()
        {
            try
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String folderName = Report.getreportname();
                Report.UpdateTestLogTitle(methodName);

                var cmDemoLink = driverHelper.GetElement("HomePage", "CMDemoLink");
                cmDemoLink.Click();

                Assert.AreEqual(true,   driverHelper.GetElement("CMPage", "addContactLink").Displayed);
                Report.UpdateTestLog("Navigate to contact manager page", "Navigate to contact manager page successfully", Report.Status.PASS);
            }
            catch
            {
                Report.UpdateTestLog("Navigate to contact manager page", "Navigate to contact manager page failed", Report.Status.FAIL);
            }
                    
        }

        /// <summary>
        /// Logout contact manager
        /// </summary>
        public void LogoutCM()
        {
            try
            {
                String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                String folderName = Report.getreportname();
                Report.UpdateTestLogTitle(methodName);

                var logoutLink = driverHelper.GetElement("HomePage", "logoutLink");
                logoutLink.Click();

                Assert.AreEqual(true, driverHelper.GetElement("LoginPage", "LoginLink").Displayed);
                Report.UpdateTestLog("Logout Contact manager", "Logout Contact manager successfully", Report.Status.PASS);
            }
            catch
            {
                Report.UpdateTestLog("Logout Contact manager", "Logout Contact manager failed", Report.Status.FAIL);
            }            
        }
    }
}
