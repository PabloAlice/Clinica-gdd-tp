using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Pantalla_Cancelacion_Afiliado : Form
    {
        string fechaHoy;
        GD2C2016DataSetTableAdapters.turnosDeAfiliadoTableAdapter turnosAdapter;
        GD2C2016DataSet.turnosDeAfiliadoDataTable turnosData;
        decimal idUser;

        public Pantalla_Cancelacion_Afiliado(int idU)
        {
            InitializeComponent();

            idUser = idU;

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();


            GD2C2016DataSetTableAdapters.turnosDeAfiliadoTableAdapter turnosAdapter = new GD2C2016DataSetTableAdapters.turnosDeAfiliadoTableAdapter();


            turnosData = turnosAdapter.obtenerTurnosDeAfiliado(Convert.ToDecimal(idUser));


            foreach (DataRow turno in turnosData.Rows)
            {

                dataGridView1.Rows.Add(turno.Field<decimal>("numero"),
                                       turno.Field<string>("nombre"),
                                       turno.Field<string>("apellido"),
                                       turno.Field<string>("descripcion"),
                                       turno.Field<DateTime>("fecha"));


            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime fechaTime = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);

            string fechaTurno = fechaTime.Date.ToShortDateString();

            if (fechaTurno == fechaHoy)
            {

                MessageBox.Show("No puede cancelar una consulta el mismo día de atención de la misma");

            }
            else
            {

                decimal idTurno = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].Value);

                Pantalla_Motivo_Cancelacion_Afiliado pmc = new Pantalla_Motivo_Cancelacion_Afiliado(idUser,idTurno);
                pmc.guardarDatos(this);
                pmc.ShowDialog();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
