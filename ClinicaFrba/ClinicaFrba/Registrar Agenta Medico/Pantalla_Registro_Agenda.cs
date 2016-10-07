using System;
using System.Windows.Forms;

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    public partial class Pantalla_Registro_Agenda : Form
    {
        public Pantalla_Registro_Agenda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int outPut;

            if (listBox1.SelectedItems.Count == 0 || textBox1.Text == "" || textBox2.Text == "")
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

                            DialogResult result1 = MessageBox.Show("Desea registrar más días?",
                            "Pregunta registro días",
                            MessageBoxButtons.YesNo);

                            if (result1 == DialogResult.Yes)
                            {
                                listBox1.Items.Remove(listBox1.SelectedItem);
                            }
                            else
                            {
                                MessageBox.Show("Agenda registrada satisfactoriamente");
                                this.Close();
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

                            DialogResult result1 = MessageBox.Show("Desea registrar más días?",
                            "Pregunta registro días",
                            MessageBoxButtons.YesNo);

                            if (result1 == DialogResult.Yes)
                            {
                                listBox1.Items.Remove(listBox1.SelectedItem);
                            }
                            else
                            {
                                MessageBox.Show("Agenda registrada satisfactoriamente");
                                this.Close();
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
        }
    }
