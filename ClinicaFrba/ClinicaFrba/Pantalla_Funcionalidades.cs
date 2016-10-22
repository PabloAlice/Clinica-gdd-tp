using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Registrar_Agenta_Medico;
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
    public partial class Pantalla_Funcionalidades : Form
    {
        public Pantalla_Funcionalidades()
        {
            InitializeComponent();
        }

 
        private void button2_Click(object sender, EventArgs e)
        {
            Pantalla_Rol_Principal prprinci = new Pantalla_Rol_Principal();
            prprinci.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pantalla_Afiliado_Principal paprinci = new Pantalla_Afiliado_Principal();
            paprinci.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pantalla_Seleccion_Profesional pragenda = new Pantalla_Seleccion_Profesional();
            pragenda.ShowDialog();
        }
    }
}
