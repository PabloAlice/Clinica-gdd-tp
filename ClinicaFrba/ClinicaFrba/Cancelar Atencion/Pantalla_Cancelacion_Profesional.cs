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

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MinDate = Convert.ToDateTime(fechaHoy);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == fechaHoy)
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
    }
}
