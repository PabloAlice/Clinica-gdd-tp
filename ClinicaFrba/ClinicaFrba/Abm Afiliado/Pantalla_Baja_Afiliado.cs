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
    public partial class Pantalla_Baja_Afiliado : Form
    {
        public Pantalla_Baja_Afiliado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {

                MessageBox.Show("Ingrese algún filtro de búsqueda de afiliado");

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {

                MessageBox.Show("Ingrese algún filtro de búsqueda de afiliado");

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Afiliado dado de baja correctamente");
            this.Close();
        }

   
    }
}
