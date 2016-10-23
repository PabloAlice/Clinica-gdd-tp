﻿using System;
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
 
            MessageBox.Show("Compra exitosa");
            Pantalla_Importe pimporte = new Pantalla_Importe();
            pimporte.guardarCantidad(this.numericUpDown1.Value);
            pimporte.ShowDialog();
            this.Close();
            panterior.Close();
        }

        internal void guardarPantalla(Pantalla_Compra_Bono_Afiliado pantalla_Compra_Bono_Afiliado)
        {
            panterior = pantalla_Compra_Bono_Afiliado;
        }
    }
}
