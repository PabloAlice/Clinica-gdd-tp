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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Pantalla_Selecc_Profesional : Form
    {
        GD2C2016DataSetTableAdapters.UsuarioTableAdapter usuAdapter;
        GD2C2016DataSet.UsuarioDataTable usuData;


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

            dataGridView1.Rows.Clear();

            usuAdapter = new GD2C2016DataSetTableAdapters.UsuarioTableAdapter();

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
                        decimal dni = Convert.ToDecimal(textBox2.Text);

                        usuData = usuAdapter.obtenerProfesionalPorDNI(dni);

                        foreach (DataRow profesional in usuData.Rows)
                        {

                            dataGridView1.Rows.Add(profesional.Field<string>("nombre"),
                                                   profesional.Field<string>("apellido"));

                        }



                    }
                    catch (SqlException ex)
                    {

                        switch (ex.Number)
                        {

                            case 40005: MessageBox.Show("No existen profesionales con ese DNI");
                                break;


                        }

                    }
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GD2C2016DataSetTableAdapters.AgendaTableAdapter agendaAdapter = new GD2C2016DataSetTableAdapters.AgendaTableAdapter();
            GD2C2016DataSet.AgendaDataTable agendaData;
            DateTime fechaInicioRegistrada;
            DateTime fechaFinRegistrada;

            if(Convert.ToBoolean(agendaAdapter.yaTieneAgenda(usuData.Rows[0].Field<decimal>("id")))){

                DialogResult result1 = MessageBox.Show("El profesional ya tiene una agenda registrada.Desea extender la misma?",
                                "Pregunta extensión agenda",
                                MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    agendaData = agendaAdapter.fechasRegistradas(usuData.Rows[0].Field<decimal>("id"));

                    fechaInicioRegistrada = agendaData.Rows[0].Field<DateTime>("fecha_inicio");

                    fechaFinRegistrada = agendaData.Rows[0].Field<DateTime>("fecha_fin");

                    Pantalla_Fecha_Vigencia_Agenda pfvagenda = new Pantalla_Fecha_Vigencia_Agenda();
                    pfvagenda.guardarDatos(this, usuData.Rows[0].Field<decimal>("id"));
                    pfvagenda.guardarFechas(fechaInicioRegistrada, fechaFinRegistrada);
                    pfvagenda.ShowDialog();
                 

                }

            }else{

                Pantalla_Fecha_Vigencia_Agenda pfvagenda = new Pantalla_Fecha_Vigencia_Agenda();
                pfvagenda.guardarDatos(this, usuData.Rows[0].Field<decimal>("id"));
                pfvagenda.ShowDialog();

            }

        }
    }
}