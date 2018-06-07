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
    public partial class mdiPrincipal : Form
    {
        private int childFormNumber = 0;
        public static List<Perfiles> listPerfiles = new List<Perfiles>();

        public mdiPrincipal()
        {
            InitializeComponent();
            lblUserName.Text = frmLogin.UserName;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmClientes objFrmCliente = new frmClientes();
           if (frmLogin.PermiteEntrar("CLIENTES","CLIENTES_NUEVO"))
            objFrmCliente.Show();

        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmClienteBusqueda objFrmClienteBusqueda = new frmClienteBusqueda(false,null);
            if (frmLogin.PermiteEntrar("CLIENTES", "CLIENTES_BUSCAR"))
                objFrmClienteBusqueda.Show();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores objFrmProveedores = new frmProveedores();
            if (frmLogin.PermiteEntrar("PROVEEDORES", "PROVEEDORES_NUEVO"))
                objFrmProveedores.Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEmpleados objFrmEmpleados = new frmEmpleados();
            if (frmLogin.PermiteEntrar("EMPLEADOS", "EMPLEADOS_ALTA"))
                objFrmEmpleados.Show();
        }

        private void buscarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmEmpleadosBusqueda objFrmEmpleadosBusqueda = new frmEmpleadosBusqueda(false, null);
            if (frmLogin.PermiteEntrar("EMPLEADOS", "EMPLEADOS_BUSCAR"))
                objFrmEmpleadosBusqueda.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedoresBusqueda objFrmProveedoresBusqueda = new frmProveedoresBusqueda(false,null);
            if (frmLogin.PermiteEntrar("PROVEEDORES", "PROVEEDORES_BUSCAR"))
                objFrmProveedoresBusqueda.Show();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulos objFrmArticulos = new frmArticulos();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ALTA"))
                objFrmArticulos.Show();
        }

        private void buscarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmArticulosBusqueda objfrmArticulosBusqueda = new frmArticulosBusqueda(false);
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_BUSCAR"))
                objfrmArticulosBusqueda.Show();
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas objFrmVentas = new frmVentas();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_NUEVA"))
                objFrmVentas.Show();
        }

        private void buscarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVentasBusqueda objFrmVentasBusqueda = new frmVentasBusqueda();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_BUSCAR"))
                objFrmVentasBusqueda.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosReportes objFrmArticulosReportes = new frmArticulosReportes();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_REPORTES"))
                objFrmArticulosReportes.Show();
        }


        private void parametrizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiccionario objFrmDiccionario = new frmDiccionario();
            if (frmLogin.PermiteEntrar("SISTEMA", "SISTEMA_PARAMETRIZACIONES"))
                objFrmDiccionario.Show();
        }


        private void nuevaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCompras objFrmCompras = new frmCompras();
            if (frmLogin.PermiteEntrar("COMPRAS", "COMPRAS_NUEVO"))
                objFrmCompras.Show();
        }

        private void buscarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmComprasBusqueda objFrmComprasBusqueda = new frmComprasBusqueda();
            if (frmLogin.PermiteEntrar("COMPRAS", "COMPRAS_BUSCAR"))
                objFrmComprasBusqueda.Show();
        }

        private void cierreDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCierreCaja objFrmCierreCaja = new frmCierreCaja();
            if (frmLogin.PermiteEntrar("SISTEMA", "SISTEMA_CIERRE_CAJA"))
                objFrmCierreCaja.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarStock objFrmArticulosActualizarStock = new frmArticulosActualizarStock();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarStock.Show();
        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarPrecio objFrmArticulosActualizarPrecio = new frmArticulosActualizarPrecio();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarPrecio.Show();
        }

        private void buscarPorImagenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosBusquedaPorImagen objFrmArticulosBusquedaPorImagen = new frmArticulosBusquedaPorImagen(false);
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_BUSCAR_IMAGEN"))
                objFrmArticulosBusquedaPorImagen.Show();
        }

        private void ubicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarUbicacion objFrmArticulosActualizaUbicacion = new frmArticulosActualizarUbicacion();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizaUbicacion.Show();
        }

        private void articulosMasivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosMasivo objFrmArticulosMasivo = new frmArticulosMasivo();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosMasivo.Show();
        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios objFrmUsuario = new frmUsuarios();
            if (frmLogin.PermiteEntrar("USUARIOS", "USUARIOS_ADMINISTRACION"))
                objFrmUsuario.Show();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosPerfiles objFrmUsuariosPerfiles = new frmUsuariosPerfiles();
            if (frmLogin.PermiteEntrar("USUARIOS", "USUARIOS_PERFILES"))
                objFrmUsuariosPerfiles.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosCambiarContraseña objFrmUsuariosCambiarContraseña = new frmUsuariosCambiarContraseña();
            if (frmLogin.PermiteEntrar("USUARIOS", "USUARIOS_CONTRASEÑA"))
                objFrmUsuariosCambiarContraseña.Show();
        }

        private void mdiPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gananciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarPorcentaje objFrmArticulosActualizaPorcentaje = new frmArticulosActualizarPorcentaje();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizaPorcentaje.Show();
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            frmVentas objFrmVentas = new frmVentas();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_NUEVA"))
                objFrmVentas.Show();
        }

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            frmVentasReportes objFrmVentasReportes = new frmVentasReportes();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_REPORTES"))
                objFrmVentasReportes.Show();
        }

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            frmArticulos objFrmArticulos = new frmArticulos();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ALTA"))
                objFrmArticulos.Show();
        }

        private void btnMenu4_Click(object sender, EventArgs e)
        {
            frmArticulosBusqueda objfrmArticulosBusqueda = new frmArticulosBusqueda(false);
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_BUSCAR"))
                objfrmArticulosBusqueda.Show();
        }

        private void btnMenu5_Click(object sender, EventArgs e)
        {
            frmVentasBusqueda objFrmVentasBusqueda = new frmVentasBusqueda();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_BUSCAR"))
                objFrmVentasBusqueda.Show();
        }

        private void btnMenu6_Click(object sender, EventArgs e)
        {
            frmArticulosBusquedaPorImagen objFrmArticulosBusquedaPorImagen = new frmArticulosBusquedaPorImagen(false);
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_BUSCAR_IMAGEN"))
                objFrmArticulosBusquedaPorImagen.Show();
        }

        private void codArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarCodigo objFrmArticulosActualizarCodigo = new frmArticulosActualizarCodigo();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarCodigo.Show();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarMarca objFrmArticulosActualizarMarca = new frmArticulosActualizarMarca();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarMarca.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarProveedor objFrmArticulosActualizarProveedor = new frmArticulosActualizarProveedor();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarProveedor.Show();
        }

        private void rubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarRubro objFrmArticulosActualizarRubro = new frmArticulosActualizarRubro();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarRubro.Show();
        }

        private void nuevaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDevoluciones objFrmVentasDevoluciones = new frmDevoluciones();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_DEVOLUCION"))
                objFrmVentasDevoluciones.Show();
        }

        private void buscarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmDevolucionesBusqueda objFrmDevoluciones = new frmDevolucionesBusqueda();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_DEVOLUCION_BUSCAR"))
                objFrmDevoluciones.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pagosYDevolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void precioL2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarListaPrecio2 objFrmArticulosActualizarListaPrecio2 = new frmArticulosActualizarListaPrecio2();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarListaPrecio2.Show();

        }

        private void precioL3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarListaPrecio3 objFrmArticulosActualizarListaPrecio3 = new frmArticulosActualizarListaPrecio3();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objFrmArticulosActualizarListaPrecio3.Show();
        }

        private void configuracionDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpresion objFrmImpresion = new frmImpresion();
            if (frmLogin.PermiteEntrar("SISTEMA", "SISTEMA_TICKET"))
                objFrmImpresion.Show();
        }

        private void configuracionDePCCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracionPcCaja objFrmConfiguracionPcCaja = new frmConfiguracionPcCaja(); 
            if (frmLogin.PermiteEntrar("SISTEMA", "SISTEMA_CONFIGURACION"))
                objFrmConfiguracionPcCaja.Show();
        }

        private void mediosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedioPago objFrmMediosDePago = new frmMedioPago();
            if (frmLogin.PermiteEntrar("SISTEMA", "SISTEMA_MEDIO_DE_PAGOS"))
                objFrmMediosDePago.Show();

        }

        private void nuevaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmDevoluciones objFrmVentasDevoluciones = new frmDevoluciones();
            if (frmLogin.PermiteEntrar("DEVOLUCIONES", "DEVOLUCION_NUEVA"))
                objFrmVentasDevoluciones.Show();
        }

        private void buscarToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmDevolucionesBusqueda objFrmDevoluciones = new frmDevolucionesBusqueda();
            if (frmLogin.PermiteEntrar("DEVOLUCIONES", "DEVOLUCION_BUSCAR"))
                objFrmDevoluciones.Show();
        }



        private void aperturaCierreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCierreCaja objFrmCierreCaja = new frmCierreCaja();
            if (frmLogin.PermiteEntrar("CAJA", "CAJA_CIERRE"))
                objFrmCierreCaja.Show();
        }

        private void mdiPrincipal_Shown(object sender, EventArgs e)
        {
            ManejaCierreDeCaja objManejaCierreDeCaja = new ManejaCierreDeCaja();
            ManejaConfiguraciones objManejaConfiguracion = new ManejaConfiguraciones();
            Configuraciones objConfiguracion = new Configuraciones();
            Int32 idCierreCaja = 0;

            objConfiguracion= objManejaConfiguracion.BuscarConfiguracion(Environment.MachineName);
            if (objConfiguracion != null)
            {
                idCierreCaja = objManejaCierreDeCaja.getCierreCajaId(objConfiguracion.IntNumeroCaja);

                if (idCierreCaja != 0)
                {
                    if (objManejaCierreDeCaja.ValidaFechaAperturaCierreCaja(idCierreCaja))
                    {

                        MessageBox.Show("La Caja quedo abierta con fecha de un dia anterior. Para Cerrarla debe Ingresar al Modulo (Caja)");
                    }
                }
            }
        }

        private void reporteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCierreCajaReporte objFrmCierreCaja = new frmCierreCajaReporte();
            if (frmLogin.PermiteEntrar("CAJA", "CAJA_BUSCAR"))
                objFrmCierreCaja.Show();
        }

        private void reportesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVentasReportes objFrmVentasReportes = new frmVentasReportes();
            if (frmLogin.PermiteEntrar("VENTAS", "VENTA_REPORTES"))
                objFrmVentasReportes.Show();
        }

        private void monedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonedas objFrmMoneda = new frmMonedas();
            if (frmLogin.PermiteEntrar("SISTEMA", "SISTEMA_MONEDAS"))
                objFrmMoneda.Show();
        }

        private void descripciónCortaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarDescripcionCorta objfrmArticulosActualizar = new frmArticulosActualizarDescripcionCorta();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objfrmArticulosActualizar.Show();
        }

        private void descripciónLargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarDescripcionLarga objfrmArticulosActualizar = new frmArticulosActualizarDescripcionLarga();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objfrmArticulosActualizar.Show();
        }

        private void precioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulosActualizarListaPrecio1 objfrmArticulosActualizar = new frmArticulosActualizarListaPrecio1();
            if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ACTUALIZACIONES"))
                objfrmArticulosActualizar.Show();
        }

        private void pagosYDevolucionesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmVentasReportesPagos objFrmVentasReportes = new frmVentasReportesPagos();
            if (frmLogin.PermiteEntrar("DEVOLUCIONES", "DEVOLUCION_REPORTES"))
                objFrmVentasReportes.Show();
        }






    }
}
