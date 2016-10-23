using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class Pantalla_Profesionales_Menos_Horas_Trabajo : Form
    {
        public Pantalla_Profesionales_Menos_Horas_Trabajo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {

                MessageBox.Show("Complete el plan y la especialidad");

            }
            else
            {




            }
        }
    }
}
