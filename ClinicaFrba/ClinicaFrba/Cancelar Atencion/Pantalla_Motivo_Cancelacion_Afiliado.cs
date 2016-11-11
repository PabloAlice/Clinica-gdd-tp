using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Pantalla_Motivo_Cancelacion_Afiliado : Form
    {
        Pantalla_Cancelacion_Afiliado pca;
        decimal idUser;
        GD2C2016DataSetTableAdapters.Tipo_CancelacionTableAdapter tipoCanceAdapter;
        GD2C2016DataSet.Tipo_CancelacionDataTable tipoCanceData;
        GD2C2016DataSetTableAdapters.Cancelacion_TurnoTableAdapter canceAdapter;
        decimal idTurno;
        decimal idTipoCance;

        public Pantalla_Motivo_Cancelacion_Afiliado(decimal idU,decimal idT)
        {
            InitializeComponent();

            idUser = idU;
            idTurno = idT;

            tipoCanceAdapter = new GD2C2016DataSetTableAdapters.Tipo_CancelacionTableAdapter();
            tipoCanceData = tipoCanceAdapter.GetData();

            foreach (DataRow tipo in tipoCanceData.Rows)
            {

                comboBox1.Items.Add(tipo.Field<string>("tipo"));

            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int outPut;
            canceAdapter = new GD2C2016DataSetTableAdapters.Cancelacion_TurnoTableAdapter();

            if (comboBox1.Text=="" || string.IsNullOrWhiteSpace(textBox1.Text))
            {

                MessageBox.Show("Quedan datos por completar");


            }
            else
            {
                if (int.TryParse(textBox1.Text, out outPut))
                {

                    MessageBox.Show("El motivo no puede ser todo numérico");


                }
                else
                {

                    foreach (DataRow tipo in tipoCanceData.Rows)
                     {

                        if(tipo.Field<string>("tipo").Equals(comboBox1.Text)){

                            idTipoCance = tipo.Field<decimal>("id");

                        }

                     }

                    canceAdapter.cancelarTurnoPorAfiliado(idUser, idTurno, idTipoCance, textBox1.Text);

                    MessageBox.Show("Turno dado de baja correctamente");
                    this.Close();
                    pca.Close();


                }

            }
        }

        internal void guardarDatos(Pantalla_Cancelacion_Afiliado pantalla_Cancelacion_Afiliado)
        {

            pca = pantalla_Cancelacion_Afiliado;

        }
    }
}
