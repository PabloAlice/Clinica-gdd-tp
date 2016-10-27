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
using ClinicaFrba.AbmRol;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    public partial class Pantalla_Login : Form
    {

        GD2C2016DataSetTableAdapters.UsuarioTableAdapter adapterUsuarios;
        GD2C2016DataSetTableAdapters.RolTableAdapter adapterRol;


        public Pantalla_Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            adapterUsuarios = new GD2C2016DataSetTableAdapters.UsuarioTableAdapter();
            adapterRol = new GD2C2016DataSetTableAdapters.RolTableAdapter();

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
                
                try{

                bool outPut = Convert.ToBoolean(adapterUsuarios.login(textBox1.Text, textBox2.Text));

                 if (outPut)
                    {

                        int cantRoles = (int)adapterUsuarios.cantidadRoles(textBox1.Text);

                        if (cantRoles > 1)
                        {
                            Pantalla_Seleccion_Rol seleccionRol = new Pantalla_Seleccion_Rol(textBox1.Text);
                            seleccionRol.ShowDialog();
                            
                        }
                        else
                        {
                            GD2C2016DataSet.RolDataTable infoRol = adapterRol.ObtenerRol(textBox1.Text);
                            Pantalla_Funcionalidades pantallaFunci = new Pantalla_Funcionalidades(infoRol.Rows[0].Field<String>("nombre"));
                            pantallaFunci.ShowDialog();
                            
                        }
                    }
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {

                        case 40003:
                            MessageBox.Show("Password incorrecta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        case 40002:
                            MessageBox.Show("Usuario bloqueado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        case 40001:
                            MessageBox.Show("El usuario no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;       
                            default: MessageBox.Show("Error desconocido"+ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                    }
                }

            }
        }
    }
}
