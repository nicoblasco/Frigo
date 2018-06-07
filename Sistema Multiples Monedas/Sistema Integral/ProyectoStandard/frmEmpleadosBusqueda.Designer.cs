namespace ProyectoStandard
{
    partial class frmEmpleadosBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleadosBusqueda));
            this.gridBuscarEmpleados = new System.Windows.Forms.DataGridView();
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dtpFechadeIngresoHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaIngresoDesde = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboApellido = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCodigo = new System.Windows.Forms.ComboBox();
            this.cboNombre = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarEmpleados)).BeginInit();
            this.grBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBuscarEmpleados
            // 
            this.gridBuscarEmpleados.AllowUserToAddRows = false;
            this.gridBuscarEmpleados.AllowUserToDeleteRows = false;
            this.gridBuscarEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBuscarEmpleados.Location = new System.Drawing.Point(42, 174);
            this.gridBuscarEmpleados.Name = "gridBuscarEmpleados";
            this.gridBuscarEmpleados.ReadOnly = true;
            this.gridBuscarEmpleados.Size = new System.Drawing.Size(772, 427);
            this.gridBuscarEmpleados.TabIndex = 11;
            this.gridBuscarEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBuscarEmpleados_CellDoubleClick);
            // 
            // grBusqueda
            // 
            this.grBusqueda.Controls.Add(this.btnLimpiar);
            this.grBusqueda.Controls.Add(this.dtpFechadeIngresoHasta);
            this.grBusqueda.Controls.Add(this.label2);
            this.grBusqueda.Controls.Add(this.dtpFechaIngresoDesde);
            this.grBusqueda.Controls.Add(this.label13);
            this.grBusqueda.Controls.Add(this.cboTipoDoc);
            this.grBusqueda.Controls.Add(this.txtDni);
            this.grBusqueda.Controls.Add(this.label16);
            this.grBusqueda.Controls.Add(this.cboApellido);
            this.grBusqueda.Controls.Add(this.txtApellido);
            this.grBusqueda.Controls.Add(this.label1);
            this.grBusqueda.Controls.Add(this.btnBuscar);
            this.grBusqueda.Controls.Add(this.cboCodigo);
            this.grBusqueda.Controls.Add(this.cboNombre);
            this.grBusqueda.Controls.Add(this.txtNombre);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.txtCodigo);
            this.grBusqueda.Controls.Add(this.label3);
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(42, 12);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(772, 156);
            this.grBusqueda.TabIndex = 10;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(597, 115);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(45, 25);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dtpFechadeIngresoHasta
            // 
            this.dtpFechadeIngresoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechadeIngresoHasta.Location = new System.Drawing.Point(276, 114);
            this.dtpFechadeIngresoHasta.Name = "dtpFechadeIngresoHasta";
            this.dtpFechadeIngresoHasta.Size = new System.Drawing.Size(101, 22);
            this.dtpFechadeIngresoHasta.TabIndex = 11;
            this.dtpFechadeIngresoHasta.Value = new System.DateTime(2012, 6, 18, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 110;
            this.label2.Text = "Hasta";
            // 
            // dtpFechaIngresoDesde
            // 
            this.dtpFechaIngresoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngresoDesde.Location = new System.Drawing.Point(121, 114);
            this.dtpFechaIngresoDesde.Name = "dtpFechaIngresoDesde";
            this.dtpFechaIngresoDesde.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaIngresoDesde.TabIndex = 10;
            this.dtpFechaIngresoDesde.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtpFechaIngresoDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaIngresoDesde_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 16);
            this.label13.TabIndex = 108;
            this.label13.Text = "Fecha de Ing.";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Items.AddRange(new object[] {
            "=",
            "<",
            ">"});
            this.cboTipoDoc.Location = new System.Drawing.Point(120, 77);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(61, 24);
            this.cboTipoDoc.TabIndex = 6;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(187, 78);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(189, 22);
            this.txtDni.TabIndex = 7;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 16);
            this.label16.TabIndex = 102;
            this.label16.Text = "Documento";
            // 
            // cboApellido
            // 
            this.cboApellido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApellido.FormattingEnabled = true;
            this.cboApellido.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboApellido.Location = new System.Drawing.Point(503, 48);
            this.cboApellido.Name = "cboApellido";
            this.cboApellido.Size = new System.Drawing.Size(61, 24);
            this.cboApellido.TabIndex = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(570, 49);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(189, 22);
            this.txtApellido.TabIndex = 5;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaIngresoDesde_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 99;
            this.label1.Text = "Apellido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(503, 115);
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
            "=",
            "<",
            ">"});
            this.cboCodigo.Location = new System.Drawing.Point(120, 16);
            this.cboCodigo.Name = "cboCodigo";
            this.cboCodigo.Size = new System.Drawing.Size(61, 24);
            this.cboCodigo.TabIndex = 0;
            // 
            // cboNombre
            // 
            this.cboNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNombre.FormattingEnabled = true;
            this.cboNombre.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboNombre.Location = new System.Drawing.Point(120, 47);
            this.cboNombre.Name = "cboNombre";
            this.cboNombre.Size = new System.Drawing.Size(61, 24);
            this.cboNombre.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(187, 48);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(189, 22);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaIngresoDesde_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Nombre";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(187, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(112, 22);
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
            // frmEmpleadosBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 628);
            this.Controls.Add(this.gridBuscarEmpleados);
            this.Controls.Add(this.grBusqueda);
            this.MaximizeBox = false;
            this.Name = "frmEmpleadosBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Busqueda de Empleados";
            this.Load += new System.EventHandler(this.frmEmpleadosBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarEmpleados)).EndInit();
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBuscarEmpleados;
        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DateTimePicker dtpFechadeIngresoHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIngresoDesde;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCodigo;
        private System.Windows.Forms.ComboBox cboNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
    }
}