namespace ProyectoStandard
{
    partial class frmVentasCuentaCorriente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasCuentaCorriente));
            this.grPagos = new System.Windows.Forms.GroupBox();
            this.cboMedioDePago = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.grid_Pagos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDebe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Pagos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grPagos
            // 
            this.grPagos.Controls.Add(this.cboMedioDePago);
            this.grPagos.Controls.Add(this.label11);
            this.grPagos.Controls.Add(this.btnEliminar);
            this.grPagos.Controls.Add(this.btnLimpiar);
            this.grPagos.Controls.Add(this.btnAceptar);
            this.grPagos.Controls.Add(this.txtImporte);
            this.grPagos.Controls.Add(this.label1);
            this.grPagos.Controls.Add(this.dtpFecha);
            this.grPagos.Controls.Add(this.label13);
            this.grPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grPagos.Location = new System.Drawing.Point(12, 12);
            this.grPagos.Name = "grPagos";
            this.grPagos.Size = new System.Drawing.Size(513, 115);
            this.grPagos.TabIndex = 17;
            this.grPagos.TabStop = false;
            // 
            // cboMedioDePago
            // 
            this.cboMedioDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedioDePago.FormattingEnabled = true;
            this.cboMedioDePago.Location = new System.Drawing.Point(133, 49);
            this.cboMedioDePago.Name = "cboMedioDePago";
            this.cboMedioDePago.Size = new System.Drawing.Size(231, 24);
            this.cboMedioDePago.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(16, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 16);
            this.label11.TabIndex = 115;
            this.label11.Text = "Medio de Pago";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(330, 78);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 23);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(252, 78);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(32, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(290, 78);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(34, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(133, 79);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(112, 22);
            this.txtImporte.TabIndex = 2;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 110;
            this.label1.Text = "Importe";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(133, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(112, 22);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.Value = new System.DateTime(2012, 6, 18, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 16);
            this.label13.TabIndex = 108;
            this.label13.Text = "Fecha";
            // 
            // grid_Pagos
            // 
            this.grid_Pagos.AllowUserToAddRows = false;
            this.grid_Pagos.AllowUserToDeleteRows = false;
            this.grid_Pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Pagos.Location = new System.Drawing.Point(12, 133);
            this.grid_Pagos.Name = "grid_Pagos";
            this.grid_Pagos.ReadOnly = true;
            this.grid_Pagos.Size = new System.Drawing.Size(513, 252);
            this.grid_Pagos.TabIndex = 16;
            this.grid_Pagos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_Pagos_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDebe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 59);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtDebe
            // 
            this.txtDebe.Enabled = false;
            this.txtDebe.Location = new System.Drawing.Point(395, 21);
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.Size = new System.Drawing.Size(112, 22);
            this.txtDebe.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 117;
            this.label3.Text = "Debe";
            // 
            // frmVentasCuentaCorriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grPagos);
            this.Controls.Add(this.grid_Pagos);
            this.Name = "frmVentasCuentaCorriente";
            this.Text = "Cuenta Corriente";
            this.Load += new System.EventHandler(this.frmVentasCuentaCorriente_Load);
            this.grPagos.ResumeLayout(false);
            this.grPagos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Pagos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grPagos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView grid_Pagos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDebe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMedioDePago;
        private System.Windows.Forms.Label label11;
    }
}