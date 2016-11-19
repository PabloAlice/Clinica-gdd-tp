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
    public partial class Pantalla_Especialidades_Canceladas : Form
    {

        decimal añoConsulta;
        decimal semestreConsulta;
        GD2C2016DataSetTableAdapters.topEspecialidadesMasCancelacionesTableAdapter topEMCadapter;
        GD2C2016DataSet.topEspecialidadesMasCancelacionesDataTable topEMCdata;

        public Pantalla_Especialidades_Canceladas(decimal año,decimal semestre)
        {
            InitializeComponent();

            añoConsulta = año;

            semestreConsulta = semestre;

            topEMCadapter = new GD2C2016DataSetTableAdapters.topEspecialidadesMasCancelacionesTableAdapter();

            topEMCdata = topEMCadapter.topEspecialidadesMasCancelaciones(añoConsulta, semestreConsulta);

            foreach (DataRow espe in topEMCdata.Rows)
            {

                dataGridView1.Rows.Add(espe.Field<string>("mes"),
                                       espe.Field<string>("descripcion"),
                                       espe.Field<int>("cantidad"));

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
