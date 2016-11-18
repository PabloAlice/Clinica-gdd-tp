using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Afiliado_Principal : Form
    {
        public Pantalla_Afiliado_Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pantalla_Creacion_Afiliado pcafiliado = new Pantalla_Creacion_Afiliado();
            pcafiliado.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Pantalla_Baja_Afiliado pbafiliado = new Pantalla_Baja_Afiliado();
            pbafiliado.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Pantalla_Habilitacion_Afiliado phafi = new Pantalla_Habilitacion_Afiliado();
            phafi.ShowDialog();

        }
    }
}
