using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Tesla.CM.CommonHelper
{
    public class UIMapHelper
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
        public class UIMap
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }

        /// <summary>
        /// Get WebElement from UIMap
        /// </summary>
        /// <param name="uiMapFileName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public IWebElement GetElement(string uiMapFileName, string key)
        {
            var collection = new Dictionary<string, UIMap>();  
            var collectionStr = File.ReadAllText(ExcelHelper.GetAppConfig("prefixUIMapPath") + "\\" + uiMapFileName + ".txt");  
         
            var obj = JsonConvert.DeserializeObject<Dictionary<string, UIMap>>(collectionStr);          
            string type = obj[key].Type;
            string value = obj[key].Value;
            return driver.FindElement(this.getBy(type, value));
        }

        private By getBy(string type, string value)
        {
            By by = null;
            if (type.Equals("Id"))
            {
                by = By.Id(value);
            }
            if (type.Equals("Name"))
            {
                by = By.Name(value);
            }
            if (type.Equals("XPath"))
            {
                by = By.XPath(value);
            }
            if (type.Equals("ClassName"))
            {
                by = By.ClassName(value);
            }
            if (type.Equals("LinkText"))
            {
                by = By.LinkText(value);
            }
            return by;
        }
    }
}