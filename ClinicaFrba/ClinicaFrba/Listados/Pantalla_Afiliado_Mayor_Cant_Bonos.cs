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
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        GD2C2016DataSet.AfiliadoDataTable afiData;

        public Pantalla_Afiliado_Mayor_Cant_Bonos(decimal anio,decimal semestre)
        {
            InitializeComponent();

            anioConsulta = anio;

            semestreConsulta = semestre;

            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();

            afiData = afiAdapter.topAfiliadoMasBonosComprados(anioConsulta, semestreConsulta);

            foreach (DataRow afi in afiData.Rows)
            {


                dataGridView1.Rows.Add(afi.Field<string>("nombre"),
                                       afi.Field<string>("apellido"),
                                       afi.Field<bool>("tieneFamilia"),
                                       afi.Field<decimal>("bonosComprados"));


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
