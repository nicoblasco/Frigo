namespace ProyectoStandard
{
    partial class frmSubVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubVenta));
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEfectivoVuelto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEfectivoAbona = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboTarjetaTipo = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnQuitarTarjeta = new System.Windows.Forms.Button();
            this.btnAltaTarjeta = new System.Windows.Forms.Button();
            this.grillaTarjetas = new System.Windows.Forms.DataGridView();
            this.cboTarjeta = new System.Windows.Forms.ComboBox();
            this.txtTarjetaCuotas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTarjetaNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTarjetaAbona = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnQuitarCheque = new System.Windows.Forms.Button();
            this.btnAgregarCheque = new System.Windows.Forms.Button();
            this.btnAltaCheque = new System.Windows.Forms.Button();
            this.grillaCheques = new System.Windows.Forms.DataGridView();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.cboChequeBanco = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChequeNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChequeAbona = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtCtaCteMontoTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCtaCteACuenta = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSubTotalEfectivo = new System.Windows.Forms.Label();
            this.lblSubTotalTarjeta = new System.Windows.Forms.Label();
            this.lblSubTotalCheque = new System.Windows.Forms.Label();
            this.lblSubtotalCtaCte = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTarjetas)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCheques)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSubTotal.Location = new System.Drawing.Point(223, 23);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(162, 23);
            this.txtSubTotal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "SubTotal";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(65, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(410, 355);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.txtEfectivoVuelto);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtEfectivoAbona);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(402, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Efectivo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtEfectivoVuelto
            // 
            this.txtEfectivoVuelto.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoVuelto.Location = new System.Drawing.Point(171, 81);
            this.txtEfectivoVuelto.Name = "txtEfectivoVuelto";
            this.txtEfectivoVuelto.Size = new System.Drawing.Size(162, 40);
            this.txtEfectivoVuelto.TabIndex = 1;
            this.txtEfectivoVuelto.Leave += new System.EventHandler(this.txtEfectivoVuelto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 33);
            this.label3.TabIndex = 37;
            this.label3.Text = "Vuelto";
            // 
            // txtEfectivoAbona
            // 
            this.txtEfectivoAbona.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivoAbona.Location = new System.Drawing.Point(171, 35);
            this.txtEfectivoAbona.Name = "txtEfectivoAbona";
            this.txtEfectivoAbona.Size = new System.Drawing.Size(162, 40);
            this.txtEfectivoAbona.TabIndex = 0;
            this.txtEfectivoAbona.Leave += new System.EventHandler(this.tabControl1_Leave);
            this.txtEfectivoAbona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivoAbona_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 33);
            this.label1.TabIndex = 35;
            this.label1.Text = "Abona";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.cboTarjetaTipo);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.btnQuitarTarjeta);
            this.tabPage2.Controls.Add(this.btnAltaTarjeta);
            this.tabPage2.Controls.Add(this.grillaTarjetas);
            this.tabPage2.Controls.Add(this.cboTarjeta);
            this.tabPage2.Controls.Add(this.txtTarjetaCuotas);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtTarjetaNumero);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtTarjetaAbona);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnAgregarTarjeta);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(402, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tarjeta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboTarjetaTipo
            // 
            this.cboTarjetaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarjetaTipo.FormattingEnabled = true;
            this.cboTarjetaTipo.Items.AddRange(new object[] {
            "CREDITO",
            "DEBITO"});
            this.cboTarjetaTipo.Location = new System.Drawing.Point(154, 88);
            this.cboTarjetaTipo.Name = "cboTarjetaTipo";
            this.cboTarjetaTipo.Size = new System.Drawing.Size(162, 24);
            this.cboTarjetaTipo.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(65, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 14);
            this.label20.TabIndex = 77;
            this.label20.Text = "Tipo";
            // 
            // btnQuitarTarjeta
            // 
            this.btnQuitarTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarTarjeta.Image")));
            this.btnQuitarTarjeta.Location = new System.Drawing.Point(321, 194);
            this.btnQuitarTarjeta.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnQuitarTarjeta.Name = "btnQuitarTarjeta";
            this.btnQuitarTarjeta.Size = new System.Drawing.Size(34, 23);
            this.btnQuitarTarjeta.TabIndex = 6;
            this.btnQuitarTarjeta.UseVisualStyleBackColor = true;
            this.btnQuitarTarjeta.Click += new System.EventHandler(this.btnQuitarTarjeta_Click);
            // 
            // btnAltaTarjeta
            // 
            this.btnAltaTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaTarjeta.Image")));
            this.btnAltaTarjeta.Location = new System.Drawing.Point(322, 58);
            this.btnAltaTarjeta.Name = "btnAltaTarjeta";
            this.btnAltaTarjeta.Size = new System.Drawing.Size(34, 23);
            this.btnAltaTarjeta.TabIndex = 72;
            this.btnAltaTarjeta.UseVisualStyleBackColor = true;
            this.btnAltaTarjeta.Click += new System.EventHandler(this.btnAltaTarjeta_Click);
            // 
            // grillaTarjetas
            // 
            this.grillaTarjetas.AllowUserToAddRows = false;
            this.grillaTarjetas.AllowUserToDeleteRows = false;
            this.grillaTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTarjetas.Location = new System.Drawing.Point(68, 166);
            this.grillaTarjetas.Name = "grillaTarjetas";
            this.grillaTarjetas.ReadOnly = true;
            this.grillaTarjetas.ShowEditingIcon = false;
            this.grillaTarjetas.Size = new System.Drawing.Size(240, 150);
            this.grillaTarjetas.TabIndex = 56;
            this.grillaTarjetas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTarjetas_CellDoubleClick);
            // 
            // cboTarjeta
            // 
            this.cboTarjeta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTarjeta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTarjeta.FormattingEnabled = true;
            this.cboTarjeta.Location = new System.Drawing.Point(154, 60);
            this.cboTarjeta.Name = "cboTarjeta";
            this.cboTarjeta.Size = new System.Drawing.Size(162, 24);
            this.cboTarjeta.TabIndex = 1;
            this.cboTarjeta.Leave += new System.EventHandler(this.cboTarjeta_Leave);
            // 
            // txtTarjetaCuotas
            // 
            this.txtTarjetaCuotas.Location = new System.Drawing.Point(154, 140);
            this.txtTarjetaCuotas.Name = "txtTarjetaCuotas";
            this.txtTarjetaCuotas.Size = new System.Drawing.Size(41, 23);
            this.txtTarjetaCuotas.TabIndex = 4;
            this.txtTarjetaCuotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjetaNumero_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 44;
            this.label7.Text = "Cuotas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 42;
            this.label6.Text = "Tarjeta";
            // 
            // txtTarjetaNumero
            // 
            this.txtTarjetaNumero.Location = new System.Drawing.Point(154, 115);
            this.txtTarjetaNumero.Name = "txtTarjetaNumero";
            this.txtTarjetaNumero.Size = new System.Drawing.Size(162, 23);
            this.txtTarjetaNumero.TabIndex = 3;
            this.txtTarjetaNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarjetaNumero_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 41;
            this.label4.Text = "Numero";
            // 
            // txtTarjetaAbona
            // 
            this.txtTarjetaAbona.Location = new System.Drawing.Point(154, 34);
            this.txtTarjetaAbona.Name = "txtTarjetaAbona";
            this.txtTarjetaAbona.Size = new System.Drawing.Size(162, 23);
            this.txtTarjetaAbona.TabIndex = 0;
            this.txtTarjetaAbona.Leave += new System.EventHandler(this.txtTarjetaAbona_Leave);
            this.txtTarjetaAbona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivoAbona_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 39;
            this.label5.Text = "Abona";
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTarjeta.Image")));
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(321, 166);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(34, 23);
            this.btnAgregarTarjeta.TabIndex = 5;
            this.btnAgregarTarjeta.UseVisualStyleBackColor = true;
            this.btnAgregarTarjeta.Click += new System.EventHandler(this.btnAgregarTarjeta_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.btnQuitarCheque);
            this.tabPage3.Controls.Add(this.btnAgregarCheque);
            this.tabPage3.Controls.Add(this.btnAltaCheque);
            this.tabPage3.Controls.Add(this.grillaCheques);
            this.tabPage3.Controls.Add(this.dtpFechaVencimiento);
            this.tabPage3.Controls.Add(this.cboChequeBanco);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txtChequeNumero);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtChequeAbona);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(402, 326);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cheque";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnQuitarCheque
            // 
            this.btnQuitarCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarCheque.Image")));
            this.btnQuitarCheque.Location = new System.Drawing.Point(321, 177);
            this.btnQuitarCheque.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnQuitarCheque.Name = "btnQuitarCheque";
            this.btnQuitarCheque.Size = new System.Drawing.Size(34, 23);
            this.btnQuitarCheque.TabIndex = 8;
            this.btnQuitarCheque.UseVisualStyleBackColor = true;
            this.btnQuitarCheque.Click += new System.EventHandler(this.btnQuitarCheque_Click);
            // 
            // btnAgregarCheque
            // 
            this.btnAgregarCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCheque.Image")));
            this.btnAgregarCheque.Location = new System.Drawing.Point(321, 149);
            this.btnAgregarCheque.Name = "btnAgregarCheque";
            this.btnAgregarCheque.Size = new System.Drawing.Size(34, 23);
            this.btnAgregarCheque.TabIndex = 7;
            this.btnAgregarCheque.UseVisualStyleBackColor = true;
            this.btnAgregarCheque.Click += new System.EventHandler(this.btnAgregarCheque_Click);
            // 
            // btnAltaCheque
            // 
            this.btnAltaCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaCheque.Image")));
            this.btnAltaCheque.Location = new System.Drawing.Point(323, 52);
            this.btnAltaCheque.Name = "btnAltaCheque";
            this.btnAltaCheque.Size = new System.Drawing.Size(34, 23);
            this.btnAltaCheque.TabIndex = 4;
            this.btnAltaCheque.UseVisualStyleBackColor = true;
            this.btnAltaCheque.Click += new System.EventHandler(this.btnAltaCheque_Click);
            // 
            // grillaCheques
            // 
            this.grillaCheques.AllowUserToAddRows = false;
            this.grillaCheques.AllowUserToDeleteRows = false;
            this.grillaCheques.AllowUserToResizeRows = false;
            this.grillaCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCheques.Location = new System.Drawing.Point(65, 149);
            this.grillaCheques.Name = "grillaCheques";
            this.grillaCheques.ReadOnly = true;
            this.grillaCheques.Size = new System.Drawing.Size(240, 150);
            this.grillaCheques.TabIndex = 55;
            this.grillaCheques.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaCheques_CellDoubleClick);
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(154, 123);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaVencimiento.TabIndex = 6;
            this.dtpFechaVencimiento.Value = new System.DateTime(2012, 8, 2, 0, 0, 0, 0);
            // 
            // cboChequeBanco
            // 
            this.cboChequeBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChequeBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChequeBanco.FormattingEnabled = true;
            this.cboChequeBanco.Location = new System.Drawing.Point(154, 53);
            this.cboChequeBanco.Name = "cboChequeBanco";
            this.cboChequeBanco.Size = new System.Drawing.Size(162, 24);
            this.cboChequeBanco.TabIndex = 3;
            this.cboChequeBanco.Leave += new System.EventHandler(this.cboChequeBanco_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(59, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 14);
            this.label8.TabIndex = 52;
            this.label8.Text = "Fecha de Venc.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 14);
            this.label9.TabIndex = 50;
            this.label9.Text = "Banco";
            // 
            // txtChequeNumero
            // 
            this.txtChequeNumero.Location = new System.Drawing.Point(154, 87);
            this.txtChequeNumero.Name = "txtChequeNumero";
            this.txtChequeNumero.Size = new System.Drawing.Size(162, 23);
            this.txtChequeNumero.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 49;
            this.label10.Text = "Numero";
            // 
            // txtChequeAbona
            // 
            this.txtChequeAbona.Location = new System.Drawing.Point(154, 18);
            this.txtChequeAbona.Name = "txtChequeAbona";
            this.txtChequeAbona.Size = new System.Drawing.Size(100, 23);
            this.txtChequeAbona.TabIndex = 0;
            this.txtChequeAbona.Leave += new System.EventHandler(this.txtChequeAbona_Leave);
            this.txtChequeAbona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivoAbona_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(59, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 47;
            this.label11.Text = "Abona";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.txtCtaCteMontoTotal);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.txtCtaCteACuenta);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(402, 326);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "A Cta. Cte.";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtCtaCteMontoTotal
            // 
            this.txtCtaCteMontoTotal.Location = new System.Drawing.Point(170, 65);
            this.txtCtaCteMontoTotal.Name = "txtCtaCteMontoTotal";
            this.txtCtaCteMontoTotal.Size = new System.Drawing.Size(162, 23);
            this.txtCtaCteMontoTotal.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(81, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 14);
            this.label14.TabIndex = 49;
            this.label14.Text = "Monto Total";
            // 
            // txtCtaCteACuenta
            // 
            this.txtCtaCteACuenta.Location = new System.Drawing.Point(170, 29);
            this.txtCtaCteACuenta.Name = "txtCtaCteACuenta";
            this.txtCtaCteACuenta.Size = new System.Drawing.Size(162, 23);
            this.txtCtaCteACuenta.TabIndex = 0;
            this.txtCtaCteACuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivoAbona_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(81, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 14);
            this.label15.TabIndex = 47;
            this.label15.Text = "A Cuenta";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(307, 436);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 50);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(508, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 56;
            this.label12.Text = "Cheque: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(501, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 16);
            this.label13.TabIndex = 55;
            this.label13.Text = "Efectivo: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Green;
            this.label16.Location = new System.Drawing.Point(508, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 54;
            this.label16.Text = "Tarjeta: ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label17.Location = new System.Drawing.Point(481, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 18);
            this.label17.TabIndex = 53;
            this.label17.Text = "Resumen de pago";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(491, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 16);
            this.label18.TabIndex = 57;
            this.label18.Text = "A Cta. Cte: ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(528, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 19);
            this.label19.TabIndex = 58;
            this.label19.Text = "Total: ";
            // 
            // lblSubTotalEfectivo
            // 
            this.lblSubTotalEfectivo.AutoSize = true;
            this.lblSubTotalEfectivo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalEfectivo.Location = new System.Drawing.Point(611, 130);
            this.lblSubTotalEfectivo.Name = "lblSubTotalEfectivo";
            this.lblSubTotalEfectivo.Size = new System.Drawing.Size(54, 16);
            this.lblSubTotalEfectivo.TabIndex = 59;
            this.lblSubTotalEfectivo.Text = "label20";
            // 
            // lblSubTotalTarjeta
            // 
            this.lblSubTotalTarjeta.AutoSize = true;
            this.lblSubTotalTarjeta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalTarjeta.Location = new System.Drawing.Point(610, 153);
            this.lblSubTotalTarjeta.Name = "lblSubTotalTarjeta";
            this.lblSubTotalTarjeta.Size = new System.Drawing.Size(54, 16);
            this.lblSubTotalTarjeta.TabIndex = 60;
            this.lblSubTotalTarjeta.Text = "label21";
            // 
            // lblSubTotalCheque
            // 
            this.lblSubTotalCheque.AutoSize = true;
            this.lblSubTotalCheque.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSubTotalCheque.Location = new System.Drawing.Point(610, 178);
            this.lblSubTotalCheque.Name = "lblSubTotalCheque";
            this.lblSubTotalCheque.Size = new System.Drawing.Size(54, 16);
            this.lblSubTotalCheque.TabIndex = 61;
            this.lblSubTotalCheque.Text = "label22";
            // 
            // lblSubtotalCtaCte
            // 
            this.lblSubtotalCtaCte.AutoSize = true;
            this.lblSubtotalCtaCte.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalCtaCte.Location = new System.Drawing.Point(610, 202);
            this.lblSubtotalCtaCte.Name = "lblSubtotalCtaCte";
            this.lblSubtotalCtaCte.Size = new System.Drawing.Size(54, 16);
            this.lblSubtotalCtaCte.TabIndex = 62;
            this.lblSubtotalCtaCte.Text = "label23";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(610, 241);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 19);
            this.lblTotal.TabIndex = 63;
            this.lblTotal.Text = "label24";
            // 
            // btnVolver
            // 
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(196, 436);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(70, 51);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelto.Location = new System.Drawing.Point(610, 268);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(69, 19);
            this.lblVuelto.TabIndex = 66;
            this.lblVuelto.Text = "label24";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(518, 267);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 19);
            this.label21.TabIndex = 65;
            this.label21.Text = "Vuelto: ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(489, 218);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(224, 16);
            this.label22.TabIndex = 67;
            this.label22.Text = "___________________________";
            // 
            // frmSubVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 493);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblSubtotalCtaCte);
            this.Controls.Add(this.lblSubTotalCheque);
            this.Controls.Add(this.lblSubTotalTarjeta);
            this.Controls.Add(this.lblSubTotalEfectivo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmSubVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ventas";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTarjetas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCheques)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtEfectivoAbona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEfectivoVuelto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTarjetaNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTarjetaAbona;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTarjeta;
        private System.Windows.Forms.TextBox txtTarjetaCuotas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCtaCteMontoTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCtaCteACuenta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSubTotalEfectivo;
        private System.Windows.Forms.Label lblSubTotalTarjeta;
        private System.Windows.Forms.Label lblSubTotalCheque;
        private System.Windows.Forms.Label lblSubtotalCtaCte;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView grillaTarjetas;
        private System.Windows.Forms.Button btnAltaTarjeta;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnAgregarCheque;
        private System.Windows.Forms.Button btnAltaCheque;
        private System.Windows.Forms.DataGridView grillaCheques;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.ComboBox cboChequeBanco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChequeNumero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChequeAbona;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnQuitarTarjeta;
        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.Button btnQuitarCheque;
        private System.Windows.Forms.ComboBox cboTarjetaTipo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
    }
}