using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Model;
using DAO;
using Microsoft.Office.Interop.Excel;


namespace ProyectoStandard
{
    public partial class frmArticulosMasivo : Form
    {
        public frmArticulosMasivo()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            int intTienePacientesRepetidos = 0;
            int intElementoRepetidoEnGrilla = 0;
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            object strCol1 = null;
            object strCol2 = null;
            object strCol3 = null;
            object strCol4 = null;
            object strCol5 = null;
            object strCol6 = null;
            object strCol7 = null;
            object strCol8 = null;
            object strCol9 = null;
            object strCol10 = null;
            object strCol11 = null;
            object strCol12 = null;
            object strCol13 = null;
            string strMessageValidacion = null;


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


            try
            {
                string[] array = new string[exlRange.Rows.Count];
                //Recorremos el archivo excel como si fuera una matriz
                for (int i = 2; i <= exlRange.Rows.Count; i++)
                {

                    strMessageValidacion = "";
                    strCol1 = "";
                    strCol2 = "";
                    strCol3 = "";
                    strCol4 = "";
                    strCol5 = "";
                    strCol6 = "";
                    strCol7 = "";
                    strCol8 = "";
                    strCol9 = "";
                    strCol10 = "";
                    strCol11 = "";
                    strCol12 = "";
                    strCol13 = "";


                    strCol1 = (exlRange.Cells[i, 1] as Range).Value2;
                    //Verifico que el codigo este repetido                                      
                    //Recorro el array y me fijo si ese elemento ya existe
                    //Si no existe lo agrego, sino salgo e informo
                    if (strCol1 != null)
                    {
                        intElementoRepetidoEnGrilla = 0;
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (array[j] == strCol1.ToString())
                            {
                                //MessageBox.Show("El elemento de la fila: " + i + " esta repetido");
                                //gridArticulos.Rows.Clear();
                                //exlApp.Quit();
                                //return;
                                intElementoRepetidoEnGrilla = 1;
                            }
                        }

                        if (intElementoRepetidoEnGrilla == 0)
                        {
                            //lo Asigno
                            array[i - 1] = strCol1.ToString();
                            strCol2 = (exlRange.Cells[i, 2] as Range).Value2;
                            strCol3 = (exlRange.Cells[i, 3] as Range).Value2;
                            strCol4 = (exlRange.Cells[i, 4] as Range).Value2;
                            strCol5 = (exlRange.Cells[i, 5] as Range).Value2;
                            strCol6 = (exlRange.Cells[i, 6] as Range).Value2;
                            strCol7 = (exlRange.Cells[i, 7] as Range).Value2;
                            strCol8 = (exlRange.Cells[i, 8] as Range).Value2;
                            strCol9 = (exlRange.Cells[i, 9] as Range).Value2;
                            strCol10 = (exlRange.Cells[i, 10] as Range).Value2;
                            strCol11 = (exlRange.Cells[i, 11] as Range).Value2;
                            strCol12 = (exlRange.Cells[i, 12] as Range).Value2;
                            strCol13 = (exlRange.Cells[i, 13] as Range).Value2;


                            if (strCol1 != null && strCol2 != null && strCol4 != null && strCol5 != null && strCol6 != null)
                            {
                                //Valida Codigo Existente

                                if (String.IsNullOrEmpty(Convert.ToString(strCol13)))
                                    strCol13 = "1"; //Pongo por defecto ARS para la moneda

                                strMessageValidacion = ValidaRegistros(Convert.ToString(strCol1), Convert.ToString(strCol4), Convert.ToString(strCol13));
                                if (String.IsNullOrEmpty(strMessageValidacion))
                                    gridArticulos.Rows.Add(Convert.ToString(strCol1), Convert.ToString(strCol2), Convert.ToString(strCol3), Convert.ToString(strCol4), Convert.ToString(strCol5), Convert.ToString(strCol6), Convert.ToString(strCol7), Convert.ToString(strCol8), Convert.ToString(strCol9), Convert.ToString(strCol10), Convert.ToString(strCol11), Convert.ToString(strCol12), Convert.ToString(strCol13));
                                else
                                {
                                    //MessageBox.Show(strMessageValidacion + i);
                                    //gridArticulos.Rows.Clear();
                                    //exlApp.Quit();
                                    //return;
                                    intTienePacientesRepetidos = intTienePacientesRepetidos + 1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("La fila: " + i + " contiene datos obligatorios imcompletos, revise el Excel");
                            }
                        }
                    }
                    //}
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

            if (intTienePacientesRepetidos > 0)
            {
                MessageBox.Show("El Excel tiene articulos repetidos. Los mismos no fueron agregados a la grilla.");
            }

            MessageBox.Show("Presione Procesar para continuar");
        }

        private string ValidaRegistros(string strCol1, string strCol4, string strCol12)
        {
            ManejaArticulos objManejaArticulos = new ManejaArticulos();

            //Valida si existe el articulo, si ya existe devuelve falso
            if (objManejaArticulos.ExisteArticulo(strCol1))
                return "El Articulo: " + strCol1.ToUpper() + " ya se encuentra ingresado. No se agregara a la grilla, Fila: ";
            //Valida si el proveedor Existe

            if (!objManejaArticulos.ExisteProveedor(strCol4))
                return "Proveedor No Existe en la fila: ";

            //Valida si existe la Moneda

            if (!objManejaArticulos.ExisteMoneda(strCol12))
                return "Moneda No Existe en la fila: ";

            return null;


        }

        private void CargoTituloGrilla()
        {
            gridArticulos.DataSource = null;
            gridArticulos.Rows.Clear();
            gridArticulos.Columns.Clear();
            gridArticulos.Columns.Add("CODIGO", null);//Este es el id extra
            gridArticulos.Columns.Add("DESCRIPCION", null);
            gridArticulos.Columns.Add("DESCRIPCION CORTA", null);
            gridArticulos.Columns.Add("ID PROVEEDOR", null);
            gridArticulos.Columns.Add("RUBRO", null);
            gridArticulos.Columns.Add("MARCA", null);
            gridArticulos.Columns.Add("UBICACION", null);
            gridArticulos.Columns.Add("STOCK", null);
            gridArticulos.Columns.Add("STOCK MIN", null);
            gridArticulos.Columns.Add("COSTO", null);
            gridArticulos.Columns.Add("% GAN", null);
            gridArticulos.Columns.Add("PRECIO", null);
            gridArticulos.Columns.Add("ID MONEDA", null);
        }

        private void frmArticulosMasivo_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("ARTICULOS", "ARTICULOS_ACTUALIZACIONES");

            if (strPermiso == "LECTURA")
            {
                btnImportar.Enabled = false;
                btnProcesar.Enabled = false;
                btnTemplate.Enabled = false;
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



        private void btnTemplate_Click(object sender, EventArgs e)
        {
            string strDestino = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strDestino = folderBrowserDialog1.SelectedPath;
                if (string.IsNullOrEmpty(strDestino))
                    return;
                else
                {
                    if (strDestino.Substring(strDestino.Length - 1, 1) != "\\")
                        strDestino = strDestino + "\\";
                }
            }
            else
            {
                return;
            }

            //Bajo el template para que pueda completarlo

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is no esta intalado!!");
                return;
            }



            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "Código";
            xlWorkSheet.Cells[1, 2] = "Descripción";
            xlWorkSheet.Cells[1, 3] = "Descripción Corta";
            xlWorkSheet.Cells[1, 4] = "ID Proveedor";
            xlWorkSheet.Cells[1, 5] = "Rubro";
            xlWorkSheet.Cells[1, 6] = "Marca";
            xlWorkSheet.Cells[1, 7] = "Ubicación";
            xlWorkSheet.Cells[1, 8] = "Stock";
            xlWorkSheet.Cells[1, 9] = "Stock Min";
            xlWorkSheet.Cells[1, 10] = "Costo";
            xlWorkSheet.Cells[1, 11] = "% Gan";
            xlWorkSheet.Cells[1, 12] = "Precio";
            xlWorkSheet.Cells[1, 13] = "ID Moneda";


            xlWorkSheet.get_Range("A1", "F1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            xlWorkSheet.get_Range("C1", "C1").Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            xlWorkBook.SaveAs(strDestino + "ArchivosMasivo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //xlWorkBook.SaveAs("C:\\ArchivosMasivo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("El template Excel fue creado , puedes buscarlo en " + strDestino + "ArchivosMasivo.xls");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }


        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Precaución";

            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();
            message = "¿Esta seguro de que desea correr el proceso?";

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
                        Articulos objArticulos = new Articulos();
                        objArticulos.StrCodigo = Convert.ToString(row.Cells[0].Value).Trim();
                        objArticulos.StrDescripcion = Convert.ToString(row.Cells[1].Value).Trim().ToUpper();
                        objArticulos.StrDescrCorta = Convert.ToString(row.Cells[2].Value).Trim().ToUpper();
                        objArticulos.IntProveedor = Convert.ToInt32(row.Cells[3].Value);
                        objArticulos.StrRubro = Convert.ToString(row.Cells[4].Value).Trim().ToUpper();
                        objArticulos.StrMarca = Convert.ToString(row.Cells[5].Value).Trim().ToUpper();
                        objArticulos.StrUbicacion = Convert.ToString(row.Cells[6].Value).Trim();

                        if (String.IsNullOrEmpty(Convert.ToString(row.Cells[12].Value)))
                            objArticulos.IntMoneda = 1; //Por defecto pongo moneda ARS
                        else
                            objArticulos.IntMoneda = Convert.ToInt32(row.Cells[12].Value);

                        if (String.IsNullOrEmpty(Convert.ToString(row.Cells[7].Value)))
                            objArticulos.Intstock = 0;
                        else
                            objArticulos.Intstock = Convert.ToInt32(row.Cells[7].Value);

                        if (String.IsNullOrEmpty(Convert.ToString(row.Cells[8].Value)))
                            objArticulos.Intstockminimo = 0;
                        else
                            objArticulos.Intstockminimo = Convert.ToInt32(row.Cells[8].Value);


                        if (String.IsNullOrEmpty(Convert.ToString(row.Cells[9].Value)))
                            objArticulos.DoCosto = 0;
                        else
                            objArticulos.DoCosto = Convert.ToDecimal(row.Cells[9].Value);

                        if (String.IsNullOrEmpty(Convert.ToString(row.Cells[10].Value)))
                            objArticulos.DoGanancia = 0;
                        else
                            objArticulos.DoGanancia = Convert.ToDecimal(row.Cells[10].Value);

                        if (String.IsNullOrEmpty(Convert.ToString(row.Cells[11].Value)))
                            objArticulos.DoPrecioEfectivo = 0;
                        else
                            objArticulos.DoPrecioEfectivo = Convert.ToDecimal(row.Cells[11].Value);

                        objArticulos.DtFechaAlta = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                        int intcodigo = objManejaArticulos.GrabarArticulos(objArticulos);

                        //Me fijo si existe el Rubro
                        if (!objManejaDiccionario.ExisteDiccionario("PRODUCTOS/SERVICIOS", objArticulos.StrRubro))
                        {
                            //Si no existe lo creo                 
                            Diccionario objDiccionario = new Diccionario();
                            objDiccionario.StrParametro = "PRODUCTOS/SERVICIOS";
                            objDiccionario.StrValor1 = objArticulos.StrRubro;
                            objManejaDiccionario.GrabarDiccionario(objDiccionario);
                        }

                        //Me fijo si existe la Marca
                        if (!objManejaDiccionario.ExisteDiccionario("MARCA", objArticulos.StrMarca))
                        {
                            //Si no existe la creo                 
                            Diccionario objDiccionario = new Diccionario();
                            objDiccionario.StrParametro = "MARCA";
                            objDiccionario.StrValor1 = objArticulos.StrMarca;
                            objManejaDiccionario.GrabarDiccionario(objDiccionario);
                        }

                    }
                    gridArticulos.Rows.Clear();
                    objManejaArticulos = null;
                    MessageBox.Show("La creación masiva ha sido correcta");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Formato incorrecto, revise el Excel");
                    gridArticulos.Rows.Clear();
                    return;
                }

            }
        }


    }
}
