using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class Pantalla_Cancelacion_Profesional : Form
    {
        string fechaHoy;
        decimal idUser;
        int diaIngresado;
        DateTime? horaInicio;
        DateTime? horaFin;

        public Pantalla_Cancelacion_Profesional(decimal idU)
        {
            InitializeComponent();

            idUser = idU;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MinDate = Convert.ToDateTime(fechaHoy);
            dateTimePicker2.MinDate = Convert.ToDateTime(fechaHoy);

            comboBox2.Items.Add("00");
            comboBox2.Items.Add(30);

            comboBox4.Items.Add("00");
            comboBox4.Items.Add(30);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            string fechaIngresada = dateTimePicker1.Value.ToShortDateString();

            
            if (fechaIngresada == fechaHoy)
            {

                MessageBox.Show("No puedes cancelar turnos un mismo día");

            }
            else
            {


                Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional(fechaIngresada,idUser,null,null);
                pmcp.guardarDatos(this);
                pmcp.ShowDialog();
               

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string fechaIngresada = dateTimePicker2.Value.ToShortDateString();

            if (fechaIngresada == fechaHoy)
            {

                MessageBox.Show("No puedes cancelar turnos un mismo día");

            }
            else
            {
                button3.Enabled = false;

                button5.Enabled = true;

                DateTime fecha = Convert.ToDateTime(fechaIngresada);

                diaIngresado = (int)fecha.DayOfWeek;

                if (diaIngresado == 6)
                {

                    comboBox1.Items.Add(10);
                    comboBox1.Items.Add(11);
                    comboBox1.Items.Add(12);
                    comboBox1.Items.Add(13);
                    comboBox1.Items.Add(14);
                    comboBox1.Items.Add(15);

                    comboBox3.Items.Add(10);
                    comboBox3.Items.Add(11);
                    comboBox3.Items.Add(12);
                    comboBox3.Items.Add(13);
                    comboBox3.Items.Add(14);
                    comboBox3.Items.Add(15);


                }
                else
                {

                    comboBox1.Items.Add(7);
                    comboBox1.Items.Add(8);
                    comboBox1.Items.Add(9);
                    comboBox1.Items.Add(10);
                    comboBox1.Items.Add(11);
                    comboBox1.Items.Add(12);
                    comboBox1.Items.Add(13);
                    comboBox1.Items.Add(14);
                    comboBox1.Items.Add(15);
                    comboBox1.Items.Add(16);
                    comboBox1.Items.Add(17);
                    comboBox1.Items.Add(18);
                    comboBox1.Items.Add(19);
                    comboBox1.Items.Add(20);

                    comboBox3.Items.Add(7);
                    comboBox3.Items.Add(8);
                    comboBox3.Items.Add(9);
                    comboBox3.Items.Add(10);
                    comboBox3.Items.Add(11);
                    comboBox3.Items.Add(12);
                    comboBox3.Items.Add(13);
                    comboBox3.Items.Add(14);
                    comboBox3.Items.Add(15);
                    comboBox3.Items.Add(16);
                    comboBox3.Items.Add(17);
                    comboBox3.Items.Add(18);
                    comboBox3.Items.Add(19);
                    comboBox3.Items.Add(20);

                }

                dateTimePicker2.Enabled = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                button4.Enabled = true;

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

           string fechaAcancelar = dateTimePicker2.Value.ToShortDateString();

            horaInicio = new DateTime(1800, 1, 1, Convert.ToInt16(comboBox1.Text), Convert.ToInt16(comboBox2.Text), 0);

            horaFin = new DateTime(1800, 1, 1, Convert.ToInt16(comboBox3.Text), Convert.ToInt16(comboBox4.Text), 0);

            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox4.Text) || string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                MessageBox.Show("Complete rango de horario de cancelación");
            }
            else
            {
                if (Convert.ToInt16(comboBox1.Text) > Convert.ToInt16(comboBox3.Text))
                {

                    MessageBox.Show("El horario desde no puede ser mayor que el hasta");

                }
                else
                {

                    if (Convert.ToInt16(comboBox1.Text) == Convert.ToInt16(comboBox3.Text))
                    {

                        if (Convert.ToInt16(comboBox2.Text) > Convert.ToInt16(comboBox4.Text))
                        {

                            MessageBox.Show("El horario desde no puede ser mayor que el hasta");

                        }
                        
                        }

                        else
                        {

                            if (diaIngresado == 6)
                            {
                                if (Convert.ToInt16(comboBox1.Text) >= 10 && Convert.ToInt16(comboBox3.Text) < 15)
                                {


                                    Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional(fechaAcancelar,idUser,horaInicio,horaFin);
                                    pmcp.guardarDatos(this);
                                    pmcp.ShowDialog();


                                }
                                else
                                {
                                    if (Convert.ToInt16(comboBox1.Text) < 10 && Convert.ToInt16(comboBox3.Text) > 15)
                                    {

                                        MessageBox.Show("Esta cerrada la clínica en esos horarios");

                                    }
                                    else
                                    {

                                        if (Convert.ToInt16(comboBox3.Text) == 15)
                                        {
                                            if (Convert.ToInt16(comboBox4.Text) == 30)
                                            {


                                                MessageBox.Show("Esta cerrada la clínica en esos horarios");

                                            }
                                            else
                                            {

                                                Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional(fechaAcancelar, idUser, horaInicio, horaFin);
                                                pmcp.guardarDatos(this);
                                                pmcp.ShowDialog();

                                            }

                                        }

                                    }

                                }
                            }
                            else
                            {


                                if (Convert.ToInt16(comboBox1.Text) >= 7 && Convert.ToInt16(comboBox3.Text) < 20)
                                {


                                    Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional(fechaAcancelar, idUser, horaInicio, horaFin);
                                    pmcp.guardarDatos(this);
                                    pmcp.ShowDialog();


                                }
                                else
                                {

                                    if (Convert.ToInt16(comboBox3.Text) == 20 && Convert.ToInt16(comboBox4.Text) == 30)
                                    {

                                        MessageBox.Show("Esta cerrada la clínica en esos horarios");

                                    }
                                    else
                                    {

                                        Pantalla_Motivo_Cancelacion_Profesional pmcp = new Pantalla_Motivo_Cancelacion_Profesional(fechaAcancelar, idUser, horaInicio, horaFin);
                                        pmcp.guardarDatos(this);
                                        pmcp.ShowDialog();

                                    }

                                }

                            }

                        }

                    }
                }

            }
        

        private void button5_Click(object sender, EventArgs e)
        {

            dateTimePicker2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;

            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

        }
    }
}
