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
    public partial class Pantalla_Importe : Form
    {
        int cantidadComprada;

        public Pantalla_Importe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        internal void guardarCantidad(decimal cantidad)
        {
            cantidadComprada = Convert.ToInt16(cantidad);
            this.textBox1.Text = Convert.ToString(cantidadComprada);

        }
    }
}
