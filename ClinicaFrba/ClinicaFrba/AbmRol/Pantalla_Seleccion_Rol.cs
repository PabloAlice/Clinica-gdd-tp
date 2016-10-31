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
    public partial class Pantalla_Seleccion_Rol : Form
    {

        string userName;

        GD2C2016DataSetTableAdapters.RolTableAdapter rolAdapter;
        GD2C2016DataSet.RolDataTable rolData;

        public Pantalla_Seleccion_Rol(string nombreUsuario)
        {
            InitializeComponent();

            rolAdapter = new GD2C2016DataSetTableAdapters.RolTableAdapter();
            rolData = new GD2C2016DataSet.RolDataTable();

            userName = nombreUsuario;

            rolData = rolAdapter.ObtenerRol(userName);

            foreach (DataRow rol in rolData.Rows)
            {

            comboBox1.Items.Add(rol.Field<string>("nombre"));


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {

                MessageBox.Show("Selecciona algún rol para ingresar");

            }
            else
            {

                Pantalla_Funcionalidades pfuncio = new Pantalla_Funcionalidades(comboBox1.Text);
                pfuncio.ShowDialog();


            }
        }
    }
}
