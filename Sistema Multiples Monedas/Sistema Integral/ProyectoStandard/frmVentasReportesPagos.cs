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
    public partial class frmVentasReportesPagos : Form
    {
        CombosStandard objCombosStandard;

        public frmVentasReportesPagos()
        {
            InitializeComponent();
            CargoCombos();
            cboEstado.Text = "CUMPLIDA";
            ckPagos.Checked = true;
            ckDevoluciones.Checked = true;
        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarEmpleados(cboVendedor, null);
            objCombosStandard.CargarClientes(cboCliente, null);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            CargoDatos();

        }

        private string ArmoDevoluciones()
        {
            string strSql = "";
            strSql = " select 'DEVOLUCION' tipo, d.devolucionid as facturaid, fechaalta as fecha, total as importe ";
            strSql += " from Devoluciones d, Empleados e, Clientes c   ";
            strSql += " where d.empleadoid=e.emp_id ";
            strSql += " and d.clienteid=c.cli_id ";


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
                strSql += " and  d.estado = '" + cboEstado.Text + "'";
            }


            strSql += " and d.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaVentaDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeVentaHasta.Text + "')+1)";


            if (txtCodigoArticulo.Text != "")
            {
                strSql += " and d.devolucionid in (select e.devolucionid from dbo.Devoluciones_Detalle e,dbo.Articulos a where e.articuloid=a.id and a.idextra=  '" + txtCodigoArticulo.Text + "')";
                if (cboCodigoArticulo.Text == "like")
                    strSql += " and d.devolucionid  in (select e.devolucionid from dbo.Devoluciones_Detalle e,dbo.Articulos a where e.articuloid=a.id and a.idextra like '" + txtCodigoArticulo.Text + "%' )";
                if (cboCodigoArticulo.Text == "path")
                    strSql += " and d.devolucionid  in (select e.devolucionid from dbo.Devoluciones_Detalle e,dbo.Articulos a where e.articuloid=a.id and a.idextra '%" + txtCodigoArticulo.Text + "%' )";
            }

            if (txtDescripcionArticulo.Text != "")
            {
                if (cboDescripcionArticulo.Text == "=")
                    strSql += " and d.devolucionid  in (select e.devolucionid from dbo.Devoluciones_Detalle e,dbo.Articulos a where e.articuloid=a.id and a.descripcion = '" + txtDescripcionArticulo.Text + "')";
                if (cboDescripcionArticulo.Text == "like")
                    strSql += " and d.devolucionid  in (select e.devolucionid from dbo.Devoluciones_Detalle e,dbo.Articulos a where e.articuloid=a.id and a.descripcion like '" + txtDescripcionArticulo.Text + "%' )";
                if (cboDescripcionArticulo.Text == "path")
                    strSql += " and d.devolucionid  in (select e.devolucionid from dbo.Devoluciones_Detalle e,dbo.Articulos a where e.articuloid=a.id and a.descripcion like '%" + txtDescripcionArticulo.Text + "%' )";

            }
            return strSql;
        }

        private string ArmoPagos()
        {
            string strSql = "";
            strSql = " select 'FACTURA' tipo,facturaid, p.fecha,importe ";
            strSql += " from dbo.Factura f,  Ventas_Pagos p, Empleados e, Clientes c ";
            strSql += " where f.facturaid = p.ventas_id ";
            strSql += " and f.empleadoid=e.emp_id";
            strSql += " and f.clienteid=c.cli_id";

            //if (txtCodigoVenta.Text != "")
            //{
            //    strSql += " and  f.facturaid " + cboCodigoVenta.Text + txtCodigoVenta.Text;
            //}

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


            strSql += " and p.fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaVentaDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeVentaHasta.Text + "')+1)";


            if (txtCodigoArticulo.Text != "")
            {
                strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and a.idextra=  '" + txtCodigoArticulo.Text + "')";
                if (cboCodigoArticulo.Text == "like")
                    strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and a.idextra like '" + txtCodigoArticulo.Text + "%' )";
                if (cboCodigoArticulo.Text == "path")
                    strSql += " and f.facturaid in (select d.facturaid from  dbo.Factura_Detalle d,dbo.Articulos a where d.articuloid=a.id and a.idextra like '%" + txtCodigoArticulo.Text + "%' )";
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
            return strSql;
        }

        private void CargoDatos()
        {


            string strSql = "";


            strSql = "select * from (";
            if (ckPagos.Checked)
            {
                strSql += ArmoPagos();

                if (ckDevoluciones.Checked)
                {
                    strSql += " UNION ";
                    strSql += ArmoDevoluciones();

                }
            }
            else
            {
                strSql += ArmoDevoluciones();

            }

            strSql += " ) tabla order by fecha";



            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            ManejaVentas objManejaVentas = new ManejaVentas();
            frmReportes objfrmReporte;


            objfrmReporte = new frmReportes("ReportePagosDevoluciones.rdlc", objManejaVentas.ReporteDePagosDevoluciones(dt), "VentasReportePago");




            objfrmReporte.Show();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboCliente.Text = "";
            cboCodigoArticulo.Text = "=";
            cboDescripcionArticulo.Text = "=";
            cboVendedor.Text = "";
            txtCodigoArticulo.Text = "";
            txtDescripcionArticulo.Text = "";
            cboEstado.Text = "CUMPLIDA";
            ckPagos.Checked = true;
            ckDevoluciones.Checked = true;

            dtpFechadeVentaHasta.Value = DateTime.Now;
            dtpFechaVentaDesde.Value = Convert.ToDateTime("01/01/1980");
            //rbArticulosDetallado.Checked = true;

        }

        private void frmVentasReportesPagos_Load(object sender, EventArgs e)
        {
            cboCodigoArticulo.Text = "=";
            cboDescripcionArticulo.Text = "=";
            //rbArticulosDetallado.Checked = true;

            dtpFechadeVentaHasta.Value = DateTime.Now;
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
    }
}
