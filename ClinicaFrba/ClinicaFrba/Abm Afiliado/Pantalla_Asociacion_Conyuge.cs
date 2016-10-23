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
        Pantalla_Creacion_Afiliado pca;
        string fechaHoy;

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

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MaxDate = Convert.ToDateTime(fechaHoy);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPutI;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text)  ||
               comboBox1.Text == "" || comboBox2.Text == "")
            {

                MessageBox.Show("Hay campos vacíos");

            }
            else
            {

                if (int.TryParse(textBox1.Text, out outPutI) || int.TryParse(textBox2.Text, out outPutI) ||
                  (!int.TryParse(textBox3.Text, out outPutI)) || int.TryParse(textBox4.Text, out outPutI) ||
                  (!int.TryParse(textBox5.Text, out outPutI)) || int.TryParse(textBox6.Text, out outPutI))
                {

                    MessageBox.Show("Datos inválidos");

                }
                else
                {

                    if (radioB != null)
                    {
                        DialogResult result1 = MessageBox.Show("Desea asociar a sus familiares?",
                            "Pregunta alta familiar",
                            MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {

                            Pantalla_Asociacion_Familiares pafamiliares = new Pantalla_Asociacion_Familiares();
                            pafamiliares.guardaPlanMedico(this.textBox7.Text);
                            pafamiliares.guardameDos(this);
                            pafamiliares.guardame(pca);
                            pafamiliares.ShowDialog();


                        }
                        else
                        {

                            MessageBox.Show("Registro de cónyuge exitoso");
                            this.Close();
                            pca.Close();


                        }

                    }
                    else
                    {

                        MessageBox.Show("Registros exitosos");
                        Pantalla_Muchos_Afiliados pma = new Pantalla_Muchos_Afiliados();
                        pma.ShowDialog();
                        this.Close();
                        pca.Close();


                    }

                }

            }

        }

        internal void guardaRadioButton(RadioButton radioButton)
        {
            radioB = radioButton;
        }

        internal void guardaPlanMedico(string p)
        {
            this.textBox7.Text = p;
        }

        internal void guardame(Pantalla_Creacion_Afiliado pantalla_Creacion_Afiliado)
        {

            pca = pantalla_Creacion_Afiliado;

        }


    }
}
