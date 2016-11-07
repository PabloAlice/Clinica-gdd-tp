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
    public partial class Pantalla_Seleccion_Cantidad_Compra : Form
    {
        Pantalla_Compra_Bono_Afiliado panterior;
        Decimal importe;
        int idUser;
        int codigoPlan;
        int nroAfiliado;
        Pantalla_Compra_Bono_Afiliado pcafi;

        public Pantalla_Seleccion_Cantidad_Compra()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
 
            Pantalla_Importe pimporte = new Pantalla_Importe();
            pimporte.guardarDatos(this.numericUpDown1.Value,importe,codigoPlan,idUser,nroAfiliado,this,pcafi);
            pimporte.ShowDialog();

        }

        internal void guardarPantalla(Pantalla_Compra_Bono_Afiliado pantalla_Compra_Bono_Afiliado,Decimal import,int codigop,int idu,string nroAfi,Pantalla_Compra_Bono_Afiliado pca)
        {
            panterior = pantalla_Compra_Bono_Afiliado;
            importe = import;
            codigoPlan = codigop;
            idUser = idu;
            nroAfiliado = Convert.ToInt32(nroAfi);
            pcafi = pca;

        }
    }
}
