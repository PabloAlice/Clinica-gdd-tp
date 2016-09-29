using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class Pantalla_Login : Form
    {
        public Pantalla_Login()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "" && textBox2.Text == "") || (textBox1.Text == "" || textBox2.Text == ""))
            {

                MessageBox.Show("Usuario y/o contraseña inválidos");

            }
            else
            {

                Pantalla_Funcionalidades pfuncio = new Pantalla_Funcionalidades();
                pfuncio.ShowDialog();

            }
        }
    }
}
