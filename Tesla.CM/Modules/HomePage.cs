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
            //uiMapper.setDriver(driver);
            String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            String folderName = Report.getreportname();
            Report.UpdateTestLogTitle(methodName);

            var cmDemoLink = driverHelper.GetElement("HomePage", "CMDemoLink");
            cmDemoLink.Click();           
        }

        /// <summary>
        /// Logout contact manager
        /// </summary>
        public void LogoutCM()
        {
            //uiMapper.setDriver(driver);
            String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            String folderName = Report.getreportname();
            Report.UpdateTestLogTitle(methodName);

            var logoutLink = driverHelper.GetElement("HomePage", "logoutLink");
            logoutLink.Click();
        }
    }
}
