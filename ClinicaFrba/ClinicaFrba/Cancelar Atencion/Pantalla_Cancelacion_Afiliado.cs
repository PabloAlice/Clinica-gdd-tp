using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Pantalla_Cancelacion_Afiliado : Form
    {
        string fechaHoy;

        public Pantalla_Cancelacion_Afiliado()
        {
            InitializeComponent();

            dataGridView1.Rows[0].Cells[4].Value = "20/10/2016";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value) == fechaHoy )
            {

                MessageBox.Show("No puede cancelar una consulta el mismo día de atención de la misma");

            }
            else
            {

                Pantalla_Motivo_Cancelacion_Afiliado pmc = new Pantalla_Motivo_Cancelacion_Afiliado();
                pmc.guardarDatos(this);
                pmc.ShowDialog();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
