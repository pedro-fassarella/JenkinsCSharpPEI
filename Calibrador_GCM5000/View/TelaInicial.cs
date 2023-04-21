using Calibrador_GCM5000.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calibrador_GCM5000.View
{
    public partial class TelaInicial : Form
    {

        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e) => Application.Exit();

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            NavegarSite();
        }

        private void NavegarSite()
        {
            Navegacao nav = new Navegacao();

            do
                Thread.Sleep(TimeSpan.FromSeconds(1));
            while (!nav.Resposta);

            nav.T1.Abort(100);
            nav.T1.Join();

            Hide(); Dispose();
            Application.Exit();
        }

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            CalibracaoCalculo calc = new CalibracaoCalculo();

            calc.Calcular();

            NavegarSite();
        }
    }
}
