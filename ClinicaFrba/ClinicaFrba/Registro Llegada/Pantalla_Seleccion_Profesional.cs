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
    public partial class Pantalla_Seleccion_Profesional : Form
    {
        TextBox nombreProfesional;
        TextBox ApellidoProfesional;
        TextBox especialidad;

        public Pantalla_Seleccion_Profesional()
        {
            InitializeComponent();
            dataGridView1.Rows[0].Cells[0].Value = "Fabian";
            dataGridView1.Rows[0].Cells[1].Value = "Rodriguez";
            comboBox1.Items.Add("Kinesiologia");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 


        internal void guardaDatos(TextBox textBox1, TextBox textBox2,TextBox textBox3)
        {
            nombreProfesional = textBox1;
            ApellidoProfesional = textBox2;
            especialidad = textBox3;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nombreProfesional.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            ApellidoProfesional.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            especialidad.Text = comboBox1.Text;

            this.Close();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {

                MessageBox.Show("Seleccione alguna especialidad");

            }
        }
    }
}
