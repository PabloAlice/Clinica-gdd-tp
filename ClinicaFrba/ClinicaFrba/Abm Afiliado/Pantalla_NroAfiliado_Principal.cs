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
    public partial class Pantalla_NroAfiliado_Principal : Form
    {
        public Pantalla_NroAfiliado_Principal(int nroAfi)
        {
            InitializeComponent();

            this.textBox1.Text = Convert.ToString(nroAfi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("El registro se ha realizado correctamente");

        }
    }
}
