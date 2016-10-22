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
    public partial class Pantalla_Modificacion_Rol : Form
    {
        public Pantalla_Modificacion_Rol()
        {
            InitializeComponent();
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

            if(int.TryParse(textBox1.Text,out outPut)){

            MessageBox.Show("Nombre rol incorrecto");

            }
            else
            {

                MessageBox.Show("Rol modificado correctamente");
                this.Close();
            }
        }
    }
}
