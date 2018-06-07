namespace ProyectoStandard
{
    partial class frmDevolucionesBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevolucionesBusqueda));
            this.gridBuscarClientes = new System.Windows.Forms.DataGridView();
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.cboNumeroCaja = new System.Windows.Forms.ComboBox();
            this.lblMedioDePago = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDescripcionArticulo = new System.Windows.Forms.ComboBox();
            this.txtDescripcionArticulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCodigoArticulo = new System.Windows.Forms.ComboBox();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechadeVentaHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaVentaDesde = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCodigoVenta = new System.Windows.Forms.ComboBox();
            this.txtCodigoVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarClientes)).BeginInit();
            this.grBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBuscarClientes
            // 
            this.gridBuscarClientes.AllowUserToAddRows = false;
            this.gridBuscarClientes.AllowUserToDeleteRows = false;
            this.gridBuscarClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBuscarClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridBuscarClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridBuscarClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridBuscarClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBuscarClientes.Location = new System.Drawing.Point(0, 224);
            this.gridBuscarClientes.Name = "gridBuscarClientes";
            this.gridBuscarClientes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBuscarClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridBuscarClientes.Size = new System.Drawing.Size(899, 429);
            this.gridBuscarClientes.TabIndex = 15;
            this.gridBuscarClientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBuscarClientes_CellDoubleClick);
            // 
            // grBusqueda
            // 
            this.grBusqueda.AutoSize = true;
            this.grBusqueda.Controls.Add(this.cboNumeroCaja);
            this.grBusqueda.Controls.Add(this.lblMedioDePago);
            this.grBusqueda.Controls.Add(this.cboEstado);
            this.grBusqueda.Controls.Add(this.label8);
            this.grBusqueda.Controls.Add(this.cboDescripcionArticulo);
            this.grBusqueda.Controls.Add(this.txtDescripcionArticulo);
            this.grBusqueda.Controls.Add(this.label5);
            this.grBusqueda.Controls.Add(this.cboCodigoArticulo);
            this.grBusqueda.Controls.Add(this.txtCodigoArticulo);
            this.grBusqueda.Controls.Add(this.label6);
            this.grBusqueda.Controls.Add(this.dtpFechadeVentaHasta);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.dtpFechaVentaDesde);
            this.grBusqueda.Controls.Add(this.label13);
            this.grBusqueda.Controls.Add(this.cboCliente);
            this.grBusqueda.Controls.Add(this.label1);
            this.grBusqueda.Controls.Add(this.cboVendedor);
            this.grBusqueda.Controls.Add(this.label2);
            this.grBusqueda.Controls.Add(this.btnLimpiar);
            this.grBusqueda.Controls.Add(this.btnBuscar);
            this.grBusqueda.Controls.Add(this.cboCodigoVenta);
            this.grBusqueda.Controls.Add(this.txtCodigoVenta);
            this.grBusqueda.Controls.Add(this.label3);
            this.grBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(0, 0);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(899, 224);
            this.grBusqueda.TabIndex = 14;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // cboNumeroCaja
            // 
            this.cboNumeroCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNumeroCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNumeroCaja.FormattingEnabled = true;
            this.cboNumeroCaja.Location = new System.Drawing.Point(119, 179);
            this.cboNumeroCaja.Name = "cboNumeroCaja";
            this.cboNumeroCaja.Size = new System.Drawing.Size(61, 24);
            this.cboNumeroCaja.TabIndex = 12;
            // 
            // lblMedioDePago
            // 
            this.lblMedioDePago.AutoSize = true;
            this.lblMedioDePago.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedioDePago.Location = new System.Drawing.Point(3, 183);
            this.lblMedioDePago.Name = "lblMedioDePago";
            this.lblMedioDePago.Size = new System.Drawing.Size(84, 14);
            this.lblMedioDePago.TabIndex = 140;
            this.lblMedioDePago.Text = "Número Caja";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "",
            "CUMPLIDA",
            "CANCELADA"});
            this.cboEstado.Location = new System.Drawing.Point(502, 117);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(157, 24);
            this.cboEstado.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(437, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 127;
            this.label8.Text = "Estado";
            // 
            // cboDescripcionArticulo
            // 
            this.cboDescripcionArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescripcionArticulo.FormattingEnabled = true;
            this.cboDescripcionArticulo.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboDescripcionArticulo.Location = new System.Drawing.Point(502, 150);
            this.cboDescripcionArticulo.Name = "cboDescripcionArticulo";
            this.cboDescripcionArticulo.Size = new System.Drawing.Size(61, 24);
            this.cboDescripcionArticulo.TabIndex = 10;
            // 
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(569, 151);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(235, 22);
            this.txtDescripcionArticulo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(390, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Descripcion Art.";
            // 
            // cboCodigoArticulo
            // 
            this.cboCodigoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodigoArticulo.FormattingEnabled = true;
            this.cboCodigoArticulo.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboCodigoArticulo.Location = new System.Drawing.Point(119, 149);
            this.cboCodigoArticulo.Name = "cboCodigoArticulo";
            this.cboCodigoArticulo.Size = new System.Drawing.Size(61, 24);
            this.cboCodigoArticulo.TabIndex = 7;
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(186, 150);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(198, 22);
            this.txtCodigoArticulo.TabIndex = 8;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 14);
            this.label6.TabIndex = 121;
            this.label6.Text = "Codigo Articulo";
            // 
            // dtpFechadeVentaHasta
            // 
            this.dtpFechadeVentaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeVentaHasta.Location = new System.Drawing.Point(283, 115);
            this.dtpFechadeVentaHasta.Name = "dtpFechadeVentaHasta";
            this.dtpFechadeVentaHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechadeVentaHasta.TabIndex = 5;
            this.dtpFechadeVentaHasta.Value = new System.DateTime(2012, 8, 3, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 114;
            this.label4.Text = "Hasta";
            // 
            // dtpFechaVentaDesde
            // 
            this.dtpFechaVentaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVentaDesde.Location = new System.Drawing.Point(119, 115);
            this.dtpFechaVentaDesde.Name = "dtpFechaVentaDesde";
            this.dtpFechaVentaDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaVentaDesde.TabIndex = 4;
            this.dtpFechaVentaDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(3, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 14);
            this.label13.TabIndex = 113;
            this.label13.Text = "Fecha Devolución";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(119, 79);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(265, 24);
            this.cboCliente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 61;
            this.label1.Text = "Cliente";
            // 
            // cboVendedor
            // 
            this.cboVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(120, 46);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(265, 24);
            this.cboVendedor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "Vendendor";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(341, 179);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(45, 25);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(283, 179);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 25);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboCodigoVenta
            // 
            this.cboCodigoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodigoVenta.FormattingEnabled = true;
            this.cboCodigoVenta.Items.AddRange(new object[] {
            "=",
            "<",
            ">"});
            this.cboCodigoVenta.Location = new System.Drawing.Point(120, 16);
            this.cboCodigoVenta.Name = "cboCodigoVenta";
            this.cboCodigoVenta.Size = new System.Drawing.Size(61, 24);
            this.cboCodigoVenta.TabIndex = 0;
            // 
            // txtCodigoVenta
            // 
            this.txtCodigoVenta.Location = new System.Drawing.Point(187, 17);
            this.txtCodigoVenta.Name = "txtCodigoVenta";
            this.txtCodigoVenta.Size = new System.Drawing.Size(112, 22);
            this.txtCodigoVenta.TabIndex = 1;
            this.txtCodigoVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoVenta_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 55;
            this.label3.Text = "Nro Devolución";
            // 
            // frmDevolucionesBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 653);
            this.Controls.Add(this.gridBuscarClientes);
            this.Controls.Add(this.grBusqueda);
            this.Name = "frmDevolucionesBusqueda";
            this.Text = "Busqueda de Devoluciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDevolucionesBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarClientes)).EndInit();
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBuscarClientes;
        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.ComboBox cboDescripcionArticulo;
        private System.Windows.Forms.TextBox txtDescripcionArticulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCodigoArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechadeVentaHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaVentaDesde;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCodigoVenta;
        private System.Windows.Forms.TextBox txtCodigoVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboNumeroCaja;
        private System.Windows.Forms.Label lblMedioDePago;
    }
}