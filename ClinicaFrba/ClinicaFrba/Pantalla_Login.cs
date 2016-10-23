using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            if ((string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
                || (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                
                MessageBox.Show("Usuario y/o contraseña inválidos");

            }
            else
            {

                SHA256 CriptoPass = SHA256Managed.Create();
                byte[] valorHash;
                valorHash = CriptoPass.ComputeHash(Encoding.UTF8.GetBytes(textBox2.Text));


                Pantalla_Funcionalidades pfuncio = new Pantalla_Funcionalidades();
                pfuncio.ShowDialog();

            }
        }
    }
}
