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
    public partial class Pantalla_Opciones_Modificacion : Form
    {
        public Pantalla_Opciones_Modificacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pantalla_Modificacion_Rol_Principal pmrprinci = new Pantalla_Modificacion_Rol_Principal();
            pmrprinci.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pantalla_Habilitacion_Rol phrol = new Pantalla_Habilitacion_Rol();
            phrol.ShowDialog();
        }
    }
}
