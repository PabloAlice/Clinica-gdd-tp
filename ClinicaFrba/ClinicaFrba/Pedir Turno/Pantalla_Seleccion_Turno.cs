using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Pantalla_Seleccion_Turno : Form
    {
        Pantalla_PedidoTurno_Principal pptp;
        string fechaHoy;
        decimal idProfesional;
        decimal idEspecialidad;
        decimal idUser;
        GD2C2016DataSetTableAdapters.Horario_AtencionTableAdapter horaAdapter;
        GD2C2016DataSet.Horario_AtencionDataTable horaData;
        GD2C2016DataSetTableAdapters.TurnoTableAdapter turnosAdapter;
        decimal idHorarioElegido;

        public Pantalla_Seleccion_Turno(decimal idP, decimal idE, decimal idUser)
        {
            InitializeComponent();

            horaAdapter = new GD2C2016DataSetTableAdapters.Horario_AtencionTableAdapter();

            turnosAdapter = new GD2C2016DataSetTableAdapters.TurnoTableAdapter();

            idProfesional = idP;

            idEspecialidad = idE;

            this.idUser = idUser;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MinDate = Convert.ToDateTime(fechaHoy);

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {

                MessageBox.Show("Seleccione algun horario para el turno");

            }
            else
            {

                foreach(DataRow horarios in horaData.Rows){

                    if(Convert.ToDateTime(listBox1.SelectedItem) == horarios.Field<DateTime>("fecha")){


                        idHorarioElegido = horarios.Field<decimal>("id");

                    }


                }

                Int32 nroTurno = Convert.ToInt32(turnosAdapter.registrarTurno(idUser, idHorarioElegido));

                MessageBox.Show("Registro de turno exitoso");
                Pantalla_Nro_Turno pnturno = new Pantalla_Nro_Turno(nroTurno);
                pnturno.guardaPantalla(this,pptp);
                pnturno.ShowDialog();


            }
        }


        internal void guardarDatos(Pantalla_PedidoTurno_Principal pantalla_PedidoTurno_Principal)
        {
            pptp = pantalla_PedidoTurno_Principal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            horaData = horaAdapter.obtenerHorariosDisponibles(idProfesional, idEspecialidad, dateTimePicker1.Value.Date);

            foreach (DataRow horario in horaData.Rows)
            {

                listBox1.Items.Add(horario.Field<DateTime>("fecha"));


            }

            if (horaData.Rows.Count == 0)
            {

                MessageBox.Show("El profesional no tiene turnos disponibles para esa fecha");

            }


        }
    }
}
