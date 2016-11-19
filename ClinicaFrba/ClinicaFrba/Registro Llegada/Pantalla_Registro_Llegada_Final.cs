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
        Pantalla_Registro_Turno prt;
        int cantBonos;
        decimal idAfiliado;
        int nroTurno;

        public Pantalla_Registro_Llegada_Final(decimal idAfi,int bonos,int nroT)
        {
            InitializeComponent();

            textBox1.Text = Convert.ToString(bonos) ;

            nroTurno = nroT;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            idAfiliado =idAfi;

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
            GD2C2016DataSetTableAdapters.Consulta_MedicaTableAdapter consultaAdapter = new GD2C2016DataSetTableAdapters.Consulta_MedicaTableAdapter();

            if (Convert.ToInt16(textBox1.Text) == 0)
            {

                MessageBox.Show("No tiene bonos disponibles para realizar la consulta. Compre si desea");

            }
            else
            {
                consultaAdapter.registrarLlegada(idAfiliado, nroTurno,Convert.ToDateTime(fechaHoy));

                MessageBox.Show("Llegada registrada correctamente");
                this.Close();
                prt.Close();
                prllp.Close();


            }
        }

        internal void guardarDatos(Pantalla_Registro_Turno prt2, Pantalla_Registro_Llegada_Principal prllp2)
        {
            prllp = prllp2;
            prt = prt2;
        }
    }
}
