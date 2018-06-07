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
using System.Data.SqlClient;

namespace ProyectoStandard
{
    public partial class frmArticulosReportes : Form
    {
        CombosStandard objCombosStandard;

        public frmArticulosReportes()
        {
            InitializeComponent();
            CargoCombos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbFechaVenta.Checked && (!ckCumplida.Checked && !ckCancelada.Checked))
                MessageBox.Show("Debe seleccional al menos un estado de venta");
            else
                Buscar();
        }

        private void Buscar()
        {
            CargoDatos();

        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarProveedores(cboProveedor,null);
            objCombosStandard.CargarDiccionario(cboRubro, "PRODUCTOS/SERVICIOS");
            objCombosStandard.CargarDiccionario(cboMarca, "MARCA");
        }
        private void CargoDatos()
        {

            string strSql;

            if (rbFechaVenta.Checked)
            {
                strSql = "select f.fechaalta, f.facturaid,idextra,descripcion, rubro, marca,f.ubicacion, stock, precioefectivo, cantidad, d.descuento, d.total ";
                strSql += " from dbo.Articulos a LEFT OUTER JOIN dbo.Proveedores  P  ON a.proveedor = P.id  , dbo.Factura_Detalle D, dbo.Factura f ";
                strSql += " where a.id = D.articuloid  and d.facturaid = f.facturaid ";
                if (ckCumplida.Checked)
                    strSql += " and ( f.estado='CUMPLIDA' ";


                if (ckCancelada.Checked && ckCancelada.Checked)
                    strSql += " or f.estado='CANCELADA' ";

                if (ckCancelada.Checked && !ckCancelada.Checked)
                    strSql += " and (f.estado='CANCELADA' ";

                if (ckCumplida.Checked || ckCancelada.Checked)
                    strSql += " ) ";
                strSql += " and f.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaVentaDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeVentaHasta.Text + "')+1)";
                
            }
            else
            {
                strSql = " select a.id,idextra,descripcion, rubro, marca, stock, a.ubicacion, precioefectivo, isnull (sum(cantidad),0) as cantidad, isnull (sum(d.total),0) as total   ";
                strSql += " from dbo.Articulos a LEFT OUTER JOIN dbo.Proveedores  P  ON a.proveedor = P.id  LEFT OUTER JOIN dbo.Factura_Detalle D  ON a.id = D.articuloid  LEFT OUTER JOIN dbo.Factura F On F.facturaid = D.facturaid  ";
                if (ckCumplida.Checked)
                    strSql += " and ( f.estado='CUMPLIDA' ";


                if (ckCancelada.Checked && ckCancelada.Checked)
                    strSql += " or f.estado='CANCELADA' ";

                if (ckCancelada.Checked && !ckCancelada.Checked)
                    strSql += " and (f.estado='CANCELADA' ";

                if (ckCumplida.Checked || ckCancelada.Checked)
                    strSql += " ) ";


                strSql += " where 1=1 ";
            }

            if (txtCodigo.Text != "")
            {
                if (txtCodigo.Text.Substring(0, 2).Trim() == "20" && txtCodigo.Text.Trim().Length == 13) //Los dos primeros digitos tienen que se 20 y el ancho del codigo de barra tiene que ser de 12 digitos
                {
                    //Reemplazo la busqueda,
                    //El codigo de barra se conforma de la siguiente manera
                    //20PPPPIIIIIIX

                    //20- Codigo Identificatorio. 2Digitos
                    //P- Codigo PLU . 4Digitos
                    //I-Importe. 6Digitos
                    //X-Digito Control. 1Digito

                    //Ejemplo:
                    //2000010003006
                    //Es un producto de almacen

                    if (cboCodigo.Text == "=")
                        strSql += " and  SUBSTRING(a.idextra,1,6) = '" + txtCodigo.Text.Substring(0, 6) + "'";
                    if (cboCodigo.Text == "like")
                        strSql += " and  SUBSTRING(a.idextra,1,6) like '" + txtCodigo.Text.Substring(0, 6) + "%' ";
                    if (cboCodigo.Text == "path")
                        strSql += " and  SUBSTRING(a.idextra,1,6) '%" + txtCodigo.Text.Substring(0, 6) + "%' ";
                }
                else
                {

                    if (cboCodigo.Text == "=")
                        strSql += " and  a.idextra = '" + txtCodigo.Text + "'";
                    if (cboCodigo.Text == "like")
                        strSql += " and  a.idextra like '" + txtCodigo.Text + "%' ";
                    if (cboCodigo.Text == "path")
                        strSql += " and  a.idextra like '%" + txtCodigo.Text + "%' ";

                }
 
            }


            if (txtDescripcion.Text != "")
            {
                if (cboDescripcion.Text == "=")
                    strSql += " and  a.descripcion = '" + txtDescripcion.Text + "'";
                if (cboDescripcion.Text == "like")
                    strSql += " and  a.descripcion like '" + txtDescripcion.Text + "%' ";
                if (cboDescripcion.Text == "path")
                    strSql += " and  a.descripcion like '%" + txtDescripcion.Text + "%' ";

            }

            if (cboRubro.Text != "")
            {
                strSql += " and  a.rubro = '" + cboRubro.Text + "'";

            }

            if (cboMarca.Text != "")
            {
                strSql += " and  a.marca = '" + cboMarca.Text + "'";

            }


            if (txtUbicacion.Text != "")
            {
                if (cboUbicacion.Text == "=")
                    strSql += " and  a.ubicacion = '" + txtUbicacion.Text + "'";
                if (cboUbicacion.Text == "like")
                    strSql += " and  a.ubicacion like '" + txtUbicacion.Text + "%' ";
                if (cboUbicacion.Text == "path")
                    strSql += " and  a.ubicacion like '%" + txtUbicacion.Text + "%' ";

            }

            if (cboProveedor.Text != "")
            {
                strSql += " and  a.proveedor =" + cboProveedor.SelectedValue;
            }

            if (txtStock.Text != "")
            {
                strSql += " and  a.stock " + cboStock.Text + txtStock.Text;
            }

            if (CkStockMinimo.Checked)
            {
                strSql += " and  a.stock<=a.stockminimo";
            }

            if (cboEstadoArt.Text != "")
            {
                if (cboEstadoArt.Text=="ALTA")
                    strSql += " and  a.fechabaja is null " ;
                else
                    strSql += " and  a.fechabaja is not null ";
            }




            if (rbFechaVenta.Checked)
                strSql += " order by f.fechaalta";
            else
                strSql += " group by a.id,idextra,descripcion, a.fechaalta, rubro, marca,a.ubicacion, stock, precioefectivo  ";


            if (rbCodigo.Checked)
                strSql += " order by idextra";

            else if (rbMarca.Checked)
                strSql += " order by marca";

            else if (rbMasVendido.Checked)
                strSql += " order by cantidad desc ";

            else if (rbMayorGanancia.Checked)
                strSql += "  order by total desc ";

            else if (rbMenosVendido.Checked)
                strSql += " order by cantidad asc ";

            else if (rbOrdenAlfabetico.Checked)
                strSql += " order by descripcion ";

            else if (rbRubro.Checked)
                strSql += " order by rubro ";





            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            frmReportes objfrmReporte;

            if (rbFechaVenta.Checked)
                objfrmReporte = new frmReportes("ReporteArticulosVenta.rdlc", objManejaArticulos.ReporteDeArticulosVenta(dt), "ArticulosReporte");
               
            else
                objfrmReporte = new frmReportes("ReporteArticulosGeneral.rdlc", objManejaArticulos.ReporteDeArticulos(dt), "ArticulosReporte");

            objfrmReporte.Show();

 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboDescripcion.Text = "=";
            cboMarca.Text = "";
            cboProveedor.Text = "";
            cboRubro.Text = "";
            cboStock.Text = "=";
            cboUbicacion.Text = "=";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
            txtUbicacion.Text = "";
            CkStockMinimo.Checked = false;
            cboEstadoArt.Text = "";
            ckCancelada.Checked = true;
            ckCumplida.Checked = true;
            rbMasVendido.Checked = true;
            HabilitoDesabilitoPorVenta(false);
            dtpFechadeVentaHasta.Value = DateTime.Now;
        }

        private void frmArticulosReportes_Load(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboDescripcion.Text = "=";
            cboStock.Text = "=";
            cboUbicacion.Text = "=";
            rbMasVendido.Checked = true;
            HabilitoDesabilitoPorVenta(false);
            ckCancelada.Checked = true;
            ckCumplida.Checked = true;
            dtpFechadeVentaHasta.Value = DateTime.Now;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();

            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void rbFechaVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechaVenta.Checked)
                HabilitoDesabilitoPorVenta(true);
            else
                HabilitoDesabilitoPorVenta(false);

        }

        private void HabilitoDesabilitoPorVenta(bool boRes)
        {
            dtpFechaVentaDesde.Enabled = boRes;
            dtpFechadeVentaHasta.Enabled = boRes;

        }

    }
}
