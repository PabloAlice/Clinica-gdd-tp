using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Pantalla_PedidoTurno_Principal : Form
    {
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;
        GD2C2016DataSetTableAdapters.ProfesionalTableAdapter profeAdapter;
        GD2C2016DataSet.ProfesionalDataTable profeData;
        decimal idEspecialidad;
        decimal idUser;

        public Pantalla_PedidoTurno_Principal(decimal idUser)
        {
            InitializeComponent();
            this.idUser = idUser;
            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();
            espeData = espeAdapter.obtenerEspecialidades();

            foreach (DataRow especialidad in espeData.Rows)
            {

                comboBox1.Items.Add(especialidad.Field<string>("descripcion"));


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal idProfesional = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].Value);


            foreach (DataRow especialidad in espeData.Rows)
            {

                if (comboBox1.Text == especialidad.Field<string>("descripcion"))
                {

                    idEspecialidad = especialidad.Field<decimal>("codigo");


                }


            }

            Pantalla_Seleccion_Turno pst = new Pantalla_Seleccion_Turno(idProfesional,idEspecialidad,idUser);
            pst.guardarDatos(this);
            pst.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            profeAdapter = new GD2C2016DataSetTableAdapters.ProfesionalTableAdapter();

            if (comboBox1.Text == "")
            {

                MessageBox.Show("Seleccione alguna especialidad");

            }
            else
            {

                profeData = profeAdapter.obtenerProfesionalesPorEspecialidad(comboBox1.Text);

                foreach (DataRow profesional in profeData.Rows)
                {

                    dataGridView1.Rows.Add(profesional.Field<decimal>("id"),
                                           profesional.Field<string>("nombre"),
                                           profesional.Field<string>("apellido"));

                }

            }
        }

   
    }
}
