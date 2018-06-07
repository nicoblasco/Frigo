namespace ProyectoStandard
{
    partial class frmReportes
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
            this.components = new System.ComponentModel.Container();
            this.reportArticulosGeneral = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ArticulosReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticulosReporteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportArticulosGeneral
            // 
            this.reportArticulosGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportArticulosGeneral.LocalReport.ReportEmbeddedResource = "ProyectoStandard.Reportes.ReporteArticulosGeneral.rdlc";
            this.reportArticulosGeneral.Location = new System.Drawing.Point(0, 0);
            this.reportArticulosGeneral.Margin = new System.Windows.Forms.Padding(1);
            this.reportArticulosGeneral.Name = "reportArticulosGeneral";
            this.reportArticulosGeneral.Size = new System.Drawing.Size(874, 630);
            this.reportArticulosGeneral.TabIndex = 0;
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(Model.Articulos);
            // 
            // ArticulosReporteBindingSource
            // 
            this.ArticulosReporteBindingSource.DataSource = typeof(Model.ArticulosReporte);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 630);
            this.Controls.Add(this.reportArticulosGeneral);
            this.MaximizeBox = false;
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArticulosReporteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportArticulosGeneral;
        private System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.BindingSource ArticulosReporteBindingSource;
    }
}