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
        decimal idProfesional;
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;
        GD2C2016DataSetTableAdapters.TurnosDeProfesionalDelDiaTableAdapter turnosAdapter;
        GD2C2016DataSet.TurnosDeProfesionalDelDiaDataTable turnosData;
        string fechaHoy;

        public Pantalla_Registro_Turno(decimal idP)
        {
            InitializeComponent();

            idProfesional = idP;

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();

            turnosAdapter = new GD2C2016DataSetTableAdapters.TurnosDeProfesionalDelDiaTableAdapter();

            espeData = espeAdapter.obtenerEspecialidades();

    
            turnosData = turnosAdapter.obtenerTurnosDeProfesionalDelDia(idProfesional,Convert.ToDateTime(fechaHoy));

            foreach (DataRow turno in turnosData.Rows)
            {

                dataGridView1.Rows.Add(turno.Field<decimal>("numero"),
                                       turno.Field<decimal>("id"),
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

            GD2C2016DataSetTableAdapters.BonoTableAdapter bonoAdapter = new GD2C2016DataSetTableAdapters.BonoTableAdapter();

            decimal idAfiliado = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
            int nroTurno = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            int cantBonos = Convert.ToInt16(bonoAdapter.obtenerCantidadBonosDisponiblesPorAfiliado(idAfiliado));

            Pantalla_Registro_Llegada_Final prlf = new Pantalla_Registro_Llegada_Final(idAfiliado,cantBonos,nroTurno);
            prlf.guardarDatos(this, prlp);
            prlf.ShowDialog();

        }


        internal void guardarDatos(Pantalla_Registro_Llegada_Principal pantalla_Registro_Llegada_Principal)
        {

            prlp = pantalla_Registro_Llegada_Principal;

        }
    }
}
