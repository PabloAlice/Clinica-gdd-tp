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
    public partial class Pantalla_Profesionales_Mas_Consultados : Form
    {

        decimal añoConsulta;
        decimal semestreConsulta;
        GD2C2016DataSetTableAdapters.topProfesionalesMasConsultadosPorPlanTableAdapter topPMCPadapter;
        GD2C2016DataSet.topProfesionalesMasConsultadosPorPlanDataTable topPMCPdata;


        public Pantalla_Profesionales_Mas_Consultados(decimal año,decimal semestre)
        {
            InitializeComponent();

            añoConsulta = año;

            semestreConsulta = semestre;

            topPMCPadapter = new GD2C2016DataSetTableAdapters.topProfesionalesMasConsultadosPorPlanTableAdapter();

            topPMCPdata = topPMCPadapter.topProfesionalesMasConsultadosPorPlan(añoConsulta, semestreConsulta);

            foreach (DataRow profe in topPMCPdata.Rows)
            {

                dataGridView1.Rows.Add(profe.Field<string>("mes"),
                                       profe.Field<string>("nombre"),
                                       profe.Field<string>("apellido"),
                                       profe.Field<string>("desc_esp"),
                                       profe.Field<string>("desc_plan"),
                                       profe.Field<int>("cantidad"));

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
