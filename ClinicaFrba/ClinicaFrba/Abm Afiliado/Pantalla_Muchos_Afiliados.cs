using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Muchos_Afiliados : Form
    {
        public Pantalla_Muchos_Afiliados(DataTable tablaAfiliados)
        {
            InitializeComponent();


            foreach (DataRow afiliado in tablaAfiliados.Rows)
            {

                dataGridView1.Rows.Add(afiliado.Field<string>("nro_afiliado"),
                                       afiliado.Field<string>("nombre"),
                                       afiliado.Field<string>("apellido"));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
