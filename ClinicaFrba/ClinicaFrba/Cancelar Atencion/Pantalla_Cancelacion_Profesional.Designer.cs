namespace ClinicaFrba.Cancelar_Atencion
{
    partial class Pantalla_Cancelacion_Profesional
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellidoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDiaAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaCancelar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 357);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultas registradas";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Si desea cancelar todo un día en particular seleccione la fecha debajo:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaEspecialidad,
            this.ColumnaNombreProfesional,
            this.ColumnaApellidoProfesional,
            this.ColumnaHorario,
            this.ColumnaDiaAtencion,
            this.ColumnaCancelar});
            this.dataGridView1.Location = new System.Drawing.Point(6, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(653, 220);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnaEspecialidad
            // 
            this.ColumnaEspecialidad.HeaderText = "Nro_afiliado";
            this.ColumnaEspecialidad.Name = "ColumnaEspecialidad";
            this.ColumnaEspecialidad.ReadOnly = true;
            // 
            // ColumnaNombreProfesional
            // 
            this.ColumnaNombreProfesional.HeaderText = "Nombre_afiliado";
            this.ColumnaNombreProfesional.Name = "ColumnaNombreProfesional";
            this.ColumnaNombreProfesional.ReadOnly = true;
            this.ColumnaNombreProfesional.Width = 105;
            // 
            // ColumnaApellidoProfesional
            // 
            this.ColumnaApellidoProfesional.HeaderText = "Apellido_afiliado";
            this.ColumnaApellidoProfesional.Name = "ColumnaApellidoProfesional";
            this.ColumnaApellidoProfesional.ReadOnly = true;
            this.ColumnaApellidoProfesional.Width = 105;
            // 
            // ColumnaHorario
            // 
            this.ColumnaHorario.HeaderText = "Horario_atencion";
            this.ColumnaHorario.Name = "ColumnaHorario";
            this.ColumnaHorario.ReadOnly = true;
            // 
            // ColumnaDiaAtencion
            // 
            this.ColumnaDiaAtencion.HeaderText = "Fecha_atencion";
            this.ColumnaDiaAtencion.Name = "ColumnaDiaAtencion";
            this.ColumnaDiaAtencion.ReadOnly = true;
            // 
            // ColumnaCancelar
            // 
            this.ColumnaCancelar.HeaderText = "Cancelar";
            this.ColumnaCancelar.Name = "ColumnaCancelar";
            this.ColumnaCancelar.ReadOnly = true;
            this.ColumnaCancelar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaCancelar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Si desea cancelar una atención en particular seleccionela debajo:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pantalla_Cancelacion_Profesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pantalla_Cancelacion_Profesional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla cancelación atención médica profesional";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellidoProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDiaAtencion;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnaCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
    }
}