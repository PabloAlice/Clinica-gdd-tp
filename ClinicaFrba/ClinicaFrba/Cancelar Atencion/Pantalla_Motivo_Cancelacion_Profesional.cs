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
    public partial class Pantalla_Motivo_Cancelacion_Profesional : Form
    {
        Pantalla_Cancelacion_Profesional pcp;
        decimal idUser;
        string fechaCancelacion;
        GD2C2016DataSetTableAdapters.Tipo_CancelacionTableAdapter tipoCanceAdapter;
        GD2C2016DataSet.Tipo_CancelacionDataTable tipoCanceData;
        decimal idTipoCancelacion;
        DateTime? horaInicio;
        DateTime? horaFin;

        public Pantalla_Motivo_Cancelacion_Profesional(string fechaCanceDia,decimal idU,DateTime? horaI,DateTime? horaF)
        {
            InitializeComponent();

            idUser = idU;

             fechaCancelacion = fechaCanceDia;

            if (horaI != null && horaF != null)
            {
                horaInicio = horaI;

                horaFin = horaF;

            }

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

        internal void guardarDatos(Pantalla_Cancelacion_Profesional pantalla_Cancelacion_Profesional)
        {
            pcp = pantalla_Cancelacion_Profesional;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPut;
            GD2C2016DataSetTableAdapters.Cancelacion_TurnoTableAdapter canceAdapter = new GD2C2016DataSetTableAdapters.Cancelacion_TurnoTableAdapter();

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

                            idTipoCancelacion = tipo.Field<decimal>("id");

                        }

                     }

                    if (horaInicio == null)
                    {

                        DateTime fecha = Convert.ToDateTime(fechaCancelacion);
                        DateTime fechaCance = fecha.Date;

                        canceAdapter.cancelarDiaPorProfesional(idUser,fechaCance, idTipoCancelacion, textBox1.Text);

                        MessageBox.Show("Día cancelado correctamente");
                    
                    }
                    else
                    {

                        canceAdapter.cancelarTurnosPorProfesional(idUser,horaInicio,horaFin, idTipoCancelacion, textBox1.Text,fechaCancelacion);

                        MessageBox.Show("Turnos dados de baja correctamente");
                    }

 
                    this.Close();
                    pcp.Close();


                }

            }


        }

  
    }
}
