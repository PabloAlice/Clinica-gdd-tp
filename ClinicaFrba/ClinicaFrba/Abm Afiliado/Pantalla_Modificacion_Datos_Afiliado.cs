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
    public partial class Pantalla_Modificacion_Datos_Afiliado : Form
    {

        Pantalla_Modificacion_Afiliado_Principal pmap;

        public Pantalla_Modificacion_Datos_Afiliado()
        {
            InitializeComponent();

            comboBox2.Items.Add("Masculino");
            comboBox2.Items.Add("Femenino");

            comboBox3.Items.Add("Soltero/a");
            comboBox3.Items.Add("Casado/a");
            comboBox3.Items.Add("Viudo/a");
            comboBox3.Items.Add("Concubinato");
            comboBox3.Items.Add("Divorciado/a");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPutI;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox9.Text))
            {

                MessageBox.Show("Hay campos vacíos");

            }
            else
            {

                if ((!int.TryParse(textBox1.Text, out outPutI)) || int.TryParse(textBox2.Text, out outPutI) ||
                int.TryParse(textBox4.Text, out outPutI))
                {

                    MessageBox.Show("Datos inválidos");

                }
                else
                {

                    MessageBox.Show("Datos modificados correctamente");
                    this.Close();
                    pmap.Close();


                }

            }
        }

        internal void guardarDatos(Pantalla_Modificacion_Afiliado_Principal pantalla_Modificacion_Afiliado_Principal)
        {

            pmap = pantalla_Modificacion_Afiliado_Principal;

        }
    }
}
