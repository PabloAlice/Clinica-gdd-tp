using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Pantalla_Seleccion_Especialidades : Form
    {
        TextBox especialidad;

        public Pantalla_Seleccion_Especialidades()
        {
            InitializeComponent();
            dataGridView1.Rows[0].Cells[0].Value = "asd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            especialidad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            this.Close();
        }

        internal void guardaDatos(TextBox textBox)
        {
            especialidad = textBox;
        }
    }
}
