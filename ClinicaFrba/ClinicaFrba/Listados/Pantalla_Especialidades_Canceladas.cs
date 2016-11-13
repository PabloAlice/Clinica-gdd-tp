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
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;

        public Pantalla_Especialidades_Canceladas(decimal año,decimal semestre)
        {
            InitializeComponent();

            añoConsulta = año;

            semestreConsulta = semestre;

            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();

            espeData = new GD2C2016DataSet.EspecialidadDataTable();
            
            espeData = espeAdapter.topEspecialidadesMasCancelaciones(añoConsulta, semestreConsulta);

            foreach (DataRow espe in espeData.Rows)
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
