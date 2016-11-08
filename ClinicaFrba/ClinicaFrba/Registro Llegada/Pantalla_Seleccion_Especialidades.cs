using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class Pantalla_Seleccion_Especialidades : Form
    {
        TextBox especialidad;
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;

        public Pantalla_Seleccion_Especialidades()
        {
            InitializeComponent();
            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();
            espeData = espeAdapter.obtenerEspecialidades();

            foreach (DataRow especialidad in espeData.Rows)
            {

                dataGridView1.Rows.Add(especialidad.Field<string>("descripcion"));


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            especialidad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            this.Close();
        }

        internal void guardaDatos(TextBox textBox)
        {
            especialidad = textBox;
        }
    }
}
