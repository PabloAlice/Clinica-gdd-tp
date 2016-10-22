using System;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Creacion_Afiliado : Form
    {
        public Pantalla_Creacion_Afiliado()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            comboBox1.Items.Add("DNI");
            comboBox1.Items.Add("CI");
            comboBox1.Items.Add("LE");
            comboBox1.Items.Add("LC");

            comboBox2.Items.Add("Masculino");
            comboBox2.Items.Add("Femenino");

            comboBox3.Items.Add("Soltero/a");
            comboBox3.Items.Add("Casado/a");
            comboBox3.Items.Add("Viudo/a");
            comboBox3.Items.Add("Concubinato");
            comboBox3.Items.Add("Divorciado/a");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if ((comboBox3.Text.Equals("Casado/a") || comboBox3.Text.Equals("Concubinato")) && radioButton1.Checked)
            {

                DialogResult result1 = MessageBox.Show("Desea asociar a su cónyuge?",
                "Pregunta alta cónyuge",
                MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    Pantalla_Asociacion_Conyuge paconyuge = new Pantalla_Asociacion_Conyuge();
                    paconyuge.guardaRadioButton(this.radioButton1);
                    paconyuge.ShowDialog();

                }
                else
                {
                    DialogResult result2 = MessageBox.Show("Desea asociar a sus familiares?",
                    "Pregunta alta familiares",
                    MessageBoxButtons.YesNo);

                    if (result2 == DialogResult.Yes)
                    {

                        Pantalla_Asociacion_Familiares pafamiliares = new Pantalla_Asociacion_Familiares();
                        pafamiliares.ShowDialog();

                    }
                    else
                    {

                        Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                        pnaprincipal.ShowDialog();

                    }

                }

            }
            else
            {
                if ((comboBox3.Text.Equals("Casado/a") || comboBox3.Text.Equals("Concubinato")) && !radioButton1.Checked)
                {

                    DialogResult result3 = MessageBox.Show("Desea asociar a su cónyuge?",
                "Pregunta alta cónyuge",
                MessageBoxButtons.YesNo);

                    if (result3 == DialogResult.Yes)
                    {

                        Pantalla_Asociacion_Conyuge paconyuge = new Pantalla_Asociacion_Conyuge();
                        paconyuge.ShowDialog();

                    }
                    else
                    {

                        Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                        pnaprincipal.ShowDialog();

                    }

                }
                else
                {
                    if ((!comboBox3.Text.Equals("Casado/a") && !comboBox3.Text.Equals("Concubinato")) && radioButton1.Checked)
                    {
                        DialogResult result4 = MessageBox.Show("Desea asociar a sus familiares?",
                        "Pregunta alta familiares",
                        MessageBoxButtons.YesNo);

                        if (result4 == DialogResult.Yes)
                        {

                            Pantalla_Asociacion_Familiares pafamiliares = new Pantalla_Asociacion_Familiares();
                            pafamiliares.ShowDialog();

                        }
                        else
                        {

                            Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                            pnaprincipal.ShowDialog();

                        }

                    }

                    else
                    {

                        Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                        pnaprincipal.ShowDialog();

                    }
                }
            }
        }
    }
}