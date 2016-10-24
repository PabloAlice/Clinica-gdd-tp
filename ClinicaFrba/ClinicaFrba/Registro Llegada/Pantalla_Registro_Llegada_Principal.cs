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
    public partial class Pantalla_Registro_Llegada_Principal : Form
    {
        public Pantalla_Registro_Llegada_Principal()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pantalla_Registro_Turno prt = new Pantalla_Registro_Turno();
            prt.guardarDatos(this);
            prt.ShowDialog();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            Pantalla_Seleccion_Especialidades pse = new Pantalla_Seleccion_Especialidades();
            pse.guardaDatos(this.textBox3);
            pse.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) &&
                string.IsNullOrWhiteSpace(textBox3.Text))
            {

                MessageBox.Show("Complete los filtros de búsqueda");

            }
            else
            {

                if (((!string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text)) &&
                (!string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))) ||
                ((string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)) &&
                (!string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))))
                {

                    MessageBox.Show("Nombre y apellido deben estar completos");

                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                        !string.IsNullOrWhiteSpace(textBox3.Text))
                    {



                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox3.Text))
                        {



                        }
                        else
                        {



                        }



                    }


                }


            }

        }

    }

}
 
 

    

