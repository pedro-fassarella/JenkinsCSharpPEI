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
        public Thread T1;

        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)=> Application.Exit();

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            SetT1();
        }

        private void Inicio()
        {
            Navegacao nav = new Navegacao();
            nav.Iniciar();
        }

        private void SetT1()
        {
            T1 = new Thread(Inicio)
            {
                Name = "Thread #1",
            };

            T1.SetApartmentState(ApartmentState.STA);
            T1.Start();
        }
    }
}
