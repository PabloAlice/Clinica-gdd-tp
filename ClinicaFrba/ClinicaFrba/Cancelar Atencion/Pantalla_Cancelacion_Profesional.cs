using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Pantalla_Cancelacion_Profesional : Form
    {
        string fechaHoy;

        public Pantalla_Cancelacion_Profesional()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MinDate = Convert.ToDateTime(fechaHoy);
            dateTimePicker2.MinDate = Convert.ToDateTime(fechaHoy);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            string fechaIngresada = dateTimePicker1.Value.ToShortDateString();

            
            if (fechaIngresada == fechaHoy)
            {

                MessageBox.Show("No puedes cancelar turnos un mismo día");

            }
            else
            {
                Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional();
                pmcp.guardarDatos(this);
                pmcp.ShowDialog();
               

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string fechaIngresada = dateTimePicker2.Value.ToShortDateString();

            if (fechaIngresada == fechaHoy)
            {

                MessageBox.Show("No puedes cancelar turnos un mismo día");

            }
            else
            {
                dateTimePicker2.Enabled = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button4.Enabled = true;


            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            int outPut;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {

                MessageBox.Show("Complete rango de horario de cancelación");


            }
            else
            {
                if (int.TryParse(textBox1.Text, out outPut) && int.TryParse(textBox2.Text, out outPut))
                {

                        Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional();
                        pmcp.guardarDatos(this);
                        pmcp.ShowDialog();


                }
                else
                {

                    MessageBox.Show("Los horarios deben ser valores numéricos");

                }

            }

        }
    }
}
