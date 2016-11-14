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
    public partial class Pantalla_Asociacion_Familiares : Form
    {

        Pantalla_Creacion_Afiliado pca;
        Pantalla_Asociacion_Conyuge pac;
        string fechaHoy;
        DataTable tablaAfiliados;
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        int nroAfiliadoConyuPrincipal;
        int times;
        string numeroAfiliado;
        int nroAfi;
        int familiares;

        public Pantalla_Asociacion_Familiares(int nroAfiliadoConyuPrinci, string nombre, string apellido)
        {
            InitializeComponent();

            times = 0;

            familiares = 0;

            tablaAfiliados = new DataTable();

            tablaAfiliados.Columns.Add("nro_afiliado");
            tablaAfiliados.Columns.Add("nombre");
            tablaAfiliados.Columns.Add("apellido");

            if (nroAfiliadoConyuPrinci != -1)
            {

                nroAfiliadoConyuPrincipal = nroAfiliadoConyuPrinci;

                tablaAfiliados.Rows.Add(nroAfiliadoConyuPrinci, nombre, apellido);
            }
            else
            {

                times = -1;

            }


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            var MyReader = new System.Configuration.AppSettingsReader();

            fechaHoy = MyReader.GetValue("Datekey", typeof(string)).ToString();

            dateTimePicker1.MaxDate = Convert.ToDateTime(fechaHoy);

            comboBox3.Items.Add("Soltero/a");
            comboBox3.Items.Add("Casado/a");
            comboBox3.Items.Add("Viudo/a");
            comboBox3.Items.Add("Concubinato");
            comboBox3.Items.Add("Divorciado/a");

            comboBox1.Items.Add("DNI");
            comboBox1.Items.Add("CI");
            comboBox1.Items.Add("LE");
            comboBox1.Items.Add("LC");

            comboBox2.Items.Add("Masculino");
            comboBox2.Items.Add("Femenino");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();
            string username;
            string password;
            string plan;
            Decimal telefono;
            string mail;
            DateTime fecha_nac;
            int sexo;
            int estado_civil;
            string nombre;
            string apellido;
            Decimal dni;
            string direccion;

            int outPutI;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text)  ||
               string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox9.Text) ||
               comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
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

                    familiares = familiares + 1;

                    if (times == 0)
                    {

                        numeroAfiliado = nroAfiliadoConyuPrincipal + "1";

                        nroAfi = Convert.ToInt32(numeroAfiliado);

                    }
                    else
                    {

                        if (times == -1)
                        {

                            Int32 index = tablaAfiliados.Rows.Count - 1;

                            numeroAfiliado = tablaAfiliados.Rows[index].Field<string>("nro_afiliado");

                            nroAfi = Convert.ToInt32(numeroAfiliado) + 1;

                        }

                    }

                    if (comboBox2.Text == "Masculino")
                    {
                        sexo = 1;
                    }
                    else
                    {
                        sexo = 0;
                    }


                    if (comboBox3.Text == "Soltero/a")
                    {
                        estado_civil = 0;
                    }
                    else
                    {

                        if (comboBox3.Text == "Casado/a")
                        {
                            estado_civil = 1;
                        }
                        else
                        {

                            if (comboBox3.Text == "Viudo/a")
                            {
                                estado_civil = 2;
                            }
                            else
                            {

                                if (comboBox3.Text == "Concubinato")
                                {
                                    estado_civil = 3;
                                }
                                else
                                {
                                    estado_civil = 4;
                                }

                            }
                        }
                    }


                    DialogResult result1 = MessageBox.Show("Desea asociar a más familiares?",
                       "Pregunta asociación familiares",
                       MessageBoxButtons.YesNo);

                    if (result1 == DialogResult.Yes)
                    {


                        try
                        {

                            if (times == 1)
                            {

                                Int32 index = tablaAfiliados.Rows.Count - 1;

                                numeroAfiliado = tablaAfiliados.Rows[index].Field<string>("nro_afiliado");

                                nroAfi = Convert.ToInt32(numeroAfiliado) + 1;
                            }

                            afiAdapter.crearAfiliado(username, password, nombre, apellido, dni, direccion, telefono, mail, fecha_nac, Convert.ToBoolean(sexo), nroAfi, estado_civil, 0, plan);

                            tablaAfiliados.Rows.Add(nroAfi, nombre, apellido);

                            times = 1;

                            textBox1.ResetText();
                            textBox2.ResetText();
                            textBox3.ResetText();
                            textBox4.ResetText();
                            textBox5.ResetText();
                            textBox6.ResetText();
                            textBox9.ResetText();
                            textBox8.ResetText();
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                            comboBox3.SelectedIndex = -1;



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
                            if (times != -1)
                            {
                                Int32 index = tablaAfiliados.Rows.Count - 1;

                                numeroAfiliado = tablaAfiliados.Rows[index].Field<string>("nro_afiliado");

                                nroAfi = Convert.ToInt32(numeroAfiliado) + 1;
                            }

                            afiAdapter.crearAfiliado(username, password, nombre, apellido, dni, direccion, telefono, mail, fecha_nac, Convert.ToBoolean(sexo), nroAfi, estado_civil, 0, plan);
                            
                            tablaAfiliados.Rows.Add(nroAfi, nombre, apellido);

                            afiAdapter.actualizarFamiliaresAfiliado(Convert.ToDecimal(tablaAfiliados.Rows[0].Field<string>("nro_afiliado")), familiares);
                            
                            MessageBox.Show("Registros exitosos");
                            
                            Pantalla_Muchos_Afiliados pma = new Pantalla_Muchos_Afiliados(tablaAfiliados);
                            pma.ShowDialog();
                            this.Close();
                            pca.Close();

                            if (pac != null)
                            {
                                pac.Close();
                            }

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
            }
        }

        internal void guardaPlanMedico(string p)
        {
            this.textBox7.Text = p;
        }

        internal void guardame(Pantalla_Creacion_Afiliado pantalla_Creacion_Afiliado)
        {
            pca = pantalla_Creacion_Afiliado;
        }

        internal void guardameDos(Pantalla_Asociacion_Conyuge pantalla_Asociacion_Conyuge)
        {
            pac = pantalla_Asociacion_Conyuge;
        }


        internal void guardarTabla(DataTable tablaAfi)
        {

            foreach (DataRow afiliado in tablaAfi.Rows)
            {

                tablaAfiliados.Rows.Add(afiliado.Field<string>("nro_afiliado"),
                                         afiliado.Field<string>("nombre"),
                                         afiliado.Field<string>("apellido"));

            }

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
            comboBox3.SelectedIndex = -1;
        }

    }
}