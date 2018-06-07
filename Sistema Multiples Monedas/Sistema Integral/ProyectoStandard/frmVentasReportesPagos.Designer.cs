namespace ProyectoStandard
{
    partial class frmVentasReportesPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasReportesPagos));
            this.grBusqueda = new System.Windows.Forms.GroupBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckDevoluciones = new System.Windows.Forms.CheckBox();
            this.ckPagos = new System.Windows.Forms.CheckBox();
            this.grBusqueda.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBusqueda
            // 
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
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(12, 88);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(759, 217);
            this.grBusqueda.TabIndex = 20;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "",
            "CUMPLIDA",
            "PENDIENTE",
            "CANCELADA"});
            this.cboEstado.Location = new System.Drawing.Point(503, 79);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(181, 24);
            this.cboEstado.TabIndex = 126;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(382, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 14);
            this.label8.TabIndex = 125;
            this.label8.Text = "Estado Venta";
            // 
            // cboDescripcionArticulo
            // 
            this.cboDescripcionArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescripcionArticulo.FormattingEnabled = true;
            this.cboDescripcionArticulo.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboDescripcionArticulo.Location = new System.Drawing.Point(503, 119);
            this.cboDescripcionArticulo.Name = "cboDescripcionArticulo";
            this.cboDescripcionArticulo.Size = new System.Drawing.Size(61, 24);
            this.cboDescripcionArticulo.TabIndex = 117;
            // 
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(570, 120);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(186, 22);
            this.txtDescripcionArticulo.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(382, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 14);
            this.label5.TabIndex = 122;
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
            this.cboCodigoArticulo.Location = new System.Drawing.Point(120, 118);
            this.cboCodigoArticulo.Name = "cboCodigoArticulo";
            this.cboCodigoArticulo.Size = new System.Drawing.Size(61, 24);
            this.cboCodigoArticulo.TabIndex = 115;
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(187, 119);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(189, 22);
            this.txtCodigoArticulo.TabIndex = 116;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 14);
            this.label6.TabIndex = 121;
            this.label6.Text = "Codigo Articulo";
            // 
            // dtpFechadeVentaHasta
            // 
            this.dtpFechadeVentaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeVentaHasta.Location = new System.Drawing.Point(275, 84);
            this.dtpFechadeVentaHasta.Name = "dtpFechadeVentaHasta";
            this.dtpFechadeVentaHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechadeVentaHasta.TabIndex = 112;
            this.dtpFechadeVentaHasta.Value = new System.DateTime(2012, 8, 3, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 114;
            this.label4.Text = "Hasta";
            // 
            // dtpFechaVentaDesde
            // 
            this.dtpFechaVentaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVentaDesde.Location = new System.Drawing.Point(120, 84);
            this.dtpFechaVentaDesde.Name = "dtpFechaVentaDesde";
            this.dtpFechaVentaDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaVentaDesde.TabIndex = 111;
            this.dtpFechaVentaDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(4, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 14);
            this.label13.TabIndex = 113;
            this.label13.Text = "Fecha de Pago";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(503, 46);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(256, 24);
            this.cboCliente.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(437, 50);
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
            this.cboVendedor.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "Vendedor";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(324, 162);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(45, 25);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(275, 162);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 25);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckDevoluciones);
            this.groupBox1.Controls.Add(this.ckPagos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 70);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // ckDevoluciones
            // 
            this.ckDevoluciones.AutoSize = true;
            this.ckDevoluciones.Location = new System.Drawing.Point(143, 36);
            this.ckDevoluciones.Name = "ckDevoluciones";
            this.ckDevoluciones.Size = new System.Drawing.Size(122, 20);
            this.ckDevoluciones.TabIndex = 1;
            this.ckDevoluciones.Text = "Devoluciones";
            this.ckDevoluciones.UseVisualStyleBackColor = true;
            // 
            // ckPagos
            // 
            this.ckPagos.AutoSize = true;
            this.ckPagos.Location = new System.Drawing.Point(15, 36);
            this.ckPagos.Name = "ckPagos";
            this.ckPagos.Size = new System.Drawing.Size(72, 20);
            this.ckPagos.TabIndex = 0;
            this.ckPagos.Text = "Pagos";
            this.ckPagos.UseVisualStyleBackColor = true;
            // 
            // frmVentasReportesPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grBusqueda);
            this.MinimizeBox = false;
            this.Name = "frmVentasReportesPagos";
            this.Text = "Reporte de Devoluciones";
            this.Load += new System.EventHandler(this.frmVentasReportesPagos_Load);
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckDevoluciones;
        private System.Windows.Forms.CheckBox ckPagos;
    }
}