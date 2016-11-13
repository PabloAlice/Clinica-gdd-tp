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
        GD2C2016DataSetTableAdapters.ProfesionalTableAdapter profeAdapter;
        GD2C2016DataSet.ProfesionalDataTable profeData;


        public Pantalla_Profesionales_Mas_Consultados(decimal año,decimal semestre)
        {
            InitializeComponent();

            añoConsulta = año;

            semestreConsulta = semestre;

            profeAdapter = new GD2C2016DataSetTableAdapters.ProfesionalTableAdapter();

            profeData = profeAdapter.topProfesionalesMasConsultadosPorPlan(añoConsulta, semestreConsulta);

            foreach (DataRow profe in profeData.Rows)
            {

                dataGridView1.Rows.Add(profe.Field<string>("mes"),
                                       profe.Field<string>("nombre"),
                                       profe.Field<string>("apellido"),
                                       profe.Field<string>("desc_esp"),
                                       profe.Field<string>("desc_plan"),
                                       profe.Field<decimal>("cantidad"));

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
