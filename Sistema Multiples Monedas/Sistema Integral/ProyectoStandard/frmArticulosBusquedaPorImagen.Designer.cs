namespace ProyectoStandard
{
    partial class frmArticulosBusquedaPorImagen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSeleccion = new System.Windows.Forms.ComboBox();
            this.lblIngrese = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.pnlImagenes = new System.Windows.Forms.Panel();
            this.pnlDetalle1 = new System.Windows.Forms.Panel();
            this.lblMarcaLlenar = new System.Windows.Forms.Label();
            this.lblIDLlenar = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblStockLlenar = new System.Windows.Forms.Label();
            this.lblUbicacionLlenar = new System.Windows.Forms.Label();
            this.lblPrecioLlenar = new System.Windows.Forms.Label();
            this.lblDescripcionLlenar = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.cboAgregar = new System.Windows.Forms.Button();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pcImagen = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.pnlImagenes.SuspendLayout();
            this.pnlDetalle1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSeleccion);
            this.groupBox1.Controls.Add(this.lblIngrese);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda:";
            // 
            // cboSeleccion
            // 
            this.cboSeleccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSeleccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeleccion.FormattingEnabled = true;
            this.cboSeleccion.Items.AddRange(new object[] {
            "DESCRIPCION",
            "RUBRO",
            "UBICACION"});
            this.cboSeleccion.Location = new System.Drawing.Point(469, 21);
            this.cboSeleccion.Name = "cboSeleccion";
            this.cboSeleccion.Size = new System.Drawing.Size(248, 24);
            this.cboSeleccion.TabIndex = 8;
            // 
            // lblIngrese
            // 
            this.lblIngrese.AutoSize = true;
            this.lblIngrese.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrese.Location = new System.Drawing.Point(6, 26);
            this.lblIngrese.Name = "lblIngrese";
            this.lblIngrese.Size = new System.Drawing.Size(61, 14);
            this.lblIngrese.TabIndex = 5;
            this.lblIngrese.Text = "Ingrese: ";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(73, 22);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(390, 23);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // pnlImagenes
            // 
            this.pnlImagenes.AutoSize = true;
            this.pnlImagenes.Controls.Add(this.pnlDetalle1);
            this.pnlImagenes.Location = new System.Drawing.Point(10, 75);
            this.pnlImagenes.Name = "pnlImagenes";
            this.pnlImagenes.Size = new System.Drawing.Size(1085, 578);
            this.pnlImagenes.TabIndex = 2;
            // 
            // pnlDetalle1
            // 
            this.pnlDetalle1.AutoScroll = true;
            this.pnlDetalle1.Controls.Add(this.lblMarcaLlenar);
            this.pnlDetalle1.Controls.Add(this.lblIDLlenar);
            this.pnlDetalle1.Controls.Add(this.lblMarca);
            this.pnlDetalle1.Controls.Add(this.lblID);
            this.pnlDetalle1.Controls.Add(this.lblStockLlenar);
            this.pnlDetalle1.Controls.Add(this.lblUbicacionLlenar);
            this.pnlDetalle1.Controls.Add(this.lblPrecioLlenar);
            this.pnlDetalle1.Controls.Add(this.lblDescripcionLlenar);
            this.pnlDetalle1.Controls.Add(this.lblStock);
            this.pnlDetalle1.Controls.Add(this.lblUbicacion);
            this.pnlDetalle1.Controls.Add(this.cboAgregar);
            this.pnlDetalle1.Controls.Add(this.lblPrecio);
            this.pnlDetalle1.Controls.Add(this.lblDescripcion);
            this.pnlDetalle1.Controls.Add(this.pcImagen);
            this.pnlDetalle1.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle1.Name = "pnlDetalle1";
            this.pnlDetalle1.Size = new System.Drawing.Size(265, 285);
            this.pnlDetalle1.TabIndex = 0;
            this.pnlDetalle1.Visible = false;
            // 
            // lblMarcaLlenar
            // 
            this.lblMarcaLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarcaLlenar.Location = new System.Drawing.Point(135, 211);
            this.lblMarcaLlenar.Name = "lblMarcaLlenar";
            this.lblMarcaLlenar.Size = new System.Drawing.Size(126, 19);
            this.lblMarcaLlenar.TabIndex = 16;
            // 
            // lblIDLlenar
            // 
            this.lblIDLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDLlenar.Location = new System.Drawing.Point(27, 211);
            this.lblIDLlenar.Name = "lblIDLlenar";
            this.lblIDLlenar.Size = new System.Drawing.Size(64, 19);
            this.lblIDLlenar.TabIndex = 15;
            // 
            // lblMarca
            // 
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(89, 211);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(52, 19);
            this.lblMarca.TabIndex = 14;
            this.lblMarca.Text = "Marca:";
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(4, 211);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 19);
            this.lblID.TabIndex = 13;
            this.lblID.Text = "ID:";
            // 
            // lblStockLlenar
            // 
            this.lblStockLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLlenar.Location = new System.Drawing.Point(223, 235);
            this.lblStockLlenar.Name = "lblStockLlenar";
            this.lblStockLlenar.Size = new System.Drawing.Size(40, 19);
            this.lblStockLlenar.TabIndex = 12;
            // 
            // lblUbicacionLlenar
            // 
            this.lblUbicacionLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacionLlenar.Location = new System.Drawing.Point(125, 235);
            this.lblUbicacionLlenar.Name = "lblUbicacionLlenar";
            this.lblUbicacionLlenar.Size = new System.Drawing.Size(53, 19);
            this.lblUbicacionLlenar.TabIndex = 11;
            // 
            // lblPrecioLlenar
            // 
            this.lblPrecioLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioLlenar.Location = new System.Drawing.Point(27, 235);
            this.lblPrecioLlenar.Name = "lblPrecioLlenar";
            this.lblPrecioLlenar.Size = new System.Drawing.Size(64, 19);
            this.lblPrecioLlenar.TabIndex = 10;
            // 
            // lblDescripcionLlenar
            // 
            this.lblDescripcionLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDescripcionLlenar.Location = new System.Drawing.Point(87, 193);
            this.lblDescripcionLlenar.Name = "lblDescripcionLlenar";
            this.lblDescripcionLlenar.Size = new System.Drawing.Size(174, 18);
            this.lblDescripcionLlenar.TabIndex = 9;
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(184, 235);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(41, 19);
            this.lblStock.TabIndex = 8;
            this.lblStock.Text = "Stock:";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUbicacion.Location = new System.Drawing.Point(89, 235);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(40, 19);
            this.lblUbicacion.TabIndex = 7;
            this.lblUbicacion.Text = "Ubic:";
            // 
            // cboAgregar
            // 
            this.cboAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgregar.Location = new System.Drawing.Point(71, 257);
            this.cboAgregar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cboAgregar.Name = "cboAgregar";
            this.cboAgregar.Size = new System.Drawing.Size(84, 26);
            this.cboAgregar.TabIndex = 6;
            this.cboAgregar.Text = "Agregar";
            this.cboAgregar.UseVisualStyleBackColor = true;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(4, 235);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(25, 19);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "$:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(3, 193);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 18);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // pcImagen
            // 
            this.pcImagen.Location = new System.Drawing.Point(3, 3);
            this.pcImagen.Name = "pcImagen";
            this.pcImagen.Size = new System.Drawing.Size(262, 187);
            this.pcImagen.TabIndex = 0;
            this.pcImagen.TabStop = false;
            // 
            // frmArticulosBusquedaPorImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1105, 673);
            this.Controls.Add(this.pnlImagenes);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmArticulosBusquedaPorImagen";
            this.Text = "Busqueda de Articulos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlImagenes.ResumeLayout(false);
            this.pnlDetalle1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSeleccion;
        private System.Windows.Forms.Label lblIngrese;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Panel pnlImagenes;
        private System.Windows.Forms.Panel pnlDetalle1;
        private System.Windows.Forms.Label lblMarcaLlenar;
        private System.Windows.Forms.Label lblIDLlenar;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblStockLlenar;
        private System.Windows.Forms.Label lblUbicacionLlenar;
        private System.Windows.Forms.Label lblPrecioLlenar;
        private System.Windows.Forms.Label lblDescripcionLlenar;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Button cboAgregar;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox pcImagen;
    }
}