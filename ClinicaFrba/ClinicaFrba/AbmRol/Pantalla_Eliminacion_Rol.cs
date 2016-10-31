using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Pantalla_Eliminacion_Rol : Form
    {
        GD2C2016DataSetTableAdapters.RolTableAdapter rolAdapter;
        GD2C2016DataSet.RolDataTable rolData;

        public Pantalla_Eliminacion_Rol()
        {
            InitializeComponent();

            rolAdapter = new GD2C2016DataSetTableAdapters.RolTableAdapter();
            rolData = rolAdapter.obtenerRolesHabilitados();

            foreach (DataRow rol in rolData.Rows)
            {

                dataGridView1.Rows.Add(rol.Field<string>("nombre"));

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRol = Convert.ToInt16(rolAdapter.obtenerIDrol((string)dataGridView1.CurrentRow.Cells[0].Value));

            rolAdapter.eliminarRol(idRol);
           
            MessageBox.Show("Rol eliminado satisfactoriamente");
            this.Close();
        }
    }
}
