namespace ClinicaFrba.Abm_Planes
{
    partial class Pantalla_Historial_Cambio_Plan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 260);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial de cambios de plan";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFechaHora,
            this.ColumnaMotivo,
            this.ColumnaPlan});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(500, 235);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnFechaHora
            // 
            this.ColumnFechaHora.HeaderText = "Fecha_cambio";
            this.ColumnFechaHora.Name = "ColumnFechaHora";
            this.ColumnFechaHora.ReadOnly = true;
            // 
            // ColumnaMotivo
            // 
            this.ColumnaMotivo.HeaderText = "Motivo";
            this.ColumnaMotivo.Name = "ColumnaMotivo";
            this.ColumnaMotivo.ReadOnly = true;
            this.ColumnaMotivo.Width = 256;
            // 
            // ColumnaPlan
            // 
            this.ColumnaPlan.HeaderText = "Plan";
            this.ColumnaPlan.Name = "ColumnaPlan";
            this.ColumnaPlan.ReadOnly = true;
            // 
            // Pantalla_Historial_Cambio_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Pantalla_Historial_Cambio_Plan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla historial cambio de plan";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaPlan;
    }
}