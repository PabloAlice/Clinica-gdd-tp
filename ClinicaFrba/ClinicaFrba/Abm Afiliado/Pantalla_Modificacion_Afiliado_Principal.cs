using System;
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
    public partial class Pantalla_Modificacion_Afiliado_Principal : Form
    {
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        GD2C2016DataSet.AfiliadoDataTable afiData;

        public Pantalla_Modificacion_Afiliado_Principal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();
            afiData = new GD2C2016DataSet.AfiliadoDataTable();

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


                        afiData = afiAdapter.afiliadosPorDNI(Convert.ToDecimal(textBox2.Text));

                        foreach (DataRow afiliado in afiData.Rows)
                        {

                            dataGridView1.Rows.Add(afiliado.Field<decimal>("numero_afiliado"),
                                                   afiliado.Field<string>("nombre"),
                                                   afiliado.Field<string>("apellido"));


                        }


                    }
                    catch (SqlException ex)
                    {

                        switch (ex.Number)
                        {

                            case 40004: MessageBox.Show("No existen afiliados con ese DNI");
                                break;

                        }


                    }


                }

             }

            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal telefono = afiData.Rows[0].Field<decimal>("telefono");
            string mail = afiData.Rows[0].Field<string>("mail");
            string direccion = afiData.Rows[0].Field<string>("Direccion");
            decimal plan = afiData.Rows[0].Field<decimal>("codigo_plan");
            bool? sexo = afiData.Rows[0].Field<bool?>("sexo");
            decimal? estadoCivil = afiData.Rows[0].Field<decimal?>("estado_civil");
            decimal nroAfiliado = afiData.Rows[0].Field<decimal>("numero_afiliado");

            Pantalla_Modificacion_Datos_Afiliado pmdafiliado = new Pantalla_Modificacion_Datos_Afiliado(telefono, mail, direccion, plan, sexo, estadoCivil,nroAfiliado);
            pmdafiliado.guardarDatos(this);
            pmdafiliado.ShowDialog();
        }

    }
}
