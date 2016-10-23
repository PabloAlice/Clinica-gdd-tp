using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Pantalla_Modificacion_Rol_Principal : Form
    {
        public Pantalla_Modificacion_Rol_Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Pantalla_Modificacion_Rol pmrol = new Pantalla_Modificacion_Rol();
            pmrol.guardarDatos(this);
            pmrol.ShowDialog();

        }
    }
}
