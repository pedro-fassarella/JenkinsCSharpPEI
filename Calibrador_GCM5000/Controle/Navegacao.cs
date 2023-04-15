using OpenQA.Selenium;

namespace Calibrador_GCM5000.Controle
{
    class Navegacao
    {
        private Selenium rs = new Selenium();

        public Navegacao()
        {
            rs.IniciarChrome();
        }

        public bool Iniciar()
        {
            if (!AcessarSite()) return false;


            return true;
        }

        private bool AcessarSite()
        {
            rs.Navigate("https://portal.multivix.edu.br/Corpore.Net/Login.aspx");
            rs.WaitPageLoad();

            var bannerCookies = rs.driver.FindElement(By.Id("onetrust-banner-sdk"));

            rs.Click(bannerCookies, By.Id("onetrust-accept-btn-handler"));
            rs.HoldTime(0.5);

            rs.Click(By.Id("txtUser"));
            rs.SendKeys(By.Id("txtUser"), "1-1920432"); rs.HoldTime(0.1);

            rs.Click(By.Id("txtPass"));
            rs.SendKeys(By.Id("txtPass"), "pedroasd123"); rs.HoldTime(0.1);

            rs.Click(By.Id("btnLogin")); rs.HoldTime(0.5);
            rs.WaitPageLoad();

            return true;
        }
    }
}
