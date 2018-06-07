namespace ProyectoStandard
{
    partial class frmArticulosBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulosBusqueda));
            this.gridBuscarArticulos = new System.Windows.Forms.DataGridView();
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.ckSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dtpFechadeIngresoHasta = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaIngresoDesde = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.CkStockMinimo = new System.Windows.Forms.CheckBox();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCodigo = new System.Windows.Forms.ComboBox();
            this.cboDescripcion = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImagenMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarArticulos)).BeginInit();
            this.grBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBuscarArticulos
            // 
            this.gridBuscarArticulos.AllowUserToAddRows = false;
            this.gridBuscarArticulos.AllowUserToDeleteRows = false;
            this.gridBuscarArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBuscarArticulos.Location = new System.Drawing.Point(26, 264);
            this.gridBuscarArticulos.Name = "gridBuscarArticulos";
            this.gridBuscarArticulos.Size = new System.Drawing.Size(1143, 410);
            this.gridBuscarArticulos.TabIndex = 11;
            this.gridBuscarArticulos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBuscarArticulos_CellDoubleClick);
            // 
            // grBusqueda
            // 
            this.grBusqueda.Controls.Add(this.ckSeleccionarTodos);
            this.grBusqueda.Controls.Add(this.btnBorrar);
            this.grBusqueda.Controls.Add(this.btnReporte);
            this.grBusqueda.Controls.Add(this.dtpFechadeIngresoHasta);
            this.grBusqueda.Controls.Add(this.label7);
            this.grBusqueda.Controls.Add(this.dtpFechaIngresoDesde);
            this.grBusqueda.Controls.Add(this.label13);
            this.grBusqueda.Controls.Add(this.CkStockMinimo);
            this.grBusqueda.Controls.Add(this.cboStock);
            this.grBusqueda.Controls.Add(this.txtStock);
            this.grBusqueda.Controls.Add(this.label6);
            this.grBusqueda.Controls.Add(this.cboUbicacion);
            this.grBusqueda.Controls.Add(this.txtUbicacion);
            this.grBusqueda.Controls.Add(this.label2);
            this.grBusqueda.Controls.Add(this.cboRubro);
            this.grBusqueda.Controls.Add(this.label5);
            this.grBusqueda.Controls.Add(this.cboMarca);
            this.grBusqueda.Controls.Add(this.cboProveedor);
            this.grBusqueda.Controls.Add(this.btnLimpiar);
            this.grBusqueda.Controls.Add(this.label16);
            this.grBusqueda.Controls.Add(this.label1);
            this.grBusqueda.Controls.Add(this.btnBuscar);
            this.grBusqueda.Controls.Add(this.cboCodigo);
            this.grBusqueda.Controls.Add(this.cboDescripcion);
            this.grBusqueda.Controls.Add(this.txtDescripcion);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.txtCodigo);
            this.grBusqueda.Controls.Add(this.label3);
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(26, 34);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(1143, 224);
            this.grBusqueda.TabIndex = 10;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // ckSeleccionarTodos
            // 
            this.ckSeleccionarTodos.AutoSize = true;
            this.ckSeleccionarTodos.Location = new System.Drawing.Point(6, 198);
            this.ckSeleccionarTodos.Name = "ckSeleccionarTodos";
            this.ckSeleccionarTodos.Size = new System.Drawing.Size(159, 20);
            this.ckSeleccionarTodos.TabIndex = 181;
            this.ckSeleccionarTodos.Text = "Seleccionar Todos";
            this.ckSeleccionarTodos.UseVisualStyleBackColor = true;
            this.ckSeleccionarTodos.CheckedChanged += new System.EventHandler(this.ckSeleccionarTodos_CheckedChanged);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(171, 195);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 180;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Visible = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.Location = new System.Drawing.Point(605, 194);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(41, 25);
            this.btnReporte.TabIndex = 126;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // dtpFechadeIngresoHasta
            // 
            this.dtpFechadeIngresoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeIngresoHasta.Location = new System.Drawing.Point(275, 143);
            this.dtpFechadeIngresoHasta.Name = "dtpFechadeIngresoHasta";
            this.dtpFechadeIngresoHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechadeIngresoHasta.TabIndex = 123;
            this.dtpFechadeIngresoHasta.Value = new System.DateTime(2016, 5, 6, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 125;
            this.label7.Text = "Hasta";
            // 
            // dtpFechaIngresoDesde
            // 
            this.dtpFechaIngresoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngresoDesde.Location = new System.Drawing.Point(120, 143);
            this.dtpFechaIngresoDesde.Name = "dtpFechaIngresoDesde";
            this.dtpFechaIngresoDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaIngresoDesde.TabIndex = 122;
            this.dtpFechaIngresoDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 16);
            this.label13.TabIndex = 124;
            this.label13.Text = "Fecha de Ing.";
            // 
            // CkStockMinimo
            // 
            this.CkStockMinimo.AutoSize = true;
            this.CkStockMinimo.Location = new System.Drawing.Point(121, 171);
            this.CkStockMinimo.Name = "CkStockMinimo";
            this.CkStockMinimo.Size = new System.Drawing.Size(150, 20);
            this.CkStockMinimo.TabIndex = 121;
            this.CkStockMinimo.Text = "Con Stock Minimo";
            this.CkStockMinimo.UseVisualStyleBackColor = true;
            // 
            // cboStock
            // 
            this.cboStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Items.AddRange(new object[] {
            "=",
            "<",
            ">"});
            this.cboStock.Location = new System.Drawing.Point(503, 114);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(61, 24);
            this.cboStock.TabIndex = 118;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(570, 115);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(112, 22);
            this.txtStock.TabIndex = 119;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 120;
            this.label6.Text = "Stock";
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Items.AddRange(new object[] {
            "=",
            "<",
            ">"});
            this.cboUbicacion.Location = new System.Drawing.Point(120, 113);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(61, 24);
            this.cboUbicacion.TabIndex = 115;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(187, 115);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(112, 22);
            this.txtUbicacion.TabIndex = 116;
            this.txtUbicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 117;
            this.label2.Text = "Ubicacion";
            // 
            // cboRubro
            // 
            this.cboRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(120, 80);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(256, 24);
            this.cboRubro.TabIndex = 114;
            this.cboRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 113;
            this.label5.Text = "SubRubro";
            // 
            // cboMarca
            // 
            this.cboMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(503, 80);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(232, 24);
            this.cboMarca.TabIndex = 112;
            this.cboMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // cboProveedor
            // 
            this.cboProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(503, 47);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(232, 24);
            this.cboProveedor.TabIndex = 111;
            this.cboProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(552, 194);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(45, 25);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 16);
            this.label16.TabIndex = 102;
            this.label16.Text = "Rubro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 99;
            this.label1.Text = "Proveedor";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(503, 194);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 25);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboCodigo
            // 
            this.cboCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodigo.FormattingEnabled = true;
            this.cboCodigo.Items.AddRange(new object[] {
            "="});
            this.cboCodigo.Location = new System.Drawing.Point(120, 16);
            this.cboCodigo.Name = "cboCodigo";
            this.cboCodigo.Size = new System.Drawing.Size(61, 24);
            this.cboCodigo.TabIndex = 0;
            // 
            // cboDescripcion
            // 
            this.cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescripcion.FormattingEnabled = true;
            this.cboDescripcion.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboDescripcion.Location = new System.Drawing.Point(120, 47);
            this.cboDescripcion.Name = "cboDescripcion";
            this.cboDescripcion.Size = new System.Drawing.Size(61, 24);
            this.cboDescripcion.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(187, 48);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(189, 22);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Descripcion";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(187, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(189, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Codigo";
            // 
            // btnImagenMode
            // 
            this.btnImagenMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImagenMode.Location = new System.Drawing.Point(26, 5);
            this.btnImagenMode.Name = "btnImagenMode";
            this.btnImagenMode.Size = new System.Drawing.Size(154, 23);
            this.btnImagenMode.TabIndex = 13;
            this.btnImagenMode.Text = "Cambiar a Modo Imagen";
            this.btnImagenMode.UseVisualStyleBackColor = true;
            this.btnImagenMode.Visible = false;
            this.btnImagenMode.Click += new System.EventHandler(this.btnImagenMode_Click);
            // 
            // frmArticulosBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 686);
            this.Controls.Add(this.btnImagenMode);
            this.Controls.Add(this.gridBuscarArticulos);
            this.Controls.Add(this.grBusqueda);
            this.MaximizeBox = false;
            this.Name = "frmArticulosBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Busqueda de Articulos";
            this.Load += new System.EventHandler(this.frmArticulosBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarArticulos)).EndInit();
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBuscarArticulos;
        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCodigo;
        private System.Windows.Forms.ComboBox cboDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CkStockMinimo;
        private System.Windows.Forms.Button btnImagenMode;
        private System.Windows.Forms.DateTimePicker dtpFechadeIngresoHasta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaIngresoDesde;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.CheckBox ckSeleccionarTodos;
        private System.Windows.Forms.Button btnBorrar;
    }
}