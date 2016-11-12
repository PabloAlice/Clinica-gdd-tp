namespace ClinicaFrba.Cancelar_Atencion
{
    partial class Pantalla_Cancelacion_Afiliado
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellidoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultas registradas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaTurno,
            this.ColumnaNombreProfesional,
            this.ColumnaApellidoProfesional,
            this.ColumnaEspecialidad,
            this.ColumnaDiaAtencion,
            this.ColumnaCancelar});
            this.dataGridView1.Location = new System.Drawing.Point(6, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(825, 190);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnaTurno
            // 
            this.ColumnaTurno.HeaderText = "Nro_turno";
            this.ColumnaTurno.Name = "ColumnaTurno";
            this.ColumnaTurno.ReadOnly = true;
            // 
            // ColumnaNombreProfesional
            // 
            this.ColumnaNombreProfesional.HeaderText = "Nombre_profesional";
            this.ColumnaNombreProfesional.Name = "ColumnaNombreProfesional";
            this.ColumnaNombreProfesional.ReadOnly = true;
            this.ColumnaNombreProfesional.Width = 105;
            // 
            // ColumnaApellidoProfesional
            // 
            this.ColumnaApellidoProfesional.HeaderText = "Apellido_profesional";
            this.ColumnaApellidoProfesional.Name = "ColumnaApellidoProfesional";
            this.ColumnaApellidoProfesional.ReadOnly = true;
            this.ColumnaApellidoProfesional.Width = 105;
            // 
            // ColumnaEspecialidad
            // 
            this.ColumnaEspecialidad.HeaderText = "Especialidad";
            this.ColumnaEspecialidad.Name = "ColumnaEspecialidad";
            this.ColumnaEspecialidad.ReadOnly = true;
            this.ColumnaEspecialidad.Width = 255;
            // 
            // ColumnaDiaAtencion
            // 
            this.ColumnaDiaAtencion.HeaderText = "Fecha_atencion";
            this.ColumnaDiaAtencion.Name = "ColumnaDiaAtencion";
            this.ColumnaDiaAtencion.ReadOnly = true;
            this.ColumnaDiaAtencion.Width = 120;
            // 
            // ColumnaCancelar
            // 
            this.ColumnaCancelar.HeaderText = "Cancelar";
            this.ColumnaCancelar.Name = "ColumnaCancelar";
            this.ColumnaCancelar.ReadOnly = true;
            this.ColumnaCancelar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnaCancelar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnaCancelar.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la atención médica que desea cancelar:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pantalla_Cancelacion_Afiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pantalla_Cancelacion_Afiliado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla cancelación atención médica afiliado";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellidoProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDiaAtencion;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnaCancelar;
    }
}