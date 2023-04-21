using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Calibrador_GCM5000.Model
{
    class Selenium
    {
        public IWebDriver driver;

        public void IniciarChrome()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions opt = new ChromeOptions();

            opt.AddArgument("start-maximized");
            opt.AddArgument("--disable-blink-features=AutomationControlled");

            List<string> ls = new List<string>
            {
                "enable-automation",
                "excludeSwitches",
                "enable-logging",
                "disable-popup-blocking"
            };
            opt.AddExcludedArguments(ls);

            //opt.AddExcludedArgument("enabled-automation");
            opt.AddAdditionalOption("useAutomationExtension", false);

            service.HideCommandPromptWindow = !Debugger.IsAttached;

            driver = new ChromeDriver(service, opt);
        }

        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public void Navigate(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void HoldTime(double Time)
        {
            Time *= 1000;
            Application.DoEvents();
            Thread.Sleep(TimeSpan.FromMilliseconds(Time));
        }

        public void WaitPageLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString().Equals("complete"));
        }

        public void WaitElementToBeDisplayed(By Parametro)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
            wait.Until(wd => driver.FindElement(Parametro).Displayed);
        }

        public void Click(By Paramtero)
        {
            try
            {
                var element = driver.FindElement(Paramtero);
                element.Click();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Click(By Paramtero, string Atributo, string Valor)
        {
            try
            {
                var element = driver.FindElements(Paramtero).FirstOrDefault(x => x.GetAttribute(Atributo).ToUpper().Equals(Valor.ToUpper()));
                element?.Click();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Click(IWebElement Elemento, By Paramtero)
        {
            try
            {
                var element = Elemento.FindElement(Paramtero);
                element.Click();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Click(IWebElement Elemento, By Paramtero, string Atributo, string Valor)
        {
            try
            {
                var element = Elemento.FindElements(Paramtero).FirstOrDefault(x => x.GetAttribute(Atributo).ToUpper().Equals(Valor.ToUpper()));
                element?.Click();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendKeys(By Parametro, string Valor)
        {
            driver.FindElement(Parametro).SendKeys(Valor);
        }
    }
}
