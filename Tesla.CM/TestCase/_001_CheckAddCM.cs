using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Tesla.CM.CommonHelper;
using System.Data;
using Tesla.CM.Modules;

namespace Tesla.CM
{
    [TestClass]
    public class _001_CheckAddCM
    {
        [TestMethod]
        public void _001__CheckAddCM()
        {
            LoginPage.LoginCM();
            HomePage.NavigateToCMPage();
            CMPage.AddContact(0);
            HomePage.LogoutCM();
        }

        #region TestInitialize and TestCleanup
      
        private IWebDriver driver;        
        private LoginPage LoginPage;
        private HomePage HomePage;
        private CMPage CMPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContextInstance)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomainAssemblyResolver.Resolver);
        }

        [TestInitialize]
        public void TestInitialize()
        {
           Initialize(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
          // Initialize Driver
          SeleniumDriver selenium = new SeleniumDriver();
          driver = selenium.getDriver();
          driver.Manage().Window.Maximize();
          var driverHelper = new DriverHelper(driver);
          LoginPage = new LoginPage(driverHelper);
          HomePage = new HomePage(driverHelper);
          CMPage = new CMPage(driverHelper);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Quit driver
            driver.Close();
            driver.Quit();
            CloseReport();
            Assert.AreEqual(0, Report.getfailno());
        }

        public static void Initialize(string reportname)
        {
            bool takeScreenshotFailedStep = Convert.ToBoolean(ExcelHelper.GetAppConfig("TakeScreenshotFailedStep"));
            bool takeScreenshotPassedStep = Convert.ToBoolean(ExcelHelper.GetAppConfig("TakeScreenshotPassedStep"));

            string reportpath = ExcelHelper.GetAppConfig("reportPath");

            Report.InitialReport(reportpath, reportname, takeScreenshotFailedStep, takeScreenshotPassedStep);

            Report.CreateTestLogHeader("Contact Manager Demo");

            Report.setstepno(0);

            Report.setpassno(0);

            Report.setfailno(0);

            Report.setstarttime(DateTime.Now);
        }
        public static void CloseReport()
        {
            Report.setendtime(DateTime.Now);

            Report.CreateTestLogFooter(Util.GetTimeDifference(Report.getstarttime(), Report.getendtime()), Report.getpassno(), Report.getfailno());
        }
        #endregion
    }
}
