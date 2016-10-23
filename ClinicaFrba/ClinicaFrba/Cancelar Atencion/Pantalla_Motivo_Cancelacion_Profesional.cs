using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Pantalla_Motivo_Cancelacion_Profesional : Form
    {
        Pantalla_Cancelacion_Profesional pcp;

        public Pantalla_Motivo_Cancelacion_Profesional()
        {
            InitializeComponent();
            comboBox1.Items.Add("Urgencia");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void guardarDatos(Pantalla_Cancelacion_Profesional pantalla_Cancelacion_Profesional)
        {
            pcp = pantalla_Cancelacion_Profesional;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPut;

            if (comboBox1.Text=="" || string.IsNullOrWhiteSpace(textBox1.Text))
            {

                MessageBox.Show("Quedan datos por completar");


            }
            else
            {
                if (int.TryParse(textBox1.Text, out outPut))
                {

                    MessageBox.Show("El motivo no puede ser todo numérico");


                }
                else
                {

                    MessageBox.Show("Turno/s dado/s de baja correctamente");
                    this.Close();
                    pcp.Close();


                }

            }


        }

  
    }
}
