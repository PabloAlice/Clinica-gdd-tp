using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class Pantalla_Especialidades_Mayor_Cant_Bonos : Form
    {
        decimal anioConsulta;
        decimal semestreConsulta;
        GD2C2016DataSetTableAdapters.topEspecialidadesMasBonosUsadosTableAdapter topEMBUadapter;
        GD2C2016DataSet.topEspecialidadesMasBonosUsadosDataTable topEMBUdata;


        public Pantalla_Especialidades_Mayor_Cant_Bonos(decimal anio,decimal semestre)
        {
            InitializeComponent();

            anioConsulta = anio;
            semestreConsulta = semestre;

            topEMBUadapter = new GD2C2016DataSetTableAdapters.topEspecialidadesMasBonosUsadosTableAdapter();

            topEMBUdata = topEMBUadapter.topEspecialidadesMasBonosUsados(anioConsulta, semestreConsulta);

            foreach (DataRow espe in topEMBUdata.Rows)
            {

                dataGridView1.Rows.Add(espe.Field<string>("descripcion"),
                                       espe.Field<int>("cantidad"));

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
