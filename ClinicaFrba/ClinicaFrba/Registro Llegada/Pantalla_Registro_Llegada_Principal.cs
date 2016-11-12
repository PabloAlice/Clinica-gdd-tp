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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Pantalla_Registro_Llegada_Principal : Form
    {

        string nombre;
        string apellido;
        string especialidad;
        GD2C2016DataSetTableAdapters.ProfesionalTableAdapter profeAdapter;
        GD2C2016DataSet.ProfesionalDataTable profeData;

        public Pantalla_Registro_Llegada_Principal()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            nombre = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            apellido = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            especialidad = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);

            Pantalla_Registro_Turno prt = new Pantalla_Registro_Turno(nombre,apellido,especialidad);
            prt.guardarDatos(this);
            prt.ShowDialog();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            Pantalla_Seleccion_Especialidades pse = new Pantalla_Seleccion_Especialidades();
            pse.guardaDatos(this.textBox3);
            pse.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int outPut;
            profeAdapter = new GD2C2016DataSetTableAdapters.ProfesionalTableAdapter();

            if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text) &&
                string.IsNullOrWhiteSpace(textBox3.Text))
            {

                MessageBox.Show("Complete los filtros de búsqueda");

            }
            else
            {

                if (((!string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text)) &&
                (!string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))) ||
                ((string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)) &&
                (!string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))))
                {

                    MessageBox.Show("Nombre y apellido deben estar completos");

                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                        !string.IsNullOrWhiteSpace(textBox3.Text))
                    {

                        MessageBox.Show("Busque por nombre y apellido o por especialidad");

                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(textBox3.Text))
                        {

                            if (int.TryParse(textBox1.Text, out outPut) || int.TryParse(textBox2.Text, out outPut))
                            {

                                MessageBox.Show("El nombre y apellido no pueden ser numéricos");


                            }
                            else
                            {

                                try
                                {

                                    nombre = textBox1.Text;
                                    apellido = textBox2.Text;


                                    profeData = profeAdapter.obtenerProfesionalesPorNyA(nombre, apellido);


                                    foreach (DataRow profesional in profeData.Rows)
                                    {


                                        dataGridView1.Rows.Add(profesional.Field<string>("nombre"),
                                                               profesional.Field<string>("apellido"),
                                                                profesional.Field<string>("descripcion"));



                                    }
                                }
                                catch(SqlException ex){

                                    switch(ex.Number){

                                        case 40008: MessageBox.Show("No existen profesionales con ese nombre y apellido");
                                                     break;

                                    }

                                }

                            }

                        }
                        else
                        {

                            especialidad = textBox3.Text;

                         profeData = profeAdapter.obtenerProfesionalesPorEspecialidad(especialidad);


                                foreach (DataRow profesional in profeData.Rows)
                                {

                                    dataGridView1.Rows.Add(profesional.Field<string>("nombre"),
                                                           profesional.Field<string>("apellido"),
                                                           especialidad);

                                }


                        }


                    }


                }


            }

        }

    }

}
 
 

    

