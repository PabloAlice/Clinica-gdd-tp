using System;
using System.Data;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Creacion_Afiliado : Form
    {
        string fechaHoy;
        GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter planAdapter;
        GD2C2016DataSet.Plan_MedicoDataTable planData;

        public Pantalla_Creacion_Afiliado()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MaxDate = Convert.ToDateTime(fechaHoy);

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

            planAdapter = new GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter();

            planData = planAdapter.obtenerPlanesMedicos();

            foreach(DataRow plan in planData.Rows)
            {

                comboBox4.Items.Add(plan.Field<string>("descripcion"));


            }
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int outPutI;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text)  || string.IsNullOrWhiteSpace(textBox6.Text) ||
               string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text)  ||
                comboBox1.Text == "" || comboBox2.Text == "" ||comboBox3.Text == "" ||comboBox4 .Text == ""){

                MessageBox.Show("Hay campos vacíos");

            }else{

            if((!int.TryParse(textBox3.Text,out outPutI)) || (!int.TryParse(textBox5.Text,out outPutI)) ||
              int.TryParse(textBox1.Text,out outPutI) || int.TryParse(textBox2.Text,out outPutI) ||
              int.TryParse(textBox6.Text, out outPutI) || int.TryParse(textBox4.Text, out outPutI))
            {

                  MessageBox.Show("Datos inválidos");
            
            }else{

            if ((comboBox3.Text.Equals("Casado/a") || comboBox3.Text.Equals("Concubinato")) && radioButton1.Checked)
            {

                DialogResult result1 = MessageBox.Show("Desea asociar a su cónyuge?",
                "Pregunta alta cónyuge",
                MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {

                    Pantalla_Asociacion_Conyuge paconyuge = new Pantalla_Asociacion_Conyuge();
                    paconyuge.guardaRadioButton(this.radioButton1);
                    paconyuge.guardaPlanMedico(this.comboBox4.Text);
                    paconyuge.guardame(this);
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
                        pafamiliares.guardaPlanMedico(this.comboBox4.Text);
                        pafamiliares.guardame(this);
                        pafamiliares.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Registro Exitoso");
                        Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                        pnaprincipal.ShowDialog();
                        this.Close();

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
                        paconyuge.guardaPlanMedico(this.comboBox4.Text);
                        paconyuge.guardame(this);
                        paconyuge.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Registro Exitoso");
                        Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                        pnaprincipal.ShowDialog();
                        this.Close();
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
                            pafamiliares.guardaPlanMedico(this.comboBox4.Text);
                            pafamiliares.guardame(this);
                            pafamiliares.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Registro Exitoso");
                            Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                            pnaprincipal.ShowDialog();
                            this.Close();
                        }

                    }

                    else
                    {
                        MessageBox.Show("Registro Exitoso");
                        Pantalla_NroAfiliado_Principal pnaprincipal = new Pantalla_NroAfiliado_Principal();
                        pnaprincipal.ShowDialog();
                        this.Close();
                    }
                }
            }
        }
    }

  }

 }

}