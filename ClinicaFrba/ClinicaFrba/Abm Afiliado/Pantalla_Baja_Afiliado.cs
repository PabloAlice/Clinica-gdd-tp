﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Baja_Afiliado : Form
    {
        GD2C2016DataSetTableAdapters.UsuarioTableAdapter usuAdapter;
        GD2C2016DataSet.UsuarioDataTable usuData;


        public Pantalla_Baja_Afiliado()
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
            usuAdapter = new GD2C2016DataSetTableAdapters.UsuarioTableAdapter();

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

                    try
                    {

                        decimal dni = Convert.ToDecimal(this.textBox2.Text);

                        usuData = usuAdapter.afiliadosPorDNIeliminacion(dni);

                        dataGridView1.Rows.Add(usuData.Rows[0].Field<string>("nombre"),
                                               usuData.Rows[0].Field<string>("apellido"));

                    }
                    catch (SqlException ex)
                    {
                        switch (ex.Number)
                        {

                            case 40004: MessageBox.Show("No existe un afiliado con ese DNI");
                                return;
                            case 40005: MessageBox.Show("El usuario ya se encuentra deshabilitado");
                                return;


                        }

                    }

                }

            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            usuAdapter.eliminarAfiliado(Convert.ToInt16(this.textBox2.Text));

            MessageBox.Show("Afiliado dado de baja correctamente");
            this.Close();

        }
    }
}
