using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Pantalla_Registro_Consulta_Final : Form
    {
        Pantalla_Registro_Consulta_Principal prcp;

        public Pantalla_Registro_Consulta_Final()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int outPut;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {

                MessageBox.Show("Hay campos vacíos");

            }
            else
            {

                if (int.TryParse(textBox1.Text, out outPut) || int.TryParse(textBox2.Text, out outPut))
                {

                    MessageBox.Show("Lo ingresado no puede ser todo numérico");

                }
                else
                {


                    MessageBox.Show("Consulta registrada exitosamente");
                    this.Close();
                    prcp.Close();


                }



            }
        }

        internal void guardarDatos(Pantalla_Registro_Consulta_Principal pantalla_Registro_Consulta_Principal)
        {
            prcp = pantalla_Registro_Consulta_Principal;
        }
    }
}
