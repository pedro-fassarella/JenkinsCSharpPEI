using Calibrador_GCM5000.Model;
using OpenQA.Selenium;
using System.Threading;

namespace Calibrador_GCM5000.Controle
{
    class Navegacao
    {
        private Selenium rs = new Selenium();
        public Thread T1;
        public bool Resposta;

        public Navegacao() => Processar();

        private void Processar()
        {
            rs.IniciarChrome();

            T1 = new Thread(Iniciar) { Name = "Thread #1" };
            T1.SetApartmentState(ApartmentState.STA);
            T1.Start();
        }

        public void Iniciar()
        {
            Resposta = AcessarSite();
        }

        private bool AcessarSite()
        {
            rs.Navigate("https://portal.multivix.edu.br/Corpore.Net/Login.aspx");
            rs.WaitPageLoad(); rs.HoldTime(1);

            rs.WaitElementToBeDisplayed(By.Id("onetrust-banner-sdk"));

            var bannerCookies = rs.driver.FindElement(By.Id("onetrust-banner-sdk"));
            rs.Click(bannerCookies, By.Id("onetrust-accept-btn-handler"));
            rs.HoldTime(0.5);

            rs.Click(By.Id("txtUser"));
            rs.SendKeys(By.Id("txtUser"), "1-1920432"); rs.HoldTime(0.1);

            rs.Click(By.Id("txtPass"));
            rs.SendKeys(By.Id("txtPass"), "pedroasd123"); rs.HoldTime(0.1);

            rs.Click(By.Id("btnLogin")); rs.HoldTime(0.5);
            rs.WaitPageLoad();

            rs.driver.Quit();

            return true;
        }
    }
}
