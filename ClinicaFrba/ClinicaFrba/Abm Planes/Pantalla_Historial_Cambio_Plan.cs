using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Planes
{
    public partial class Pantalla_Historial_Cambio_Plan : Form
    {
        GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter planAdapter;
        GD2C2016DataSet.Plan_MedicoDataTable planData;

        public Pantalla_Historial_Cambio_Plan(decimal idUser)
        {
            InitializeComponent();

            planAdapter = new GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter();

            planData = planAdapter.consultarCambiosDePlan(idUser);

            foreach (DataRow plan in planData.Rows)
            {

                dataGridView1.Rows.Add(plan.Field<DateTime>("fecha_baja"),
                                       plan.Field<string>("motivo"),
                                       plan.Field<decimal>("codigo_plan"));

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
