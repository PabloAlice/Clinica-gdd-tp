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

namespace ClinicaFrba.AbmRol
{
    public partial class Pantalla_Modificacion_Rol : Form
    {
        Pantalla_Modificacion_Rol_Principal pmrp;
        GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter funciAdapter;
        GD2C2016DataSetTableAdapters.RolTableAdapter rolAdapter;
        GD2C2016DataSet.FuncionalidadDataTable funciData;
        GD2C2016DataSet.FuncionalidadDataTable funciData2;
        string nombreRol;

        public Pantalla_Modificacion_Rol(string rol)
        {
            InitializeComponent();

            funciAdapter = new GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter();
            funciData = funciAdapter.obtenerFuncionalidadesXrol(rol);

            textBox1.Text = rol;

            nombreRol = rol;

            foreach (DataRow funcionalidad in funciData.Rows)
            {

                listBox1.Items.Add(funcionalidad.Field<string>("nombre"));

            }

            funciAdapter = new GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter();
            funciData2 = funciAdapter.obtenerFuncionalidades();

            foreach (DataRow funcionalidad in funciData2.Rows)
            {

                if (!listBox1.Items.Contains(funcionalidad.Field<string>("nombre")))
                {

                    listBox2.Items.Add(funcionalidad.Field<string>("nombre"));


                }

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {

                MessageBox.Show("No ha seleccionado ninguna funcionalidad para quitar");

            }
            else
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox2.SelectedItems.Count == 0)
            {

                MessageBox.Show("No ha seleccionado ninguna funcionalidad para agregar");

            }
            else
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int outPut;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

                MessageBox.Show("Completar nombre de rol");

            }
            else
            {

                if (int.TryParse(textBox1.Text, out outPut))
                {

                    MessageBox.Show("Nombre rol incorrecto");

                }
                else
                {

                    try
                    {

                        DataTable tablaFuncionalidades = new DataTable();
                        tablaFuncionalidades.Columns.Add("id_funcionalidad");

                        foreach (string funcionalidad in listBox1.Items)
                        {

                            int idFunci = Convert.ToInt16(funciAdapter.obtenerIDfuncionalidad(funcionalidad));

                            tablaFuncionalidades.Rows.Add(idFunci);

                        }


                        rolAdapter = new GD2C2016DataSetTableAdapters.RolTableAdapter();

                        int idRol = Convert.ToInt16(rolAdapter.obtenerIDrol(nombreRol));

                        rolAdapter.modificarRol(idRol, textBox1.Text, tablaFuncionalidades);

                        MessageBox.Show("Rol modificado correctamente");
                        this.Close();
                        pmrp.Close();

                    }catch(SqlException ex){

                        switch (ex.Number)
                        {

                            case 40000: MessageBox.Show("Ya existe ese nombre de rol");
                                break;

                        }


                    }
                }
            }
        }

        internal void guardarDatos(Pantalla_Modificacion_Rol_Principal pantalla_Modificacion_Rol_Principal)
        {
            pmrp = pantalla_Modificacion_Rol_Principal;
        }
    }
}
