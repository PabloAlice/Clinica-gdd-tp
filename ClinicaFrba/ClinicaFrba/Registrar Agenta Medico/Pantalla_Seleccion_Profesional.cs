using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Pantalla_Seleccion_Profesional : Form
    {
        public Pantalla_Seleccion_Profesional()
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

                MessageBox.Show("Ingrese algun filtro de búsqueda de profesional");


            }
            else
            {

                if (textBox1.Text != "" && textBox2.Text == "")
                {





                }
                else
                {
                    if (textBox1.Text == "" && textBox2.Text != "")
                    {




                    }
                    else
                    {


                        
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pantalla_Registro_Agenda pragenda = new Pantalla_Registro_Agenda();
            pragenda.ShowDialog();
        }
    }
}