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
    public partial class Pantalla_Asociacion_Familiares : Form
    {

        Pantalla_Creacion_Afiliado pca;
        Pantalla_Asociacion_Conyuge pac;
        string fechaHoy;

        public Pantalla_Asociacion_Familiares()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MaxDate = Convert.ToDateTime(fechaHoy);

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
                    DialogResult result1 = MessageBox.Show("Desea asociar a más familiares?",
                       "Pregunta asociación familiares",
                       MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {

                        textBox1.ResetText();
                        textBox2.ResetText();
                        textBox3.ResetText();
                        textBox4.ResetText();
                        textBox5.ResetText();
                        textBox6.ResetText();


                    }
                    else
                    {

                        MessageBox.Show("Registro exitoso");
                        Pantalla_Muchos_Afiliados pma = new Pantalla_Muchos_Afiliados();
                        pma.ShowDialog();
                        this.Close();
                        pca.Close();

                        if (pac != null)
                        {
                            pac.Close();
                        }

                    }

                }
            }
        }

        internal void guardaPlanMedico(string p)
        {
            this.textBox7.Text = p;
        }

        internal void guardame(Pantalla_Creacion_Afiliado pantalla_Creacion_Afiliado)
        {
            pca = pantalla_Creacion_Afiliado;
        }

        internal void guardameDos(Pantalla_Asociacion_Conyuge pantalla_Asociacion_Conyuge)
        {
            pac = pantalla_Asociacion_Conyuge;
        }

    }
}