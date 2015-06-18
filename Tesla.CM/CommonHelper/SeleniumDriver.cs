using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace Tesla.CM.CommonHelper
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        public IWebDriver getDriver()
        {
            return driver;
        }
        public SeleniumDriver()
        {
            this.initialDriver();
        }
        private void initialDriver()
        {
            if ("firefox".Equals(ExcelHelper.GetAppConfig("Browser")))
            {
                driver = new FirefoxDriver();
            }
            if ("ie".Equals(ExcelHelper.GetAppConfig("Browser")))
            {
                driver = new InternetExplorerDriver();
            }
            if ("chrome".Equals(ExcelHelper.GetAppConfig("Browser")))
            {
                driver = new ChromeDriver();
            }
        }
    }
}
