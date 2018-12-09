using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Serilog;
using System;
using System.Collections.Generic;

namespace Stepaniuk.Homework.Utils
{
    static class DriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> _driverDictionary = new Dictionary<string, IWebDriver>();
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {                      
                return _driver;                
            }
            private set
            {
                _driver = value;
            }
        }

        public static void InstantiateDriver(string driverType)
        {
            switch (driverType)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        _driver = new FirefoxDriver();
                        _driverDictionary.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        _driver = new InternetExplorerDriver();
                        _driverDictionary.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        _driver = new ChromeDriver();
                        _driverDictionary.Add("Chrome", Driver);
                    }
                    break;
            }

            Log.Information($"Initializing {driverType} driver...");
            _driver.Manage().Window.Maximize();
            Log.Debug("Setting browser window to maximum...");
        }       

        public static void CloseAllDrivers()
        {
            foreach (var key in _driverDictionary.Keys)
            {
                Log.Information($"Closing driver instance...");
                _driverDictionary[key].Quit();
            }
        }
    }
}
