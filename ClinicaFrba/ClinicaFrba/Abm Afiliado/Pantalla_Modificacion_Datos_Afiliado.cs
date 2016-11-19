using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Abm_Afiliado
{
    public partial class Pantalla_Modificacion_Datos_Afiliado : Form
    {
        GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter planAdapter;
        GD2C2016DataSet.Plan_MedicoDataTable planData;
        Pantalla_Funcionalidades pf;
        string contraseña = null;
        string nombrePlan;
        GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter;
        GD2C2016DataSet.AfiliadoDataTable afiData;
        decimal nroAfiliado;

        public Pantalla_Modificacion_Datos_Afiliado(decimal idUser)
        {
            InitializeComponent();

            planAdapter = new GD2C2016DataSetTableAdapters.Plan_MedicoTableAdapter();
            planData = planAdapter.obtenerPlanesMedicos();

            afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();
            afiData = afiAdapter.afiliadosPorID(idUser);

            textBox1.Text = Convert.ToString(afiData.Rows[0].Field<decimal>("telefono"));
            textBox2.Text = Convert.ToString(afiData.Rows[0].Field<string>("mail"));
            textBox4.Text = Convert.ToString(afiData.Rows[0].Field<string>("Direccion"));
            decimal plan = afiData.Rows[0].Field<decimal>("codigo_plan");
            bool? sexo = afiData.Rows[0].Field<bool?>("sexo");
            decimal? estadoCivil = afiData.Rows[0].Field<decimal?>("estado_civil");
            nroAfiliado = afiData.Rows[0].Field<decimal>("numero_afiliado");

            foreach (DataRow planM in planData.Rows)
            {

                comboBox4.Items.Add(planM.Field<string>("descripcion"));


            }

            nombrePlan = Convert.ToString(planAdapter.obtenerPlanMedicoPorID(plan));

            comboBox2.Items.Add("Masculino");
            comboBox2.Items.Add("Femenino");

            comboBox3.Items.Add("Soltero/a");
            comboBox3.Items.Add("Casado/a");
            comboBox3.Items.Add("Viudo/a");
            comboBox3.Items.Add("Concubinato");
            comboBox3.Items.Add("Divorciado/a");

            for(int i=0; i<comboBox4.Items.Count; i++)
            {

                if (Convert.ToString(comboBox4.Items[i]) == nombrePlan)
                {

                    comboBox4.SelectedIndex = i;
                
                }
            
            }
            if (sexo == Convert.ToBoolean(1))
            {

                comboBox2.SelectedIndex = 0;

            }
            else
            {

                comboBox2.SelectedIndex = 1;

            }


            if (estadoCivil == 0)
            {
                comboBox3.SelectedIndex = 0;
            }
            else
            {

                if (estadoCivil == 1)
                {
                    comboBox3.SelectedIndex = 1;
                }
                else
                {

                    if (estadoCivil == 2)
                    {
                        comboBox3.SelectedIndex = 2;
                    }
                    else
                    {

                        if (estadoCivil == 3)
                        {
                            comboBox3.SelectedIndex = 3;
                        }
                        else
                        {
                            comboBox3.SelectedIndex = 4;
                        }

                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GD2C2016DataSetTableAdapters.AfiliadoTableAdapter afiAdapter = new GD2C2016DataSetTableAdapters.AfiliadoTableAdapter();

            string mail;
            decimal telefono;
            string direccion;
            string plan;
            int sexo;
            decimal estado_civil;

            int outPutI;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {

                MessageBox.Show("Hay campos vacíos");

            }
            else
            {

                if ((!int.TryParse(textBox1.Text, out outPutI)) || int.TryParse(textBox2.Text, out outPutI) ||
                int.TryParse(textBox4.Text, out outPutI))
                {

                    MessageBox.Show("Datos inválidos");

                }
                else
                {

                    telefono = Convert.ToDecimal(textBox1.Text);
                    mail = textBox2.Text;
                    direccion = textBox4.Text;

                    if(!string.IsNullOrWhiteSpace(textBox9.Text)){

                    contraseña = textBox9.Text;

                    }
                    plan = comboBox4.Text;

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


                    afiAdapter.modificarAfiliado(direccion, telefono, mail, Convert.ToBoolean(sexo), nroAfiliado, estado_civil, contraseña, plan);

                    MessageBox.Show("Datos modificados correctamente");
                    this.Close();


                    if (nombrePlan != plan)
                    {

                        Pantalla_Motivo_Cambio_Plan pmcb = new Pantalla_Motivo_Cambio_Plan(plan,nroAfiliado);
                        pmcb.ShowDialog();

                    }

                }

            }
        }

    }
}
