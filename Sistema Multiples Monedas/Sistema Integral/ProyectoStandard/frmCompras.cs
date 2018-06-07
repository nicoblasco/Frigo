using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using Model;

namespace ProyectoStandard
{
    public partial class frmCompras : Form
    {
        CombosStandard objCombosStandard;
        Compras objCompras;
        ManejaCompras objManejaCompras;
        ManejaConfiguraciones objManejaConfiguracion;
        Configuraciones objConfiguracion;
        bool boOtraPantalla;
        public int intCodigoCompra;
        ManejaCierreDeCaja objManejaCierreCaja;
        Int32 idCierreCaja = 0;


        public frmCompras()
        {
            InitializeComponent();
             objCompras = new Compras();
             CargoCombosStandard();
             CargoConfiguracion();
             HabilitaDesabilitaCampos(false);
             dtpFechaIngreso.Value = DateTime.Now;
              

        }

        public frmCompras(Compras objCompras)
        {
            InitializeComponent();
            this.objCompras = objCompras;
            CargoCombosStandard();
            CargoConfiguracion();
            AsignoCamposConObjetos();
            ManejaProveedores objManejaProveedores = new ManejaProveedores();
            LlenoCamposDelProveedor(objManejaProveedores.BuscarProveedores(Convert.ToInt32(cboProveedor.SelectedValue)));
            btnEliminar.Enabled = true;
            this.Text = "Compra: " + txtFactura.Text + " " + cboProveedor.Text;
            boOtraPantalla = true;

            if (!string.IsNullOrEmpty(objCompras.DtFechaBaja))
                DesabilitaCamposPorBaja();
        }


        private void DesabilitaCamposPorBaja()
        {
            cboLocalidad.Enabled = false;
            cboPais.Enabled = false;
            cboProvincia.Enabled = false;
            txtDepto.Enabled = false;
            txtDireccion.Enabled = false;
            txtNro.Enabled = false;
            txtPiso.Enabled = false;
            dtpFechaIngreso.Enabled = false;
            txtTotal.Enabled = false;
            cboProveedor.Enabled = false;
            txtFactura.Enabled = false;
            txtObservaciones.Enabled = false;
            btnEliminar.Enabled = false;
            btnAceptar.Enabled = false;
            btnBuscarProveedor.Enabled = false;
        }


        private void CargoCombosStandard()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarPaises(cboPais);
            objCombosStandard.CargarProvincias(cboProvincia, cboPais.SelectedValue);
            objCombosStandard.CargarLocalidades(cboLocalidad, cboProvincia.SelectedValue);
            objCombosStandard.CargarProveedores(cboProveedor,Convert.ToString(objCompras.IntProveedor));


            cboPais.Text = "";
            cboPais.SelectedIndex = -1;
            cboProvincia.Text = "";
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.Text = "";
            cboLocalidad.SelectedIndex = -1;



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

        }

        private void CargoConfiguracion()
        {
            //Cargo Configuraciones
            objManejaConfiguracion = new ManejaConfiguraciones();
            objConfiguracion = objManejaConfiguracion.BuscarConfiguracion(Environment.MachineName);
        }

        private void cboProveedor_Leave(object sender, EventArgs e)
        {
            //Esto significa si hizo click en el boton de buscar
            if (!(btnBuscarProveedor.Focused))
            {
                if (!string.IsNullOrEmpty(cboProveedor.Text))
                {
                    int variable = 0;
                    variable = cboProveedor.FindStringExact(cboProveedor.Text);
                    if (variable == -1)//El proveedor no esta dentro de la lista, debo obligarlo a cargar
                    {
                        string message = "¿Desea Cargar datos del Proveedor?";
                        string caption = "Proveedor Inexistente";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            ManejaProveedores objManejaProveedores = new ManejaProveedores();
                            frmProveedores objFrmProveedores = new frmProveedores(cboProveedor.Text);
                            objFrmProveedores.ShowDialog();


                            if (objFrmProveedores.intCodigoProveedor > 0)
                            {
                                objCombosStandard.CargarProveedores(cboProveedor, Convert.ToString(objFrmProveedores.intCodigoProveedor));
                                //objCombosStandard.CargarClientes(cboCliente, Convert.ToString(objVentas.ObjCliente.IntCodigo));
                                cboProveedor.SelectedValue = objFrmProveedores.intCodigoProveedor;

                                LlenoCamposDelProveedor(objManejaProveedores.BuscarProveedores(Convert.ToInt32(cboProveedor.SelectedValue)));
                            }

                        }
                        else
                        {
                            cboProveedor.Text = "";
                            LimpioCamposDelProveedor();
                        }
                    }
                }
                else
                {
                    LimpioCamposDelProveedor();
                }
            }
        }


        private void LlenoCamposDelProveedor(Proveedores objProveedor )
        {
            HabilitaDesabilitaCampos(true);

            cboLocalidad.SelectedValue = objProveedor.IntLocalidad;
            cboPais.SelectedValue = objProveedor.IntPais;
            cboProvincia.SelectedValue = objProveedor.IntProvincia;
            txtDepto.Text = objProveedor.StrDepto;
            txtDireccion.Text = objProveedor.StrDirecccion;
            txtNro.Text = objProveedor.StrNro;
            txtPiso.Text = objProveedor.StrPiso;

            HabilitaDesabilitaCampos(false);
        }

        private void LimpioCamposDelProveedor()
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

        private void cboProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboProveedor.SelectedValue) > 0)
            {
                ManejaProveedores objManejaProveedores = new ManejaProveedores();
                Proveedores objProveedores = new Proveedores();
                objProveedores = objManejaProveedores.BuscarProveedores(Convert.ToInt32(cboProveedor.SelectedValue));
                LlenoCamposDelProveedor(objProveedores);
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            ManejaProveedores objManejaProveedores = new ManejaProveedores();
            Proveedores objProveedores = new Proveedores();

            if (Convert.ToInt32(cboProveedor.SelectedValue) != 0)
            {
                objProveedores = objManejaProveedores.BuscarProveedores(Convert.ToInt32(cboProveedor.SelectedValue));
                frmProveedores objFrmProveedores = new frmProveedores(objProveedores);
                objFrmProveedores.ShowDialog();
                if (objFrmProveedores.intCodigoProveedor != 0)
                {
                    objCombosStandard.CargarProveedores(cboProveedor, Convert.ToString(objFrmProveedores.intCodigoProveedor));
                    cboProveedor.SelectedValue = objFrmProveedores.intCodigoProveedor;
                    LlenoCamposDelProveedor(objProveedores);
                }

            }
            else
            {
                frmProveedoresBusqueda objFrmProveedorBusqueda = new frmProveedoresBusqueda(true, cboProveedor.Text);
                objFrmProveedorBusqueda.ShowDialog();
                objCombosStandard.CargarProveedores(cboProveedor,Convert.ToString(cboProveedor.SelectedValue));
                cboProveedor.SelectedValue = objFrmProveedorBusqueda.intCodigo;
                LlenoCamposDelProveedor(objProveedores);

                if (objFrmProveedorBusqueda.intCodigo != 0)
                {
                    objProveedores = objManejaProveedores.BuscarProveedores(objFrmProveedorBusqueda.intCodigo);
                    LlenoCamposDelProveedor(objProveedores);
                }



                //Busco todos los datos del cliente, esto esta mal, deberia hacerlo de otra manera...

            }
             LlenoCamposDelProveedor(objProveedores);
        }

        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el cuil y la razon social

            if ((String.IsNullOrEmpty(cboProveedor.Text)) || (String.IsNullOrEmpty(txtTotal.Text)))
                return false;
            else
                return true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }

            if (objCompras.IntCodigo != 0)
            {
                Modifico();
                this.Text = "Compra: " + Convert.ToString(objCompras.IntCodigo);

            }
            else
            {
                Grabo();
                this.Text = "Compra: " + Convert.ToString(objCompras.IntCodigo);
            }


            if (boOtraPantalla)
            {
                intCodigoCompra = objCompras.IntCodigo;
                this.Close();
            }
            else
            {
                LimpioCampos();
            }
        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaCompras = new ManejaCompras();
            objCompras.IntCodigo = objManejaCompras.GrabarCompras(objCompras);
            MessageBox.Show("La Compra " + objCompras.IntCodigo + " ha sido grabada correctamente");
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            ManejaCompras objManejaCompras = new ManejaCompras();
            objManejaCompras.ModificaCompras(objCompras);
            MessageBox.Show("La Compra " + objCompras.IntCodigo + " ha sido modificada correctamente");

        }

        private void AsignoDatosAlObjeto()
        {

            objCompras.DtFechaAlta = Convert.ToDateTime(dtpFechaIngreso.Text);
            if (String.IsNullOrEmpty(txtTotal.Text))
            {
                txtTotal.Text = "0";
            }
            objCompras.DeTotal = Convert.ToDecimal(txtTotal.Text.Replace('.', ','));
            objCompras.IntProveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            objCompras.StrNroFactura = txtFactura.Text;
            objCompras.StrObservaciones = txtObservaciones.Text;
            objCompras.IntNumeroCaja = idCierreCaja; //objConfiguracion.IntNumeroCaja;


        }

        private void AsignoCamposConObjetos()
        {

            dtpFechaIngreso.Value = objCompras.DtFechaAlta;
            lblLegajo.Text = Convert.ToString(objCompras.IntCodigo);
            txtTotal.Text = Convert.ToString(objCompras.DeTotal);
            cboProveedor.SelectedValue = objCompras.IntProveedor;
            txtFactura.Text = objCompras.StrNroFactura;
            txtObservaciones.Text = objCompras.StrObservaciones;

        }

        private void LimpioCampos()
        {
            dtpFechaIngreso.Text = Convert.ToString(DateTime.Now);
            lblLegajo.Text = "";
            txtTotal.Text = "";
            cboProveedor.Text = "";
            txtFactura.Text = "";
            txtObservaciones.Text = "";

            objCompras = null;
            objCompras = new Compras();

            btnEliminar.Enabled = false;

            cboPais.Text = "";
            cboPais.SelectedIndex = -1;
            cboProvincia.Text = "";
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.Text = "";
            cboLocalidad.SelectedIndex = -1;

        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";

            ManejaCompras objManejaCompras = new ManejaCompras();
            message = "Desea Eliminar la Compra?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino

                objManejaCompras.EliminaCompras(objCompras.IntCodigo);

                MessageBox.Show("La Compra " + objCompras.IntCodigo + " ha sido eliminada correctamente");

                if (boOtraPantalla)
                {
                    LimpioCampos();
                    this.Close();
                }
                else
                {
                    LimpioCampos();
                }

            }
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("COMPRAS", "COMPRAS_NUEVO");

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
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
    }
}
