namespace ProyectoStandard
{
    partial class frmArticulosMasivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulosMasivo));
            this.ofdAbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.lblComentario = new System.Windows.Forms.Label();
            this.gridArticulos = new System.Windows.Forms.DataGridView();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdAbrirArchivo
            // 
            this.ofdAbrirArchivo.DefaultExt = "xlsx";
            // 
            // lblComentario
            // 
            this.lblComentario.Location = new System.Drawing.Point(12, 45);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(751, 18);
            this.lblComentario.TabIndex = 27;
            this.lblComentario.Text = "Descargar el template presionando el icono Excel. Luego completar los datos y sub" +
                "ir el template presionando el boton Seleccione.";
            // 
            // gridArticulos
            // 
            this.gridArticulos.AllowUserToAddRows = false;
            this.gridArticulos.AllowUserToDeleteRows = false;
            this.gridArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArticulos.Location = new System.Drawing.Point(12, 87);
            this.gridArticulos.Name = "gridArticulos";
            this.gridArticulos.ReadOnly = true;
            this.gridArticulos.Size = new System.Drawing.Size(751, 302);
            this.gridArticulos.TabIndex = 26;
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(97, 14);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(93, 23);
            this.btnImportar.TabIndex = 25;
            this.btnImportar.Text = "Seleccione ...";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(660, 395);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(103, 23);
            this.btnProcesar.TabIndex = 28;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnTemplate.Image")));
            this.btnTemplate.Location = new System.Drawing.Point(15, 8);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(57, 34);
            this.btnTemplate.TabIndex = 29;
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "Los Campos Obligatorios estan pintados en rojo.";
            // 
            // frmArticulosMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 426);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.gridArticulos);
            this.Controls.Add(this.btnImportar);
            this.Name = "frmArticulosMasivo";
            this.Text = "Articulos Masivo";
            this.Load += new System.EventHandler(this.frmArticulosMasivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdAbrirArchivo;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.DataGridView gridArticulos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}