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
    public partial class frmVentas : Form
    {
        const int COL_ID = 0;
        const int COL_DESCRIPCION = 1;
        const int COL_UNIDADES = 2;
        const int COL_KILOS = 3;
        const int COL_PRECIO_UNITARIO = 4;
        const int COL_TOTAL = 5;
        const int COL_LINEA = 6;
        CombosStandard objCombosStandard;
        Ventas objVentas;
        Articulos objArticulos;
        ArticulosPorVenta objArticulosporVenta;
        List<Ventas_Pagos> listPagos;
        ManejaConfiguraciones objManejaConfiguracion;
        Configuraciones objConfiguracion;
        ManejaCierreDeCaja objManejaCierreCaja;
        Int32 idCierreCaja = 0;
        string strEstadoAnterior;

        List<ArticulosPorVenta> objListArticulosPorVentaBorrados = new List<ArticulosPorVenta>();

        // bool boOtraPantalla;

        public frmVentas()
        {
            InitializeComponent();

            HabilitaDesabilitaCampos(false);
            objVentas = new Ventas();

            objVentas.ListArticulosPorVenta = new List<ArticulosPorVenta>();
            objVentas.ListSubVentaTarjeta = new List<SubVentaTarjeta>();
            objVentas.ListSubVentaCheque = new List<SubVentaCheque>();
            objVentas.ListTarjetasBorradas = new List<SubVentaTarjeta>();
            objVentas.ListChequesBorrados = new List<SubVentaCheque>();
            objVentas.ObjCliente = new Clientes();
            objVentas.ObjEmpleado = new Empleados();
            objVentas.ObjSubVentaACtaCte = new SubVentaACtaCte();
            //objVentas.ObjSubVentaCheque = new SubVentaCheque();
            objVentas.ObjSubVentaEfectivo = new SubVentaEfectivo();
            //objVentas.ObjSubVentaTarjeta = new SubVentaTarjeta();
            objVentas.ListPagos = new List<Ventas_Pagos>();

            CargoCombosStandard();
            CargoConfiguracion();
            CargoCombosHabilitados(true);
            btnQuitar.Enabled = false;
            //btnImprimir.Enabled = false;
            txtUnidades.Text = "1";
            cboEstado.Items.Add("INICIAL");
            cboEstado.Items.Add("EN PREPARACION");
            cboEstado.Text = "INICIAL";
            cboEstado.Enabled = false;
            dtpFechaIngreso.Value = DateTime.Now;
            //  boOtraPantalla = false;
            cboListaDePrecio.Text = "LISTA 1";

        }

        public frmVentas(Ventas objVentas)
        {
            InitializeComponent();

            this.objVentas = objVentas;
            listPagos = objVentas.ListPagos;
            CargoCombosStandard();
            CargoEstados(objVentas.StrEstado);
            CargoConfiguracion();
            CargoCombosHabilitados(false);
            //listTelefonos = objEmpleados.ListTelefonos;
            AsignoCamposConObjetos();

            btnPagar.Visible = true;

            if (frmLogin.isAdmin)
            {
                btnGuardar.Enabled = true;
                btnPagar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
                btnPagar.Enabled = false;
            }

            btnImprimir.Enabled = true;
            // boOtraPantalla = true;
            this.Text = "Pedido: " + lblLegajo.Text + "  " + cboUbicacion.Text;



            //if (objVentas.StrEstado != "PENDIENTE")
            //{
            //    HabilitaDesabilitaCamposTodos(false);
            //}

        }


        private void CargoEstados(string strEstado)
        {
            switch (strEstado)
            {
                case "INICIAL":
                    cboEstado.Items.Add("INICIAL");
                    cboEstado.Items.Add("EN PREPARACION");
                    cboEstado.Items.Add("CANCELADO");
                    break; 
                case "EN PREPARACION":
                    cboEstado.Items.Add("INICIAL");
                    cboEstado.Items.Add("EN PREPARACION");
                    cboEstado.Items.Add("PEDIENTE DE ENTREGA");
                    cboEstado.Items.Add("CANCELADO");
                    break;
                case "PEDIENTE DE ENTREGA":
                    cboEstado.Items.Add("EN PREPARACION");
                    cboEstado.Items.Add("PEDIENTE DE ENTREGA");
                    cboEstado.Items.Add("ENTREGADO");
                    cboEstado.Items.Add("CANCELADO");
                    break;
                case "ENTREGADO":
                    cboEstado.Items.Add("PEDIENTE DE ENTREGA");
                    cboEstado.Items.Add("ENTREGADO");
                    cboEstado.Items.Add("CANCELADO");
                    break;
                case "CANCELADO":
                    cboEstado.Items.Add("CANCELADO");
                    break;
                default:
                    break;
            }
        }

        private void HabilitaDesabilitaCamposTodos(Boolean booRes)
        {
            /*     cboLocalidad.Enabled = booRes;
                 cboPais.Enabled = booRes;
                 cboProvincia.Enabled = booRes;
                 txtDepto.Enabled = booRes;
                 txtDireccion.Enabled = booRes;
                 txtNro.Enabled = booRes;
                 txtPiso.Enabled = booRes;*/
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
            txtUnidades.Enabled = booRes;
            btnLimpiarArticulo.Enabled = booRes;
            cboAgregar.Enabled = booRes;
            btnQuitar.Enabled = booRes;
            txtNetoEF.Enabled = booRes;
            txtDescuento.Enabled = booRes;
            txtTotalEF.Enabled = booRes;
            txtIVA21.Enabled = booRes;
            txtIVA10.Enabled = booRes;
            txtNetoTARJ.Enabled = booRes;
            txtTotalTarj.Enabled = booRes;
            txtSubtotal.Enabled = booRes;
            cboUbicacion.Enabled = booRes;
            txtPago.Enabled = booRes;
            txtDebe.Enabled = booRes;
            cboListaDePrecio.Enabled = booRes;

        }

        private void CargoConfiguracion()
        {
            //Cargo Configuraciones
            objManejaConfiguracion = new ManejaConfiguraciones();
            objConfiguracion = objManejaConfiguracion.BuscarConfiguracion(Environment.MachineName);
            if (objConfiguracion != null)
            {
                groupBox1.Text = "Datos Comerciales - CAJA: " + Convert.ToString(objConfiguracion.IntNumeroCaja);
            }
        }

        private void CargoCombosStandard()
        {

            objCombosStandard = new CombosStandard();
            //objCombosStandard.CargarEmpleadosConPredeterminado(cboVendedor);
            objCombosStandard.CargarEmpleadosConSuUsuario(cboVendedor, frmLogin.Usuarioid);
            objCombosStandard.CargarClientesConPredeterminado(cboCliente);
            objCombosStandard.CargarPaises(cboPais);
            objCombosStandard.CargarProvincias(cboProvincia, cboPais.SelectedValue);
            objCombosStandard.CargarLocalidades(cboLocalidad, cboProvincia.SelectedValue);
            objCombosStandard.CargarDiccionario(cboUbicacion, "UBICACION");


            cboPais.Text = "";
            cboPais.SelectedIndex = -1;
            cboProvincia.Text = "";
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.Text = "";
            cboLocalidad.SelectedIndex = -1;

            

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
                objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objVentas.ObjEmpleado.IntCodigo));
                objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objVentas.ObjCliente.IntCodigo));
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

                            objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objVentas.ObjEmpleado.IntCodigo));
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
                                objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objVentas.ObjCliente.IntCodigo));
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
                    objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objVentas.ObjEmpleado.IntCodigo));
                    cboVendedor.SelectedValue = objFrmEmpleados.intCodigoEmpleados;
                }

            }
            else
            {
                frmEmpleadosBusqueda objFrmEmpleadosBusqueda = new frmEmpleadosBusqueda(true, cboVendedor.Text);
                objFrmEmpleadosBusqueda.ShowDialog();
                if (objFrmEmpleadosBusqueda.intCodigo != 0)
                {
                    objCombosStandard.CargarEmpleados(cboVendedor, Convert.ToString(objVentas.ObjEmpleado.IntCodigo));
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
                    objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objVentas.ObjCliente.IntCodigo));
                    cboCliente.SelectedValue = objFrmClientes.intCodigoCliente;
                    LlenoCamposDelCliente(objClientes);
                }

            }
            else
            {
                frmClienteBusqueda objFrmClientesBusqueda = new frmClienteBusqueda(true, cboCliente.Text);
                objFrmClientesBusqueda.ShowDialog();
                objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objVentas.ObjCliente.IntCodigo));
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
            txtUnidades.Text = "1";
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
            txtUnidades.Text = "1";
            txtPrecio.Text = "";
        }

        private void cboAgregar_Click(object sender, EventArgs e)
        {
            //Debo guardar lo que esta en la grilla


            //Lo primero que debo hacer es guardar el objeto articulo en la lista
            if (objArticulos != null)
            {
                objArticulosporVenta = new ArticulosPorVenta();
                objArticulosporVenta.ObjArticulo = objArticulos;
                if (string.IsNullOrEmpty(txtUnidades.Text))
                    objArticulosporVenta.IntUnidades = 0;
                else
                    objArticulosporVenta.IntUnidades = Convert.ToInt32(txtUnidades.Text);                

                // Si el articulo es de venta por unidad, ya calculo el precio
                if (objArticulosporVenta.ObjArticulo.StrUnidadDeVenta == "Unidad")
                    objArticulosporVenta.IntCantidad = objArticulosporVenta.IntUnidades;
                else
                    objArticulosporVenta.IntCantidad = 0;

                objArticulosporVenta.DoPrecioUnitarioConEfectivo = Redondeo(TomaPrecioDeLista(objArticulos));
                objArticulosporVenta.DoTotalConEfectivo = Redondeo((TomaPrecioDeLista(objArticulos) * objArticulosporVenta.IntCantidad));                
                


                this.objVentas.ListArticulosPorVenta.Add(objArticulosporVenta);
                CargoGrilla();
                LimpiarArticulos();
                objArticulos = null;
                if (cboEstado.Text != "INICIAL")
                    CalculoPrecioNetoEnEfectivo();


            }

        }


        private void CalculoPrecioNetoEnEfectivo()
        {
            //Tengo que recorrer la grilla por las columna de cantidad y precio unitario

            decimal celdaef = 0;

            //Recorremos el DataGridView con un bucle for
            for (Int32 i = 0; i < grillaArticulos.Rows.Count; i++)
            {
                    celdaef += Convert.ToInt32(grillaArticulos.Rows[i].Cells[COL_TOTAL].Value);
            }
            txtNetoEF.Text = Convert.ToString(Redondeo(celdaef));
            CalculoPrecioTotalEnEfectivo();
            
            //Lo pongo en el total a pagar
            //txtPago.Text = txtTotalEF.Text;

            //Lo pongo todo en el Debe
            txtDebe.Text = txtTotalEF.Text;
            txtPago.Text = "0";
        }

        private void CalculoPrecioNetoConTarjeta(decimal deTotal)
        {
            txtNetoTARJ.Text = Convert.ToString(Redondeo(deTotal));
            CalculoPrecioTotalConTarjeta();

        }

        private void CalculoPrecioTotalEnEfectivo()
        {
            if (string.IsNullOrEmpty(txtDescuento.Text) || Convert.ToInt32(txtDescuento.Text) < 1)

                txtTotalEF.Text = txtNetoEF.Text;

            else
                txtTotalEF.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtNetoEF.Text) - ((Convert.ToDecimal(txtNetoEF.Text) * Convert.ToInt32(txtDescuento.Text)) / 100)));
        }
        private void CalculoPrecioTotalConTarjeta()
        {
            if (string.IsNullOrEmpty(txtDescuento.Text) || Convert.ToInt32(txtDescuento.Text) < 1)

                txtTotalTarj.Text = txtNetoTARJ.Text;

            else
                txtTotalTarj.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtNetoTARJ.Text) - ((Convert.ToDecimal(txtNetoTARJ.Text) * Convert.ToInt32(txtDescuento.Text)) / 100)));
        }

        private void CargoGrilla()
        {
            int i = 0;
            grillaArticulos.DataSource = null;
            grillaArticulos.Rows.Clear();
            CargoTituloGrilla();
            if (this.objVentas.ListArticulosPorVenta.Count != 0)
            {

                foreach (ArticulosPorVenta element in objVentas.ListArticulosPorVenta)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    grillaArticulos.Rows.Add();
                    grillaArticulos[0, i].Value = element.ObjArticulo.StrCodigo;
                    grillaArticulos[1, i].Value = element.ObjArticulo.StrDescripcion;
                    grillaArticulos[2, i].Value = element.IntUnidades;
                    grillaArticulos[3, i].Value = Redondeo(element.IntCantidad);
                    grillaArticulos[4, i].Value = Redondeo(element.DoPrecioUnitarioConEfectivo);
                    grillaArticulos[5, i].Value = Redondeo(element.DoTotalConEfectivo);
                    grillaArticulos[6, i].Value = i;
                    element.IntLinea = i;    
                    //grillaArticulos[3, i].Value = element.IntDescuento;
                    //grillaArticulos[4, i].Value = element.ObjArticulo.StrUbicacion;
                    //grillaArticulos[5, i].Value = Redondeo(element.DoPrecioUnitarioConEfectivo);
                    //grillaArticulos[6, i].Value = Redondeo(element.DoPrecioUnitarioConTarjeta);
                    //grillaArticulos[7, i].Value = Redondeo(element.DoTotalConEfectivo);
                    //grillaArticulos[8, i].Value = Redondeo(element.DoTotalConTarjeta);
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
            if (this.objVentas.ListArticulosPorVenta != null)
            {
                int j = 0;
                grillaArticulos.DataSource = null;
                grillaArticulos.Rows.Clear();
                grillaArticulos.Columns.Clear();
                grillaArticulos.Columns.Add("Codigo", null);
                grillaArticulos.Columns[j++].ReadOnly = true;
                grillaArticulos.Columns.Add("Descripcion", null);
                grillaArticulos.Columns[j++].ReadOnly = true;
                grillaArticulos.Columns.Add("Unidades", null);
                grillaArticulos.Columns[j++].ReadOnly = true;
                grillaArticulos.Columns.Add("Kilos/Unidad", null);
                grillaArticulos.Columns[j++].ReadOnly = false;
                grillaArticulos.Columns.Add("Precio Unitario", null);
                grillaArticulos.Columns[j++].ReadOnly = true;
                grillaArticulos.Columns.Add("Total", null);
                grillaArticulos.Columns[j++].ReadOnly = true;
                grillaArticulos.Columns.Add("Linea", null);
                grillaArticulos.Columns[j++].ReadOnly = true;

                this.grillaArticulos.Columns[COL_LINEA].Visible = false;

            }
        }


        private void grillaArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objVentas.StrEstado == "PENDIENTE" || string.IsNullOrEmpty(objVentas.StrEstado))
            {
                btnQuitar.Enabled = true;
            }
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {


            //Antes de removerlo, deberia marcarlo para luego borrarlo y descontar el stock o pasarlo a una nueva lista
            //Siempre y cuando el producto/articulo esta grabado en la base, osea que tenga facturadetalleid
            //Entonces me dijo si tiene id
            if (this.objVentas.ListArticulosPorVenta.ElementAt(grillaArticulos.CurrentRow.Index).IntCodigo > 0)
                objListArticulosPorVentaBorrados.Add(this.objVentas.ListArticulosPorVenta.ElementAt(grillaArticulos.CurrentRow.Index));

            //Luego lo borro de la lista y al momento de grabar lo borro de todos lados
            this.objVentas.ListArticulosPorVenta.RemoveAt(grillaArticulos.CurrentRow.Index);
            grillaArticulos.Rows.RemoveAt(grillaArticulos.CurrentRow.Index);

            btnQuitar.Enabled = false;
           // CalculoPrecioNetoEnEfectivo();

        }

        private void grillaArticulos_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            /*
                 //Primero debo guardar los datos de la celda en la lista
                 //recorro todas las columnas de la fila
                 for (int i = 0; i < grillaArticulos.Rows.Count -1; i++)
                 {
                     for (int j = 2; j < grillaArticulos.Columns.Count; j++)
                     {
                         if (j == 2)
                         {
                           this.objVentas.ListArticulosPorVenta.ElementAt(i).IntCantidad= Convert.ToInt32( grillaArticulos.Rows[i].Cells[j].Value.ToString());
                         }
                         if (j == 3)
                         {
                             this.objVentas.ListArticulosPorVenta.ElementAt(i).IntDescuento = Convert.ToInt32(grillaArticulos.Rows[i].Cells[j].Value.ToString());
                         }
                         if (j == 4)
                         {
                             this.objVentas.ListArticulosPorVenta.ElementAt(i).DoPrecioUnitarioConEfectivo = Convert.ToDecimal(grillaArticulos.Rows[i].Cells[j].Value.ToString());
                         }
                         if (j == 5)
                         {
                             this.objVentas.ListArticulosPorVenta.ElementAt(i).DoPrecioUnitarioConTarjeta = Convert.ToDecimal(grillaArticulos.Rows[i].Cells[j].Value.ToString());
                         }

                         if (j == 6)
                         {
                             this.objVentas.ListArticulosPorVenta.ElementAt(i).DoTotalConEfectivo = Convert.ToDecimal(grillaArticulos.Rows[i].Cells[j].Value.ToString());
                         }

                         if (j == 7)
                         {
                             this.objVentas.ListArticulosPorVenta.ElementAt(i).DoTotalConTarjeta = Convert.ToDecimal(grillaArticulos.Rows[i].Cells[j].Value.ToString());
                         }

                     }

                 }*/

            //vuelvo a calcular los importes
        }

        private void grillaArticulos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescuento.Text))
                txtDescuento.Text = "0";

            if (string.IsNullOrEmpty(txtNetoEF.Text))
                txtNetoEF.Text = "0";

            txtTotalEF.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtNetoEF.Text) - (Convert.ToDecimal(txtNetoEF.Text) * Convert.ToInt32(txtDescuento.Text) / 100)));
            // txtTotalTarj.Text = Convert.ToString(Convert.ToDecimal(txtNetoTARJ.Text) - (Convert.ToDecimal(txtNetoTARJ.Text) * Convert.ToInt32(txtDescuento.Text) / 100));
            txtDebe.Text = Convert.ToString(Convert.ToDecimal(txtTotalEF.Text.Replace('.', ',')) - Convert.ToDecimal(txtPago.Text.Replace('.', ',')));
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ListoParaGrabar())
                return;
            /*Puede ser que la venta que esta cargada*/
            //Si es una venta nueva
            //  if (objVentas.IntCodigo != 0)
            CalculoPrecioNetoEnEfectivo();
            AsignoDatosAlObjetoVenta();

            frmSubVenta objFrmSubVenta = new frmSubVenta(objVentas);
            objFrmSubVenta.ShowDialog();

            lblLegajo.Text = Convert.ToString(objVentas.IntCodigo);
            cboEstado.Text = objVentas.StrEstado;

            if (objVentas.IntCodigo > 0)
                btnImprimir.Enabled = true;

            if (objVentas.StrEstado == "PENDIENTE")
                HabilitaDesabilitaCamposTodos(true);
            else
            {
                HabilitaDesabilitaCamposTodos(false);
                cboEstado.Enabled = true;
                this.Text = "Pedido: " + lblLegajo.Text + "  " + cboUbicacion.Text;
            }

        }


        private void AsignoDatosAlObjetoVenta()
        {
            //Se definen 5 estados
            //INICIAL: Estado Inicial, estado de carga de pedido
            //EN PREPARACION: Una vez pesado el pedido, se procede a actualizar el pedido
            //PEDIENTE DE ENTREGA: en este estado se completa la fecha de entrega y se actualiza el pedido si es que hubo algun cambio
            //ENTREGADO: Pedido finalizado
            //CANCELADO: Pedido Cancelado

            //if (cboEstado.Text == "INICIAL")
            //{
                objVentas.StrEstado = cboEstado.Text;
                objVentas.DtFecha = dtpFechaIngreso.Value;
                objVentas.ObjEmpleado.IntCodigo = Convert.ToInt32(cboVendedor.SelectedValue);
                objVentas.ObjEmpleado.StrNombre = cboVendedor.Text;
                objVentas.ObjCliente.IntCodigo = Convert.ToInt32(cboCliente.SelectedValue);
                objVentas.ObjCliente.StrNombre = cboCliente.Text;
                objVentas.StrObservaciones = txtObservaciones.Text;
                objVentas.StrListaPrecio = cboListaDePrecio.Text;
                objVentas.StrMesa = cboUbicacion.Text;
            //}


            objVentas.DoDescuento = Convert.ToInt32(txtDescuento.Text);
            objVentas.DoIva105 = Redondeo(Convert.ToDecimal(txtIVA10.Text));
            if (String.IsNullOrEmpty(txtNetoEF.Text))
                txtNetoEF.Text = "0";
            if (String.IsNullOrEmpty(txtTotalEF.Text))
                txtTotalEF.Text = "0";
            objVentas.DoIva21 = Redondeo(Convert.ToDecimal(txtIVA21.Text));
            objVentas.DoNeto = Redondeo(Convert.ToDecimal(txtNetoEF.Text));
            objVentas.DoSubtotal = Redondeo(Convert.ToDecimal(txtTotalEF.Text));
            objVentas.DoTotal = 0;


            objVentas.DoPago = Redondeo(Convert.ToDecimal(txtPago.Text.Replace('.', ',')));
            objVentas.DoDebe = Redondeo(Convert.ToDecimal(txtDebe.Text));

            //Tengo que actualizar el objeto por con los cambios de la grilla


            for (int i = 0; i <= Convert.ToInt32(grillaArticulos.Rows.Count) - 1; i++)
            {
                foreach (var item in objVentas.ListArticulosPorVenta)
                {
                    if (Convert.ToInt32(grillaArticulos[COL_LINEA, i].Value) == item.IntLinea)
                    {
                        item.IntCantidad = Convert.ToDecimal(grillaArticulos[COL_KILOS, i].Value);
                        item.DoTotalConEfectivo = Convert.ToDecimal(grillaArticulos[COL_TOTAL, i].Value);
                    }

                }
            }

            


        }


        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private void AsignoCamposConObjetos()
        {
            ManejaClientes objManejaClientes = new ManejaClientes();
            Clientes objClientes = new Clientes();

            lblLegajo.Text = Convert.ToString(objVentas.IntCodigo);
            cboVendedor.SelectedValue = objVentas.ObjEmpleado.IntCodigo;
            cboCliente.SelectedValue = objVentas.ObjCliente.IntCodigo;
            //Cargo Datos del cliente                     
            objClientes = objManejaClientes.BuscarCliente(objVentas.ObjCliente.IntCodigo);
            LlenoCamposDelCliente(objClientes);
            //
            txtObservaciones.Text = objVentas.StrObservaciones;
            txtDescuento.Text = Convert.ToString(Redondeo(objVentas.DoDescuento));
            txtIVA10.Text = Convert.ToString(Redondeo(objVentas.DoIva105));
            txtIVA21.Text = Convert.ToString(Redondeo(objVentas.DoIva21));
            txtNetoEF.Text = Convert.ToString(Redondeo(objVentas.DoNeto));
            txtSubtotal.Text = Convert.ToString(Redondeo(objVentas.DoSubtotal));
            txtTotalEF.Text = Convert.ToString(Redondeo(objVentas.DoSubtotal));
            txtPago.Text = Convert.ToString(Redondeo(objVentas.DoPago));
            txtDebe.Text = Convert.ToString(Redondeo(objVentas.DoDebe));
            cboEstado.Text = objVentas.StrEstado;
            dtpFechaIngreso.Value = objVentas.DtFecha;
            cboUbicacion.Text = objVentas.StrMesa;
            cboListaDePrecio.Text = objVentas.StrListaPrecio;
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

            frmSubVenta objFrmSubVenta = new frmSubVenta(objVentas);


            //Me fijo si es una modificacion o un alta

            if (objVentas.IntCodigo > 0)
                Modifico();
            else
            {
                //objVentas.StrEstado = "EN PREPARACION";
                //cboEstado.Text = objVentas.StrEstado;
                Grabo();
                cboEstado.Enabled = true;
            }

            if (strEstadoAnterior != objVentas.StrEstado)
            {
                GraboSeguimiento(objVentas.IntCodigo, strEstadoAnterior, objVentas.StrEstado);
                strEstadoAnterior = objVentas.StrEstado;
                cboEstado.Items.Clear();
                CargoEstados(objVentas.StrEstado);
                cboEstado.Text = objVentas.StrEstado;
            }

        }

        private void GraboSeguimiento(Int32 intFacturaID, string strEstadoAnterior, string strEstadoActual)
        {
                        //Grabo Seguimiento
            ManejaVentas objManejaVentas = new ManejaVentas();
            Seguimiento objSeguimiento = new Seguimiento();

            objSeguimiento.IntFacturaID = intFacturaID;
            objSeguimiento.IntUsuarioID = frmLogin.Usuarioid;
            objSeguimiento.DtFecha = DateTime.Now;
            objSeguimiento.StrEstadoDesde = strEstadoAnterior;
            objSeguimiento.StrEstadoHasta = strEstadoActual;

            objManejaVentas.GrabarSeguimiento(objSeguimiento);

        }


        public void Grabo(Ventas objVentas)
        {
            this.objVentas = objVentas;
            Grabo();

        }

        public void Modifico(Ventas objVentas)
        {
            this.objVentas = objVentas;
            //vuelvo a reasignar la fecha 
            dtpFechaIngreso.Value = objVentas.DtFecha;
            Modifico();
        }

        private void Grabo()
        {
            //Tengo que setear una fecha porque todavia no esta cargada
            //objVentas.ObjSubVentaCheque.DtFechaVencimiento = DateTime.Now;
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();

            string message;
            string caption = "Mensaje";
            message = "¿Desea Grabar el Pedido?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Verifico si el cliente o el empleado estan dados de baja cuando cumplo la orden

                if (objVentas.StrEstado == "CUMPLIDA")
                {
                    if (String.IsNullOrEmpty(cboCliente.Text))
                    {
                        objVentas.StrEstado = "INICIAL";
                        cboEstado.Text = "INICIAL";
                        MessageBox.Show("Debe completar el cliente para continuar");
                        return;
                    }

                    if (String.IsNullOrEmpty(cboVendedor.Text))
                    {
                        objVentas.StrEstado = "INICIAL";
                        cboEstado.Text = "INICIAL";
                        MessageBox.Show("Debe completar el vendedor para continuar");
                        return;
                    }


                    ManejaClientes objManejaClientes = new ManejaClientes();
                    if (objManejaClientes.ClienteDadoDeBaja(objVentas.ObjCliente.IntCodigo))
                    {
                        objVentas.StrEstado = "INICIAL";
                        cboEstado.Text = "INICIAL";
                        MessageBox.Show("El cliente se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                    ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
                    if (objManejaEmpleados.EmpleadoDadoDeBaja(objVentas.ObjEmpleado.IntCodigo))
                    {
                        objVentas.StrEstado = "INICIAL";
                        cboEstado.Text = "INICIAL";
                        MessageBox.Show("El vendedor se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                }

                ManejaArticulos objManejaArticulos = new ManejaArticulos();

                //Antes de Grabar la venta debo verificar si el el articulo esta dado de baja y si posee Stock
                foreach (var c in objVentas.ListArticulosPorVenta)
                {
                    int sumaStockArt = 0;
                    if (objManejaArticulos.ArticuloDadoDeBaja(c.ObjArticulo.IntCodigo))
                    {
                        objVentas.StrEstado = "INICIAL";
                        cboEstado.Text = "INICIAL";
                        MessageBox.Show("El articulo " + c.ObjArticulo.StrCodigo + " - " + c.ObjArticulo.StrDescripcion + " se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                    //Por ahora no tomo en cuenta el stock

                    //Obtengo el stock Actual
                    //int stockActual = objManejaArticulos.CantidadDeStock(c.ObjArticulo.IntCodigo);
                    ////Ahora sumo todos los articulos que hay en la compra
                    //foreach (var art in objVentas.ListArticulosPorVenta)
                    //{
                    //    if (art.ObjArticulo.IntCodigo == c.ObjArticulo.IntCodigo)
                    //        //Sumo la cantidad de articulos
                    //        sumaStockArt = sumaStockArt + art.IntCantidad;
                    //}
                    //if (stockActual < sumaStockArt) //Si el stock actual es menor a lo que estoy vendiendo, aviso
                    //{
                    //    objVentas.StrEstado = "INICIAL";
                    //    cboEstado.Text = "INICIAL";
                    //    MessageBox.Show("El articulo " + c.ObjArticulo.StrCodigo + " - " + c.ObjArticulo.StrDescripcion + " se encuentra sin Stock suficiente, posee " + stockActual + " y esta vendiendo " + sumaStockArt + ", debe borrarlo o modificar el stock para continuar");
                    //    return;
                    //}

                }

                ManejaVentas objManejaVentas = new ManejaVentas();
                objVentas.IntCodigo = objManejaVentas.GrabarVenta(objVentas);
                lblLegajo.Text = Convert.ToString(objVentas.IntCodigo);
                this.Text = "Pedido: " + lblLegajo.Text + "  " + cboUbicacion.Text;

                foreach (var c in objVentas.ListArticulosPorVenta)
                {

                    c.IntCodigo = objManejaVentas.GrabarVentaDetalle(c, objVentas.IntCodigo);
                    //ActualizoStock(c, cboEstado.Text);


                }                

                //Fix

                //Grabo en la cuenta corriente el efectivo abona

                if (objVentas.ListPagos.Count == 0)
                {
                    Ventas_Pagos objPagos = new Ventas_Pagos();
                    objPagos.IntCodigo = objVentas.IntCodigo;
                    if (String.IsNullOrEmpty(txtPago.Text))
                        txtPago.Text = "0";
                    objPagos.DeImporte = Convert.ToDecimal(txtPago.Text);
                    objPagos.DtFecha = DateTime.Now;
                    objPagos.IntNumeroCaja = idCierreCaja; // objConfiguracion.IntNumeroCaja;

                    if (objPagos.IntMedioPago == 0)
                        objPagos.IntMedioPago = objManejaVentas.BuscoMedioDePagoPredeterminado();


                    objManejaVentas.GrabarVentasPagos(objPagos, objVentas.IntCodigo);
                }
                else
                {
                    foreach (var pagos in objVentas.ListPagos)
                    {

                        objManejaVentas.GrabarVentasPagos(pagos, objVentas.IntCodigo);


                    }
                }

                


                if (objVentas.ListSubVentaTarjeta != null)
                {
                    foreach (var d in objVentas.ListSubVentaTarjeta)
                    {

                        d.IntCodigo = objManejaVentas.GrabarTarjetas(d, objVentas.IntCodigo);

                    }
                }

                if (objVentas.ListSubVentaCheque != null)
                {

                    foreach (var e in objVentas.ListSubVentaCheque)
                    {

                        e.IntCodigo = objManejaVentas.GrabarCheques(e, objVentas.IntCodigo);

                    }
                }

                MessageBox.Show("El Pedido ha sido guardado");
                btnImprimir.Enabled = true;

                //Fix
                if (objVentas.StrEstado == "CUMPLIDA")
                {
                    //Imprimo siempre y cuando este parametrizado que tiene impresora
                    if (objManejaDiccionario.BuscarValor("IMPRESORA") == "SI")
                        Imprimir();//btnImprimir_Click(null, null);
                }

                //CalculoPrecioNetoEnEfectivo();

            }
            else
            {
                if (objVentas.StrEstado == "CUMPLIDA")
                {
                    objVentas.StrEstado = "PENDIENTE";
                    cboEstado.Text = "PENDIENTE";
                }
            }

            //if (objVentas.StrEstado == "PENDIENTE")
            //    HabilitaDesabilitaCamposTodos(true);
            //else
            //    HabilitaDesabilitaCamposTodos(false);
            

        }

        private void Modifico()
        {
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();
            bool boCancelaVenta = false;

            //Tengo que setear una fecha porque todavia no esta cargada
            //objVentas.ObjSubVentaCheque.DtFechaVencimiento = DateTime.Now;
            int intStockActual;
            string message;
            string caption = "Mensaje";
            message = "¿Desea Grabar el Pedido?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ManejaVentas objManejaVentas = new ManejaVentas();
                //Si estoy cancelando una orden, una vez actualizado el estado debo devolver el stock

                if ((cboEstado.Text == "CANCELADA") && (objManejaVentas.BuscoEstado(objVentas.IntCodigo) != "CANCELADA"))
                {
                    boCancelaVenta = true;
                }


                //Verifico si el cliente o el empleado estan dados de baja cuando cumplo la orden
                if (cboEstado.Text == "PENDIENTE")
                {
                    objVentas.StrEstado = "CUMPLIDA";
                    cboEstado.Text = "CUMPLIDA";

                }
                if (objVentas.StrEstado == "CUMPLIDA")
                {
                    ManejaClientes objManejaClientes = new ManejaClientes();
                    if (objManejaClientes.ClienteDadoDeBaja(objVentas.ObjCliente.IntCodigo))
                    {
                        objVentas.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El cliente se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                    ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
                    if (objManejaEmpleados.EmpleadoDadoDeBaja(objVentas.ObjEmpleado.IntCodigo))
                    {
                        objVentas.StrEstado = "PENDIENTE";
                        cboEstado.Text = "PENDIENTE";
                        MessageBox.Show("El vendedor se encuentra eliminado, debe borrarlo para continuar");
                        return;
                    }

                }






                ManejaArticulos objManejaArticulos = new ManejaArticulos();
                foreach (var c in objVentas.ListArticulosPorVenta)
                {
                    if (objManejaArticulos.ArticuloDadoDeBaja(c.ObjArticulo.IntCodigo))
                    {
                        objVentas.StrEstado = "INICAL";
                        cboEstado.Text = "INICAL";
                        MessageBox.Show("El articulo " + c.ObjArticulo.StrCodigo + " - " + c.ObjArticulo.StrDescripcion + " se encuentra borrarlo, debe eliminarlo para continuar");
                        return;
                    }

                }




                objManejaVentas.ModificaVentas(objVentas);
                this.Text = "Venta: " + lblLegajo.Text + "  " + cboUbicacion.Text;

                foreach (var c in objVentas.ListArticulosPorVenta)
                {
                    if (c.IntCodigo > 0)
                    {
                        //Como se si es algo que no se modifico????
                        //Quizas deberia comparar con la cantidad con la que tiene guardada en esa factura detalle
                        //intStockActual = objManejaVentas.BuscoStock(c.IntCodigo);
                        objManejaVentas.ModificaVentaDetalle(c, objVentas.IntCodigo);
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
                        c.IntCodigo = objManejaVentas.GrabarVentaDetalle(c, objVentas.IntCodigo);
                        //ActualizoStock(c, cboEstado.Text);

                    }


                }


                //Registro los pagos

                foreach (var a in objVentas.ListPagos)
                {
                    objManejaVentas.VerificaModificacionVentasPagos(a, objVentas.IntCodigo);
                }


                //Estos son los articulos dados de baja
                foreach (var d in objListArticulosPorVentaBorrados)
                {
                    //Borro los detalles de la base y luego devuelvo el stock

                    //ActualizoStock(d.ObjArticulo.IntCodigo, d.IntCantidad, "CANCELADA"); //Le pongo el estado CUMPLIDA para que agregue
                    objManejaVentas.EliminaVentaDetalle(d.IntCodigo);

                }

                //Esto es para una orden dada de baja
                //if (boCancelaVenta)
                //{
                //    foreach (var artbaja in objVentas.ListArticulosPorVenta)
                //    {
                //        ActualizoStock(artbaja.ObjArticulo.IntCodigo, artbaja.IntCantidad, "CANCELADA");
                //    }
                //}

                //foreach (var e in objVentas.ListSubVentaTarjeta)
                //{
                //    if (e.IntCodigo > 0)
                //    {
                //        objManejaVentas.ModificarTarjetas(e);
                //    }
                //    else
                //    {
                //        objManejaVentas.GrabarTarjetas(e, objVentas.IntCodigo);

                //    }

                //}

                //foreach (var e in objVentas.ListSubVentaCheque)
                //{
                //    if (e.IntCodigo > 0)
                //    {
                //        objManejaVentas.ModificarCheques(e);
                //    }
                //    else
                //    {
                //        objManejaVentas.GrabarCheques(e, objVentas.IntCodigo);

                //    }

                //}

                //foreach (var d in objVentas.ListTarjetasBorradas)
                //{
                //    //Borro tarjetas

                //    objManejaVentas.EliminaTarjeta(d.IntCodigo);

                //}

                //foreach (var d in objVentas.ListChequesBorrados)
                //{
                //    //Borro Cheques

                //    objManejaVentas.EliminaCheque(d.IntCodigo);

                //}

                MessageBox.Show("El Pedido ha sido guardado");

                //Verifico si el nuevo estado es PENDIENTE, en ese caso habilito todos los campos de lo contrario los griso

                //if (objVentas.StrEstado == "PENDIENTE")
                //    HabilitaDesabilitaCamposTodos(true);
                //else
                //    sHabilitaDesabilitaCamposTodos(false);


                //Fix
                if (objVentas.StrEstado == "CUMPLIDA")
                {
                    //Imprimo siempre y cuando este parametrizado que tiene impresora
                    if (objManejaDiccionario.BuscarValor("IMPRESORA") == "SI")
                        Imprimir();//btnImprimir_Click(null, null);
                }

                //CalculoPrecioNetoEnEfectivo();

            }
            else
            {
                if (objVentas.StrEstado == "CUMPLIDA")
                {
                    objVentas.StrEstado = "PENDIENTE";
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

                txtUnidades.Text = "1";

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
                        txtUnidades.Text = "";
                    }
                }
            }

        }

        private void frmVentas_Load(object sender, EventArgs e)
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

            string strPermiso = frmLogin.getPermiso("VENTAS", "VENTA_NUEVA");

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
                btnGuardar.Enabled = false;
                btnImprimir.Enabled = false;
                btnPagar.Enabled = false;
            }
            if (strPermiso == "LECTURA/ESCRITURA")
            {
                btnGuardar.Enabled = true;
                btnImprimir.Enabled = true;
                btnPagar.Enabled = true;
            }

            strEstadoAnterior = cboEstado.Text;

        }

        //private void ActualizoStock(ArticulosPorVenta objArticulosPorVenta, string strEstadoVenta)
        //{
        //    //Si el estado de la orden es pendiente o cumplida entonces descuento el stock
        //    //Si el estado es cancelado incremento el stock
        //    ManejaArticulos objManejaArticulos = new ManejaArticulos();
        //    objManejaArticulos.ModificaStock(objArticulosPorVenta.ObjArticulo.IntCodigo, objArticulosPorVenta.IntCantidad, strEstadoVenta);


        //}

        private void ActualizoStock(int intCodigo, int intCantidad, string strEstadoVenta)
        {
            //Si el estado de la orden es pendiente o cumplida entonces descuento el stock
            //Si el estado es cancelado incremento el stock
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            objManejaArticulos.ModificaStock(intCodigo, intCantidad, strEstadoVenta);


        }

        private bool ListoParaGrabar()
        {
            //No Dejar grabar sin ningun articulo
            if (objVentas.ListArticulosPorVenta.Count == 0)
            {
                MessageBox.Show("Debe cargar algun articulo para grabar o continuar");
                return false;
            }
            return true;
        }

        private void cboEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            if (objVentas.StrEstado == "PENDIENTE" && cboEstado.Text == "CUMPLIDA")
                cboEstado.Text = "PENDIENTE";
        }

        private void cboUbicacion_Leave(object sender, EventArgs e)
        {
            if (!(btnBuscarUbicacion.Focused))
            {
                if (!string.IsNullOrEmpty(cboUbicacion.Text))
                {
                    int variable = 0;
                    variable = cboUbicacion.FindString(cboUbicacion.Text);
                    if (variable == -1)//El proveedor no esta dentro de la lista, debo obligarlo a cargar
                    {
                        string message = "¿Desea Cargar datos de la Ubicacion?";
                        string caption = "Ubicacion Inexistente";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            frmDiccionario objFrmDiccionario = new frmDiccionario("UBICACION", cboUbicacion.Text, false);

                            objFrmDiccionario.ShowDialog();

                            objCombosStandard.CargarDiccionario(cboUbicacion, "UBICACION");
                            cboUbicacion.SelectedValue = objFrmDiccionario.intCodigo;

                        }
                        else
                        {
                            cboUbicacion.Text = "";
                        }
                    }
                }
            }
        }

        private void btnBuscarUbicacion_Click(object sender, EventArgs e)
        {
            //Pero me tengo que fijar si ese combo estaba cargada, si es que estaba cargado tengo que abrir la pantalla del proveedor            
            frmDiccionario objFrmDiccionario;
            if (Convert.ToInt32(cboUbicacion.SelectedValue) > 0)
                objFrmDiccionario = new frmDiccionario("UBICACION", Convert.ToInt32(cboUbicacion.SelectedValue));
            else
                objFrmDiccionario = new frmDiccionario("UBICACION", cboUbicacion.Text, false);

            objFrmDiccionario.ShowDialog();
            objCombosStandard.CargarDiccionario(cboUbicacion, "UBICACION");
            cboUbicacion.SelectedValue = objFrmDiccionario.intCodigo;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            string message;
            string caption = "Mensaje";
            message = "¿Desea Imprimir el Ticket?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            //// Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.No)
                return;

            Imprimir();

        }


        private void Imprimir()
        {
            //Primero verifico que tenga seteada una impresora

            if (String.IsNullOrEmpty(objConfiguracion.StrNombreImpresora))
            {
                MessageBox.Show("Debe setear una impresora para continuar");
                return;
            }
            Ticket ticket = new Ticket();
            ManejaDatosImpresion objManejaDatosImpresion = new ManejaDatosImpresion();
            DatosImpresion objDatosImpresion = new DatosImpresion();
            objDatosImpresion = objManejaDatosImpresion.BuscarDatosImpresion();

            //ticket.HeaderImage = "C:\imagen.jpg"; //esta propiedad no es obligatoria

            if (objDatosImpresion == null)
            {
                MessageBox.Show("Debe completar los datos de la Impresora para continuar");
                return;
            }
            if (objVentas.ListArticulosPorVenta.Count == 0)
            {
                MessageBox.Show("Debe tener un articulo cargado");
                return;
            }

            if (!string.IsNullOrEmpty(objDatosImpresion.StrComercio))
                ticket.AddHeaderLine(objDatosImpresion.StrComercio);//Nombre del comercio

            if (!string.IsNullOrEmpty(objDatosImpresion.StrDireccion) || !string.IsNullOrEmpty(objDatosImpresion.StrProvincia) || !string.IsNullOrEmpty(objDatosImpresion.StrLocalidad))
                ticket.AddHeaderLine("EXPEDIDO EN:");

            if (!string.IsNullOrEmpty(objDatosImpresion.StrDireccion))
                ticket.AddHeaderLine(objDatosImpresion.StrDireccion);//Direccion

            if (!string.IsNullOrEmpty(objDatosImpresion.StrProvincia) && !string.IsNullOrEmpty(objDatosImpresion.StrProvincia))
                ticket.AddHeaderLine(objDatosImpresion.StrProvincia + ", " + objDatosImpresion.StrLocalidad);//Provincia, Localidad
            else if (string.IsNullOrEmpty(objDatosImpresion.StrProvincia) && !string.IsNullOrEmpty(objDatosImpresion.StrProvincia))
                ticket.AddHeaderLine(objDatosImpresion.StrLocalidad);//Provincia, Localidad
            else if (!string.IsNullOrEmpty(objDatosImpresion.StrProvincia) && string.IsNullOrEmpty(objDatosImpresion.StrProvincia))
                ticket.AddHeaderLine(objDatosImpresion.StrProvincia);//Provincia, Localidad

            if (!string.IsNullOrEmpty(objDatosImpresion.StrCodigoInterno))
                ticket.AddHeaderLine(objDatosImpresion.StrCodigoInterno);//Codigo Interno

            //El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
            //de que al final de cada linea agrega una linea punteada "=========="
            ticket.AddSubHeaderLine("Presupuesto # " + objVentas.IntCodigo);//Numero de caja y ticket
            ticket.AddSubHeaderLine("CAJA: " + Convert.ToString(objConfiguracion.IntNumeroCaja));//CAJA
            ticket.AddSubHeaderLine("Ha sido atendido por: " + cboVendedor.Text);//Empleado que lo atendio
            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            //El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
            //del producto y el tercero es el precio
            //ticket.AddItem("1", "Articulo Prueba", "15.00");

            foreach (var c in objVentas.ListArticulosPorVenta)
            {
                if (String.IsNullOrEmpty( c.ObjArticulo.StrDescrCorta))
                    ticket.AddItem(Convert.ToString(c.IntCantidad), c.ObjArticulo.StrDescripcion, Convert.ToString(Redondeo(c.DoTotalConEfectivo)));
                else
                    ticket.AddItem(Convert.ToString(c.IntCantidad), c.ObjArticulo.StrDescrCorta, Convert.ToString(Redondeo(c.DoTotalConEfectivo)));
            }

            //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            if (objVentas.IntCodigo != 0)
            {
                ticket.AddTotal("SUBTOTAL: ", Convert.ToString(objVentas.DoNeto));
                ticket.AddTotal("DESCUENTO: ", Convert.ToString(objVentas.DoDescuento));
                ticket.AddTotal("TOTAL: ", Convert.ToString(objVentas.DoTotal));

            }
            else
            {
                ticket.AddTotal("SUBTOTAL: ", txtNetoEF.Text) ;
                ticket.AddTotal("DESCUENTO: ", txtDescuento.Text) ;
                ticket.AddTotal("TOTAL: ", txtTotalEF.Text)  ;
            }
            ticket.AddTotal("", ""); //Ponemos un total en blanco que sirve de espacio
            ticket.AddTotal("PAGO: ", Convert.ToString(objVentas.DoPago));
            ticket.AddTotal("DEBE: ", Convert.ToString(objVentas.DoDebe));
            ticket.AddTotal("", ""); //Ponemos un total en blanco que sirve de espacio

            //ticket.AddTotal("RECIBIDO", "50.00");
            //ticket.AddTotal("CAMBIO", "15.00");
            ticket.AddTotal("", "");//Ponemos un total en blanco que sirve de espacio
            //ticket.AddTotal("USTED AHORRO", "0.00");

            //El metodo AddFooterLine funciona igual que la cabecera
            ticket.AddFooterLine(objDatosImpresion.StrComentarioLinea1);
            ticket.AddFooterLine(objDatosImpresion.StrComentarioLinea2);
            ticket.AddFooterLine(objDatosImpresion.StrComertarioLinea3);

            //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un
            //parametro de tipo string que debe de ser el nombre de la impresora.


            //ticket.PrintTicket(objDatosImpresion.StrImpresora);
            ticket.PrintTicket(objConfiguracion.StrNombreImpresora);

        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnidades.Text))
                txtUnidades.Text = "0";

            if (!string.IsNullOrEmpty(txtPrecio.Text) && Convert.ToInt32(txtUnidades.Text) > 0)
                txtPrecio.Text = Convert.ToString(Convert.ToDecimal(txtPrecio.Text) * Convert.ToInt32(txtUnidades.Text));
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

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPago.Text))
                txtPago.Text = "0";

            //if (txtDebe.Text !="0")
                txtDebe.Text = Convert.ToString(Convert.ToDecimal(txtTotalEF.Text.Replace('.', ',')) - Convert.ToDecimal(txtPago.Text.Replace('.', ',')));

        }

        private void txtTotalEF_TextChanged(object sender, EventArgs e)
        {
//            txtPago.Text = txtTotalEF.Text;
            txtDebe.Text = txtTotalEF.Text;
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

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //frmVentasCuentaCorriente objCuentaCorriente = new frmVentasCuentaCorriente(objVentas.ListPagos, objVentas.DoDebe, objVentas.DoTotal, objConfiguracion.IntNumeroCaja);
            if (String.IsNullOrEmpty(txtDebe.Text))
                txtDebe.Text = "0";
            if (String.IsNullOrEmpty(txtTotalEF.Text))
                txtTotalEF.Text = "0";
            frmVentasCuentaCorriente objCuentaCorriente = new frmVentasCuentaCorriente(objVentas.ListPagos, Convert.ToDecimal(txtDebe.Text), Convert.ToDecimal(txtTotalEF.Text) , idCierreCaja);
            objCuentaCorriente.ShowDialog();
            Calculo_Resto_por_Pagar();

        }


        private void Calculo_Resto_por_Pagar()
        {
            if (String.IsNullOrEmpty(txtTotalEF.Text))
                txtTotalEF.Text = "0";

            decimal deTotal = Convert.ToDecimal(txtTotalEF.Text);
            decimal dePagado = 0;

            //Calculo cuanto restan
            //if (objVentas.ListPagos == null)
            //{
            //    dePagado = 0;
            //}
            //else
            //{
            //    foreach (var a in objVentas.ListPagos)
            //    {
            //        if (a.IntEstado != 3)
            //        {
            //            dePagado = dePagado + a.DeImporte;
            //        }

            //    }
            //}
            //txtPago.Text = Convert.ToString(Redondeo(dePagado));
            //txtDebe.Text = Convert.ToString(Redondeo(deTotal - dePagado));


            if (objVentas.ListPagos != null)
            {
                if (objVentas.ListPagos.Count > 0)
                {
                    foreach (var a in objVentas.ListPagos)
                    {
                        if (a.IntEstado != 3)
                        {
                            dePagado = dePagado + a.DeImporte;
                        }

                    }
                    txtPago.Text = Convert.ToString(Redondeo(dePagado));
                    txtDebe.Text = Convert.ToString(Redondeo(deTotal - dePagado));
                }
            }
        }

        private void grillaArticulos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Calculo el precio total
            if (grillaArticulos.CurrentCell == null)
                return;

            if (grillaArticulos.CurrentCell.ColumnIndex == COL_KILOS)
            {
                //int intCodigo = Convert.ToInt32(gridBuscarClientes.CurrentRow.Cells[0].Value.ToString());
                //objArticulosporVenta.DoPrecioUnitarioConEfectivo = Redondeo(TomaPrecioDeLista(objArticulos));
                //objArticulosporVenta.DoTotalConEfectivo = Redondeo((TomaPrecioDeLista(objArticulos) * objArticulosporVenta.IntCantidad));
                grillaArticulos.CurrentRow.Cells[COL_TOTAL].Value = Redondeo(Convert.ToDecimal(grillaArticulos.CurrentRow.Cells[COL_PRECIO_UNITARIO].Value) * Convert.ToDecimal(grillaArticulos.CurrentRow.Cells[COL_KILOS].Value));
                CalculoPrecioNetoEnEfectivo();
                
            }
        }

        private void grillaArticulos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var txtEdit = (TextBox)e.Control;
            txtEdit.KeyPress += EditKeyPress; //where EditKeyPress is your keypress event
        }


        private void EditKeyPress(object sender, KeyPressEventArgs e)
        {

            if (grillaArticulos.CurrentCell.ColumnIndex == COL_KILOS)
            {
                ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
                objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnaComa(sender, e);
            }
            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.SuppressKeyPress = true; //suppress ENTER
            //    //SendKeys.Send("{Tab}"); //Next column (or row)
            //    base.OnKeyDown(e);
            //}
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    base.OnKeyDown(e);
            //    this.BeginEdit(false);
            //}
            //else
            //{
            //    base.OnKeyDown(e);
            //}

        }

        private void btnBuscarSeguimiento_Click(object sender, EventArgs e)
        {
            frmSeguimiento objfrmSeguimiento = new frmSeguimiento(objVentas.IntCodigo);
            objfrmSeguimiento.ShowDialog();
        }


    }
}
