namespace ProyectoStandard
{
    partial class frmTelefonos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelefonos));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grid_telefonos = new System.Windows.Forms.DataGridView();
            this.cboTipoContacto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtInterno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_telefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(451, 64);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(373, 64);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(32, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(411, 64);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(34, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grid_telefonos
            // 
            this.grid_telefonos.AllowUserToAddRows = false;
            this.grid_telefonos.AllowUserToDeleteRows = false;
            this.grid_telefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_telefonos.Location = new System.Drawing.Point(36, 91);
            this.grid_telefonos.Name = "grid_telefonos";
            this.grid_telefonos.ReadOnly = true;
            this.grid_telefonos.Size = new System.Drawing.Size(449, 173);
            this.grid_telefonos.TabIndex = 65;
            this.grid_telefonos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_telefonos_CellDoubleClick);
            // 
            // cboTipoContacto
            // 
            this.cboTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboTipoContacto.FormattingEnabled = true;
            this.cboTipoContacto.Items.AddRange(new object[] {
            "PERSONAL",
            "FAMILIAR",
            "VECINO",
            "LABORAL",
            "OTRO"});
            this.cboTipoContacto.Location = new System.Drawing.Point(107, 64);
            this.cboTipoContacto.Name = "cboTipoContacto";
            this.cboTipoContacto.Size = new System.Drawing.Size(260, 24);
            this.cboTipoContacto.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(33, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "Contacto";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(33, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 16);
            this.label18.TabIndex = 63;
            this.label18.Text = "Telefono";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "FIJO",
            "CELULAR",
            "FAX"});
            this.cboTipo.Location = new System.Drawing.Point(107, 30);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(90, 24);
            this.cboTipo.TabIndex = 0;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTelefono.Location = new System.Drawing.Point(203, 31);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(164, 22);
            this.txtTelefono.TabIndex = 1;
            // 
            // txtInterno
            // 
            this.txtInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtInterno.Location = new System.Drawing.Point(411, 33);
            this.txtInterno.Name = "txtInterno";
            this.txtInterno.Size = new System.Drawing.Size(74, 22);
            this.txtInterno.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(377, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "Int.";
            // 
            // frmTelefonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 297);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInterno);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grid_telefonos);
            this.Controls.Add(this.cboTipoContacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.txtTelefono);
            this.MaximizeBox = false;
            this.Name = "frmTelefonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Telefonos";
            this.Load += new System.EventHandler(this.frmTelefonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_telefonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView grid_telefonos;
        private System.Windows.Forms.ComboBox cboTipoContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtInterno;
        private System.Windows.Forms.Label label2;
    }
}