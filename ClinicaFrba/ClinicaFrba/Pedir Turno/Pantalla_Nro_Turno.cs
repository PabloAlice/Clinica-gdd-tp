using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Pantalla_Nro_Turno : Form
    {
        Pantalla_Seleccion_Turno psturno;
        Pantalla_PedidoTurno_Principal pptp;


        public Pantalla_Nro_Turno()
        {
            InitializeComponent();
        }

        internal void guardaPantalla(Pantalla_Seleccion_Turno pantalla_Seleccion_Turno,Pantalla_PedidoTurno_Principal ppt)
        {
            psturno = pantalla_Seleccion_Turno;
            pptp = ppt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            psturno.Close();
            pptp.Close();
        }
    }
}
