using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Compra_Bono
{
    public partial class Pantalla_Compra_Bono_Afiliado : Form
    {
        public Pantalla_Compra_Bono_Afiliado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pantalla_Seleccion_Cantidad_Compra psccompra = new Pantalla_Seleccion_Cantidad_Compra();
            psccompra.guardarPantalla(this);
            psccompra.ShowDialog();
        }
    }
}
