using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Listados
{
    public partial class Pantalla_Estadisticas_Principal : Form
    {
        public Pantalla_Estadisticas_Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pantalla_Especialidades_Canceladas pec = new Pantalla_Especialidades_Canceladas();
            pec.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pantalla_Profesionales_Mas_Consultados ppmc = new Pantalla_Profesionales_Mas_Consultados();
            ppmc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pantalla_Profesionales_Menos_Horas_Trabajo ppmht = new Pantalla_Profesionales_Menos_Horas_Trabajo();
            ppmht.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pantalla_Afiliado_Mayor_Cant_Bonos pamcb = new Pantalla_Afiliado_Mayor_Cant_Bonos();
            pamcb.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pantalla_Especialidades_Mayor_Cant_Bonos pemcb = new Pantalla_Especialidades_Mayor_Cant_Bonos();
            pemcb.ShowDialog();
        }
    }
}
