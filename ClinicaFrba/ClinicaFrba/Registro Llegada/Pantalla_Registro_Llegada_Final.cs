using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Pantalla_Registro_Llegada_Final : Form
    {
        string fechaHoy;
        Pantalla_Registro_Llegada_Principal prllp;

        public Pantalla_Registro_Llegada_Final()
        {
            InitializeComponent();
            textBox1.Text = "1";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.Value = Convert.ToDateTime(fechaHoy);

            dateTimePicker2.Format = DateTimePickerFormat.Time;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(textBox1.Text) == 0)
            {

                MessageBox.Show("No tiene bonos disponibles para realizar la consulta");

            }
            else
            {

                MessageBox.Show("Llegada registrada correctamente");
                this.Close();
                prllp.Close();


            }
        }

        internal void guardarDatos(Pantalla_Registro_Llegada_Principal pantalla_Registro_Llegada_Principal)
        {
            prllp = pantalla_Registro_Llegada_Principal;
        }
    }
}
