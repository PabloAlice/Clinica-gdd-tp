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

namespace ClinicaFrba.Compra_Bono
{
    public partial class Pantalla_Compra_Bono_Afiliado : Form
    {

        string rolIngresado;
        int idUser;
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        GD2C2016DataSetTableAdapters.BonoTableAdapter bonoAdapter;
        GD2C2016DataSet.BonoDataTable bonoData;
        Decimal importe;
        int codigoPlan;

        public Pantalla_Compra_Bono_Afiliado(string rol, int idU)
        {
            InitializeComponent();

            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();
            bonoAdapter = new GD2C2016DataSetTableAdapters.BonoTableAdapter();

            rolIngresado = rol;

            idUser = idU;

            if (rolIngresado.Equals("Administrativo") || rolIngresado.Equals("Administrador General"))
            {

                textBox1.Enabled = true;
                button2.Enabled = true;


            }
            else
            {

                textBox1.Text = Convert.ToString(afiAdapter.obtenerNumeroAfiliado(idUser));

                bonoData = bonoAdapter.obtenerBonosPorNroAfiliado(Convert.ToDecimal(textBox1.Text));

                codigoPlan = Convert.ToInt32(bonoData.Rows[0].Field<Decimal>("codigo"));

                foreach (DataRow bono in bonoData.Rows)
                {

                    dataGridView1.Rows.Add("Consulta",
                                           bono.Field<Decimal>("bono_consulta"));


                }



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            importe = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);

            Pantalla_Seleccion_Cantidad_Compra psccompra = new Pantalla_Seleccion_Cantidad_Compra();
            psccompra.guardarPantalla(this, importe, codigoPlan, idUser, this.textBox1.Text, this);
            psccompra.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int outPut;

            dataGridView1.Rows.Clear();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                MessageBox.Show("Complete el nro afiliado");

            }
            else
            {

                if (int.TryParse(textBox1.Text, out outPut))
                {

                    try
                    {

                        bonoData = bonoAdapter.obtenerBonosPorNroAfiliado(Convert.ToDecimal(textBox1.Text));

                        codigoPlan = Convert.ToInt32(bonoData.Rows[0].Field<Decimal>("codigo"));

                        foreach (DataRow bono in bonoData.Rows)
                        {

                            dataGridView1.Rows.Add("Consulta",
                                                   bono.Field<Decimal>("bono_consulta"));


                        }

                        idUser = Convert.ToInt16(bonoData.Rows[0].Field<Decimal>("id"));
                    }
                    catch (SqlException ex)
                    {
                        switch(ex.Number){

                            case 40008: MessageBox.Show("No existe un afiliado con ese número");
                                break;
                            
                    }

                    }
                }
                else
                {

                    MessageBox.Show("El nro de afiliado debe ser numérico");

                }
            }
        }

    }
}
