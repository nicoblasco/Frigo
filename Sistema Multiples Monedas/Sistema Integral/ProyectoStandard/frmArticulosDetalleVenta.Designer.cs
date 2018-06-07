namespace ProyectoStandard
{
    partial class frmArticulosDetalleVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulosDetalleVenta));
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.Descripcion = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPUTarjeta = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPUEfectivo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalTarjeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalEfectivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCantidad.Location = new System.Drawing.Point(120, 98);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(63, 23);
            this.txtCantidad.TabIndex = 99;
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(27, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 14);
            this.label21.TabIndex = 100;
            this.label21.Text = "Cant";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDescripcion.Location = new System.Drawing.Point(120, 62);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(260, 23);
            this.txtDescripcion.TabIndex = 98;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion.Location = new System.Drawing.Point(27, 65);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(76, 14);
            this.Descripcion.TabIndex = 97;
            this.Descripcion.Text = "Descripcion";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(120, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(162, 23);
            this.txtCodigo.TabIndex = 96;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(27, 33);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 14);
            this.label25.TabIndex = 95;
            this.label25.Text = "Codigo";
            // 
            // txtPUTarjeta
            // 
            this.txtPUTarjeta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPUTarjeta.Location = new System.Drawing.Point(124, 170);
            this.txtPUTarjeta.Name = "txtPUTarjeta";
            this.txtPUTarjeta.Size = new System.Drawing.Size(57, 23);
            this.txtPUTarjeta.TabIndex = 105;
            this.txtPUTarjeta.Visible = false;
            this.txtPUTarjeta.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(42, 174);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 14);
            this.label19.TabIndex = 106;
            this.label19.Text = "PU Tarjeta";
            this.label19.Visible = false;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDescuento.Location = new System.Drawing.Point(322, 98);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(58, 23);
            this.txtDescuento.TabIndex = 102;
            this.txtDescuento.Leave += new System.EventHandler(this.txtCantidad_Leave);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(232, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 14);
            this.label14.TabIndex = 104;
            this.label14.Text = "Descuento %";
            // 
            // txtPUEfectivo
            // 
            this.txtPUEfectivo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPUEfectivo.Location = new System.Drawing.Point(120, 134);
            this.txtPUEfectivo.Name = "txtPUEfectivo";
            this.txtPUEfectivo.Size = new System.Drawing.Size(70, 23);
            this.txtPUEfectivo.TabIndex = 101;
            this.txtPUEfectivo.Leave += new System.EventHandler(this.txtCantidad_Leave);
            this.txtPUEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPUEfectivo_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(27, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 14);
            this.label15.TabIndex = 103;
            this.label15.Text = "PU Efectivo";
            // 
            // txtTotalTarjeta
            // 
            this.txtTotalTarjeta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotalTarjeta.Location = new System.Drawing.Point(323, 168);
            this.txtTotalTarjeta.Name = "txtTotalTarjeta";
            this.txtTotalTarjeta.Size = new System.Drawing.Size(57, 23);
            this.txtTotalTarjeta.TabIndex = 109;
            this.txtTotalTarjeta.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 110;
            this.label1.Text = "Total Tarjeta";
            this.label1.Visible = false;
            // 
            // txtTotalEfectivo
            // 
            this.txtTotalEfectivo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotalEfectivo.Location = new System.Drawing.Point(323, 134);
            this.txtTotalEfectivo.Name = "txtTotalEfectivo";
            this.txtTotalEfectivo.Size = new System.Drawing.Size(64, 23);
            this.txtTotalEfectivo.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 108;
            this.label2.Text = "Total Efectivo";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(188, 170);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 47);
            this.btnAceptar.TabIndex = 111;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmArticulosDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 262);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTotalTarjeta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalEfectivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPUTarjeta);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPUEfectivo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label25);
            this.MaximizeBox = false;
            this.Name = "frmArticulosDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Articulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label Descripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPUTarjeta;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPUEfectivo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
    }
}