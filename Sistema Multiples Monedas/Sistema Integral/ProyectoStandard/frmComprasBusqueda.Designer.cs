namespace ProyectoStandard
{
    partial class frmComprasBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComprasBusqueda));
            this.gridBuscarCliente = new System.Windows.Forms.DataGridView();
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.cboNumeroCaja = new System.Windows.Forms.ComboBox();
            this.lblMedioDePago = new System.Windows.Forms.Label();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dtpFechadeCompraHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaCompraDesde = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCodigoCompra = new System.Windows.Forms.ComboBox();
            this.txtCodigoCompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarCliente)).BeginInit();
            this.grBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBuscarCliente
            // 
            this.gridBuscarCliente.AllowUserToAddRows = false;
            this.gridBuscarCliente.AllowUserToDeleteRows = false;
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
            this.gridBuscarCliente.Location = new System.Drawing.Point(53, 183);
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
            this.gridBuscarCliente.Size = new System.Drawing.Size(868, 300);
            this.gridBuscarCliente.TabIndex = 15;
            this.gridBuscarCliente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBuscarClientes_CellDoubleClick);
            // 
            // grBusqueda
            // 
            this.grBusqueda.Controls.Add(this.cboNumeroCaja);
            this.grBusqueda.Controls.Add(this.lblMedioDePago);
            this.grBusqueda.Controls.Add(this.btnReporte);
            this.grBusqueda.Controls.Add(this.dtpFechadeCompraHasta);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.dtpFechaCompraDesde);
            this.grBusqueda.Controls.Add(this.label13);
            this.grBusqueda.Controls.Add(this.cboProveedor);
            this.grBusqueda.Controls.Add(this.label2);
            this.grBusqueda.Controls.Add(this.btnLimpiar);
            this.grBusqueda.Controls.Add(this.btnBuscar);
            this.grBusqueda.Controls.Add(this.cboCodigoCompra);
            this.grBusqueda.Controls.Add(this.txtCodigoCompra);
            this.grBusqueda.Controls.Add(this.label3);
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(53, 12);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(868, 156);
            this.grBusqueda.TabIndex = 14;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // cboNumeroCaja
            // 
            this.cboNumeroCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNumeroCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNumeroCaja.FormattingEnabled = true;
            this.cboNumeroCaja.Location = new System.Drawing.Point(150, 105);
            this.cboNumeroCaja.Name = "cboNumeroCaja";
            this.cboNumeroCaja.Size = new System.Drawing.Size(61, 24);
            this.cboNumeroCaja.TabIndex = 5;
            this.cboNumeroCaja.Visible = false;
            // 
            // lblMedioDePago
            // 
            this.lblMedioDePago.AutoSize = true;
            this.lblMedioDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMedioDePago.Location = new System.Drawing.Point(6, 109);
            this.lblMedioDePago.Name = "lblMedioDePago";
            this.lblMedioDePago.Size = new System.Drawing.Size(98, 16);
            this.lblMedioDePago.TabIndex = 142;
            this.lblMedioDePago.Text = "Número Caja";
            this.lblMedioDePago.Visible = false;
            // 
            // btnReporte
            // 
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.Location = new System.Drawing.Point(373, 104);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(41, 25);
            this.btnReporte.TabIndex = 8;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // dtpFechadeCompraHasta
            // 
            this.dtpFechadeCompraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeCompraHasta.Location = new System.Drawing.Point(305, 77);
            this.dtpFechadeCompraHasta.Name = "dtpFechadeCompraHasta";
            this.dtpFechadeCompraHasta.Size = new System.Drawing.Size(110, 22);
            this.dtpFechadeCompraHasta.TabIndex = 4;
            this.dtpFechadeCompraHasta.Value = new System.DateTime(2012, 8, 3, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 114;
            this.label4.Text = "Hasta";
            // 
            // dtpFechaCompraDesde
            // 
            this.dtpFechaCompraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCompraDesde.Location = new System.Drawing.Point(150, 77);
            this.dtpFechaCompraDesde.Name = "dtpFechaCompraDesde";
            this.dtpFechaCompraDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaCompraDesde.TabIndex = 3;
            this.dtpFechaCompraDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 16);
            this.label13.TabIndex = 113;
            this.label13.Text = "Fecha de Compra";
            // 
            // cboProveedor
            // 
            this.cboProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(150, 47);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(265, 24);
            this.cboProveedor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Proveedor";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(320, 104);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(45, 25);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(271, 104);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 25);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboCodigoCompra
            // 
            this.cboCodigoCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodigoCompra.FormattingEnabled = true;
            this.cboCodigoCompra.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboCodigoCompra.Location = new System.Drawing.Point(150, 17);
            this.cboCodigoCompra.Name = "cboCodigoCompra";
            this.cboCodigoCompra.Size = new System.Drawing.Size(61, 24);
            this.cboCodigoCompra.TabIndex = 0;
            // 
            // txtCodigoCompra
            // 
            this.txtCodigoCompra.Location = new System.Drawing.Point(217, 18);
            this.txtCodigoCompra.Name = "txtCodigoCompra";
            this.txtCodigoCompra.Size = new System.Drawing.Size(112, 22);
            this.txtCodigoCompra.TabIndex = 1;
            this.txtCodigoCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVenta_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Número Factura";
            // 
            // frmComprasBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 501);
            this.Controls.Add(this.gridBuscarCliente);
            this.Controls.Add(this.grBusqueda);
            this.Name = "frmComprasBusqueda";
            this.Text = "Busqueda de Compras";
            this.Load += new System.EventHandler(this.frmComprasBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarCliente)).EndInit();
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBuscarCliente;
        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.DateTimePicker dtpFechadeCompraHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaCompraDesde;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCodigoCompra;
        private System.Windows.Forms.TextBox txtCodigoCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNumeroCaja;
        private System.Windows.Forms.Label lblMedioDePago;
        private System.Windows.Forms.Button btnReporte;
    }
}