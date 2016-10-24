using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Pantalla_Registro_Turno : Form
    {

        Pantalla_Registro_Llegada_Principal prlp;

        public Pantalla_Registro_Turno()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            Pantalla_Registro_Llegada_Final prlf = new Pantalla_Registro_Llegada_Final();
            prlf.guardarDatos(this, prlp);
            prlf.ShowDialog();

        }


        internal void guardarDatos(Pantalla_Registro_Llegada_Principal pantalla_Registro_Llegada_Principal)
        {

            prlp = pantalla_Registro_Llegada_Principal;

        }
    }
}
