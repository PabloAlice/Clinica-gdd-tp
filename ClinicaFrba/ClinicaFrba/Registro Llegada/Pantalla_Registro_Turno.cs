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
    public partial class Pantalla_Registro_Turno : Form
    {

        Pantalla_Registro_Llegada_Principal prlp;
        string nombre;
        string apellido;
        decimal IDespecialidad;
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;
        GD2C2016DataSetTableAdapters.obtenerProfesionalesDelDiaPorTableAdapter turnosAdapter;
        GD2C2016DataSet.obtenerProfesionalesDelDiaPorDataTable turnosData;
        string fechaHoy;

        public Pantalla_Registro_Turno(string nombreP,string apellidoP,string especialidad)
        {
            InitializeComponent();

            nombre = nombreP;

            apellido = apellidoP;

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();

            turnosAdapter = new GD2C2016DataSetTableAdapters.obtenerProfesionalesDelDiaPorTableAdapter();

            espeData = espeAdapter.obtenerEspecialidades();

            foreach (DataRow espe in espeData.Rows)
            {

                if (espe.Field<string>("descripcion") == especialidad)
                {

                    IDespecialidad = espe.Field<decimal>("codigo");

                }

            }

            turnosData = turnosAdapter.obtenerTurnosDelProfesionalDelDiaPor(nombre, apellido, IDespecialidad, fechaHoy);

            foreach (DataRow turno in turnosData.Rows)
            {

                dataGridView1.Rows.Add(turno.Field<decimal>("id"),
                                       turno.Field<string>("nombre"),
                                       turno.Field<string>("apellido"),
                                       turno.Field<DateTime>("fecha"));


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            Pantalla_Registro_Llegada_Final prlf = new Pantalla_Registro_Llegada_Final();
            prlf.guardarDatos(this, prlp);
            prlf.ShowDialog();

        }


        internal void guardarDatos(Pantalla_Registro_Llegada_Principal pantalla_Registro_Llegada_Principal)
        {

            prlp = pantalla_Registro_Llegada_Principal;

        }
    }
}
