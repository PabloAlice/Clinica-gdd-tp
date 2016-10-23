using ClinicaFrba.Abm_Afiliado;
using ClinicaFrba.Abm_Planes;
using ClinicaFrba.AbmRol;
using ClinicaFrba.Cancelar_Atencion;
using ClinicaFrba.Compra_Bono;
using ClinicaFrba.Listados;
using ClinicaFrba.Pedir_Turno;
using ClinicaFrba.Registrar_Agenta_Medico;
using ClinicaFrba.Registro_Llegada;
using ClinicaFrba.Registro_Resultado;
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
            Pantalla_Selecc_Profesional psp = new Pantalla_Selecc_Profesional();
            psp.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pantalla_Compra_Bono_Afiliado pcbafiliado = new Pantalla_Compra_Bono_Afiliado();
            pcbafiliado.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pantalla_PedidoTurno_Principal ptprinci = new Pantalla_PedidoTurno_Principal();
            ptprinci.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_Llegada_Principal prlprincipal = new Pantalla_Registro_Llegada_Principal();
            prlprincipal.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pantalla_Historial_Cambio_Plan phcp = new Pantalla_Historial_Cambio_Plan();
            phcp.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_Consulta_Principal prcp = new Pantalla_Registro_Consulta_Principal();
            prcp.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Pantalla_Cancelacion_Profesional pcp = new Pantalla_Cancelacion_Profesional();
            pcp.ShowDialog();


            //Pantalla_Cancelacion_Afiliado pca = new Pantalla_Cancelacion_Afiliado();
            //pca.ShowDialog();


        }

        private void button11_Click(object sender, EventArgs e)
        {
            Pantalla_Estadisticas_Principal pep = new Pantalla_Estadisticas_Principal();
            pep.ShowDialog();
        }
    }
}
