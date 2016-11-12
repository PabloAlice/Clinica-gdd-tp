using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Pantalla_Registro_Consulta_Principal : Form
    {
        GD2C2016DataSetTableAdapters.TurnosDeProfesionalDelDiaTableAdapter turnosAdapter;
        GD2C2016DataSet.TurnosDeProfesionalDelDiaDataTable turnosData;

        string fechaHoy;
        decimal idUser;

        public Pantalla_Registro_Consulta_Principal(decimal idU)
        {
            InitializeComponent();

            idUser = idU;

            turnosAdapter = new GD2C2016DataSetTableAdapters.TurnosDeProfesionalDelDiaTableAdapter();
                        
            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();


            turnosData = turnosAdapter.obtenerTurnosDeProfesionalDelDia(idUser, fechaHoy);

            foreach (DataRow turno in turnosData.Rows)
            {

                dataGridView1.Rows.Add(turno.Field<decimal>("numero"),
                                       turno.Field<decimal>("numero_afiliado"),
                                       turno.Field<string>("nombre"),
                                       turno.Field<string>("apellido"),
                                       turno.Field<DateTime>("fecha"));


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal nroTurno = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].Value);
            DateTime fechaConsulta = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);


            Pantalla_Registro_Consulta_Final prcf = new Pantalla_Registro_Consulta_Final(nroTurno,fechaConsulta);
            prcf.guardarDatos(this);
            prcf.ShowDialog();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
