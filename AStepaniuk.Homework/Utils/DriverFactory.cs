using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;

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
                        var options = new FirefoxOptions();

                        if (ConfigurationManager.AppSettings["HeadlessMode"].Equals("True") ||
                            (TestContext.Parameters["HeadlessMode"] != null && TestContext.Parameters["HeadlessMode"].Equals("True")))
                        {
                            options.AddArguments("-headless");
                        }

                        _driver = new FirefoxDriver(options);
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

                    var options = new ChromeOptions();

                        if (ConfigurationManager.AppSettings["HeadlessMode"].Equals("True") || 
                            (TestContext.Parameters["HeadlessMode"] != null && TestContext.Parameters["HeadlessMode"].Equals("True")))
                        {
                            options.AddArguments("-headless");                           
                        }

                        _driver = new ChromeDriver(options);
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
