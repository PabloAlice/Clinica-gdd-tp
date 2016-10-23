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
            Pantalla_Registro_Llegada_Final prllf = new Pantalla_Registro_Llegada_Final();
            prllf.guardarDatos(this);
            prllf.ShowDialog();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            Pantalla_Seleccion_Profesional psprofesional = new Pantalla_Seleccion_Profesional();
            psprofesional.guardaDatos(this.textBox1, this.textBox2,this.textBox3);
            psprofesional.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {

                MessageBox.Show("Complete nombre y apellido del profesional o búsquelo por especialidad");

            }
            else
            {
   


            }


        }

    }

}
 
      

    

