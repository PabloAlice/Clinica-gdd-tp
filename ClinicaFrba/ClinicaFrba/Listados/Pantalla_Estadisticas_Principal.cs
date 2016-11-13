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
        string añoHoy;

        public Pantalla_Estadisticas_Principal()
        {
            InitializeComponent();


            var MyReader = new System.Configuration.AppSettingsReader();

            DateTime fechaHoy = Convert.ToDateTime(MyReader.GetValue("Datekey", typeof(string)).ToString());

            string añoHoy = fechaHoy.Year.ToString();

            numericUpDown1.Minimum = 2000;
            numericUpDown1.Maximum = Convert.ToInt16(añoHoy);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pantalla_Especialidades_Canceladas pec = new Pantalla_Especialidades_Canceladas(numericUpDown1.Value,numericUpDown2.Value);
            pec.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pantalla_Profesionales_Mas_Consultados ppmc = new Pantalla_Profesionales_Mas_Consultados(numericUpDown1.Value, numericUpDown2.Value);
            ppmc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pantalla_Profesionales_Menos_Horas_Trabajo ppmht = new Pantalla_Profesionales_Menos_Horas_Trabajo(numericUpDown1.Value, numericUpDown2.Value);
            ppmht.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pantalla_Afiliado_Mayor_Cant_Bonos pamcb = new Pantalla_Afiliado_Mayor_Cant_Bonos(numericUpDown1.Value, numericUpDown2.Value);
            pamcb.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pantalla_Especialidades_Mayor_Cant_Bonos pemcb = new Pantalla_Especialidades_Mayor_Cant_Bonos(numericUpDown1.Value, numericUpDown2.Value);
            pemcb.ShowDialog();
        }

  
    }
}
