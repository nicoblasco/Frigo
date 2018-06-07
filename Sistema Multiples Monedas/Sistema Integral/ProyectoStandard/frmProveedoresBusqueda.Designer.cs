namespace ProyectoStandard
{
    partial class frmProveedoresBusqueda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedoresBusqueda));
            this.gridBuscarProveedores = new System.Windows.Forms.DataGridView();
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckMartes = new System.Windows.Forms.CheckBox();
            this.ckMiercoles = new System.Windows.Forms.CheckBox();
            this.ckJueves = new System.Windows.Forms.CheckBox();
            this.ckDomingo = new System.Windows.Forms.CheckBox();
            this.ckSabado = new System.Windows.Forms.CheckBox();
            this.ckViernes = new System.Windows.Forms.CheckBox();
            this.ckLunes = new System.Windows.Forms.CheckBox();
            this.cboServicios = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dtpFechadeIngresoHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaIngresoDesde = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCodigo = new System.Windows.Forms.ComboBox();
            this.cboRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarProveedores)).BeginInit();
            this.grBusqueda.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBuscarProveedores
            // 
            this.gridBuscarProveedores.AllowUserToAddRows = false;
            this.gridBuscarProveedores.AllowUserToDeleteRows = false;
            this.gridBuscarProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBuscarProveedores.Location = new System.Drawing.Point(43, 314);
            this.gridBuscarProveedores.Name = "gridBuscarProveedores";
            this.gridBuscarProveedores.ReadOnly = true;
            this.gridBuscarProveedores.Size = new System.Drawing.Size(772, 322);
            this.gridBuscarProveedores.TabIndex = 11;
            this.gridBuscarProveedores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBuscarProveedores_CellDoubleClick);
            // 
            // grBusqueda
            // 
            this.grBusqueda.Controls.Add(this.groupBox2);
            this.grBusqueda.Controls.Add(this.cboServicios);
            this.grBusqueda.Controls.Add(this.label12);
            this.grBusqueda.Controls.Add(this.btnLimpiar);
            this.grBusqueda.Controls.Add(this.dtpFechadeIngresoHasta);
            this.grBusqueda.Controls.Add(this.label2);
            this.grBusqueda.Controls.Add(this.dtpFechaIngresoDesde);
            this.grBusqueda.Controls.Add(this.label13);
            this.grBusqueda.Controls.Add(this.cboTipoDoc);
            this.grBusqueda.Controls.Add(this.txtDni);
            this.grBusqueda.Controls.Add(this.label16);
            this.grBusqueda.Controls.Add(this.btnBuscar);
            this.grBusqueda.Controls.Add(this.cboCodigo);
            this.grBusqueda.Controls.Add(this.cboRazonSocial);
            this.grBusqueda.Controls.Add(this.txtRazonSocial);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.txtCodigo);
            this.grBusqueda.Controls.Add(this.label3);
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(43, 22);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(772, 286);
            this.grBusqueda.TabIndex = 10;
            this.grBusqueda.TabStop = false;
            this.grBusqueda.Text = "Buscar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckMartes);
            this.groupBox2.Controls.Add(this.ckMiercoles);
            this.groupBox2.Controls.Add(this.ckJueves);
            this.groupBox2.Controls.Add(this.ckDomingo);
            this.groupBox2.Controls.Add(this.ckSabado);
            this.groupBox2.Controls.Add(this.ckViernes);
            this.groupBox2.Controls.Add(this.ckLunes);
            this.groupBox2.Location = new System.Drawing.Point(19, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 48);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dias de visita del proveedor";
            // 
            // ckMartes
            // 
            this.ckMartes.AutoSize = true;
            this.ckMartes.Location = new System.Drawing.Point(70, 23);
            this.ckMartes.Name = "ckMartes";
            this.ckMartes.Size = new System.Drawing.Size(53, 20);
            this.ckMartes.TabIndex = 6;
            this.ckMartes.Text = "Mar";
            this.ckMartes.UseVisualStyleBackColor = true;
            // 
            // ckMiercoles
            // 
            this.ckMiercoles.AutoSize = true;
            this.ckMiercoles.Location = new System.Drawing.Point(140, 23);
            this.ckMiercoles.Name = "ckMiercoles";
            this.ckMiercoles.Size = new System.Drawing.Size(52, 20);
            this.ckMiercoles.TabIndex = 5;
            this.ckMiercoles.Text = "Mié";
            this.ckMiercoles.UseVisualStyleBackColor = true;
            // 
            // ckJueves
            // 
            this.ckJueves.AutoSize = true;
            this.ckJueves.Location = new System.Drawing.Point(210, 23);
            this.ckJueves.Name = "ckJueves";
            this.ckJueves.Size = new System.Drawing.Size(52, 20);
            this.ckJueves.TabIndex = 4;
            this.ckJueves.Text = "Jue";
            this.ckJueves.UseVisualStyleBackColor = true;
            // 
            // ckDomingo
            // 
            this.ckDomingo.AutoSize = true;
            this.ckDomingo.Location = new System.Drawing.Point(405, 23);
            this.ckDomingo.Name = "ckDomingo";
            this.ckDomingo.Size = new System.Drawing.Size(59, 20);
            this.ckDomingo.TabIndex = 3;
            this.ckDomingo.Text = "Dom";
            this.ckDomingo.UseVisualStyleBackColor = true;
            // 
            // ckSabado
            // 
            this.ckSabado.AutoSize = true;
            this.ckSabado.Location = new System.Drawing.Point(345, 23);
            this.ckSabado.Name = "ckSabado";
            this.ckSabado.Size = new System.Drawing.Size(55, 20);
            this.ckSabado.TabIndex = 2;
            this.ckSabado.Text = "Sab";
            this.ckSabado.UseVisualStyleBackColor = true;
            // 
            // ckViernes
            // 
            this.ckViernes.AutoSize = true;
            this.ckViernes.Location = new System.Drawing.Point(277, 23);
            this.ckViernes.Name = "ckViernes";
            this.ckViernes.Size = new System.Drawing.Size(50, 20);
            this.ckViernes.TabIndex = 1;
            this.ckViernes.Text = "Vie";
            this.ckViernes.UseVisualStyleBackColor = true;
            // 
            // ckLunes
            // 
            this.ckLunes.AutoSize = true;
            this.ckLunes.Location = new System.Drawing.Point(7, 23);
            this.ckLunes.Name = "ckLunes";
            this.ckLunes.Size = new System.Drawing.Size(51, 20);
            this.ckLunes.TabIndex = 0;
            this.ckLunes.Text = "Lun";
            this.ckLunes.UseVisualStyleBackColor = true;
            // 
            // cboServicios
            // 
            this.cboServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicios.FormattingEnabled = true;
            this.cboServicios.Location = new System.Drawing.Point(160, 146);
            this.cboServicios.Name = "cboServicios";
            this.cboServicios.Size = new System.Drawing.Size(322, 24);
            this.cboServicios.TabIndex = 111;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 14);
            this.label12.TabIndex = 112;
            this.label12.Text = "Productos/Servicios";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(442, 248);
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
            this.dtpFechadeIngresoHasta.Value = new System.DateTime(2016, 5, 6, 0, 0, 0, 0);
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
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(348, 248);
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
            // cboRazonSocial
            // 
            this.cboRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRazonSocial.FormattingEnabled = true;
            this.cboRazonSocial.Items.AddRange(new object[] {
            "=",
            "like",
            "path"});
            this.cboRazonSocial.Location = new System.Drawing.Point(120, 47);
            this.cboRazonSocial.Name = "cboRazonSocial";
            this.cboRazonSocial.Size = new System.Drawing.Size(61, 24);
            this.cboRazonSocial.TabIndex = 2;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(187, 48);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(295, 22);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Razon Social";
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
            // frmProveedoresBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 648);
            this.Controls.Add(this.gridBuscarProveedores);
            this.Controls.Add(this.grBusqueda);
            this.MaximizeBox = false;
            this.Name = "frmProveedoresBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Busqueda de Proveedores";
            this.Load += new System.EventHandler(this.frmProveedoresBusqueda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridBuscarProveedores)).EndInit();
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBuscarProveedores;
        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DateTimePicker dtpFechadeIngresoHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIngresoDesde;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCodigo;
        private System.Windows.Forms.ComboBox cboRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboServicios;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckMartes;
        private System.Windows.Forms.CheckBox ckMiercoles;
        private System.Windows.Forms.CheckBox ckJueves;
        private System.Windows.Forms.CheckBox ckDomingo;
        private System.Windows.Forms.CheckBox ckSabado;
        private System.Windows.Forms.CheckBox ckViernes;
        private System.Windows.Forms.CheckBox ckLunes;
    }
}