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
    public partial class Pantalla_Profesionales_Menos_Horas_Trabajo : Form
    {
        decimal anioConsulta;
        decimal semestreConsulta;
        decimal idEspecialidad;
        decimal codigoPlan;
        GD2C2016DataSetTableAdapters.topProfesionalesMenosHorasTableAdapter topPMHadapter;
        GD2C2016DataSet.topProfesionalesMenosHorasDataTable topPMHdata;
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;
        GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter planAdapter;
        GD2C2016DataSet.Plan_MedicoDataTable planData;

        public Pantalla_Profesionales_Menos_Horas_Trabajo(decimal anio, decimal semestre)
        {
            InitializeComponent();

            anioConsulta = anio;
            semestreConsulta = semestre;

            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();

            espeData = espeAdapter.obtenerEspecialidades();

            foreach(DataRow espe in espeData.Rows){

                comboBox2.Items.Add(espe.Field<string>("descripcion"));


            }

            planAdapter = new GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter();

            planData = planAdapter.obtenerPlanesMedicos();

            foreach(DataRow plan in planData.Rows){

                comboBox1.Items.Add(plan.Field<string>("descripcion"));


            }

            topPMHadapter = new GD2C2016DataSetTableAdapters.topProfesionalesMenosHorasTableAdapter();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
   

            if (comboBox1.Text == "" || comboBox2.Text == "")
            {

                MessageBox.Show("Complete el plan y la especialidad");

            }
            else
            {
               
                foreach (DataRow espe in espeData.Rows)
                {

                    if(comboBox2.Text == (espe.Field<string>("descripcion"))){

                        idEspecialidad = espe.Field<decimal>("codigo");

                    }


                }


                foreach (DataRow plan in planData.Rows)
                {

                    if (comboBox1.Text == (plan.Field<string>("descripcion")))
                    {

                        codigoPlan = plan.Field<decimal>("codigo");

                    }


                }


                topPMHdata = topPMHadapter.topProfesionalesMenosHoras(codigoPlan, idEspecialidad, anioConsulta, semestreConsulta);


                foreach (DataRow profe in topPMHdata.Rows)
                {

                    dataGridView1.Rows.Add(profe.Field<string>("mes"),
                                           profe.Field<string>("nombre"),
                                           profe.Field<string>("apellido"),
                                           profe.Field<decimal>("hs_trabajadas"));


                }

            }
        }
    }
}
