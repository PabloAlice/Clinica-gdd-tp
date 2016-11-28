using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Pantalla_Registro_Agenda : Form
    {

        List<int> horasLaboralesTotales;
        Pantalla_Selecc_Profesional psp;
        Pantalla_Fecha_Vigencia_Agenda pfva;
        GD2C2016DataSetTableAdapters.EspecialidadTableAdapter espeAdapter;
        GD2C2016DataSet.EspecialidadDataTable espeData;
        DateTime fechaFinAgenda;
        DateTime fechaInicioAgenda;
        DataTable tablaDias;
        decimal idProfesional;
        int dia;
        GD2C2016DataSetTableAdapters.AgendaTableAdapter agendaAdapter;
        DateTime horaInicio;
        DateTime horaFin;
        decimal idEspecialidad;

        public Pantalla_Registro_Agenda(decimal idP)
        {
            InitializeComponent();
            horasLaboralesTotales = new List<int>();

            idProfesional = idP;

            tablaDias = new DataTable();

            DataColumn dia = new DataColumn("dia");
            dia.DataType = System.Type.GetType("System.Int16");
            tablaDias.Columns.Add(dia);

            DataColumn horarioI = new DataColumn("horarioInicio");
            horarioI.DataType = System.Type.GetType("System.DateTime");
            tablaDias.Columns.Add(horarioI);

            DataColumn horarioF = new DataColumn("horarioFin");
            horarioF.DataType = System.Type.GetType("System.DateTime");
            tablaDias.Columns.Add(horarioF);
            
            DataColumn idEspe = new DataColumn("codigoE");
            idEspe.DataType = System.Type.GetType("System.Decimal");
            tablaDias.Columns.Add(idEspe); 

 
            agendaAdapter = new GD2C2016DataSetTableAdapters.AgendaTableAdapter();

            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();

            espeData = espeAdapter.obtenerEspecialidadesPorProfesional(idProfesional);


            foreach (DataRow espe in espeData.Rows)
            {
                comboBox1.Items.Add(espe.Field<string>("descripcion"));

            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sumaHorasLaborales;

            if (listBox1.SelectedItems.Count > 0)
            {

                switch (Convert.ToString(listBox1.SelectedItem))
                {

                    case "Lunes": dia = 1;
                        break;

                    case "Martes": dia = 2;
                        break;

                    case "Miércoles": dia = 3;
                        break;

                    case "Jueves": dia = 4;
                        break;

                    case "Viernes": dia = 5;
                        break;

                    case "Sábado": dia = 6;
                        break;


                }

            }

                if (listBox1.SelectedItems.Count == 0 || comboBox1.Text == "" || comboBox2.Text == "" ||
                    comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "")
                {
                    MessageBox.Show("Faltan datos que completar");
                }
                else
                {
                    if ((Convert.ToInt16(comboBox2.Text) > Convert.ToInt16(comboBox3.Text)) ||
                        (Convert.ToInt16(comboBox2.Text) == Convert.ToInt16(comboBox3.Text) &&
                        Convert.ToInt16(comboBox4.Text) == Convert.ToInt16(comboBox5.Text)) ||
                        (Convert.ToInt16(comboBox2.Text) == Convert.ToInt16(comboBox3.Text) &&
                        Convert.ToInt16(comboBox4.Text) > Convert.ToInt16(comboBox5.Text)))
                    {

                        MessageBox.Show("El horario de inicio no puede ser mayor o igual que el de fin");

                    }
                    else
                    {

                        if (listBox1.SelectedItem.Equals("Sábado"))
                        {

                            if (Convert.ToInt16(comboBox2.Text) >= 10 && Convert.ToInt16(comboBox3.Text) <= 14 &&
                                (Convert.ToInt16(comboBox5.Text) == 00 || Convert.ToInt16(comboBox5.Text) == 30))
                            {

                                horaInicio = new DateTime(1, 1, 1, Convert.ToInt16(comboBox2.Text), Convert.ToInt16(comboBox4.Text), 0);

                                horaFin = new DateTime(1, 1, 1, Convert.ToInt16(comboBox3.Text), Convert.ToInt16(comboBox5.Text), 0);

                                foreach (DataRow espe in espeData.Rows)
                                {

                                    if (espe.Field<string>("descripcion").Equals(comboBox1.Text))
                                    {


                                        idEspecialidad = espe.Field<decimal>("codigo");

                                        tablaDias.Rows.Add(dia, horaInicio, horaFin, idEspecialidad);

                                    }


                                }

                                TimeSpan tiempoTrabajo = horaFin - horaInicio;

                                horasLaboralesTotales.Add(Convert.ToInt16(tiempoTrabajo.TotalHours));

                                if (listBox1.Items.Count > 1)
                                {
                                    DialogResult result1 = MessageBox.Show("Desea registrar más días?",
                                    "Pregunta registro días",
                                    MessageBoxButtons.YesNo);

                                    if (result1 == DialogResult.Yes)
                                    {
                                        listBox1.Items.Remove(listBox1.SelectedItem);

                                    }

                                    else
                                    {
                                        sumaHorasLaborales = horasLaboralesTotales.Sum();

                                        if (sumaHorasLaborales > 48)
                                        {

                                            MessageBox.Show("El máximo de horas laborales es 48.Vuelva a registrar la agenda");
                                            this.Close();

                                        }
                                        else
                                        {
                                            try
                                            {
                                                agendaAdapter.registrarAgenda(idProfesional, fechaInicioAgenda, fechaFinAgenda, tablaDias);
                                                MessageBox.Show("Agenda registrada satisfactoriamente");
                                                this.Close();
                                                pfva.Close();
                                                psp.Close();

                                            }
                                            catch (SqlException ex)
                                            {

                                                switch (ex.Number)
                                                {

                                                    case 40000: MessageBox.Show("El profesional ya tiene una agenda creada");
                                                        return;

                                                }


                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    sumaHorasLaborales = horasLaboralesTotales.Sum();

                                    if (sumaHorasLaborales > 48)
                                    {

                                        MessageBox.Show("El máximo de horas laborales es 48.Vuelva a registrar la agenda");
                                        this.Close();

                                    }
                                    else
                                    {
                                        try
                                        {

                                            agendaAdapter.registrarAgenda(idProfesional, fechaInicioAgenda, fechaFinAgenda, tablaDias);
                                            MessageBox.Show("Agenda registrada satisfactoriamente");
                                            this.Close();
                                            pfva.Close();
                                            psp.Close();

                                        }
                                        catch (SqlException ex)
                                        {

                                            switch (ex.Number)
                                            {

                                                case 40000: MessageBox.Show("El profesional ya tiene una agenda creada");
                                                    return;

                                            }


                                        }
                                    }
                                }

                            }

                            else
                            {
                                MessageBox.Show("La clínica no atiende en esos horarios el sábado");
                            }
                        }
                        else
                        {

                            horaInicio = new DateTime(1, 1, 1, Convert.ToInt16(comboBox2.Text), Convert.ToInt16(comboBox4.Text), 0);

                            horaFin = new DateTime(1, 1, 1, Convert.ToInt16(comboBox3.Text), Convert.ToInt16(comboBox5.Text), 0);

                            foreach (DataRow espe in espeData.Rows)
                            {

                                if (espe.Field<string>("descripcion").Equals(comboBox1.Text))
                                {

                                    idEspecialidad = espe.Field<decimal>("codigo");

                                    tablaDias.Rows.Add(dia, horaInicio, horaFin, idEspecialidad);

                                }


                            }

                            TimeSpan tiempoTrabajo = horaFin - horaInicio;

                            horasLaboralesTotales.Add(Convert.ToInt16(tiempoTrabajo.TotalHours));

                            if (listBox1.Items.Count > 1)
                            {

                                DialogResult result1 = MessageBox.Show("Desea registrar más días?",
                                "Pregunta registro días",
                                MessageBoxButtons.YesNo);

                                if (result1 == DialogResult.Yes)
                                {
                                    listBox1.Items.Remove(listBox1.SelectedItem);
                                }
                                else
                                {
                                    sumaHorasLaborales = horasLaboralesTotales.Sum();

                                    if (sumaHorasLaborales > 48)
                                    {

                                        MessageBox.Show("El máximo de horas laborales es 48.Vuelva a registrar la agenda");
                                        this.Close();

                                    }
                                    else
                                    {
                                        try
                                        {
                                            agendaAdapter.registrarAgenda(idProfesional, fechaInicioAgenda, fechaFinAgenda, tablaDias);
                                            MessageBox.Show("Agenda registrada satisfactoriamente");
                                            this.Close();
                                            pfva.Close();
                                            psp.Close();

                                        }
                                        catch (SqlException ex)
                                        {

                                            switch (ex.Number)
                                            {

                                                case 40000: MessageBox.Show("El profesional ya tiene una agenda creada");
                                                    return;

                                            }


                                        }
                                    }
                                }

                            }
                            else
                            {


                                sumaHorasLaborales = horasLaboralesTotales.Sum();

                                if (sumaHorasLaborales > 48)
                                {

                                    MessageBox.Show("El máximo de horas laborales es 48.Vuelva a registrar la agenda");
                                    this.Close();

                                }
                                else
                                {
                                    try
                                    {

                                        agendaAdapter.registrarAgenda(idProfesional, fechaInicioAgenda, fechaFinAgenda, tablaDias);
                                        MessageBox.Show("Agenda registrada satisfactoriamente");
                                        this.Close();
                                        pfva.Close();
                                        psp.Close();

                                    }
                                    catch (SqlException ex)
                                    {

                                        switch (ex.Number)
                                        {

                                            case 40000: MessageBox.Show("El profesional ya tiene una agenda creada");
                                                return;

                                        }


                                    }
                                }

                            }

                        }
                    }
                }

            }
                                                    
         
        internal void guardarDatos(Pantalla_Selecc_Profesional pantalla_Seleccion_Profesional)
        {
            psp = pantalla_Seleccion_Profesional;
        }

        internal void guardarDatos(Pantalla_Selecc_Profesional psp2, Pantalla_Fecha_Vigencia_Agenda pantalla_Fecha_Vigencia_Agenda, DateTime fiagenda, DateTime ffagenda)
        {
            psp = psp2;
            pfva = pantalla_Fecha_Vigencia_Agenda;
            fechaInicioAgenda = fiagenda;
            fechaFinAgenda = ffagenda;

            DateTime fechaIAgenda = fechaInicioAgenda.Date;
            DateTime fechaFAgenda = fechaFinAgenda.Date;

            int encontrado = 0;

            for (int i = 1; i < 8; i++)
            {
                encontrado = 0;

                for (DateTime date = fechaIAgenda; date <= fechaFAgenda.Date; date = date.AddDays(1))
                {

                    if (Convert.ToInt16(date.DayOfWeek) == i)
                    {
                        encontrado = 1;
                        break;
                    }


                }

                if (encontrado == 0)
                {

                    switch (i)
                    {

                        case 1: listBox1.Items.Remove("Lunes");
                            break;

                        case 2:  listBox1.Items.Remove("Martes");
                            break;

                        case 3: listBox1.Items.Remove("Miércoles");
                            break;

                        case 4: listBox1.Items.Remove("Jueves");
                            break;

                        case 5: listBox1.Items.Remove("Viernes");
                            break;

                        case 6: listBox1.Items.Remove("Sábado");
                            break;


                    }

                }


            }

            if (listBox1.Items.Count < 6)
            {

                MessageBox.Show("Hemos removido los días que no estaban dentro de la vigencia de la agenda");

            }

        }
 
}
    }
