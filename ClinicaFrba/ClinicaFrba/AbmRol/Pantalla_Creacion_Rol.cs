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
    public partial class Pantalla_Creacion_Rol : Form
    {
        GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter funciAdapter;
        GD2C2016DataSet.FuncionalidadDataTable funciData;
        GD2C2016DataSetTableAdapters.RolTableAdapter rolAdapter;

        public Pantalla_Creacion_Rol()
        {
            InitializeComponent();

            funciAdapter = new GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter();
            funciData = funciAdapter.obtenerFuncionalidades();

            foreach (DataRow funcionalidad in funciData.Rows)
            {

                listBox1.Items.Add(funcionalidad.Field<string>("nombre"));

            }

            
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPut;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || listBox1.SelectedItems.Count == 0)
            {

                MessageBox.Show("Nombre y/o funcionalidades inválidas");


            }
            else
            {

                if (int.TryParse(textBox1.Text,out outPut))
                {
                    MessageBox.Show("Nombre de rol incorrecto");
  
                }
                else
                {

                    DataTable tablaFuncionalidades = new DataTable();
                    tablaFuncionalidades.Columns.Add("id_funcionalidad");

                    foreach(string funcionalidad in listBox1.SelectedItems){

                        int idFunci = Convert.ToInt16(funciAdapter.obtenerIDfuncionalidad(funcionalidad));

                        tablaFuncionalidades.Rows.Add(idFunci);

                    }

                    rolAdapter = new GD2C2016DataSetTableAdapters.RolTableAdapter();
                    rolAdapter.crearRol(textBox1.Text, tablaFuncionalidades);

                    MessageBox.Show("Rol creado satisfactoriamente");
                    this.Close();

                }

            }
        }

    }
}
