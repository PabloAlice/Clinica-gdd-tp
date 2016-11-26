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
    public partial class Pantalla_Seleccion_Afiliado_Modificacion : Form
    {
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        GD2C2016DataSet.AfiliadoDataTable afiData;

        public Pantalla_Seleccion_Afiliado_Modificacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();

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

                        afiData = afiAdapter.afiliadosPorDNI(dni);

                        dataGridView1.Rows.Add(afiData.Rows[0].Field<string>("nombre"),
                                               afiData.Rows[0].Field<string>("apellido"),
                                               afiData.Rows[0].Field<decimal>("numero_afiliado"));

                    }
                    catch (SqlException ex)
                    {
                        switch (ex.Number)
                        {

                            case 40004: MessageBox.Show("No existe un afiliado con ese DNI");
                                return;


                        }
                    }



                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            decimal idUser = afiData.Rows[0].Field<decimal>("id");

            Pantalla_Modificacion_Datos_Afiliado pmda = new Pantalla_Modificacion_Datos_Afiliado(idUser);
            pmda.ShowDialog();


        }
    }
}
