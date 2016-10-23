using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Pantalla_Seleccion_Turno : Form
    {
        Pantalla_PedidoTurno_Principal pptp;
        string fechaHoy;

        public Pantalla_Seleccion_Turno()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MinDate = Convert.ToDateTime(fechaHoy);

            this.listBox1.Items.Add("asd");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {

                MessageBox.Show("Seleccione algun horario para el turno");

            }
            else
            {

                MessageBox.Show("Registro de turno exitoso");
                Pantalla_Nro_Turno pnturno = new Pantalla_Nro_Turno();
                pnturno.guardaPantalla(this,pptp);
                pnturno.ShowDialog();


            }
        }


        internal void guardarDatos(Pantalla_PedidoTurno_Principal pantalla_PedidoTurno_Principal)
        {
            pptp = pantalla_PedidoTurno_Principal;
        }
    }
}
