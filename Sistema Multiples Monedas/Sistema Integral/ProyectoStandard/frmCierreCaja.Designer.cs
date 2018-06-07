namespace ProyectoStandard
{
    partial class frmCierreCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreCaja));
            this.grBusqueda = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDevoluciones = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalEfectivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComprasEnEfectivo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalCaja = new System.Windows.Forms.TextBox();
            this.txtCtaCte = new System.Windows.Forms.TextBox();
            this.txtVentaEnEfectivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDineroInicial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // grBusqueda
            // 
            this.grBusqueda.Controls.Add(this.listBox);
            this.grBusqueda.Controls.Add(this.label8);
            this.grBusqueda.Controls.Add(this.txtDevoluciones);
            this.grBusqueda.Controls.Add(this.label7);
            this.grBusqueda.Controls.Add(this.txtTotalEfectivo);
            this.grBusqueda.Controls.Add(this.label4);
            this.grBusqueda.Controls.Add(this.txtComprasEnEfectivo);
            this.grBusqueda.Controls.Add(this.label6);
            this.grBusqueda.Controls.Add(this.txtTotalCaja);
            this.grBusqueda.Controls.Add(this.txtCtaCte);
            this.grBusqueda.Controls.Add(this.txtVentaEnEfectivo);
            this.grBusqueda.Controls.Add(this.label5);
            this.grBusqueda.Controls.Add(this.label1);
            this.grBusqueda.Controls.Add(this.dtpFechaIngreso);
            this.grBusqueda.Controls.Add(this.label2);
            this.grBusqueda.Controls.Add(this.txtDineroInicial);
            this.grBusqueda.Controls.Add(this.label3);
            this.grBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grBusqueda.Name = "grBusqueda";
            this.grBusqueda.Size = new System.Drawing.Size(607, 315);
            this.grBusqueda.TabIndex = 0;
            this.grBusqueda.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(326, 87);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(266, 132);
            this.listBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(323, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 16);
            this.label8.TabIndex = 71;
            this.label8.Text = "Detalle de Ventas por Medio de Pago";
            // 
            // txtDevoluciones
            // 
            this.txtDevoluciones.Enabled = false;
            this.txtDevoluciones.Location = new System.Drawing.Point(194, 171);
            this.txtDevoluciones.Name = "txtDevoluciones";
            this.txtDevoluciones.Size = new System.Drawing.Size(99, 22);
            this.txtDevoluciones.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(7, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 69;
            this.label7.Text = "Devoluciones";
            // 
            // txtTotalEfectivo
            // 
            this.txtTotalEfectivo.Location = new System.Drawing.Point(194, 219);
            this.txtTotalEfectivo.Name = "txtTotalEfectivo";
            this.txtTotalEfectivo.Size = new System.Drawing.Size(99, 22);
            this.txtTotalEfectivo.TabIndex = 6;
            this.txtTotalEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDineroInicial_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(6, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "TOTAL";
            // 
            // txtComprasEnEfectivo
            // 
            this.txtComprasEnEfectivo.Location = new System.Drawing.Point(194, 115);
            this.txtComprasEnEfectivo.Name = "txtComprasEnEfectivo";
            this.txtComprasEnEfectivo.Size = new System.Drawing.Size(99, 22);
            this.txtComprasEnEfectivo.TabIndex = 3;
            this.txtComprasEnEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDineroInicial_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(6, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 64;
            this.label6.Text = "Compras";
            // 
            // txtTotalCaja
            // 
            this.txtTotalCaja.Location = new System.Drawing.Point(194, 276);
            this.txtTotalCaja.Name = "txtTotalCaja";
            this.txtTotalCaja.Size = new System.Drawing.Size(99, 22);
            this.txtTotalCaja.TabIndex = 8;
            this.txtTotalCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDineroInicial_KeyPress);
            // 
            // txtCtaCte
            // 
            this.txtCtaCte.Location = new System.Drawing.Point(194, 143);
            this.txtCtaCte.Name = "txtCtaCte";
            this.txtCtaCte.Size = new System.Drawing.Size(99, 22);
            this.txtCtaCte.TabIndex = 4;
            this.txtCtaCte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDineroInicial_KeyPress);
            // 
            // txtVentaEnEfectivo
            // 
            this.txtVentaEnEfectivo.Location = new System.Drawing.Point(194, 85);
            this.txtVentaEnEfectivo.Name = "txtVentaEnEfectivo";
            this.txtVentaEnEfectivo.Size = new System.Drawing.Size(99, 22);
            this.txtVentaEnEfectivo.TabIndex = 2;
            this.txtVentaEnEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDineroInicial_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 60;
            this.label5.Text = "Deben";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(6, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "TOTAL EN EFECTIVO";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Enabled = false;
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(10, 12);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(100, 22);
            this.dtpFechaIngreso.TabIndex = 0;
            this.dtpFechaIngreso.Value = new System.DateTime(2013, 2, 22, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Ventas";
            // 
            // txtDineroInicial
            // 
            this.txtDineroInicial.Location = new System.Drawing.Point(194, 44);
            this.txtDineroInicial.Name = "txtDineroInicial";
            this.txtDineroInicial.Size = new System.Drawing.Size(99, 22);
            this.txtDineroInicial.TabIndex = 1;
            this.txtDineroInicial.Leave += new System.EventHandler(this.txtDineroInicial_Leave);
            this.txtDineroInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDineroInicial_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Dinero Inicial en caja";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(235, 332);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 47);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 390);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grBusqueda);
            this.Name = "frmCierreCaja";
            this.Text = "Cierre de Caja";
            this.Load += new System.EventHandler(this.frmCierreCaja_Load);
            this.grBusqueda.ResumeLayout(false);
            this.grBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBusqueda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDineroInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCtaCte;
        private System.Windows.Forms.TextBox txtVentaEnEfectivo;
        private System.Windows.Forms.TextBox txtComprasEnEfectivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtDevoluciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalEfectivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.ListBox listBox;
    }
}