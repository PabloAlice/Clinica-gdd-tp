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
    public partial class Pantalla_Modificacion_Afiliado_Principal : Form
    {
        public Pantalla_Modificacion_Afiliado_Principal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {

                MessageBox.Show("Ingrese algún filtro de búsqueda de afiliado");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pantalla_Modificacion_Datos_Afiliado pmdafiliado = new Pantalla_Modificacion_Datos_Afiliado();
            pmdafiliado.ShowDialog();
        }
    }
}
