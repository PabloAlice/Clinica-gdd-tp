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
    public partial class Pantalla_Asociacion_Conyuge : Form
    {
        RadioButton radioB;

        public Pantalla_Asociacion_Conyuge()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            comboBox1.Items.Add("DNI");
            comboBox1.Items.Add("CI");
            comboBox1.Items.Add("LE");
            comboBox1.Items.Add("LC");

            comboBox2.Items.Add("Masculino");
            comboBox2.Items.Add("Femenino");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioB!=null)
            {
                DialogResult result1 = MessageBox.Show("Desea asociar a sus familiares?",
                    "Pregunta alta familiar",
                    MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    Pantalla_Asociacion_Familiares pafamiliares = new Pantalla_Asociacion_Familiares();
                    pafamiliares.ShowDialog();


                }
                else
                {


                }

            }
            else
            {



            }

        }

        internal void guardaRadioButton(RadioButton radioButton)
        {
            radioB = radioButton;
        }
    }
}
