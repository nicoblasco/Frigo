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

namespace ProyectoStandard
{
    public partial class frmDevoluciones : Form
    {
        CombosStandard objCombosStandard;       
        Devoluciones objDevoluciones;
        Articulos objArticulos;
        ArticulosPorDevolucion objArticulosporDevolucion;
        ManejaConfiguraciones objManejaConfiguracion;
        Configuraciones objConfiguracion;
        ManejaCierreDeCaja objManejaCierreCaja;
        Int32 idCierreCaja = 0;

        List<ArticulosPorDevolucion> objListArticulosPorDevolucionBorrados = new List<ArticulosPorDevolucion>();

        public frmDevoluciones()
        {
            InitializeComponent();

            HabilitaDesabilitaCampos(false);
            objDevoluciones = new Devoluciones();
            objDevoluciones.ListArticulosPorDevolucion = new List<ArticulosPorDevolucion>();
            objDevoluciones.ObjCliente = new Clientes();
            objDevoluciones.ObjEmpleado = new Empleados();

            CargoCombosStandard();
            CargoCombosHabilitados(true);
            CargoConfiguracion();
            btnQuitar.Enabled = false;
            //btnImprimir.Enabled = false;
            txtCantidad.Text = "1";
            cboEstado.Text = "PENDIENTE";
            cboEstado.Enabled = false;
            dtpFechaIngreso.Value = DateTime.Now;
            //  boOtraPantalla = false;
            cboListaDePrecio.Text = "LISTA 1";
        }

        public frmDevoluciones( Devoluciones objDevoluciones)
        {
            InitializeComponent();
            this.objDevoluciones = objDevoluciones;
            CargoCombosStandard();
            CargoCombosHabilitados(false);
            CargoConfiguracion();
            //listTelefonos = objEmpleados.ListTelefonos;
            AsignoCamposConObjetos();
            if (frmLogin.isAdmin)
                btnGuardar.Enabled = true;
            else
                btnGuardar.Enabled = false;
            // boOtraPantalla = true;
            this.Text = "Devolucion: " + lblLegajo.Text;

            if (objDevoluciones.StrEstado != "PENDIENTE")
                HabilitaDesabilitaCamposTodos(false);

        }

        private void HabilitaDesabilitaCamposTodos(Boolean booRes)
        {
            txtDescripcion.Enabled = booRes;
            dtpFechaIngreso.Enabled = booRes;
            cboVendedor.Enabled = booRes;
            btnBuscarVendedor.Enabled = booRes;
            cboCliente.Enabled = booRes;
            btnBuscarCliente.Enabled = booRes;
            txtObservaciones.Enabled = booRes;
            txtCodigo.Enabled = booRes;
            cboBuscarCodigo.Enabled = booRes;
            txtDescripcion.Enabled = booRes;
            txtCantidad.Enabled = booRes;
            btnLimpiarArticulo.Enabled = booRes;
            cboAgregar.Enabled = booRes;
            btnQuitar.Enabled = booRes;
            txtNetoEF.Enabled = booRes;
            txtTotalEF.Enabled = booRes;
            txtNetoTARJ.Enabled = booRes;
            txtTotalTarj.Enabled = booRes;
            txtSubtotal.Enabled = booRes;
            cboListaDePrecio.Enabled = booRes;

        }

        private void CargoCombosStandard()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarEmpleadosConSuUsuario(cboVendedor, frmLogin.Usuarioid);
            objCombosStandard.CargarClientesConPredeterminado(cboCliente);
            objCombosStandard.CargarPaises(cboPais);
            objCombosStandard.CargarProvincias(cboProvincia, cboPais.SelectedValue);
            objCombosStandard.CargarLocalidades(cboLocalidad, cboProvincia.SelectedValue);


            cboPais.Text = "";
            cboPais.SelectedIndex = -1;
            cboProvincia.Text = "";
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.Text = "";
            cboLocalidad.SelectedIndex = -1;



        }

        private void CargoConfiguracion()
        {
            //Cargo Configuraciones
            objManejaConfiguracion = new ManejaConfiguraciones();
            objConfiguracion = objManejaConfiguracion.BuscarConfiguracion(Environment.MachineName);
        }

        private void CargoCombosHabilitados(bool boRes)
        {
            objCombosStandard = new CombosStandard();
            if (boRes)
            {
                //objCombosStandard.CargarEmpleadosConPredeterminado(cboVendedor);
                objCombosStandard.CargarEmpleadosConSuUsuario(cboVendedor, frmLogin.Usuarioid);
                objCombosStandard.CargarClientesConPredeterminado(cboCliente);
            }
            else
            {
                objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objDevoluciones.ObjEmpleado.IntCodigo));
                objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objDevoluciones.ObjCliente.IntCodigo));
            }


        }

        private void HabilitaDesabilitaCampos(Boolean booRes)
        {
            cboLocalidad.Enabled = booRes;
            cboPais.Enabled = booRes;
            cboProvincia.Enabled = booRes;
            txtDepto.Enabled = booRes;
            txtDireccion.Enabled = booRes;
            txtNro.Enabled = booRes;
            txtPiso.Enabled = booRes;
            txtDescripcion.Enabled = booRes;
        }

        private void cboVendedor_Leave(object sender, EventArgs e)
        {
            //Esto significa si hizo click en el boton de buscar
            if (!(btnBuscarVendedor.Focused))
            {
                if (!string.IsNullOrEmpty(cboVendedor.Text))
                {
                    int variable = 0;
                    variable = cboVendedor.FindStringExact(cboVendedor.Text);
                    if (variable == -1)//El empleado no esta dentro de la lista, debo obligarlo a cargar
                    {
                        string message = "¿Desea Cargar datos del Vendedor?";
                        string caption = "Vendedor Inexistente";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {

                            frmEmpleados objFrmEmpleados = new frmEmpleados(cboVendedor.Text);
                            objFrmEmpleados.ShowDialog();

                            objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objDevoluciones.ObjEmpleado.IntCodigo));
                            cboVendedor.SelectedValue = objFrmEmpleados.intCodigoEmpleados;

                        }
                        else
                        {
                            cboVendedor.Text = "";
                        }
                    }
                }
            }
        }

        private void cboCliente_Leave(object sender, EventArgs e)
        {
            //Esto significa si hizo click en el boton de buscar
            if (!(btnBuscarCliente.Focused))
            {
                if (!string.IsNullOrEmpty(cboCliente.Text))
                {
                    int variable = 0;
                    variable = cboCliente.FindStringExact(cboCliente.Text);
                    if (variable == -1)//El empleado no esta dentro de la lista, debo obligarlo a cargar
                    {
                        string message = "¿Desea Cargar datos del Cliente?";
                        string caption = "Cliente Inexistente";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            ManejaClientes objManejaClientes = new ManejaClientes();
                            frmClientes objFrmClientes = new frmClientes(cboCliente.Text);
                            objFrmClientes.ShowDialog();
                            if (objFrmClientes.intCodigoCliente > 0)
                            {
                                objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objDevoluciones.ObjCliente.IntCodigo));
                                cboCliente.SelectedValue = objFrmClientes.intCodigoCliente;
                                LlenoCamposDelCliente(objManejaClientes.BuscarCliente(Convert.ToInt32(cboCliente.SelectedValue)));
                            }

                        }
                        else
                        {
                            cboCliente.Text = "";
                            LimpioCamposDelCliente();
                        }
                    }
                }
                else
                {
                    LimpioCamposDelCliente();
                }
            }
        }

        private void LimpioCamposDelCliente()
        {

            txtDepto.Text = "";
            txtDireccion.Text = "";
            txtNro.Text = "";
            txtPiso.Text = "";
            cboPais.Text = "";
            cboPais.SelectedIndex = -1;
            cboProvincia.Text = "";
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.Text = "";
            cboLocalidad.SelectedIndex = -1;
        }

        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboVendedor.SelectedValue) > 0)
            {
                ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
                Empleados objEmpleados = new Empleados();
                objEmpleados = objManejaEmpleados.BuscarEmpleados(Convert.ToInt32(cboVendedor.SelectedValue));
                frmEmpleados objFrmEmpleados = new frmEmpleados(objEmpleados);
                objFrmEmpleados.ShowDialog();
                if (objFrmEmpleados.intCodigoEmpleados != 0)
                {
                    objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objDevoluciones.ObjEmpleado.IntCodigo));
                    cboVendedor.SelectedValue = objFrmEmpleados.intCodigoEmpleados;
                }

            }
            else
            {
                frmEmpleadosBusqueda objFrmEmpleadosBusqueda = new frmEmpleadosBusqueda(true, cboVendedor.Text);
                objFrmEmpleadosBusqueda.ShowDialog();
                if (objFrmEmpleadosBusqueda.intCodigo != 0)
                {
                    objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objDevoluciones.ObjEmpleado.IntCodigo));
                    cboVendedor.SelectedValue = objFrmEmpleadosBusqueda.intCodigo;
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ManejaClientes objManejaClientes = new ManejaClientes();
            Clientes objClientes = new Clientes();

            if (Convert.ToInt32(cboCliente.SelectedValue) != 0)
            {
                objClientes = objManejaClientes.BuscarCliente(Convert.ToInt32(cboCliente.SelectedValue));
                frmClientes objFrmClientes = new frmClientes(objClientes);
                objFrmClientes.ShowDialog();
                if (objFrmClientes.intCodigoCliente != 0)
                {
                    objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objDevoluciones.ObjCliente.IntCodigo));
                    cboCliente.SelectedValue = objFrmClientes.intCodigoCliente;
                    LlenoCamposDelCliente(objClientes);
                }

            }
            else
            {
                frmClienteBusqueda objFrmClientesBusqueda = new frmClienteBusqueda(true, cboCliente.Text);
                objFrmClientesBusqueda.ShowDialog();
                objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objDevoluciones.ObjCliente.IntCodigo));
                cboCliente.SelectedValue = objFrmClientesBusqueda.intCodigo;
                LlenoCamposDelCliente(objClientes);

                if (objFrmClientesBusqueda.intCodigo != 0)
                {
                    objClientes = objManejaClientes.BuscarCliente(objFrmClientesBusqueda.intCodigo);
                    LlenoCamposDelCliente(objClientes);
                }



                //Busco todos los datos del cliente, esto esta mal, deberia hacerlo de otra manera...

            }
            LlenoCamposDelCliente(objClientes);
        }

        private void LlenoCamposDelCliente(Clientes objClientes)
        {
            HabilitaDesabilitaCampos(true);

            cboLocalidad.SelectedValue = objClientes.IntLocalidad;
            cboPais.SelectedValue = objClientes.IntPais;
            cboProvincia.SelectedValue = objClientes.IntProvincia;
            txtDepto.Text = objClientes.StrDepto;
            txtDireccion.Text = objClientes.StrDirecccion;
            txtNro.Text = objClientes.StrNro;
            txtPiso.Text = objClientes.StrPiso;

            HabilitaDesabilitaCampos(false);
        }

        private void cboCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCliente.SelectedValue) > 0)
            {
                ManejaClientes objManejaClientes = new ManejaClientes();
                Clientes objClientes = new Clientes();
                objClientes = objManejaClientes.BuscarCliente(Convert.ToInt32(cboCliente.SelectedValue));
                LlenoCamposDelCliente(objClientes);
            }
        }

        private void cboBuscarCodigo_Click(object sender, EventArgs e)
        {
            //Si el textbox del codigo esta vacio tengo que abrir la pantalla de busqueda de lo contrario tengo que buscarlo y completar la descripcion
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                frmArticulosBusqueda objfrmArticulosBusqueda = new frmArticulosBusqueda(true);
                objfrmArticulosBusqueda.ShowDialog();
                if (objfrmArticulosBusqueda.boImagenMode)
                {
                    frmArticulosBusquedaPorImagen objFrmArticulosBusquedaPorImagen = new frmArticulosBusquedaPorImagen(true);
                    objFrmArticulosBusquedaPorImagen.ShowDialog();
                    if (!string.IsNullOrEmpty(objFrmArticulosBusquedaPorImagen.strCodigo))
                        BuscaElCodigoExtraDelArticulo(objFrmArticulosBusquedaPorImagen.strCodigo);
                }
                else
                {
                    if (!string.IsNullOrEmpty(objfrmArticulosBusqueda.strCodigo))
                        BuscaElCodigoExtraDelArticulo(objfrmArticulosBusqueda.strCodigo);
                }
            }
            else
            {
                BuscaElCodigoExtraDelArticulo(txtCodigo.Text);
            }
        }

        private void BuscaElCodigoExtraDelArticulo(string strCodigo)
        {
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            objArticulos = new Articulos();
            objArticulos = objManejaArticulos.BuscarArticulosPorCodigoExtra(strCodigo, true);
            txtCodigo.Text = strCodigo;
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = objArticulos.StrDescripcion;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = true;
            txtPrecio.Text = Convert.ToString(Redondeo(TomaPrecioDeLista(objArticulos)));
            txtCantidad.Text = "1";
            txtPrecio.Enabled = false;
        }

        private void btnLimpiarArticulo_Click(object sender, EventArgs e)
        {
            LimpiarArticulos();
        }

        private void LimpiarArticulos()
        {
            txtCodigo.Text = "";
            txtDescripcion.Enabled = true;
            txtDescripcion.Text = "";
            txtDescripcion.Enabled = false;
            txtCantidad.Text = "1";
            txtPrecio.Text = "";
        }

        private void cboAgregar_Click(object sender, EventArgs e)
        {
            //Debo guardar lo que esta en la grilla


            //Lo primero que debo hacer es guardar el objeto articulo en la lista
            if (objArticulos != null)
            {
                objArticulosporDevolucion = new ArticulosPorDevolucion();
                objArticulosporDevolucion.ObjArticulo = objArticulos;
                if (string.IsNullOrEmpty(txtCantidad.Text))
                    objArticulosporDevolucion.IntCantidad = 0;
                else
                    objArticulosporDevolucion.IntCantidad = Convert.ToInt32(txtCantidad.Text);

                objArticulosporDevolucion.DoPrecioUnitarioConEfectivo = TomaPrecioDeLista(objArticulos);
                objArticulosporDevolucion.DoTotalConEfectivo = (TomaPrecioDeLista(objArticulos) * objArticulosporDevolucion.IntCantidad);
                //this.ListArticulos.Add(objArticulosporVenta);
                this.objDevoluciones.ListArticulosPorDevolucion.Add(objArticulosporDevolucion);
                CargoGrilla();
                LimpiarArticulos();
                objArticulos = null;
                CalculoPrecioNetoEnEfectivo();


            }
        }

        private void CalculoPrecioNetoEnEfectivo()
        {
            //Tengo que recorrer la grilla por las columna de cantidad y precio unitario

            decimal celdaef = 0;
            decimal celdatarj = 0;

            //Recorremos el DataGridView con un bucle for
            for (Int32 i = 0; i < grillaArticulos.Rows.Count; i++)
            {
                if (Convert.ToInt32(grillaArticulos.Rows[i].Cells[3].Value) == 0)
                {
                    celdaef += Convert.ToInt32(grillaArticulos.Rows[i].Cells[2].Value) * (Convert.ToDecimal(grillaArticulos.Rows[i].Cells[5].Value));
                    celdatarj += +Convert.ToInt32(grillaArticulos.Rows[i].Cells[2].Value) * Convert.ToDecimal(grillaArticulos.Rows[i].Cells[6].Value);
                }
                else
                {
                    celdaef += Convert.ToInt32(grillaArticulos.Rows[i].Cells[2].Value) * (Convert.ToDecimal(grillaArticulos.Rows[i].Cells[5].Value)) - ((Convert.ToInt32(grillaArticulos.Rows[i].Cells[2].Value) * (Convert.ToDecimal(grillaArticulos.Rows[i].Cells[5].Value))) * Convert.ToInt32(grillaArticulos.Rows[i].Cells[3].Value) / 100);
                    celdatarj += Convert.ToInt32(grillaArticulos.Rows[i].Cells[2].Value) * (Convert.ToDecimal(grillaArticulos.Rows[i].Cells[6].Value)) - ((Convert.ToInt32(grillaArticulos.Rows[i].Cells[2].Value) * (Convert.ToDecimal(grillaArticulos.Rows[i].Cells[6].Value))) * Convert.ToInt32(grillaArticulos.Rows[i].Cells[3].Value) / 100);
                }
            }
            txtNetoEF.Text = Convert.ToString(Redondeo(celdaef));
            CalculoPrecioTotalEnEfectivo();
            //Lo pongo en el total a pagar
            //txtPago.Text = txtTotalEF.Text;
        }


        private void CalculoPrecioTotalEnEfectivo()
        {

                txtTotalEF.Text = txtNetoEF.Text;
        }

        private void CargoGrilla()
        {
            int i = 0;
            grillaArticulos.DataSource = null;
            grillaArticulos.Rows.Clear();
            CargoTituloGrilla();
            if (this.objDevoluciones.ListArticulosPorDevolucion.Count != 0)
            {

                foreach (ArticulosPorDevolucion element in objDevoluciones.ListArticulosPorDevolucion)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    grillaArticulos.Rows.Add();
                    grillaArticulos[0, i].Value = element.ObjArticulo.StrCodigo;
                    grillaArticulos[1, i].Value = element.ObjArticulo.StrDescripcion;
                    grillaArticulos[2, i].Value = element.IntCantidad;
                    grillaArticulos[3, i].Value = 0;
                    grillaArticulos[4, i].Value = element.ObjArticulo.StrUbicacion;
                    grillaArticulos[5, i].Value = Redondeo(element.DoPrecioUnitarioConEfectivo);
                    grillaArticulos[6, i].Value = 0;
                    grillaArticulos[7, i].Value = Redondeo(element.DoTotalConEfectivo);
                    grillaArticulos[8, i].Value = 0;
                    //if (element.IntEstado == 3)
                    //  grillaArticulos.Rows[i].Visible = false;
                    i++;
                    //}


                }


            }
        }

        private void CargoTituloGrilla()
        {
            //            if (list.Count != 0)
            if (this.objDevoluciones.ListArticulosPorDevolucion != null)
            {
                grillaArticulos.DataSource = null;
                grillaArticulos.Rows.Clear();
                grillaArticulos.Columns.Clear();
                grillaArticulos.Columns.Add("Codigo", null);
                grillaArticulos.Columns.Add("Descripcion", null);
                grillaArticulos.Columns.Add("Cantidad", null);
                grillaArticulos.Columns.Add("Descuento", null);
                grillaArticulos.Columns.Add("Ubicación", null);
                grillaArticulos.Columns.Add("Prec.Unit", null);
                grillaArticulos.Columns.Add("PU TARJ", null);
                grillaArticulos.Columns.Add("Total", null);
                grillaArticulos.Columns.Add("TOTAL TARJ", null);
                //                grillaArticulos.Columns["PU TARJ"].Width = 0;
                //                grillaArticulos.Columns["TOTAL TARJ"].Width = 0;
                //this.grillaArticulos.Columns[6].Visible = false;
                //this.grillaArticulos.Columns[8].Visible = false;
                this.grillaArticulos.Columns[6].Visible = false;
                this.grillaArticulos.Columns[8].Visible = false;
                this.grillaArticulos.Columns[3].Visible = false;
                this.grillaArticulos.Columns[4].Visible = false;
                this.grillaArticulos.Columns[0].Width = 120;
                this.grillaArticulos.Columns[1].Width = 300;
                this.grillaArticulos.Columns[2].Width = 80;
                this.grillaArticulos.Columns[3].Width = 90;
            }
        }

        private void grillaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objDevoluciones.StrEstado == "PENDIENTE" || string.IsNullOrEmpty(objDevoluciones.StrEstado))
            {
                btnQuitar.Enabled = true;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            //Antes de removerlo, deberia marcarlo para luego borrarlo y descontar el stock o pasarlo a una nueva lista
            //Siempre y cuando el producto/articulo esta grabado en la base, osea que tenga facturadetalleid
            //Entonces me dijo si tiene id
            if (this.objDevoluciones.ListArticulosPorDevolucion.ElementAt(grillaArticulos.CurrentRow.Index).IntCodigo > 0)
                objListArticulosPorDevolucionBorrados.Add(this.objDevoluciones.ListArticulosPorDevolucion.ElementAt(grillaArticulos.CurrentRow.Index));

            //Luego lo borro de la lista y al momento de grabar lo borro de todos lados
            this.objDevoluciones.ListArticulosPorDevolucion.RemoveAt(grillaArticulos.CurrentRow.Index);
            grillaArticulos.Rows.RemoveAt(grillaArticulos.CurrentRow.Index);

            btnQuitar.Enabled = false;
            CalculoPrecioNetoEnEfectivo();
        }

        private void AsignoDatosAlObjetoVenta()
        {
            objDevoluciones.DtFecha = dtpFechaIngreso.Value;
            objDevoluciones.ObjEmpleado.IntCodigo = Convert.ToInt32(cboVendedor.SelectedValue);
            objDevoluciones.ObjEmpleado.StrNombre = cboVendedor.Text;
            objDevoluciones.ObjCliente.IntCodigo = Convert.ToInt32(cboCliente.SelectedValue);
            objDevoluciones.ObjCliente.StrNombre = cboCliente.Text;
            objDevoluciones.StrObservaciones = txtObservaciones.Text;
            //objDevoluciones.ListArticulosPorDevolucion; ya esta asignado

            objDevoluciones.DoTotal = Convert.ToDecimal(txtTotalEF.Text) ;
            objDevoluciones.StrEstado = cboEstado.Text;
            objDevoluciones.StrListaPrecio = cboListaDePrecio.Text;
            objDevoluciones.IntNumeroCaja = idCierreCaja;// objConfiguracion.IntNumeroCaja;

        }
        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }


        private void AsignoCamposConObjetos()
        {
            ManejaClientes objManejaClientes = new ManejaClientes();
            Clientes objClientes = new Clientes();

            lblLegajo.Text = Convert.ToString(objDevoluciones.IntCodigo);
            cboVendedor.SelectedValue = objDevoluciones.ObjEmpleado.IntCodigo;
            cboCliente.SelectedValue = objDevoluciones.ObjCliente.IntCodigo;
            //Cargo Datos del cliente                     
            objClientes = objManejaClientes.BuscarCliente(objDevoluciones.ObjCliente.IntCodigo);
            LlenoCamposDelCliente(objClientes);
            //
            txtObservaciones.Text = objDevoluciones.StrObservaciones;

            cboEstado.Text = objDevoluciones.StrEstado;
            dtpFechaIngreso.Value = objDevoluciones.DtFecha;
            cboListaDePrecio.Text = objDevoluciones.StrListaPrecio;
            txtNetoEF.Text = Convert.ToString(Redondeo( objDevoluciones.DoTotal));
            txtTotalEF.Text = txtNetoEF.Text;
            //Tengo que cargar la grilla
            CargoGrilla();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if (!ListoParaGrabar())
                return;

            //Guarda los datos parcialmente, pero la venta sigue como pendientes

            AsignoDatosAlObjetoVenta();

            //voy a la otra pantalla por si hizo algo y me traigo los datos

            //frmSubVenta objFrmSubVenta = new frmSubVenta(objDevoluciones);


            //Me fijo si es una modificacion o un alta

            if (objDevoluciones.IntCodigo > 0)
                Modifico();
            else
            {
                objDevoluciones.StrEstado = "CUMPLIDA";
                cboEstado.Text = objDevoluciones.StrEstado;
                Grabo();

            }

        }

        public void Grabo(Devoluciones objDevoluciones)
        {
            this.objDevoluciones = objDevoluciones;
            Grabo();

        }

        public void Modifico(Devoluciones objDevoluciones)
        {
            this.objDevoluciones = objDevoluciones;
            //vuelvo a reasignar la fecha 
            dtpFechaIngreso.Value = objDevoluciones.DtFecha;
            Modifico();
        }

        private void Grabo()
        {
            //Tengo que setear una fecha porque todavia no esta cargada
            //objDevoluciones.ObjSubVentaCheque.DtFechaVencimiento = DateTime.Now;
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();

            string message;
            string caption = "Mensaje";
            message = "¿Desea Grabar la Devolución?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Verifico si el cliente o el empleado estan dados de baja cuando cumplo la orden

                if (objDevoluciones.StrEstado == "CUMPLIDA")
                {
                    if (String.IsNullOrEmpty(cboCliente.Text))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("Debe completar el cliente para continuar");
                        return;
                    }

                    if (String.IsNullOrEmpty(cboVendedor.Text))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("Debe completar el vendedor para continuar");
                        return;
                    }


                    ManejaClientes objManejaClientes = new ManejaClientes();
                    if (objManejaClientes.ClienteDadoDeBaja(objDevoluciones.ObjCliente.IntCodigo))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El cliente se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                    ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
                    if (objManejaEmpleados.EmpleadoDadoDeBaja(objDevoluciones.ObjEmpleado.IntCodigo))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El vendedor se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                }

                ManejaArticulos objManejaArticulos = new ManejaArticulos();

                //Antes de Grabar la venta debo verificar si el el articulo esta dado de baja y si posee Stock
                foreach (var c in objDevoluciones.ListArticulosPorDevolucion)
                {
                    //int sumaStockArt = 0;
                    if (objManejaArticulos.ArticuloDadoDeBaja(c.ObjArticulo.IntCodigo))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El articulo " + c.ObjArticulo.StrCodigo + " - " + c.ObjArticulo.StrDescripcion + " se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                    //Obtengo el stock Actual
                    //int stockActual = objManejaArticulos.CantidadDeStock(c.ObjArticulo.IntCodigo);
                    ////Ahora sumo todos los articulos que hay en la compra
                    //foreach (var art in objDevoluciones.ListArticulosPorDevolucion)
                    //{
                    //    if (art.ObjArticulo.IntCodigo == c.ObjArticulo.IntCodigo)
                    //        //Sumo la cantidad de articulos
                    //        sumaStockArt = sumaStockArt + art.IntCantidad;
                    //}
                    //if (stockActual < sumaStockArt) //Si el stock actual es menor a lo que estoy vendiendo, aviso
                    //{
                    //    objDevoluciones.StrEstado = "PENDIENTE";
                    //    cboEstado.Text = "PENDIENTE";
                    //    MessageBox.Show("El articulo " + c.ObjArticulo.StrCodigo + " - " + c.ObjArticulo.StrDescripcion + " se encuentra sin Stock suficiente, posee " + stockActual + " y esta vendiendo " + sumaStockArt + ", debe borrarlo o modificar el stock para continuar");
                    //    return;
                    //}

                }
                CalculoPrecioNetoEnEfectivo();

                ManejaDevoluciones objManejaDevoluciones = new ManejaDevoluciones();
                
                objDevoluciones.IntCodigo = objManejaDevoluciones.GrabarDevolucion(objDevoluciones);

                lblLegajo.Text = Convert.ToString(objDevoluciones.IntCodigo);
                this.Text = "Devolución: " + lblLegajo.Text;

                foreach (var c in objDevoluciones.ListArticulosPorDevolucion)
                {

                    c.IntCodigo = objManejaDevoluciones.GrabarVentaDetalle(c, objDevoluciones.IntCodigo);
                    ActualizoStock(c, cboEstado.Text);

                }


                MessageBox.Show("La Devolución ha sido guardada");
                //btnImprimir.Enabled = true;

                //Fix
                //if (objDevoluciones.StrEstado == "CUMPLIDA")
                //{
                //    //Imprimo siempre y cuando este parametrizado que tiene impresora
                //    if (objManejaDiccionario.BuscarValor("IMPRESORA") == "SI")
                //        Imprimir();//btnImprimir_Click(null, null);
                //}

                //CalculoPrecioNetoEnEfectivo();

            }
            else
            {
                if (objDevoluciones.StrEstado == "CUMPLIDA")
                {
                    objDevoluciones.StrEstado = "PENDIENTE";
                    cboEstado.Text = "PENDIENTE";
                }
            }

            if (objDevoluciones.StrEstado == "PENDIENTE")
                HabilitaDesabilitaCamposTodos(true);
            else
                HabilitaDesabilitaCamposTodos(false);

        }

        private void Modifico()
        {
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();
            bool boCancelaVenta = false;

            //Tengo que setear una fecha porque todavia no esta cargada
            //objDevoluciones.ObjSubVentaCheque.DtFechaVencimiento = DateTime.Now;
           // int intStockActual;
            string message;
            string caption = "Mensaje";
            message = "¿Desea Grabar la Devolución?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                ManejaDevoluciones objManejaDevoluciones = new ManejaDevoluciones();
                //Si estoy cancelando una orden, una vez actualizado el estado debo devolver el stock

                if ((cboEstado.Text == "CANCELADA") && (objManejaDevoluciones.BuscoEstado(objDevoluciones.IntCodigo) != "CANCELADA"))
                {
                    boCancelaVenta = true;
                }


                //Verifico si el cliente o el empleado estan dados de baja cuando cumplo la orden
                if (cboEstado.Text == "PENDIENTE")
                {
                    objDevoluciones.StrEstado = "CUMPLIDA";
                    cboEstado.Text = "CUMPLIDA";

                }
                if (objDevoluciones.StrEstado == "CUMPLIDA")
                {
                    ManejaClientes objManejaClientes = new ManejaClientes();
                    if (objManejaClientes.ClienteDadoDeBaja(objDevoluciones.ObjCliente.IntCodigo))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El cliente se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                    ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
                    if (objManejaEmpleados.EmpleadoDadoDeBaja(objDevoluciones.ObjEmpleado.IntCodigo))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El vendedor se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                }


                ManejaArticulos objManejaArticulos = new ManejaArticulos();
                foreach (var c in objDevoluciones.ListArticulosPorDevolucion)
                {
                    if (objManejaArticulos.ArticuloDadoDeBaja(c.ObjArticulo.IntCodigo))
                    {
                        objDevoluciones.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El articulo " + c.ObjArticulo.StrCodigo + " - " + c.ObjArticulo.StrDescripcion + " se encuentra borrarlo, debe eliminarlo para continuar");
                        return;
                    }

                }



                objManejaDevoluciones.ModificaDevolucion(objDevoluciones);

                this.Text = "Devolución: " + lblLegajo.Text;

                foreach (var c in objDevoluciones.ListArticulosPorDevolucion)
                {
                    if (c.IntCodigo > 0)
                    {
                        //Como se si es algo que no se modifico????
                        //Quizas deberia comparar con la cantidad con la que tiene guardada en esa factura detalle
                      //  intStockActual = objManejaDevoluciones.BuscoStock(c.IntCodigo);
                        objManejaDevoluciones.ModificaVentaDetalle(c, objDevoluciones.IntCodigo);
                        //ActualizoStock(c.ObjArticulo.IntCodigo, c.IntCantidad, "CANCELADA");
                        //if (intStockActual != c.IntCantidad)
                        //{
                        //    if (c.IntCantidad > intStockActual) //Saco
                        //        ActualizoStock(c.ObjArticulo.IntCodigo, c.IntCantidad - intStockActual, "CUMPLIDA"); //Le pongo el estado CUMPLIDA para que saque stock
                        //    else //Agrego
                        //        ActualizoStock(c.ObjArticulo.IntCodigo, intStockActual - c.IntCantidad, "CANCELADA"); //Le pongo el estado CUMPLIDA para que agregue stock
                        //}
                    }
                    else
                    {
                        c.IntCodigo = objManejaDevoluciones.GrabarVentaDetalle(c, objDevoluciones.IntCodigo);
                        ActualizoStock(c, cboEstado.Text);

                    }


                }

                //Estos son los articulos dados de baja
                foreach (var d in objListArticulosPorDevolucionBorrados)
                {
                    //Borro los detalles de la base y luego devuelvo el stock

                    ActualizoStock(d.ObjArticulo.IntCodigo, d.IntCantidad, "CANCELADA"); //Le pongo el estado CUMPLIDA para que agregue
                    objManejaDevoluciones.EliminaDevolucionesDetalle(d.IntCodigo);

                }

                //Esto es para una orden dada de baja
                if (boCancelaVenta)
                {
                    foreach (var artbaja in objDevoluciones.ListArticulosPorDevolucion)
                    {
                        ActualizoStock(artbaja.ObjArticulo.IntCodigo, artbaja.IntCantidad, "CANCELADA");
                    }
                }







                MessageBox.Show("La Devolución ha sido guardada");

                //Verifico si el nuevo estado es PENDIENTE, en ese caso habilito todos los campos de lo contrario los griso

                if (objDevoluciones.StrEstado == "PENDIENTE")
                    HabilitaDesabilitaCamposTodos(true);
                else
                    HabilitaDesabilitaCamposTodos(false);


                //Fix
                //if (objDevoluciones.StrEstado == "CUMPLIDA")
                //{
                //    //Imprimo siempre y cuando este parametrizado que tiene impresora
                //    if (objManejaDiccionario.BuscarValor("IMPRESORA") == "SI")
                //        Imprimir();//btnImprimir_Click(null, null);
                //}

                CalculoPrecioNetoEnEfectivo();

            }
            else
            {
                if (objDevoluciones.StrEstado == "CUMPLIDA")
                {
                    objDevoluciones.StrEstado = "PENDIENTE";
                    cboEstado.Text = "PENDIENTE";
                }
            }

        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                //Busco el codigo

                ManejaArticulos objManejaArticulos = new ManejaArticulos();
                Articulos objArticulos = new Articulos();

                objArticulos = objManejaArticulos.BuscarArticulosPorCodigoExtra(txtCodigo.Text, true);

                txtCantidad.Text = "1";

                if (objArticulos.IntCodigo == 0)//El Articulo no esta, debo obligarlo a cargar
                {
                    string message = "¿Desea Cargar el articulo?";
                    string caption = "Articulo Inexistente";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        objArticulos.StrCodigo = txtCodigo.Text;
                        objArticulos.DtFechaAlta = DateTime.Now;
                        frmArticulos objFrmArticulos = new frmArticulos(objArticulos);
                        objFrmArticulos.ShowDialog();
                        objArticulos = null;
                        cboBuscarCodigo_Click(null, null);


                    }
                    else
                    {
                        txtCodigo.Text = "";
                        txtCantidad.Text = "";
                    }
                }
            }
        }

        private void frmDevoluciones_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboVendedor.Text))
            {

                //Verifico si tiene que hacer foco en la factura
                if (!string.IsNullOrEmpty(cboCliente.Text))
                {
                    cboCliente_SelectionChangeCommitted(null, null);
                    this.groupBox2.TabIndex = 0;
                    this.groupBox2.Focus();
                    this.txtCodigo.TabIndex = 0;

                }
                else
                {
                    cboCliente.TabIndex = 0;
                    cboCliente.Focus();

                }
            }
            else
                cboVendedor.Focus();

            string strPermiso = frmLogin.getPermiso("VENTAS", "VENTA_DEVOLUCION");

            //Antes de hacer alguna operacion me fijo si tiene abierta la caja
            objManejaCierreCaja = new ManejaCierreDeCaja();
            if (objManejaCierreCaja.ValidaCajaAbierta(objConfiguracion.IntNumeroCaja))
            {
                //Si la caja esta abierta recupero el id de cierre de caja
                idCierreCaja = objManejaCierreCaja.getCierreCajaId(objConfiguracion.IntNumeroCaja);
            }

            else
            {
                MessageBox.Show("La caja se encuentra cerrada, para operar debe abrirla.");
                strPermiso = "LECTURA";
            }



            if (strPermiso == "LECTURA")
            {
                //btnAceptar.Enabled = false;
                btnGuardar.Enabled = false;
                //btnImprimir.Enabled = false;
            }
            if (strPermiso == "LECTURA/ESCRITURA")
            {
                //btnAceptar.Enabled = false;
                btnGuardar.Enabled = true;
                //btnImprimir.Enabled = false;
            }

        }

        private void ActualizoStock(ArticulosPorDevolucion objArticulosPorDevolucion, string strEstadoVenta)
        {
            //Si el estado de la orden es pendiente o cumplida entonces aumento el stock
            //Si el estado es cancelado incremento el stock
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            objManejaArticulos.ModificaStockDevolucion(objArticulosPorDevolucion.ObjArticulo.IntCodigo, objArticulosPorDevolucion.IntCantidad, strEstadoVenta);


        }

        private void ActualizoStock(int intCodigo, int intCantidad, string strEstadoVenta)
        {
            //Si el estado de la orden es pendiente o cumplida entonces descuento el stock
            //Si el estado es cancelado incremento el stock
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            objManejaArticulos.ModificaStockDevolucion(intCodigo, intCantidad, strEstadoVenta);


        }

        private bool ListoParaGrabar()
        {            

            //No Dejar grabar sin ningun articulo
            if (objDevoluciones.ListArticulosPorDevolucion.Count == 0)
            {
                MessageBox.Show("Debe cargar algun articulo para grabar o continuar");
                return false;
            }                        

            return true;
        }

        private void cboEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            if (objDevoluciones.StrEstado == "PENDIENTE" && cboEstado.Text == "CUMPLIDA")
                cboEstado.Text = "PENDIENTE";
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
                txtCantidad.Text = "0";

            if (!string.IsNullOrEmpty(txtPrecio.Text) && Convert.ToInt32(txtCantidad.Text) > 0)
                txtPrecio.Text = Convert.ToString(Convert.ToDecimal(txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text));
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                cboBuscarCodigo_Click(null, null);
                if (objArticulos.IntCodigo > 0)
                    cboAgregar_Click(null, null);
                else
                    txtCodigo_Leave(null, null);
            }
        }

        private decimal TomaPrecioDeLista(Articulos objArticulos)
        {
            switch (cboListaDePrecio.Text)
            {
                case "LISTA 1":
                    return objArticulos.DoPrecioEfectivo;

                case "LISTA 2":
                    if (objArticulos.DoPrecioLista2 == 0)
                        return objArticulos.DoPrecioEfectivo;
                    else
                        return objArticulos.DoPrecioLista2;

                case "LISTA 3":
                    if (objArticulos.DoPrecioLista3 == 0)
                        return objArticulos.DoPrecioEfectivo;
                    else
                        return objArticulos.DoPrecioLista3;
                default:
                    return 0;


            }
        }
    }
}
