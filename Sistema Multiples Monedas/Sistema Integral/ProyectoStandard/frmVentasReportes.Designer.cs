namespace ProyectoStandard
{
    partial class frmVentasReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasReportes));
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.dtpFechaPagoHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechadePagoHasta = new System.Windows.Forms.Label();
            this.dtpFechaPagoDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDePago = new System.Windows.Forms.Label();
            this.cboFaltaDePago = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            this.lblMedioDePago = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbInformeTotales = new System.Windows.Forms.RadioButton();
            this.rbInformeDetallado = new System.Windows.Forms.RadioButton();
            this.rbArticulos = new System.Windows.Forms.GroupBox();
            this.rbDetalladoMedioDePago = new System.Windows.Forms.RadioButton();
            this.rbArticulosCantidadTotal = new System.Windows.Forms.RadioButton();
            this.rbArticulosDetallado = new System.Windows.Forms.RadioButton();
            this.gbOrdenTotales = new System.Windows.Forms.GroupBox();
            this.rbOrden2NumeroFactura = new System.Windows.Forms.RadioButton();
            this.rbOrden2CantidadDeArticulos = new System.Windows.Forms.RadioButton();
            this.rbOrden2MenorGanancia = new System.Windows.Forms.RadioButton();
            this.rbOrden2MayorGanancia = new System.Windows.Forms.RadioButton();
            this.rbOrden2Fecha = new System.Windows.Forms.RadioButton();
            this.grBusqueda.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.rbArticulos.SuspendLayout();
            this.gbOrdenTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBusqueda
            // 
            this.grBusqueda.Controls.Add(this.dtpFechaPagoHasta);
            this.grBusqueda.Controls.Add(this.lblFechadePagoHasta);
            this.grBusqueda.Controls.Add(this.dtpFechaPagoDesde);
            this.grBusqueda.Controls.Add(this.lblFechaDePago);
            this.grBusqueda.Controls.Add(this.cboFaltaDePago);
            this.grBusqueda.Controls.Add(this.label12);
            this.grBusqueda.Controls.Add(this.cboEstado);
            this.grBusqueda.Controls.Add(this.label8);
            this.grBusqueda.Controls.Add(this.cboMedioPago);
            this.grBusqueda.Controls.Add(this.lblMedioDePago);
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
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(815, 230);
            this.grBusqueda.TabIndex = 13;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // dtpFechaPagoHasta
            // 
            this.dtpFechaPagoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPagoHasta.Location = new System.Drawing.Point(275, 115);
            this.dtpFechaPagoHasta.Name = "dtpFechaPagoHasta";
            this.dtpFechaPagoHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechaPagoHasta.TabIndex = 8;
            this.dtpFechaPagoHasta.Value = new System.DateTime(2012, 8, 3, 0, 0, 0, 0);
            // 
            // lblFechadePagoHasta
            // 
            this.lblFechadePagoHasta.AutoSize = true;
            this.lblFechadePagoHasta.Location = new System.Drawing.Point(222, 118);
            this.lblFechadePagoHasta.Name = "lblFechadePagoHasta";
            this.lblFechadePagoHasta.Size = new System.Drawing.Size(49, 16);
            this.lblFechadePagoHasta.TabIndex = 139;
            this.lblFechadePagoHasta.Text = "Hasta";
            // 
            // dtpFechaPagoDesde
            // 
            this.dtpFechaPagoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPagoDesde.Location = new System.Drawing.Point(120, 115);
            this.dtpFechaPagoDesde.Name = "dtpFechaPagoDesde";
            this.dtpFechaPagoDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaPagoDesde.TabIndex = 7;
            this.dtpFechaPagoDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // lblFechaDePago
            // 
            this.lblFechaDePago.AutoSize = true;
            this.lblFechaDePago.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaDePago.Location = new System.Drawing.Point(4, 119);
            this.lblFechaDePago.Name = "lblFechaDePago";
            this.lblFechaDePago.Size = new System.Drawing.Size(95, 14);
            this.lblFechaDePago.TabIndex = 138;
            this.lblFechaDePago.Text = "Fecha de Pago";
            // 
            // cboFaltaDePago
            // 
            this.cboFaltaDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFaltaDePago.FormattingEnabled = true;
            this.cboFaltaDePago.Items.AddRange(new object[] {
            "",
            "CON DEUDA",
            "SIN DEUDA"});
            this.cboFaltaDePago.Location = new System.Drawing.Point(120, 181);
            this.cboFaltaDePago.Name = "cboFaltaDePago";
            this.cboFaltaDePago.Size = new System.Drawing.Size(157, 24);
            this.cboFaltaDePago.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 14);
            this.label12.TabIndex = 135;
            this.label12.Text = "Falta de Pago";
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
            this.cboEstado.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(438, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 125;
            this.label8.Text = "Estado";
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMedioPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMedioPago.FormattingEnabled = true;
            this.cboMedioPago.Location = new System.Drawing.Point(503, 154);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(181, 24);
            this.cboMedioPago.TabIndex = 13;
            this.cboMedioPago.Visible = false;
            // 
            // lblMedioDePago
            // 
            this.lblMedioDePago.AutoSize = true;
            this.lblMedioDePago.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedioDePago.Location = new System.Drawing.Point(382, 158);
            this.lblMedioDePago.Name = "lblMedioDePago";
            this.lblMedioDePago.Size = new System.Drawing.Size(98, 14);
            this.lblMedioDePago.TabIndex = 123;
            this.lblMedioDePago.Text = "Medio de pago";
            this.lblMedioDePago.Visible = false;
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
            this.cboDescripcionArticulo.TabIndex = 9;
            // 
            // txtDescripcionArticulo
            // 
            this.txtDescripcionArticulo.Location = new System.Drawing.Point(570, 120);
            this.txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            this.txtDescripcionArticulo.Size = new System.Drawing.Size(224, 22);
            this.txtDescripcionArticulo.TabIndex = 10;
            this.txtDescripcionArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
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
            this.cboCodigoArticulo.Location = new System.Drawing.Point(120, 151);
            this.cboCodigoArticulo.Name = "cboCodigoArticulo";
            this.cboCodigoArticulo.Size = new System.Drawing.Size(61, 24);
            this.cboCodigoArticulo.TabIndex = 11;
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(187, 152);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(189, 22);
            this.txtCodigoArticulo.TabIndex = 12;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 154);
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
            this.dtpFechadeVentaHasta.TabIndex = 5;
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
            this.dtpFechaVentaDesde.TabIndex = 4;
            this.dtpFechaVentaDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(4, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 14);
            this.label13.TabIndex = 113;
            this.label13.Text = "Fecha de Venta";
            // 
            // cboCliente
            // 
            this.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(503, 46);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(291, 24);
            this.cboCliente.TabIndex = 3;
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
            this.cboVendedor.TabIndex = 2;
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
            this.btnLimpiar.Location = new System.Drawing.Point(331, 181);
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
            this.btnBuscar.Location = new System.Drawing.Point(284, 181);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 25);
            this.btnBuscar.TabIndex = 15;
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
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 55;
            this.label3.Text = "Numero de Vta.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbInformeTotales);
            this.groupBox2.Controls.Add(this.rbInformeDetallado);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 70);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Informe";
            // 
            // rbInformeTotales
            // 
            this.rbInformeTotales.AutoSize = true;
            this.rbInformeTotales.Location = new System.Drawing.Point(175, 36);
            this.rbInformeTotales.Name = "rbInformeTotales";
            this.rbInformeTotales.Size = new System.Drawing.Size(79, 20);
            this.rbInformeTotales.TabIndex = 127;
            this.rbInformeTotales.TabStop = true;
            this.rbInformeTotales.Text = "Totales";
            this.rbInformeTotales.UseVisualStyleBackColor = true;
            this.rbInformeTotales.CheckedChanged += new System.EventHandler(this.rbInformeTotales_CheckedChanged);
            // 
            // rbInformeDetallado
            // 
            this.rbInformeDetallado.AutoSize = true;
            this.rbInformeDetallado.Location = new System.Drawing.Point(19, 36);
            this.rbInformeDetallado.Name = "rbInformeDetallado";
            this.rbInformeDetallado.Size = new System.Drawing.Size(94, 20);
            this.rbInformeDetallado.TabIndex = 126;
            this.rbInformeDetallado.TabStop = true;
            this.rbInformeDetallado.Text = "Detallado";
            this.rbInformeDetallado.UseVisualStyleBackColor = true;
            this.rbInformeDetallado.CheckedChanged += new System.EventHandler(this.rbInformeDetallado_CheckedChanged);
            // 
            // rbArticulos
            // 
            this.rbArticulos.Controls.Add(this.rbDetalladoMedioDePago);
            this.rbArticulos.Controls.Add(this.rbArticulosCantidadTotal);
            this.rbArticulos.Controls.Add(this.rbArticulosDetallado);
            this.rbArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbArticulos.Location = new System.Drawing.Point(334, 261);
            this.rbArticulos.Name = "rbArticulos";
            this.rbArticulos.Size = new System.Drawing.Size(493, 70);
            this.rbArticulos.TabIndex = 16;
            this.rbArticulos.TabStop = false;
            this.rbArticulos.Text = "Articulos";
            // 
            // rbDetalladoMedioDePago
            // 
            this.rbDetalladoMedioDePago.AutoSize = true;
            this.rbDetalladoMedioDePago.Location = new System.Drawing.Point(340, 36);
            this.rbDetalladoMedioDePago.Name = "rbDetalladoMedioDePago";
            this.rbDetalladoMedioDePago.Size = new System.Drawing.Size(132, 20);
            this.rbDetalladoMedioDePago.TabIndex = 128;
            this.rbDetalladoMedioDePago.TabStop = true;
            this.rbDetalladoMedioDePago.Text = "Medio de Pago";
            this.rbDetalladoMedioDePago.UseVisualStyleBackColor = true;
            this.rbDetalladoMedioDePago.CheckedChanged += new System.EventHandler(this.rbDetalladoMedioDePago_CheckedChanged);
            // 
            // rbArticulosCantidadTotal
            // 
            this.rbArticulosCantidadTotal.AutoSize = true;
            this.rbArticulosCantidadTotal.Location = new System.Drawing.Point(175, 36);
            this.rbArticulosCantidadTotal.Name = "rbArticulosCantidadTotal";
            this.rbArticulosCantidadTotal.Size = new System.Drawing.Size(145, 20);
            this.rbArticulosCantidadTotal.TabIndex = 127;
            this.rbArticulosCantidadTotal.TabStop = true;
            this.rbArticulosCantidadTotal.Text = "Total por Factura";
            this.rbArticulosCantidadTotal.UseVisualStyleBackColor = true;
            this.rbArticulosCantidadTotal.CheckedChanged += new System.EventHandler(this.rbArticulosCantidadTotal_CheckedChanged);
            // 
            // rbArticulosDetallado
            // 
            this.rbArticulosDetallado.AutoSize = true;
            this.rbArticulosDetallado.Location = new System.Drawing.Point(19, 36);
            this.rbArticulosDetallado.Name = "rbArticulosDetallado";
            this.rbArticulosDetallado.Size = new System.Drawing.Size(105, 20);
            this.rbArticulosDetallado.TabIndex = 126;
            this.rbArticulosDetallado.TabStop = true;
            this.rbArticulosDetallado.Text = "Cantidades";
            this.rbArticulosDetallado.UseVisualStyleBackColor = true;
            this.rbArticulosDetallado.CheckedChanged += new System.EventHandler(this.rbArticulosDetallado_CheckedChanged);
            // 
            // gbOrdenTotales
            // 
            this.gbOrdenTotales.Controls.Add(this.rbOrden2NumeroFactura);
            this.gbOrdenTotales.Controls.Add(this.rbOrden2CantidadDeArticulos);
            this.gbOrdenTotales.Controls.Add(this.rbOrden2MenorGanancia);
            this.gbOrdenTotales.Controls.Add(this.rbOrden2MayorGanancia);
            this.gbOrdenTotales.Controls.Add(this.rbOrden2Fecha);
            this.gbOrdenTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbOrdenTotales.Location = new System.Drawing.Point(12, 344);
            this.gbOrdenTotales.Name = "gbOrdenTotales";
            this.gbOrdenTotales.Size = new System.Drawing.Size(815, 77);
            this.gbOrdenTotales.TabIndex = 19;
            this.gbOrdenTotales.TabStop = false;
            this.gbOrdenTotales.Text = "Orden";
            // 
            // rbOrden2NumeroFactura
            // 
            this.rbOrden2NumeroFactura.AutoSize = true;
            this.rbOrden2NumeroFactura.Location = new System.Drawing.Point(662, 36);
            this.rbOrden2NumeroFactura.Name = "rbOrden2NumeroFactura";
            this.rbOrden2NumeroFactura.Size = new System.Drawing.Size(136, 20);
            this.rbOrden2NumeroFactura.TabIndex = 133;
            this.rbOrden2NumeroFactura.TabStop = true;
            this.rbOrden2NumeroFactura.Text = "Número Factura";
            this.rbOrden2NumeroFactura.UseVisualStyleBackColor = true;
            // 
            // rbOrden2CantidadDeArticulos
            // 
            this.rbOrden2CantidadDeArticulos.AutoSize = true;
            this.rbOrden2CantidadDeArticulos.Location = new System.Drawing.Point(467, 36);
            this.rbOrden2CantidadDeArticulos.Name = "rbOrden2CantidadDeArticulos";
            this.rbOrden2CantidadDeArticulos.Size = new System.Drawing.Size(174, 20);
            this.rbOrden2CantidadDeArticulos.TabIndex = 132;
            this.rbOrden2CantidadDeArticulos.TabStop = true;
            this.rbOrden2CantidadDeArticulos.Text = "Cantidad de Articulos";
            this.rbOrden2CantidadDeArticulos.UseVisualStyleBackColor = true;
            // 
            // rbOrden2MenorGanancia
            // 
            this.rbOrden2MenorGanancia.AutoSize = true;
            this.rbOrden2MenorGanancia.Location = new System.Drawing.Point(294, 36);
            this.rbOrden2MenorGanancia.Name = "rbOrden2MenorGanancia";
            this.rbOrden2MenorGanancia.Size = new System.Drawing.Size(139, 20);
            this.rbOrden2MenorGanancia.TabIndex = 129;
            this.rbOrden2MenorGanancia.TabStop = true;
            this.rbOrden2MenorGanancia.Text = "Menor Ganancia";
            this.rbOrden2MenorGanancia.UseVisualStyleBackColor = true;
            // 
            // rbOrden2MayorGanancia
            // 
            this.rbOrden2MayorGanancia.AutoSize = true;
            this.rbOrden2MayorGanancia.Location = new System.Drawing.Point(115, 36);
            this.rbOrden2MayorGanancia.Name = "rbOrden2MayorGanancia";
            this.rbOrden2MayorGanancia.Size = new System.Drawing.Size(139, 20);
            this.rbOrden2MayorGanancia.TabIndex = 127;
            this.rbOrden2MayorGanancia.TabStop = true;
            this.rbOrden2MayorGanancia.Text = "Mayor Ganancia";
            this.rbOrden2MayorGanancia.UseVisualStyleBackColor = true;
            // 
            // rbOrden2Fecha
            // 
            this.rbOrden2Fecha.AutoSize = true;
            this.rbOrden2Fecha.Location = new System.Drawing.Point(15, 36);
            this.rbOrden2Fecha.Name = "rbOrden2Fecha";
            this.rbOrden2Fecha.Size = new System.Drawing.Size(69, 20);
            this.rbOrden2Fecha.TabIndex = 126;
            this.rbOrden2Fecha.TabStop = true;
            this.rbOrden2Fecha.Text = "Fecha";
            this.rbOrden2Fecha.UseVisualStyleBackColor = true;
            // 
            // frmVentasReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 442);
            this.Controls.Add(this.gbOrdenTotales);
            this.Controls.Add(this.rbArticulos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grBusqueda);
            this.MaximizeBox = false;
            this.Name = "frmVentasReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de Ventas";
            this.Load += new System.EventHandler(this.frmVentasReportes_Load);
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.rbArticulos.ResumeLayout(false);
            this.rbArticulos.PerformLayout();
            this.gbOrdenTotales.ResumeLayout(false);
            this.gbOrdenTotales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMedioPago;
        private System.Windows.Forms.Label lblMedioDePago;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbInformeTotales;
        private System.Windows.Forms.RadioButton rbInformeDetallado;
        private System.Windows.Forms.GroupBox rbArticulos;
        private System.Windows.Forms.RadioButton rbArticulosCantidadTotal;
        private System.Windows.Forms.RadioButton rbArticulosDetallado;
        private System.Windows.Forms.GroupBox gbOrdenTotales;
        private System.Windows.Forms.RadioButton rbOrden2CantidadDeArticulos;
        private System.Windows.Forms.RadioButton rbOrden2MenorGanancia;
        private System.Windows.Forms.RadioButton rbOrden2MayorGanancia;
        private System.Windows.Forms.RadioButton rbOrden2Fecha;
        private System.Windows.Forms.ComboBox cboFaltaDePago;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbDetalladoMedioDePago;
        private System.Windows.Forms.DateTimePicker dtpFechaPagoHasta;
        private System.Windows.Forms.Label lblFechadePagoHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaPagoDesde;
        private System.Windows.Forms.Label lblFechaDePago;
        private System.Windows.Forms.RadioButton rbOrden2NumeroFactura;
    }
}