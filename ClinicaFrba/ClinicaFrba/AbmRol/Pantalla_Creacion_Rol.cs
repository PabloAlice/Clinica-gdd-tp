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
        public Pantalla_Creacion_Rol()
        {
            InitializeComponent();

            listBox1.Items.Add("ABM Roles");
            listBox1.Items.Add("ABM Planes");
            listBox1.Items.Add("ABM Afiliado");
            listBox1.Items.Add("ABM Profesional");
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPut;

            if (textBox1.Text == "" || listBox1.SelectedItems.Count == 0)
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

                    MessageBox.Show("Rol creado satisfactoriamente");
                    this.Close();

                }

            }
        }

    }
}
