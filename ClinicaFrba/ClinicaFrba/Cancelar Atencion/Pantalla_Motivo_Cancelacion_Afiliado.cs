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
    public partial class Pantalla_Motivo_Cancelacion_Afiliado : Form
    {
        Pantalla_Cancelacion_Afiliado pca;

        public Pantalla_Motivo_Cancelacion_Afiliado()
        {
            InitializeComponent();

            comboBox1.Items.Add("Motivos personales");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

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

                    MessageBox.Show("Turno dado de baja correctamente");
                    this.Close();
                    pca.Close();


                }

            }
        }

        internal void guardarDatos(Pantalla_Cancelacion_Afiliado pantalla_Cancelacion_Afiliado)
        {

            pca = pantalla_Cancelacion_Afiliado;

        }
    }
}
