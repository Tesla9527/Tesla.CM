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
            CMPage.AddContact();
            HomePage.LogoutCM();
        }

        #region TestInitialize and TestCleanup

        private FirefoxDriver driver;
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
          // Initialize the Firefox Driver
          driver = new FirefoxDriver();
          driver.Manage().Window.Maximize();
          LoginPage = new LoginPage();
          LoginPage.setDriver(driver);
          HomePage = new HomePage();
          HomePage.setDriver(driver);
          CMPage = new CMPage();
          CMPage.setDriver(driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Close Firefox and quit driver
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
