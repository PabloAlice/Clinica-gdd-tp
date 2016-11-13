using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Motivo_Cambio_Plan : Form
    {
        string p;
        decimal nroAfi;
        GD2C2016DataSetTableAdapters.Cambio_De_PlanTableAdapter cambioAdapter;
        string fechaHoy;

        public Pantalla_Motivo_Cambio_Plan(string plan, decimal numeroAfi)
        {
            InitializeComponent();

            cambioAdapter = new GD2C2016DataSetTableAdapters.Cambio_De_PlanTableAdapter();

            p = plan;

            nroAfi = numeroAfi;


            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int outPut;

            if (textBox1.Text == "")
            {

                MessageBox.Show("Ingrese motivo del cambio");

            }
            else
            {
                if (int.TryParse(textBox1.Text, out outPut))
                {

                    MessageBox.Show("El motivo no puede ser todo numerico");

                }
                else
                {

                    cambioAdapter.insertarCambioPlan(p, nroAfi, Convert.ToDateTime(fechaHoy), textBox1.Text);

                    MessageBox.Show("Cambio registrado correctamente");
                    this.Close();


                }

            }
        }
    }
}
