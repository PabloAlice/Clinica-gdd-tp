namespace ClinicaFrba.Registro_Llegada
{
    partial class Pantalla_Registro_Turno
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnaTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNroAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaRegistrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 292);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profesionales por especialidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccione la llegada a registrar:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaTurno,
            this.ColumnaNroAfiliado,
            this.ColumnaNombre,
            this.ColumnaApellido,
            this.ColumnaHorario,
            this.ColumnaRegistrar});
            this.dataGridView1.Location = new System.Drawing.Point(6, 67);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(660, 216);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ColumnaTurno
            // 
            this.ColumnaTurno.HeaderText = "Nro_turno";
            this.ColumnaTurno.Name = "ColumnaTurno";
            this.ColumnaTurno.ReadOnly = true;
            // 
            // ColumnaNroAfiliado
            // 
            this.ColumnaNroAfiliado.HeaderText = "ID_afiliado";
            this.ColumnaNroAfiliado.Name = "ColumnaNroAfiliado";
            this.ColumnaNroAfiliado.ReadOnly = true;
            // 
            // ColumnaNombre
            // 
            this.ColumnaNombre.HeaderText = "Nombre_afiliado";
            this.ColumnaNombre.Name = "ColumnaNombre";
            this.ColumnaNombre.ReadOnly = true;
            // 
            // ColumnaApellido
            // 
            this.ColumnaApellido.HeaderText = "Apellido_afiliado";
            this.ColumnaApellido.Name = "ColumnaApellido";
            this.ColumnaApellido.ReadOnly = true;
            // 
            // ColumnaHorario
            // 
            this.ColumnaHorario.HeaderText = "Horario_atencion";
            this.ColumnaHorario.Name = "ColumnaHorario";
            this.ColumnaHorario.ReadOnly = true;
            // 
            // ColumnaRegistrar
            // 
            this.ColumnaRegistrar.HeaderText = "Registrar";
            this.ColumnaRegistrar.Name = "ColumnaRegistrar";
            this.ColumnaRegistrar.ReadOnly = true;
            // 
            // Pantalla_Registro_Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Pantalla_Registro_Turno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla registro llegada";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNroAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaHorario;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnaRegistrar;
    }
}