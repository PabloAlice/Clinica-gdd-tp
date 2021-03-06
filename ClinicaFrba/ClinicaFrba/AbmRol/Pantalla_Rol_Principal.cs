﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.AbmRol
{
    public partial class Pantalla_Rol_Principal : Form
    {
        public Pantalla_Rol_Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pantalla_Creacion_Rol pcrol = new Pantalla_Creacion_Rol();
            pcrol.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pantalla_Opciones_Modificacion pomodi = new Pantalla_Opciones_Modificacion();
            pomodi.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pantalla_Eliminacion_Rol perol = new Pantalla_Eliminacion_Rol();
            perol.ShowDialog();
        }

    }
}
