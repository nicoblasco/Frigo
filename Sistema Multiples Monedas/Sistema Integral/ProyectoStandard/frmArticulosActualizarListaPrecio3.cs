using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Model;
using DAO;

namespace ProyectoStandard
{
    public partial class frmArticulosActualizarListaPrecio3 : Form
    {
        public frmArticulosActualizarListaPrecio3()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            object strCol1 = null; ;
            object strCol2 = null; ;

            //abrimos el dialogo para poder obtener el nombre la ubicacion del archivo
            ofdAbrirArchivo.Filter = "Excel files|*.xlsx;*.xls";
            ofdAbrirArchivo.ShowDialog();
            string sArchivo = ofdAbrirArchivo.FileName;

            if (String.IsNullOrEmpty(sArchivo))
                return;

            //declaramos las variables que necesitamos para poder abrir un archivo excel
            _Application exlApp;
            Workbook exlWbook;
            Worksheet exlWsheet;

            exlApp = new ApplicationClass();

            //Asignamos el libro que sera abierot
            exlWbook = exlApp.Workbooks.Open(sArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            exlWsheet = (Worksheet)exlWbook.Worksheets.get_Item(1);
            Range exlRange;

            //Definimos el el rango de celdas que seran leidas
            exlRange = exlWsheet.UsedRange;

            //Seteo la grilla
            CargoTituloGrilla();
            gridArticulos.DataSource = null;
            gridArticulos.Rows.Clear();
            strCol1 = "";
            strCol2 = "";
            try
            {

                //Recorremos el archivo excel como si fuera una matriz
                for (int i = 1; i <= exlRange.Rows.Count; i++)
                {


                    for (int j = 1; j <= 2; j++)
                    {
                        if (j == 1)
                            strCol1 = (exlRange.Cells[i, j] as Range).Value2;
                        else
                            //Debo verificar el formato del importe

                            strCol2 = (exlRange.Cells[i, j] as Range).Value2;
                    }
                    if (strCol1 != null && strCol2 != null)
                    {
                        if (objManejaArticulos.ExisteArticulo(strCol1.ToString()))
                            gridArticulos.Rows.Add(Convert.ToString(strCol1), Convert.ToDecimal(strCol2));
                        else
                        {
                            MessageBox.Show("Codigo Inexistente: " + strCol1 + ", revise el Excel");
                            gridArticulos.Rows.Clear();
                            exlApp.Quit();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Formato incorrecto en el registro con codigo: " + strCol1 + ", revise el Excel");
                gridArticulos.Rows.Clear();
                exlApp.Quit();
                return;
            }




            //cerramos el libro y la aplicacion

            exlApp.Quit();
        }

        private void CargoTituloGrilla()
        {
            gridArticulos.DataSource = null;
            gridArticulos.Rows.Clear();
            gridArticulos.Columns.Clear();
            gridArticulos.Columns.Add("CODIGO", null);
            gridArticulos.Columns.Add("PRECIO", null);//Este es el id extra

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Precaución";

            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            message = "¿Esta seguro de que desea actualizar el precio?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                if (!VerificoCamposAntesDeGrabar())
                {
                    MessageBox.Show("Debe cargar un Excel con datos completos");
                    return;
                }
                //Recorro la grilla y actualizo


                objManejaArticulos = new ManejaArticulos();
                try
                {
                    foreach (DataGridViewRow row in gridArticulos.Rows)
                    {


                        objManejaArticulos.ModificaPrecioL3Masivo (Convert.ToString(row.Cells[0].Value), Convert.ToDecimal(row.Cells[1].Value));

                    }
                    gridArticulos.Rows.Clear();
                    objManejaArticulos = null;
                    MessageBox.Show("La Actualización ha sido correcta");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Formato incorrecto, revise el Excel");
                }

            }
        }

        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el cuil y la razon social

            if (gridArticulos.Rows.Count == 0)
                return false;
            else
                return true;

        }

        private void frmArticulosActualizarPrecio_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("ARTICULOS", "ARTICULOS_ACTUALIZACIONES");

            if (strPermiso == "LECTURA")
            {
                btnImportar.Enabled = false;
                btnProcesar.Enabled = false;
            }
        }
    }
}
