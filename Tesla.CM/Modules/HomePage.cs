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
        FirefoxDriver driver;
        public FirefoxDriver getDriver()
        {
            return driver;
        }

        public void setDriver(FirefoxDriver driver)
        {
            this.driver = driver;
        }
        public void NavigateToCMPage()
        {
            String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            String folderName = Report.getreportname();
            Report.UpdateTestLogTitle(methodName);

            var cmDemoLink = driver.FindElement(By.XPath("html/body/div[1]/div/div[1]/a"));
            cmDemoLink.Click();           
        }

        public void LogoutCM()
        {
            String methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            String folderName = Report.getreportname();
            Report.UpdateTestLogTitle(methodName);

            var logoutLink = driver.FindElement(By.Id("logoutForm"));
            logoutLink.Click();
        }
    }
}
