using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Pantalla_Fecha_Vigencia_Agenda : Form
    {

        Pantalla_Selecc_Profesional psp;
        string fechaHoy;

        public Pantalla_Fecha_Vigencia_Agenda()
        {
            InitializeComponent();

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker1.MinDate = Convert.ToDateTime(fechaHoy);

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.MinDate = Convert.ToDateTime(fechaHoy);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaInicioAgenda;
            DateTime fechaFinAgenda;

            int result = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);

            if (result <= 0){

            MessageBox.Show("La fecha de fin de la agenda no puede ser menor o igual a la de inicio");
            
            }
            else
            {

                fechaInicioAgenda = dateTimePicker2.Value;

                fechaFinAgenda = dateTimePicker1.Value;

                Pantalla_Registro_Agenda pragenda = new Pantalla_Registro_Agenda();
                pragenda.guardarDatos(psp, this,fechaInicioAgenda,fechaFinAgenda);
                pragenda.ShowDialog();
            
            }            

        }

        internal void guardarDatos(Pantalla_Selecc_Profesional pantalla_Selecc_Profesional)
        {
            psp = pantalla_Selecc_Profesional;
        }
    }
}
