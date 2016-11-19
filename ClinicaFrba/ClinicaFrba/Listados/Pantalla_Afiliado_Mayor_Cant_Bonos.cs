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
    public partial class Pantalla_Afiliado_Mayor_Cant_Bonos : Form
    {
        decimal anioConsulta;
        decimal semestreConsulta;
        GD2C2016DataSetTableAdapters.topAfiliadoMasBonosCompradosTableAdapter topMBCadapter;
        GD2C2016DataSet.topAfiliadoMasBonosCompradosDataTable topMBCdata;

        public Pantalla_Afiliado_Mayor_Cant_Bonos(decimal anio,decimal semestre)
        {
            InitializeComponent();

            anioConsulta = anio;

            semestreConsulta = semestre;

            topMBCadapter = new GD2C2016DataSetTableAdapters.topAfiliadoMasBonosCompradosTableAdapter();

            topMBCdata = topMBCadapter.topAfiliadoMasBonosComprados(anioConsulta, semestreConsulta);

            foreach (DataRow afi in topMBCdata.Rows)
            {


                dataGridView1.Rows.Add(afi.Field<string>("nombre"),
                                       afi.Field<string>("apellido"),
                                       afi.Field<decimal>("Column1"),
                                       afi.Field<int>("bonosComprados"));


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
