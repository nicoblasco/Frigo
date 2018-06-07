namespace ProyectoStandard
{
    partial class frmUsuariosPerfiles
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
            this.grbFiltros = new System.Windows.Forms.GroupBox();
            this.ckEscritura = new System.Windows.Forms.CheckBox();
            this.ckLectura = new System.Windows.Forms.CheckBox();
            this.cboUsuarios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gridPerfiles = new System.Windows.Forms.DataGridView();
            this.grbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // grbFiltros
            // 
            this.grbFiltros.Controls.Add(this.ckEscritura);
            this.grbFiltros.Controls.Add(this.ckLectura);
            this.grbFiltros.Controls.Add(this.cboUsuarios);
            this.grbFiltros.Controls.Add(this.label4);
            this.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFiltros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grbFiltros.Location = new System.Drawing.Point(0, 0);
            this.grbFiltros.Name = "grbFiltros";
            this.grbFiltros.Size = new System.Drawing.Size(1101, 53);
            this.grbFiltros.TabIndex = 0;
            this.grbFiltros.TabStop = false;
            this.grbFiltros.Text = "Filtros";
            // 
            // ckEscritura
            // 
            this.ckEscritura.AutoSize = true;
            this.ckEscritura.Location = new System.Drawing.Point(864, 19);
            this.ckEscritura.Name = "ckEscritura";
            this.ckEscritura.Size = new System.Drawing.Size(132, 18);
            this.ckEscritura.TabIndex = 14;
            this.ckEscritura.Text = "Lectura/Escritura";
            this.ckEscritura.UseVisualStyleBackColor = true;
            this.ckEscritura.CheckedChanged += new System.EventHandler(this.ckEscritura_CheckedChanged);
            // 
            // ckLectura
            // 
            this.ckLectura.AutoSize = true;
            this.ckLectura.Location = new System.Drawing.Point(721, 19);
            this.ckLectura.Name = "ckLectura";
            this.ckLectura.Size = new System.Drawing.Size(72, 18);
            this.ckLectura.TabIndex = 13;
            this.ckLectura.Text = "Lectura";
            this.ckLectura.UseVisualStyleBackColor = true;
            this.ckLectura.CheckedChanged += new System.EventHandler(this.ckLectura_CheckedChanged);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUsuarios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(111, 19);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(367, 22);
            this.cboUsuarios.TabIndex = 11;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "Usuario";
            // 
            // gridPerfiles
            // 
            this.gridPerfiles.AllowUserToAddRows = false;
            this.gridPerfiles.AllowUserToDeleteRows = false;
            this.gridPerfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPerfiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridPerfiles.Location = new System.Drawing.Point(0, 59);
            this.gridPerfiles.Name = "gridPerfiles";
            this.gridPerfiles.Size = new System.Drawing.Size(1101, 540);
            this.gridPerfiles.TabIndex = 13;
            this.gridPerfiles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPerfiles_CellValueChanged);
            this.gridPerfiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPerfiles_CellDoubleClick);
            // 
            // frmUsuariosPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 599);
            this.Controls.Add(this.gridPerfiles);
            this.Controls.Add(this.grbFiltros);
            this.Name = "frmUsuariosPerfiles";
            this.Text = "Perfiles de Usuario";
            this.Load += new System.EventHandler(this.frmUsuariosPerfiles_Load);
            this.grbFiltros.ResumeLayout(false);
            this.grbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPerfiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbFiltros;
        private System.Windows.Forms.ComboBox cboUsuarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridPerfiles;
        private System.Windows.Forms.CheckBox ckEscritura;
        private System.Windows.Forms.CheckBox ckLectura;
    }
}