﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Pantalla_Selecc_Profesional : Form
    {
        public Pantalla_Selecc_Profesional()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPut;

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {

                MessageBox.Show("Número de documento vacío");


            }
            else
            {

                if (!int.TryParse(textBox2.Text, out outPut))
                {

                    MessageBox.Show("El número de documento debe ser numérico");


                }
                else
                {




                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pantalla_Fecha_Vigencia_Agenda pfvagenda = new Pantalla_Fecha_Vigencia_Agenda();
            pfvagenda.guardarDatos(this);
            pfvagenda.ShowDialog();
        }
    }
}