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
    public partial class frmVentasReportes : Form
    {
        CombosStandard objCombosStandard;

        public frmVentasReportes()
        {
            InitializeComponent();
            CargoCombos();
            cboEstado.Text = "CUMPLIDA";
        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarEmpleados(cboVendedor,null);
            objCombosStandard.CargarClientes(cboCliente,null);
            objCombosStandard.CargarMedioDePago(cboMedioPago);
            cboMedioPago.SelectedIndex = -1;


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            CargoDatos();

        }


        private void CargoDatos()
        {


            string strSql;

            //Tengo 3 formas de busqueda
            //1-Detallado por Cantidad total de articulos
            //2-Detallado de articulos
            //3-Totales

            if (rbInformeDetallado.Checked && rbArticulosCantidadTotal.Checked)
            {
                strSql = " select f.facturaid, f.fechaalta , f.estado, e.emp_nombre + ' ' + e.emp_apellido as empleado, c.cli_nombre + ' '+ c.cli_apellido as cliente, isnull( sum(d.cantidad),0) as cantidad, ";
                strSql += " isnull(f.efectivoabona,0) as efectivo, isnull((select sum(d.tarjetaabona) from dbo.Tarjetas_Detalle d where d.facturaid =f.facturaid),0)  as tarjeta , isnull( (select sum(d.chequeabona) from dbo.Cheques_Detalle d where d.facturaid =f.facturaid),0) as cheque , isnull(f.ctacte,0) as Ctacte, isnull(f.total,0) as total, f.descuento, f.neto ";
                strSql += " from dbo.Factura f, dbo.Empleados e, dbo.Clientes c,  dbo.Factura_Detalle d ";
                strSql += " where f.empleadoid= e.emp_id and f.clienteid = c.cli_id and f.facturaid = d.facturaid ";
            }
            else if (rbInformeDetallado.Checked && rbArticulosDetallado.Checked)
            {
                strSql = " select f.facturaid, f.fechaalta , f.estado, e.emp_nombre + ' ' + e.emp_apellido as empleado, c.cli_nombre + ' '+ c.cli_apellido as cliente, d.cantidad,a.descripcion, d.descuento, d.puni, d.total ";
                strSql += " from dbo.Factura f, dbo.Empleados e, dbo.Clientes c,  dbo.Factura_Detalle d, dbo.Articulos a ";
                strSql += " where f.empleadoid= e.emp_id and f.clienteid = c.cli_id and f.facturaid = d.facturaid and a.id = d.articuloid ";

            }

            else if (rbInformeDetallado.Checked && rbDetalladoMedioDePago.Checked)
            {
                strSql = " select f.facturaid, f.fechaalta , f.estado, e.emp_nombre + ' ' + e.emp_apellido as empleado, c.cli_nombre + ' '+ c.cli_apellido as cliente, a.numero_caja, m.descripcion, sum (p.importe) as total, p.mediopago, p.fecha ";
                strSql += " from dbo.Factura f, dbo.Empleados e, dbo.Clientes c,   dbo.Ventas_Pagos p, dbo.Medio_Pago m, Cierre_Caja a";
                strSql += " where f.empleadoid= e.emp_id  and f.clienteid = c.cli_id  and f.facturaid = ventas_id and p.mediopago = m.mediopago and p.cierrecajaid = a.cierrecajaid ";
            }
            else
            {
               /* strSql = " select f.facturaid, f.empleadoid, f.clienteid, f.subtotal as efectivo,f.ctacte as Ctacte, f.total, ";
                strSql += " (select sum(cantidad) from dbo.Factura_Detalle d where f.facturaid = d.facturaid) as cantidad ";
                strSql += " from dbo.Factura f       ";
                strSql += " LEFT OUTER JOIN dbo.Tarjetas_Detalle  t  ON f.facturaid = t.facturaid  ";
                strSql += " LEFT OUTER JOIN dbo.Cheques_Detalle  che  ON f.facturaid = che.facturaid,";
                strSql += " dbo.Empleados e, dbo.Clientes c,dbo.Factura_Detalle d   ";
                strSql += " where f.empleadoid= e.emp_id   ";
                strSql += " and f.clienteid = c.cli_id   ";
                strSql += " and f.facturaid = d.facturaid ";*/


                strSql = " select f.facturaid, f.empleadoid, f.clienteid, ";
                strSql += " isnull((select sum(importe) from dbo.Ventas_Pagos p where f.facturaid = p.ventas_id and p.fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaPagoDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaPagoHasta.Text + "')+1)";
                strSql += " ),0) as pagado,f.ctacte as Ctacte, f.total, ";
                strSql += "  (select sum(cantidad) from dbo.Factura_Detalle d where f.facturaid = d.facturaid) as cantidad ";
                strSql += " from dbo.Factura f, dbo.Empleados e, dbo.Clientes c,dbo.Factura_Detalle d ";
                strSql += " where f.empleadoid= e.emp_id   ";
                strSql += " and f.clienteid = c.cli_id   ";
                strSql += " and f.facturaid = d.facturaid ";

            }


            if (txtCodigoVenta.Text != "")
            {
                strSql += " and  f.facturaid " + cboCodigoVenta.Text + txtCodigoVenta.Text;
            }

            if (cboVendedor.Text != "")
            {
                strSql += " and  e.emp_id =" + cboVendedor.SelectedValue;
            }

            if (cboCliente.Text != "")
            {
                strSql += " and  c.cli_id =" + cboCliente.SelectedValue;
            }

            if (cboEstado.Text != "")
            {
                strSql += " and  f.estado = '" + cboEstado.Text + "'";
            }

            if (cboFaltaDePago.Text != "")
            {
                if (cboFaltaDePago.Text == "CON DEUDA")
                    strSql += " and  f.ctacte > 0";
                else
                    strSql += " and  f.ctacte = 0";

            }

            if (rbInformeDetallado.Checked && rbDetalladoMedioDePago.Checked)
            {
                strSql += " and p.fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaPagoDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaPagoHasta.Text + "')+1)";

            }
            strSql += " and f.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaVentaDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeVentaHasta.Text + "')+1)";


            if (txtCodigoArticulo.Text != "")
            {
                if (txtCodigoArticulo.Text.Length > 1)
                {
                    if (txtCodigoArticulo.Text.Substring(0, 2).Trim() == "20" && txtCodigoArticulo.Text.Trim().Length == 13) //Los dos primeros digitos tienen que se 20 y el ancho del codigo de barra tiene que ser de 12 digitos
                    {
                        //Si es un codigo de balanza electronica
                        strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and SUBSTRING(a.idextra,1,6)=  '" + txtCodigoArticulo.Text.Substring(0, 6) + "')";
                        if (cboCodigoArticulo.Text == "like")
                            strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and SUBSTRING(a.idextra,1,6) like '" + txtCodigoArticulo.Text.Substring(0, 6) + "%' )";
                        if (cboCodigoArticulo.Text == "path")
                            strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and SUBSTRING(a.idextra,1,6) like '%" + txtCodigoArticulo.Text.Substring(0, 6) + "%' )";
                    }
                }
                else
                {
                    strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and a.idextra=  '" + txtCodigoArticulo.Text + "')";
                    if (cboCodigoArticulo.Text == "like")
                        strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and a.idextra like '" + txtCodigoArticulo.Text + "%' )";
                    if (cboCodigoArticulo.Text == "path")
                        strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and a.idextra like '%" + txtCodigoArticulo.Text + "%' )";
                }
            }

            if (txtDescripcionArticulo.Text != "")
            {
                if (cboDescripcionArticulo.Text == "=")
                    strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d, dbo.Articulos a where a.id = d.articuloid and a.descripcion = '" + txtDescripcionArticulo.Text + "')";
                if (cboDescripcionArticulo.Text == "like")
                    strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d, dbo.Articulos a where a.id = d.articuloid and a.descripcion like '" + txtDescripcionArticulo.Text + "%' )";
                if (cboDescripcionArticulo.Text == "path")
                    strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d, dbo.Articulos a where a.id = d.articuloid and a.descripcion like '%" + txtDescripcionArticulo.Text + "%' )";

            }

            if (cboMedioPago.Text != "")
            {
                strSql += " and  p.mediopago =" + cboMedioPago.SelectedValue;
            }

            if (rbInformeDetallado.Checked && rbArticulosCantidadTotal.Checked)
            {
                strSql += " group by f.facturaid,f.fechaalta , f.estado, e.emp_nombre + ' ' + e.emp_apellido, c.cli_nombre + ' '+ c.cli_apellido, f.descuento, f.neto, f.efectivoabona,f.total,ctacte ";
            }            

            else
            {
                if (rbInformeDetallado.Checked && rbArticulosDetallado.Checked)
                {
                    strSql += " group by f.facturaid, f.fechaalta , f.estado, e.emp_nombre + ' ' + e.emp_apellido, c.cli_nombre + ' '+ c.cli_apellido , d.cantidad,a.descripcion, d.descuento, d.puni, d.total  ";
                }
                else if (rbInformeDetallado.Checked && rbDetalladoMedioDePago.Checked)
                {
                    strSql += " group by f.facturaid,f.fechaalta , f.estado, e.emp_nombre + ' ' + e.emp_apellido, c.cli_nombre + ' '+ c.cli_apellido, a.numero_caja, m.descripcion, p.mediopago, p.fecha   ";
                }
                else
                {
                    strSql += " group by f.facturaid, f.empleadoid, f.clienteid, f.subtotal,f.ctacte, f.total ";
                }
            }

            

            //Seteo los checks de ordenamiento
            if (rbInformeDetallado.Checked)
            {

                if (rbOrden2CantidadDeArticulos.Checked)
                    strSql += " order by cantidad";

                else if (rbOrden2Fecha.Checked)
                    strSql += " order by f.fechaalta";

                else if (rbOrden2MayorGanancia.Checked)
                    strSql += " order by total desc";

                else if (rbOrden2MenorGanancia.Checked)
                    strSql += " order by total asc";

                else if (rbOrden2NumeroFactura.Checked)
                    strSql += " order by f.facturaid asc";

            }

 


            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            ManejaVentas objManejaVentas = new ManejaVentas();
            frmReportes objfrmReporte;


            if (rbInformeDetallado.Checked && rbArticulosCantidadTotal.Checked)
            {
                objfrmReporte = new frmReportes("ReportePorCantidadDeArticulos.rdlc", objManejaVentas.ReporteDeCantidadTotalesDeArticulos(dt), "VentasReporte");
            }
            else if (rbInformeDetallado.Checked && rbArticulosDetallado.Checked)
            {

                objfrmReporte = new frmReportes("ReporteDetalladoPorArticulos.rdlc", objManejaVentas.ReporteDetalladoPorArticulos(dt), "VentasReporte");
            }
            else if (rbInformeDetallado.Checked && rbDetalladoMedioDePago.Checked)
            {
                objfrmReporte = new frmReportes("ReporteDetalladoPorMedioDePago.rdlc", objManejaVentas.ReporteDetalladoPorMedioDePago(dt), "VentasReporte");
            }
            else
            {
                objfrmReporte = new frmReportes("ReporteTotales.rdlc", objManejaVentas.ReporteTotales(dt, Convert.ToDateTime(dtpFechaVentaDesde.Text), Convert.ToDateTime(dtpFechadeVentaHasta.Text)), "VentasReporte");
            }



            objfrmReporte.Show();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboCliente.Text = "";
            cboCodigoArticulo.Text = "=";
            cboCodigoVenta.Text = "=";
            cboDescripcionArticulo.Text = "=";
            cboMedioPago.Text = "";
            cboVendedor.Text = "";
            txtCodigoArticulo.Text = "";
            txtCodigoVenta.Text = "";
            txtDescripcionArticulo.Text = "";
            cboEstado.Text = "CUMPLIDA";
            cboFaltaDePago.Text = "";
            dtpFechadeVentaHasta.Value = DateTime.Now;
            dtpFechaPagoHasta.Value = DateTime.Now;
            dtpFechaVentaDesde.Value = Convert.ToDateTime("01/01/1980");
            dtpFechaPagoDesde.Value = Convert.ToDateTime("01/01/1980");
            rbInformeDetallado.Checked = true;
            //rbArticulosDetallado.Checked = true;
            rbArticulosCantidadTotal.Checked = true;
            rbOrden2Fecha.Checked = true;
            cboMedioPago.Text = "";

        }

        private void frmVentasReportes_Load(object sender, EventArgs e)
        {
            cboCodigoArticulo.Text = "=";
            cboCodigoVenta.Text = "=";
            cboDescripcionArticulo.Text = "=";
            rbInformeDetallado.Checked = true;
            //rbArticulosDetallado.Checked = true;
            rbArticulosCantidadTotal.Checked = true;
            rbOrden2Fecha.Checked = true;
            dtpFechadeVentaHasta.Value = DateTime.Now;
            dtpFechaPagoHasta.Value = DateTime.Now;


            
            
        }

        private void rbInformeDetallado_CheckedChanged(object sender, EventArgs e)
        {
            rbOrden2Fecha.Checked = true;
            if (rbInformeDetallado.Checked)
            {
                //rbArticulosDetallado.Checked = true;
                rbArticulosCantidadTotal.Checked = true;
                rbArticulos.Visible = true;
                gbOrdenTotales.Visible = true;

            }
            else
            {
                rbArticulosDetallado.Checked = false;
                gbOrdenTotales.Visible = false;
                rbArticulos.Visible = false;
                rbOrden2Fecha.Checked = true;

            }


            if (rbDetalladoMedioDePago.Checked)
            {
                lblFechaDePago.Visible = true;
                lblFechadePagoHasta.Visible = true;
                dtpFechaPagoDesde.Visible = true;
                dtpFechaPagoHasta.Visible = true;

            }
            else
            {
                lblFechaDePago.Visible = false;
                lblFechadePagoHasta.Visible = false;
                dtpFechaPagoDesde.Visible = false;
                dtpFechaPagoHasta.Visible = false;
            }
        }

        private void txtCodigoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();

            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();
        }

        private void rbDetalladoMedioDePago_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDetalladoMedioDePago.Checked)
            {
                cboMedioPago.Visible = true;
                lblMedioDePago.Visible = true;
            }
            else
            {
                cboMedioPago.Visible = false;
                lblMedioDePago.Visible = false;
            }

            if (rbInformeTotales.Checked || rbDetalladoMedioDePago.Checked)
            {
                lblFechaDePago.Visible = true;
                lblFechadePagoHasta.Visible = true;
                dtpFechaPagoDesde.Visible = true;
                dtpFechaPagoHasta.Visible = true;

            }


        }

        private void rbArticulosDetallado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArticulosDetallado.Checked || rbArticulosCantidadTotal.Checked)
            {
                lblFechaDePago.Visible = false;
                lblFechadePagoHasta.Visible = false;
                dtpFechaPagoDesde.Visible = false;
                dtpFechaPagoHasta.Visible = false;
            }

        }

        private void rbArticulosCantidadTotal_CheckedChanged(object sender, EventArgs e)
        {

            if (rbArticulosDetallado.Checked || rbArticulosCantidadTotal.Checked)
            {
                lblFechaDePago.Visible = false;
                lblFechadePagoHasta.Visible = false;
                dtpFechaPagoDesde.Visible = false;
                dtpFechaPagoHasta.Visible = false;
            }
        }

        private void rbInformeTotales_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInformeTotales.Checked || rbDetalladoMedioDePago.Checked)
            {
                lblFechaDePago.Visible = true;
                lblFechadePagoHasta.Visible = true;
                dtpFechaPagoDesde.Visible = true;
                dtpFechaPagoHasta.Visible = true;

            }
        }

    }
}
