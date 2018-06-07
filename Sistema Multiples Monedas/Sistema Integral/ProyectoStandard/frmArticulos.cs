using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using DAO;
using System.Globalization;

namespace ProyectoStandard
{
    public partial class frmArticulos : Form
    {
        CombosStandard objCombosStandard;
        ManejaArticulos objManejaArticulos;
        Articulos objArticulos;
        public int intCodigoArticulo;
        string strPermiso;

        public frmArticulos()
        {
            InitializeComponent();
            //CargoComboProveedoresHabilitados(true);
            objArticulos = new Articulos();
            //Desabilito el boton de eliminar
            CargoCombos();
            btnEliminar.Enabled = false;
            dtpFechaAlta.Value = DateTime.Now;
            txtCodigo.Focus();

            //Cargo la imagen
            pbImagen.ImageLocation = Application.StartupPath + "\\Resources\\" + "SIN IMAGEN.jpg";

        }

        public frmArticulos(Articulos objArticulos)
        {
            InitializeComponent();
            //CargoComboProveedoresHabilitados(false);
            this.objArticulos = objArticulos;
            CargoCombos();
            AsignoCamposConObjetos();
            if (strPermiso != "LECTURA")
            {
                btnEliminar.Enabled = true;
            }
            this.Text = "Articulo: " + txtDescripcion.Text;

            //Si esta dado de baja bloqueo todo

            if (!string.IsNullOrEmpty(objArticulos.DtFechaBaja))
                HabilitoDesabilitoCampos(false);

        }

        private void HabilitoDesabilitoCampos(bool boRes)
        {
            if (strPermiso != "LECTURA" && boRes == true)
            {
                groupBox1.Enabled = boRes;
                btnAceptar.Enabled = boRes;
                btnEliminar.Enabled = boRes;
                btnExaminar.Enabled = boRes;
            }
        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarDiccionario(cboRubro, "RUBRO");
            objCombosStandard.CargarDiccionario(cboMarca, "SUBRUBRO");
            objCombosStandard.CargarProveedores(cboProveedor, Convert.ToString(objArticulos.IntProveedor));
            objCombosStandard.CargarMonedas(cboMoneda);
        }

        /*  private void CargoComboProveedoresHabilitados(bool boRes)
          {
              objCombosStandard = new CombosStandard();
              if (boRes)
                  objCombosStandard.CargarProveedoresHabilitados(cboProveedor);
              else
                  objCombosStandard.CargarProveedores(cboProveedor);
          }*/

        private void cboProveedor_Leave(object sender, EventArgs e)
        {

            //Esto significa si hizo click en el boton de buscar
            if (!(btnBuscarProveedor.Focused))
            {
                int variable = 0;
                variable = cboProveedor.FindStringExact(cboProveedor.Text);
                if (variable == -1 && !string.IsNullOrEmpty(cboProveedor.Text))//El proveedor no esta dentro de la lista, debo obligarlo a cargar
                {
                    string message = "¿Desea Cargar datos del Proveedor?";
                    string caption = "Proveedor Inexistente";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmProveedores objFrmProveedor = new frmProveedores(cboProveedor.Text);
                        objFrmProveedor.ShowDialog();

                        objCombosStandard.CargarProveedores(cboProveedor, Convert.ToString(objArticulos.IntProveedor));
                        cboProveedor.SelectedValue = objFrmProveedor.intCodigoProveedor;
                        //Cargo nuevamente el rubro por si lo dio de alta
                        objCombosStandard.CargarDiccionario(cboRubro, "PRODUCTOS/SERVICIOS");

                    }
                    else
                    {
                        cboProveedor.Text = "";
                    }
                }
            }
        }


        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            //Pero me tengo que fijar si ese combo estaba cargada, si es que estaba cargado tengo que abrir la pantalla del proveedor

            if (Convert.ToInt32(cboProveedor.SelectedValue) > 0)
            {
                ManejaProveedores objManejaProveedores = new ManejaProveedores();
                Proveedores objProveedores = new Proveedores();
                objProveedores = objManejaProveedores.BuscarProveedores(Convert.ToInt32(cboProveedor.SelectedValue));
                frmProveedores objFrmProveedores = new frmProveedores(objProveedores);
                objFrmProveedores.ShowDialog();
                objCombosStandard.CargarProveedores(cboProveedor, Convert.ToString(objArticulos.IntProveedor));
                //cboProveedor.SelectedValue = objFrmProveedores.intCodigoProveedor;
                cboProveedor.SelectedValue = objProveedores.IntCodigo;

            }
            else
            {
                frmProveedoresBusqueda objFrmProveedoresBusqueda = new frmProveedoresBusqueda(true, cboProveedor.Text);
                objFrmProveedoresBusqueda.ShowDialog();
                objCombosStandard.CargarProveedores(cboProveedor, Convert.ToString(objArticulos.IntProveedor));
                cboProveedor.SelectedValue = objFrmProveedoresBusqueda.intCodigo;
            }
        }


        private void cboRubro_Leave(object sender, EventArgs e)
        {
            if (!(btnBuscarRubro.Focused))
            {
                int variable = 0;
                variable = cboRubro.FindStringExact(cboRubro.Text);
                if (variable == -1 && !string.IsNullOrEmpty(cboRubro.Text))//El proveedor no esta dentro de la lista, debo obligarlo a cargar
                {
                    string message = "¿Desea Cargar datos del Rubro?";
                    string caption = "Rubro Inexistente";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmDiccionario objFrmDiccionario = new frmDiccionario("RUBRO", cboRubro.Text, false);

                        objFrmDiccionario.ShowDialog();

                        objCombosStandard.CargarDiccionario(cboRubro, "RUBRO");
                        cboRubro.SelectedValue = objFrmDiccionario.intCodigo;

                    }
                    else
                    {
                        cboRubro.Text = "";
                    }
                }
            }
        }





        private void cboMarca_Leave(object sender, EventArgs e)
        {
            if (!(btnBuscarMarca.Focused))
            {
                int variable = 0;
                variable = cboMarca.FindStringExact(cboMarca.Text);
                if (variable == -1 && !string.IsNullOrEmpty(cboMarca.Text))//El proveedor no esta dentro de la lista, debo obligarlo a cargar
                {
                    string message = "¿Desea Cargar datos del SubRubro?";
                    string caption = "SubRubro Inexistente";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmDiccionario objFrmDiccionario = new frmDiccionario("SUBRUBRO", cboMarca.Text, false);

                        objFrmDiccionario.ShowDialog();

                        objCombosStandard.CargarDiccionario(cboMarca, "SUBRUBRO");
                        cboMarca.SelectedValue = objFrmDiccionario.intCodigo;

                    }
                    else
                    {
                        cboMarca.Text = "";
                    }

                }
            }
        }

        private void btnBuscarRubro_Click(object sender, EventArgs e)
        {
            //Pero me tengo que fijar si ese combo estaba cargada, si es que estaba cargado tengo que abrir la pantalla del proveedor            
            frmDiccionario objFrmDiccionario;
            if (Convert.ToInt32(cboRubro.SelectedValue) > 0)

                objFrmDiccionario = new frmDiccionario("RUBRO", Convert.ToInt32(cboRubro.SelectedValue));

            else


                objFrmDiccionario = new frmDiccionario("RUBRO", cboRubro.Text, false);



            //frmDiccionario objFrmDiccionario = new frmDiccionario("PRODUCTOS/SERVICIOS", cboRubro.Text, boExiste);
            objFrmDiccionario.ShowDialog();
            objCombosStandard.CargarDiccionario(cboRubro, "RUBRO");
            cboRubro.SelectedValue = objFrmDiccionario.intCodigo;


        }

        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            //Pero me tengo que fijar si ese combo estaba cargada, si es que estaba cargado tengo que abrir la pantalla del proveedor            
            frmDiccionario objFrmDiccionario;
            if (Convert.ToInt32(cboMarca.SelectedValue) > 0)

                objFrmDiccionario = new frmDiccionario("SUBRUBRO", Convert.ToInt32(cboMarca.SelectedValue));

            else


                objFrmDiccionario = new frmDiccionario("SUBRUBRO", cboMarca.Text, false);



            objFrmDiccionario.ShowDialog();
            objCombosStandard.CargarDiccionario(cboMarca, "SUBRUBRO");
            cboMarca.SelectedValue = objFrmDiccionario.intCodigo;
        }

        private decimal getCotizacion()
        {
            ManejaMonedas objManejaMonedas = new ManejaMonedas();
            Monedas objMoneda = new Monedas();
            decimal deCotizacion = 1;

            objMoneda= objManejaMonedas.BuscarMoneda(Convert.ToInt32( cboMoneda.SelectedValue));
            if (objMoneda != null)
                deCotizacion = objMoneda.DeCotizacion;

            return deCotizacion;


        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            CalculoPrecio();
            //decimal deCotizacion = getCotizacion();
            ////Obtengo la cotizacion de la moneda


            //if (String.IsNullOrEmpty(txtGanancia.Text) || String.IsNullOrEmpty(txtCosto.Text))
            //{
            //    txtPrecioEfectivo.Text = Convert.ToString( Redondeo(Convert.ToDecimal( txtCosto.Text )* deCotizacion));
            //    txtPrecioTarjeta.Text = Convert.ToString( Redondeo(Convert.ToDecimal( txtCosto.Text) * deCotizacion));
            //}
            //else
            //{
            //    Decimal Ganancia = Convert.ToDecimal("1," + txtGanancia.Text.Replace('.', ','));
            //    Decimal Costo = Convert.ToDecimal(txtCosto.Text.Replace('.', ',')) * deCotizacion;
            //    Decimal resultado = Ganancia * Costo  ;
            //    txtPrecioEfectivo.Text = Convert.ToString(Redondeo(resultado));
            //    txtPrecioTarjeta.Text = Convert.ToString(Redondeo(resultado));
            //}
        }

        private void txtGanancia_TextChanged(object sender, EventArgs e)
        {
            CalculoPrecio();
            //decimal deCotizacion = getCotizacion();

            //if (String.IsNullOrEmpty(txtGanancia.Text) || String.IsNullOrEmpty(txtCosto.Text))
            //{
            //    txtPrecioEfectivo.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtCosto.Text) * deCotizacion));
            //    txtPrecioTarjeta.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtCosto.Text) * deCotizacion));
            //}
            //else
            //{
            //    Decimal Ganancia = Convert.ToDecimal(txtGanancia.Text.Replace('.', ','));
            //    Decimal Costo = Convert.ToDecimal(txtCosto.Text.Replace('.', ',')) * deCotizacion;
            //    Decimal resultado = ((Ganancia * Costo) / 100) + Costo;
            //    txtPrecioEfectivo.Text = Convert.ToString(Redondeo(resultado));
            //    txtPrecioTarjeta.Text = Convert.ToString(Redondeo(resultado));
            //}
        }

        private void CalculoPrecio()
        {
            if (String.IsNullOrEmpty(txtCosto.Text))
                return;

            decimal deCotizacion = getCotizacion();

            if (String.IsNullOrEmpty(txtGanancia.Text) || String.IsNullOrEmpty(txtCosto.Text))
            {
                txtPrecioEfectivo.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtCosto.Text) * deCotizacion));
                txtPrecioTarjeta.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtCosto.Text) * deCotizacion));
            }
            else
            {
                Decimal Ganancia = Convert.ToDecimal(txtGanancia.Text.Replace('.', ','));
                Decimal Costo = Convert.ToDecimal(txtCosto.Text.Replace('.', ',')) * deCotizacion;
                Decimal resultado = ((Ganancia * Costo) / 100) + Costo;
                txtPrecioEfectivo.Text = Convert.ToString(Redondeo(resultado));
                txtPrecioTarjeta.Text = Convert.ToString(Redondeo(resultado));
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);

        }




        private void AsignoDatosAlObjeto()
        {

            objArticulos.StrCodigo = txtCodigo.Text.ToUpper().Trim();
            objArticulos.DtFechaAlta = Convert.ToDateTime(dtpFechaAlta.Text);
            objArticulos.StrDescripcion = txtDescripcion.Text.ToUpper().Trim();
            objArticulos.IntProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            objArticulos.StrMarca = cboMarca.Text.ToUpper();
            objArticulos.StrRubro = cboRubro.Text.ToUpper();
            objArticulos.StrUbicacion = txtUbicacion.Text.ToUpper();
            //Imagen
            objArticulos.StrImagen = pbImagen.ImageLocation;
            if (String.IsNullOrEmpty(txtStock.Text))
            {
                txtStock.Text = "0";
            }
            objArticulos.Intstock = Convert.ToInt32(txtStock.Text);
            if (String.IsNullOrEmpty(txtStockMinimo.Text))
            {
                txtStockMinimo.Text = "0";
            }
            objArticulos.Intstockminimo = Convert.ToInt32(txtStockMinimo.Text);

            if (String.IsNullOrEmpty(txtGanancia.Text))
            {
                txtGanancia.Text = "0";
            }
            objArticulos.DoGanancia = Convert.ToDecimal(txtGanancia.Text);
            /*  if (String.IsNullOrEmpty(cboIVA.Text))
              {
                  cboIVA.Text = "0";
              }
              objArticulos.DoIva = Convert.ToDecimal(cboIVA.Text);*/
            if (String.IsNullOrEmpty(txtPrecioEfectivo.Text))
            {
                txtPrecioEfectivo.Text = "0";
            }
            objArticulos.DoPrecioEfectivo = Convert.ToDecimal(txtPrecioEfectivo.Text.Replace('.', ','));
            if (String.IsNullOrEmpty(txtPrecioTarjeta.Text))
            {
                txtPrecioTarjeta.Text = "0";
            }
            objArticulos.DoPrecioTarjeta = Convert.ToDecimal(txtPrecioTarjeta.Text.Replace('.', ','));

            if (String.IsNullOrEmpty(txtPrecioLista2.Text))
            {
                txtPrecioLista2.Text = "0";
            }
            objArticulos.DoPrecioLista2 = Convert.ToDecimal(txtPrecioLista2.Text.Replace('.', ','));
            if (String.IsNullOrEmpty(txtPrecioLista3.Text))
            {
                txtPrecioLista3.Text = "0";
            }
            objArticulos.DoPrecioLista3 = Convert.ToDecimal(txtPrecioLista3.Text.Replace('.', ','));

            objArticulos.StrDescrCorta = txtDescripcionCorta.Text.ToUpper().Trim();
            objArticulos.IntMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

            if (String.IsNullOrEmpty(txtCosto.Text))
            {
                txtCosto.Text = "0";
            }
            objArticulos.DoCosto = Convert.ToDecimal(txtCosto.Text.Replace('.', ','));

            objArticulos.StrUnidadDeVenta = cboUnidadDeVenta.Text;

        }

        private void AsignoCamposConObjetos()
        {
            txtCodigo.Text = objArticulos.StrCodigo;
            dtpFechaAlta.Value = objArticulos.DtFechaAlta;
            txtDescripcion.Text = objArticulos.StrDescripcion;
            txtDescripcionCorta.Text = objArticulos.StrDescrCorta;
            cboProveedor.SelectedValue = objArticulos.IntProveedor;
            cboMarca.Text = objArticulos.StrMarca;
            cboRubro.Text = objArticulos.StrRubro;
            cboMoneda.SelectedValue = objArticulos.IntMoneda;
            txtUbicacion.Text = objArticulos.StrUbicacion;
            txtStock.Text = Convert.ToString(objArticulos.Intstock);
            txtStockMinimo.Text = Convert.ToString(objArticulos.Intstockminimo);
            txtCosto.Text = Convert.ToString(Redondeo(objArticulos.DoCosto));
            txtGanancia.Text = Convert.ToString(Convert.ToInt32(objArticulos.DoGanancia));
            // cboIVA.Text = Convert.ToString (objArticulos.DoIva);
            txtPrecioEfectivo.Text = Convert.ToString(Redondeo(objArticulos.DoPrecioEfectivo));
            txtPrecioLista2.Text = Convert.ToString(Redondeo(objArticulos.DoPrecioLista2));
            txtPrecioLista3.Text = Convert.ToString(Redondeo(objArticulos.DoPrecioLista3));
            //txtPrecioTarjeta.Text = Convert.ToString(Redondeo(objArticulos.DoPrecioTarjeta));
            if (String.IsNullOrEmpty(objArticulos.StrImagen))
                pbImagen.ImageLocation = Application.StartupPath + "\\Resources\\" + "SIN IMAGEN.jpg";//Imagen Por default
            else
                pbImagen.ImageLocation = objArticulos.StrImagen;
            cboUnidadDeVenta.Text = objArticulos.StrUnidadDeVenta;

        }

        private void LimpioCampos()
        {
            txtCodigo.Text = "";
            dtpFechaAlta.Text = Convert.ToString(DateTime.Now);
            cboProveedor.Text = "";
            cboMarca.Text = "";
            cboRubro.Text = "";
            txtDescripcion.Text = "";
            txtUbicacion.Text = "";
            txtCosto.Text = "";
            txtGanancia.Text = "";
            cboIVA.Text = "";
            txtPrecioEfectivo.Text = "";
            txtPrecioTarjeta.Text = "";
            txtStock.Text = "";
            txtStockMinimo.Text = "";
            txtPrecioLista2.Text = "";
            txtPrecioLista3.Text = "";
            txtDescripcionCorta.Text = "";
            cboMoneda.SelectedIndex = 0;
            pbImagen.ImageLocation = Application.StartupPath + "\\Resources\\" + "SIN IMAGEN.jpg";//Imagen Por default
            cboUnidadDeVenta.Text = "Kilo";

            objArticulos = null;
            objArticulos = new Articulos();

            btnEliminar.Enabled = false;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }

            if (objArticulos.IntCodigo != 0)
            {
                Modifico();
                this.Text = "Articulo: " + txtDescripcion.Text;

            }
            else
            {
                Grabo();
                this.Text = "Articulo: " + txtDescripcion.Text;
            }


            LimpioCampos();
        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaArticulos = new ManejaArticulos();
            objArticulos.IntCodigo = objManejaArticulos.GrabarArticulos(objArticulos);
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            objManejaArticulos.ModificaArticulos(objArticulos);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";

            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            message = "Desea Eliminar el Articulo";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino

                objManejaArticulos.EliminaArticulos(objArticulos.IntCodigo);

                MessageBox.Show("El Articulo " + objArticulos.StrDescripcion + " ha sido eliminado correctamente");
                LimpioCampos();

            }
        }


        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el cuil y la razon social

            if ((String.IsNullOrEmpty(txtDescripcion.Text)) || (String.IsNullOrEmpty(cboProveedor.Text)) || (String.IsNullOrEmpty(cboRubro.Text)) || (String.IsNullOrEmpty(cboMarca.Text)) || (String.IsNullOrEmpty(txtPrecioEfectivo.Text)) || (String.IsNullOrEmpty(cboUnidadDeVenta.Text)))
                return false;
            else
                return true;

        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debo verificar si no se esta cambiando a un proveedor que este eliminado
            //cboProveedor.DataSource 
            /*   if (cboProveedor.SelectedIndex != -1)
               {
                   DataTable dt = new DataTable();
                   dt = (DataTable)cboProveedor.DataSource;
                   if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[cboProveedor.SelectedIndex]["fechabaja"].ToString())))
                   {                    
                       MessageBox.Show("No se puede cambiar a Proveedor eliminado");
                   }
               }*/
        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //Busco el codigo
                if (!String.IsNullOrEmpty(txtCodigo.Text))
                {
                    BuscoArticulo();
                }

                //tabulo
                txtDescripcion.Focus();
            }
        }

        private void BuscoArticulo()
        {
            objManejaArticulos = new ManejaArticulos();
            objArticulos = new Articulos();
            objArticulos = objManejaArticulos.BuscarArticulosPorCodigoExtra(txtCodigo.Text, false);

            if (objArticulos.IntCodigo > 0)
            {

                CargoCombos();
                AsignoCamposConObjetos();
                if (strPermiso != "LECTURA")
                {
                    btnEliminar.Enabled = true;
                }
                this.Text = "Articulo: " + txtDescripcion.Text;

                //Si esta dado de baja bloqueo todo

                if (!string.IsNullOrEmpty(objArticulos.DtFechaBaja))
                    HabilitoDesabilitoCampos(false);
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            BuscoArticulo();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog.FileName;
                    pbImagen.Image = Image.FromFile(imagen);
                    pbImagen.ImageLocation = imagen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }
        private void FullScreenImage(Image imageToShow)
        {
            Form fullScreenForm = new Form()
            {
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.None,
                BackgroundImage = imageToShow,
                BackgroundImageLayout = ImageLayout.Zoom
            };

            fullScreenForm.Click += fullScreen_Click;

            fullScreenForm.ShowDialog();
        }

        private void fullScreen_Click(object sender, EventArgs e)
        {
            ((Form)sender).Close();
        }

        private void pbImagen_DoubleClick(object sender, EventArgs e)
        {
            FullScreenImage(((PictureBox)sender).Image);
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            strPermiso = frmLogin.getPermiso("ARTICULOS", "ARTICULOS_ALTA");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cboMoneda.Focused )                
                    CalculoPrecio();
        }

    }
}
