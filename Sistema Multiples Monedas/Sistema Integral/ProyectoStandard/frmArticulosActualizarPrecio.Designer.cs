﻿namespace ProyectoStandard
{
    partial class frmArticulosActualizarPrecio
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
            this.gridArticulos = new System.Windows.Forms.DataGridView();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.ofdAbrirArchivo = new System.Windows.Forms.OpenFileDialog();
            this.lblComentario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridArticulos
            // 
            this.gridArticulos.AllowUserToAddRows = false;
            this.gridArticulos.AllowUserToDeleteRows = false;
            this.gridArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArticulos.Location = new System.Drawing.Point(12, 67);
            this.gridArticulos.Name = "gridArticulos";
            this.gridArticulos.ReadOnly = true;
            this.gridArticulos.Size = new System.Drawing.Size(375, 324);
            this.gridArticulos.TabIndex = 18;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(284, 397);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(103, 23);
            this.btnProcesar.TabIndex = 17;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(12, 5);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(93, 23);
            this.btnImportar.TabIndex = 16;
            this.btnImportar.Text = "Seleccione ...";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblComentario
            // 
            this.lblComentario.Location = new System.Drawing.Point(13, 35);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(372, 29);
            this.lblComentario.TabIndex = 19;
            this.lblComentario.Text = "Debe importar un Excel, con el siguiente Formato. En la 1er Columna debe ir el co" +
                "digo del articulo, en la 2da Columna el Costo. No colocar titulo.";
            // 
            // frmArticulosActualizarPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 432);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.gridArticulos);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnImportar);
            this.Name = "frmArticulosActualizarPrecio";
            this.Text = "Actualizar Costo - Masivo";
            this.Load += new System.EventHandler(this.frmArticulosActualizarPrecio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridArticulos;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.OpenFileDialog ofdAbrirArchivo;
        private System.Windows.Forms.Label lblComentario;
    }
}