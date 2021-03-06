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
    public partial class Pantalla_Habilitacion_Afiliado : Form
    {
        GD2C2016DataSetTableAdapters.UsuarioTableAdapter usuAdapter;
        GD2C2016DataSet.UsuarioDataTable usuData;

        public Pantalla_Habilitacion_Afiliado()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuAdapter = new GD2C2016DataSetTableAdapters.UsuarioTableAdapter();

            dataGridView1.Rows.Clear();

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


                    try
                    {

                        Decimal dni = Convert.ToDecimal(this.textBox2.Text);

                        usuData = usuAdapter.afiliadosPorDNIhabilitacion(dni) ;

                        dataGridView1.Rows.Add(usuData.Rows[0].Field<string>("nombre"),
                                               usuData.Rows[0].Field<string>("apellido"));

                    }
                    catch (SqlException ex)
                    {
                        switch (ex.Number)
                        {

                            case 40004: MessageBox.Show("No existe un afiliado con ese DNI");
                                return;
                            case 40005: MessageBox.Show("El usuario ya se encuentra habilitado");
                                return;


                        }
                    }



                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            usuAdapter.habilitarAfiliado(Convert.ToDecimal(this.textBox2.Text));
            MessageBox.Show("Afiliado habilitado correctamente");
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
