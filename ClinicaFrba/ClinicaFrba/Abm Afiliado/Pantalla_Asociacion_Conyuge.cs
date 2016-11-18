using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Asociacion_Conyuge : Form
    {
        RadioButton radioB;
        Pantalla_Creacion_Afiliado pca;
        string fechaHoy;
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        DataTable tablaAfiliados;
        int nroAfiliadoConyugePrincipal;

        public Pantalla_Asociacion_Conyuge(int nroAfiliadoConyuPrinci,string nombre,string apellido)
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            nroAfiliadoConyugePrincipal = nroAfiliadoConyuPrinci;

            tablaAfiliados = new DataTable();
            tablaAfiliados.Columns.Add("nro_afiliado");
            tablaAfiliados.Columns.Add("nombre");
            tablaAfiliados.Columns.Add("apellido");
            tablaAfiliados.Rows.Add(nroAfiliadoConyugePrincipal, nombre, apellido);

            comboBox1.Items.Add("DNI");
            comboBox1.Items.Add("CI");
            comboBox1.Items.Add("LE");
            comboBox1.Items.Add("LC");

            comboBox2.Items.Add("Masculino");
            comboBox2.Items.Add("Femenino");

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MaxDate = Convert.ToDateTime(fechaHoy);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();
            int outPutI;
            string username;
            string password;
            string plan;
            Decimal telefono;
            string mail;
            DateTime fecha_nac;
            int sexo;
            int estado_civil = 1;
            int familiares = 0;
            string nombre;
            string apellido;
            Decimal dni;
            string direccion;
            int numeroAfiliado;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox9.Text) ||
              comboBox1.Text == "" || comboBox2.Text == "")
            {

                MessageBox.Show("Hay campos vacíos");

            }
            else
            {

                if (int.TryParse(textBox1.Text, out outPutI) || int.TryParse(textBox2.Text, out outPutI) ||
                  (!int.TryParse(textBox3.Text, out outPutI)) || int.TryParse(textBox4.Text, out outPutI) ||
                  (!int.TryParse(textBox5.Text, out outPutI)) || int.TryParse(textBox6.Text, out outPutI))
                {

                    MessageBox.Show("Datos inválidos");

                }
                else
                {

                    username = textBox8.Text;
                    password = textBox9.Text;
                    plan = textBox7.Text;
                    telefono = Convert.ToDecimal(textBox5.Text);
                    mail = textBox6.Text;
                    fecha_nac = dateTimePicker1.Value;
                    nombre = textBox1.Text;
                    apellido = textBox2.Text;
                    dni = Convert.ToDecimal(textBox3.Text);
                    direccion = textBox4.Text;

                    numeroAfiliado = nroAfiliadoConyugePrincipal + 1;

                    tablaAfiliados.Rows.Add(numeroAfiliado, nombre, apellido);

                    if (comboBox2.Text == "Masculino")
                    {
                        sexo = 1;
                    }
                    else
                    {
                        sexo = 0;
                    }

                    afiAdapter.crearAfiliado(username, password, nombre, apellido, dni, direccion, telefono, mail, fecha_nac, Convert.ToBoolean(sexo), Convert.ToInt32(numeroAfiliado), estado_civil, familiares, plan);

                    if (radioB != null)
                    {
                        DialogResult result1 = MessageBox.Show("Desea asociar a sus familiares?",
                            "Pregunta alta familiar",
                            MessageBoxButtons.YesNo);

                        if (result1 == DialogResult.Yes)
                        {


                            try
                            {

                                Pantalla_Asociacion_Familiares pafamiliares = new Pantalla_Asociacion_Familiares(-1,"a","a");
                                pafamiliares.guardaPlanMedico(this.textBox7.Text);
                                pafamiliares.guardameDos(this);
                                pafamiliares.guardame(pca);
                                pafamiliares.guardarTabla(tablaAfiliados);
                                pafamiliares.ShowDialog();

                            }
                            catch (SqlException ex)
                            {

                                switch (ex.Number)
                                {

                                    case 40000: MessageBox.Show("Ya existe un afiliado con ese nombre de usuario");
                                        break;
                                }

                            }
                        }
                        else
                        {

                            try
                            {

                                MessageBox.Show("Registros exitosos");
                                Pantalla_Muchos_Afiliados pma = new Pantalla_Muchos_Afiliados(tablaAfiliados);
                                pma.ShowDialog();
                                this.Close();
                                pca.Close();

                            }
                            catch (SqlException ex)
                            {

                                switch (ex.Number)
                                {

                                    case 40000: MessageBox.Show("Ya existe un afiliado con ese nombre de usuario");
                                        break;
                                }

                            }


                        }

                    }
                    else
                    {
                        try
                             {
                                                                
                        MessageBox.Show("Registros exitosos");
                        Pantalla_Muchos_Afiliados pma = new Pantalla_Muchos_Afiliados(tablaAfiliados);
                        pma.ShowDialog();
                        this.Close();
                        pca.Close();

                        }catch(SqlException ex){

                            switch (ex.Number)
                            {

                                case 40000: MessageBox.Show("Ya existe un afiliado con ese nombre de usuario");
                                    break;
                            }

                        }

                    }

                }

            }

        }

        internal void guardaRadioButton(RadioButton radioButton)
        {
            radioB = radioButton;
        }

        internal void guardaPlanMedico(string p)
        {
            this.textBox7.Text = p;
        }

        internal void guardame(Pantalla_Creacion_Afiliado pantalla_Creacion_Afiliado)
        {

            pca = pantalla_Creacion_Afiliado;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }


    }
}
