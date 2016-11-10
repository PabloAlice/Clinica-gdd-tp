using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;

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

        public Pantalla_Registro_Agenda()
        {
            InitializeComponent();
            horasLaboralesTotales = new List<int>();

            espeAdapter = new GD2C2016DataSetTableAdapters.EspecialidadTableAdapter();

            espeData = espeAdapter.obtenerEspecialidades();

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
            int resultado;
            int outPut;
            int sumaHorasLaborales;

            if (listBox1.SelectedItems.Count == 0 || string.IsNullOrWhiteSpace(textBox1.Text) 
                || string.IsNullOrWhiteSpace(textBox2.Text) || comboBox1.Text =="")
            {
                MessageBox.Show("Faltan datos que completar");
            }
            else
            {

                if (int.TryParse(textBox1.Text, out outPut) && int.TryParse(textBox2.Text, out outPut))
                {

                    if (listBox1.SelectedItem.Equals("Sábado"))
                    {

                        if (Convert.ToInt16(textBox1.Text) >= 10 && Convert.ToInt16(textBox2.Text) <= 15)
                        {
                            resultado = Convert.ToInt16(textBox2.Text) - Convert.ToInt16(textBox1.Text);
                            horasLaboralesTotales.Add(resultado);
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
                                    MessageBox.Show("Agenda registrada satisfactoriamente");
                                    this.Close();
                                    psp.Close();
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
                        if (Convert.ToInt16(textBox1.Text) >= 7 && Convert.ToInt16(textBox2.Text) <= 20)
                        {
                            resultado = Convert.ToInt16(textBox2.Text) - Convert.ToInt16(textBox1.Text);
                            horasLaboralesTotales.Add(resultado);
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
                                    MessageBox.Show("Agenda registrada satisfactoriamente");
                                    this.Close();
                                    pfva.Close();
                                    psp.Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La clínica no atiende en esos horarios los días hábiles");
                       }
                    }
                }
                else
                {
                    MessageBox.Show("Los horarios deben ser valores numéricos");
                }

                }
            }

        internal void guardarDatos(Pantalla_Selecc_Profesional pantalla_Seleccion_Profesional)
        {
            psp = pantalla_Seleccion_Profesional;
        }

        internal void guardarDatos(Pantalla_Selecc_Profesional psp2, Pantalla_Fecha_Vigencia_Agenda pantalla_Fecha_Vigencia_Agenda,DateTime fiagenda,DateTime ffagenda)
        {
            psp = psp2;
            pfva = pantalla_Fecha_Vigencia_Agenda;
            fechaInicioAgenda = fiagenda;
            fechaFinAgenda = ffagenda;

        }
    }
    }
