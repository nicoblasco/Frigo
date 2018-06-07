namespace ProyectoStandard
{
    partial class frmCierreCajaReporte
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreCajaReporte));
            this.gridBuscarCliente = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpFechaAperturaDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechadeAperturaHasta = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblMedioDePago = new System.Windows.Forms.Label();
            this.cboNumeroCaja = new System.Windows.Forms.ComboBox();
            this.lblFechaDeCierreDesde = new System.Windows.Forms.Label();
            this.dtpFechadeCierreDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDeCierreHasta = new System.Windows.Forms.Label();
            this.dtpFechadeCierreHasta = new System.Windows.Forms.DateTimePicker();
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarCliente)).BeginInit();
            this.grBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBuscarCliente
            // 
            this.gridBuscarCliente.AllowUserToAddRows = false;
            this.gridBuscarCliente.AllowUserToDeleteRows = false;
            this.gridBuscarCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBuscarCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridBuscarCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridBuscarCliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridBuscarCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBuscarCliente.Location = new System.Drawing.Point(0, 150);
            this.gridBuscarCliente.Name = "gridBuscarCliente";
            this.gridBuscarCliente.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBuscarCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridBuscarCliente.Size = new System.Drawing.Size(948, 431);
            this.gridBuscarCliente.TabIndex = 15;
            this.gridBuscarCliente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBuscarClientes_CellDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(237, 105);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 25);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(286, 105);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(45, 25);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(4, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 14);
            this.label13.TabIndex = 113;
            this.label13.Text = "Fecha de Apertura";
            // 
            // dtpFechaAperturaDesde
            // 
            this.dtpFechaAperturaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAperturaDesde.Location = new System.Drawing.Point(120, 21);
            this.dtpFechaAperturaDesde.Name = "dtpFechaAperturaDesde";
            this.dtpFechaAperturaDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaAperturaDesde.TabIndex = 0;
            this.dtpFechaAperturaDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 114;
            this.label4.Text = "Hasta";
            // 
            // dtpFechadeAperturaHasta
            // 
            this.dtpFechadeAperturaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeAperturaHasta.Location = new System.Drawing.Point(275, 21);
            this.dtpFechadeAperturaHasta.Name = "dtpFechadeAperturaHasta";
            this.dtpFechadeAperturaHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechadeAperturaHasta.TabIndex = 1;
            this.dtpFechadeAperturaHasta.Value = new System.DateTime(2012, 8, 3, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(4, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 125;
            this.label8.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "",
            "ABIERTA",
            "CERRADA"});
            this.cboEstado.Location = new System.Drawing.Point(119, 49);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(157, 24);
            this.cboEstado.TabIndex = 2;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblMedioDePago
            // 
            this.lblMedioDePago.AutoSize = true;
            this.lblMedioDePago.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedioDePago.Location = new System.Drawing.Point(2, 110);
            this.lblMedioDePago.Name = "lblMedioDePago";
            this.lblMedioDePago.Size = new System.Drawing.Size(84, 14);
            this.lblMedioDePago.TabIndex = 134;
            this.lblMedioDePago.Text = "Número Caja";
            // 
            // cboNumeroCaja
            // 
            this.cboNumeroCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNumeroCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNumeroCaja.FormattingEnabled = true;
            this.cboNumeroCaja.Location = new System.Drawing.Point(119, 105);
            this.cboNumeroCaja.Name = "cboNumeroCaja";
            this.cboNumeroCaja.Size = new System.Drawing.Size(61, 24);
            this.cboNumeroCaja.TabIndex = 5;
            // 
            // lblFechaDeCierreDesde
            // 
            this.lblFechaDeCierreDesde.AutoSize = true;
            this.lblFechaDeCierreDesde.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaDeCierreDesde.Location = new System.Drawing.Point(3, 81);
            this.lblFechaDeCierreDesde.Name = "lblFechaDeCierreDesde";
            this.lblFechaDeCierreDesde.Size = new System.Drawing.Size(99, 14);
            this.lblFechaDeCierreDesde.TabIndex = 139;
            this.lblFechaDeCierreDesde.Text = "Fecha de Cierre";
            this.lblFechaDeCierreDesde.Visible = false;
            // 
            // dtpFechadeCierreDesde
            // 
            this.dtpFechadeCierreDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeCierreDesde.Location = new System.Drawing.Point(119, 77);
            this.dtpFechadeCierreDesde.Name = "dtpFechadeCierreDesde";
            this.dtpFechadeCierreDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechadeCierreDesde.TabIndex = 3;
            this.dtpFechadeCierreDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtpFechadeCierreDesde.Visible = false;
            // 
            // lblFechaDeCierreHasta
            // 
            this.lblFechaDeCierreHasta.AutoSize = true;
            this.lblFechaDeCierreHasta.Location = new System.Drawing.Point(221, 80);
            this.lblFechaDeCierreHasta.Name = "lblFechaDeCierreHasta";
            this.lblFechaDeCierreHasta.Size = new System.Drawing.Size(49, 16);
            this.lblFechaDeCierreHasta.TabIndex = 140;
            this.lblFechaDeCierreHasta.Text = "Hasta";
            this.lblFechaDeCierreHasta.Visible = false;
            // 
            // dtpFechadeCierreHasta
            // 
            this.dtpFechadeCierreHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeCierreHasta.Location = new System.Drawing.Point(274, 77);
            this.dtpFechadeCierreHasta.Name = "dtpFechadeCierreHasta";
            this.dtpFechadeCierreHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechadeCierreHasta.TabIndex = 4;
            this.dtpFechadeCierreHasta.Value = new System.DateTime(2012, 8, 3, 0, 0, 0, 0);
            this.dtpFechadeCierreHasta.Visible = false;
            // 
            // grBusqueda
            // 
            this.grBusqueda.AutoSize = true;
            this.grBusqueda.Controls.Add(this.dtpFechadeCierreHasta);
            this.grBusqueda.Controls.Add(this.lblFechaDeCierreHasta);
            this.grBusqueda.Controls.Add(this.dtpFechadeCierreDesde);
            this.grBusqueda.Controls.Add(this.lblFechaDeCierreDesde);
            this.grBusqueda.Controls.Add(this.cboNumeroCaja);
            this.grBusqueda.Controls.Add(this.lblMedioDePago);
            this.grBusqueda.Controls.Add(this.cboEstado);
            this.grBusqueda.Controls.Add(this.label8);
            this.grBusqueda.Controls.Add(this.dtpFechadeAperturaHasta);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.dtpFechaAperturaDesde);
            this.grBusqueda.Controls.Add(this.label13);
            this.grBusqueda.Controls.Add(this.btnLimpiar);
            this.grBusqueda.Controls.Add(this.btnBuscar);
            this.grBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(0, 0);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(948, 150);
            this.grBusqueda.TabIndex = 14;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // frmCierreCajaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 581);
            this.Controls.Add(this.gridBuscarCliente);
            this.Controls.Add(this.grBusqueda);
            this.Name = "frmCierreCajaReporte";
            this.Text = "Buscar Cierre de Caja";
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarCliente)).EndInit();
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBuscarCliente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpFechaAperturaDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechadeAperturaHasta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblMedioDePago;
        private System.Windows.Forms.ComboBox cboNumeroCaja;
        private System.Windows.Forms.Label lblFechaDeCierreDesde;
        private System.Windows.Forms.DateTimePicker dtpFechadeCierreDesde;
        private System.Windows.Forms.Label lblFechaDeCierreHasta;
        private System.Windows.Forms.DateTimePicker dtpFechadeCierreHasta;
        private System.Windows.Forms.GroupBox grBusqueda;
    }
}