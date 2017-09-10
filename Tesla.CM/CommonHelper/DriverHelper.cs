using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace Tesla.CM.CommonHelper
{
    public class DriverHelper
    {
        IWebDriver driver;
        public DriverHelper(IWebDriver _driver)
        {
            driver = _driver;
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

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return OpenQA.Selenium.Support.UI.ExpectedConditions.ElementExists(this.getBy(type, value)); });
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
            if (type.Equals("CssSelector"))
            {
                by = By.CssSelector(value);
            }
            return by;
        }

        internal INavigation Navigate()
        {
            return driver.Navigate();
        }

        internal ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        /// <summary>
        /// Scroll to let element show on page  
        /// </summary>
        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// Accepts the alert
        /// </summary>
        public void AlertAccept()
        {
            IAlert alert = null;
            int i = 0;
            while (i++ < 5)
            {
                try
                {
                    alert = driver.SwitchTo().Alert();
                    if (alert != null)
                    {
                        alert.Accept();
                    }
                    break;
                }
                catch (NoAlertPresentException e)
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
            }

        }

        /// <summary>
        /// Get the alert text
        /// </summary>
        /// <returns></returns>
        public string GetAlertString()
        {
            int i = 0;
            IAlert alert = null;
            string theString = string.Empty;
            while (i++ < 5)
            {
                try
                {
                    alert = driver.SwitchTo().Alert();
                    if (alert != null)
                    {
                        theString = alert.Text;

                    }
                    break;
                }
                catch (NoAlertPresentException e)
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
            }
            return theString;
        }

        /// <summary>
        /// Switch to the newly opened window
        /// </summary>
        public void SwitchToNewWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Select option in dropdown box
        /// </summary>
        public void SelectOption(IWebElement element, string optionContent)
        {
            element.Click();
            var option = new SelectElement(element);
            option.SelectByText(optionContent);
        }

        /// <summary>
        /// Effects throughout the life of web driver
        /// Set once only if necessary
        /// </summary>
        /// <param name="seconds"></param>
        public void ImplicitlyWait(double seconds)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }
        
        public void MoveToElementAndOffsetThenClick(IWebElement element, int x, int y)
        {
            Actions builder = new Actions(driver);
            Actions hoverClick = builder.MoveToElement(element).MoveByOffset(x, y).Click();
            hoverClick.Build().Perform();
        }

        public void CloseCurrentTab()
        {
            var popup = driver.WindowHandles[1]; // handler for the new tab

            driver.SwitchTo().Window(driver.WindowHandles[1]).Close(); // close the tab
            driver.SwitchTo().Window(driver.WindowHandles[0]); // get back to the main window

        }
    }
}
