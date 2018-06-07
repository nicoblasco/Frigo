using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ProyectoStandard
{
    public partial class frmReportes : Form
    {
        string rptact;
        object lst;
        string nombreClase;

        public frmReportes(string nombrereporte, object lista, string nombreClase)
        {
            InitializeComponent();
            rptact = Application.StartupPath + "\\Reportes\\" + nombrereporte;
            //rptact = "C:\\Documents and Settings\\nblasco\\Mis documentos\\sistemas\\Seguros\\ProyectoStandard\\ProyectoStandard\\Reportes\\" + nombrereporte;
            lst = lista;
            this.nombreClase = nombreClase;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            this.reportArticulosGeneral.ProcessingMode = ProcessingMode.Local;           
            this.reportArticulosGeneral.LocalReport.ReportPath = rptact;

            ReportDataSource datos = new ReportDataSource();
            datos.Name = nombreClase; //Nombre de la clase
            datos.Value = this.lst;

            this.reportArticulosGeneral.LocalReport.DataSources.Clear();
            this.reportArticulosGeneral.LocalReport.DataSources.Add(datos);

            this.reportArticulosGeneral.RefreshReport();

        }
    }
}
