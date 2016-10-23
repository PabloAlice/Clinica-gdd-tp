using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class Pantalla_Registro_Consulta_Principal : Form
    {
        public Pantalla_Registro_Consulta_Principal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Pantalla_Registro_Consulta_Final prcf = new Pantalla_Registro_Consulta_Final();
            prcf.guardarDatos(this);
            prcf.ShowDialog();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
