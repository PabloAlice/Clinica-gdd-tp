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
        GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter funciAdapter;
        GD2C2016DataSet.FuncionalidadDataTable funciXrol;
        int idUser;


        string rolIngresado;

        public Pantalla_Funcionalidades(string rol,int id)
        {
            InitializeComponent();

            rolIngresado = rol;

            idUser = id;

            funciAdapter = new GD2C2016DataSetTableAdapters.FuncionalidadTableAdapter();

            funciXrol = funciAdapter.obtenerFuncionalidadesXrol(rolIngresado);

            foreach (DataRow funcionalidad in funciXrol.Rows)
            {

                switch(funcionalidad.Field<string>("nombre")){

                    case "ABM de Rol": button2.Visible = true;
                                             break;

                    case "ABM de Afiliados": button3.Visible = true;
                                             break;

                    case "Registrar agenda profesional": button4.Visible = true;
                                             break;

                    case "Comprar bono/s": button5.Visible = true;
                                             break;

                    case "Pedir turno": button6.Visible = true;
                                             break;

                    case "Registrar llegada": button7.Visible = true;
                                             break;

                    case "Historial cambios plan": button8.Visible = true;
                                             break;

                    case "Registrar resultado consulta": button9.Visible = true;
                                             break;

                    case "Cancelar atención médica": button10.Visible = true;
                                             break;

                    case "Obtener estadísticas": button11.Visible = true;
                                             break;

                    case "Modificar datos": button12.Visible = true;
                                             break;

                }




            }


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
            Pantalla_Compra_Bono_Afiliado pcbafiliado = new Pantalla_Compra_Bono_Afiliado(rolIngresado,idUser);
            pcbafiliado.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pantalla_PedidoTurno_Principal ptprinci = new Pantalla_PedidoTurno_Principal(idUser);
            ptprinci.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_Llegada_Principal prlprincipal = new Pantalla_Registro_Llegada_Principal();
            prlprincipal.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pantalla_Historial_Cambio_Plan phcp = new Pantalla_Historial_Cambio_Plan(idUser);
            phcp.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_Consulta_Principal prcp = new Pantalla_Registro_Consulta_Principal(idUser);
            prcp.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {

         if (rolIngresado.Equals("Profesional"))
           {

                Pantalla_Cancelacion_Profesional pcp = new Pantalla_Cancelacion_Profesional(idUser);
                pcp.ShowDialog();
              }
            else
             {

                Pantalla_Cancelacion_Afiliado pca = new Pantalla_Cancelacion_Afiliado(idUser);
                pca.ShowDialog();

           }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Pantalla_Estadisticas_Principal pep = new Pantalla_Estadisticas_Principal();
            pep.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            Pantalla_Modificacion_Datos_Afiliado pmda = new Pantalla_Modificacion_Datos_Afiliado(idUser);
            pmda.ShowDialog();

        }
    }
}
