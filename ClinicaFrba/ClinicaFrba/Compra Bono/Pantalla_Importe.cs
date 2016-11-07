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
    public partial class Pantalla_Importe : Form
    {
        int cantidadComprada;
        int idUser;
        int codigoPlan;
        int nroAfiliado;
        GD2C2016DataSetTableAdapters.BonoTableAdapter bonoAdapter;
        string fechaHoy;

        public Pantalla_Importe()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        internal void guardarCantidad(decimal cantidad,Decimal importe,int codigop,int idu,int nroAfi)
        {
            cantidadComprada = Convert.ToInt16(cantidad);
            this.textBox1.Text = Convert.ToString(cantidadComprada);
            textBox2.Text = Convert.ToString(importe*cantidadComprada);
            codigoPlan = codigop;
            idUser = idu;
            nroAfiliado = nroAfi;
         


        }

        private void button2_Click(object sender, EventArgs e)
        {

            bonoAdapter = new GD2C2016DataSetTableAdapters.BonoTableAdapter();

            
            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();


            bonoAdapter.comprarBonos(idUser, nroAfiliado, codigoPlan, cantidadComprada, Convert.ToDateTime(fechaHoy));


            MessageBox.Show("Compra exitosa");

            this.Close();

        }
    }
}
