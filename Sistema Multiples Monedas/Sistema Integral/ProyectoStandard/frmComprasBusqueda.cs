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
    public partial class frmComprasBusqueda : Form
    {
        CombosStandard objCombosStandard;

        public frmComprasBusqueda()
        {
            InitializeComponent();
            CargoCombos();
            dtpFechadeCompraHasta.Value = DateTime.Now;

        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarProveedores(cboProveedor, null);
            objCombosStandard.CargarNumeroCaja(cboNumeroCaja);
            cboNumeroCaja.SelectedIndex = -1;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }


        private void Buscar()
        {
            CargoGrilla();

        }


        private void CargoGrilla()
        {

            gridBuscarCliente.DataSource = null;
            string strSql;

            strSql = "select  c.compraid,c.nrofactura,p.razonsocial,c.total, c.fechaalta ";
            strSql += " from dbo.Proveedores p ,compras c  left join Cierre_caja a  on  a.cierrecajaid = c.cierrecajaid";//, Cierre_caja a ";
            strSql += " where c.proveedorid=p.id and c.fechabaja is null";// and a.cierrecajaid = c.cierrecajaid ";


            if (txtCodigoCompra.Text != "")
            {
                if (cboCodigoCompra.Text == "=")
                    strSql += " and c.nrofactura =  '" + txtCodigoCompra.Text + "'";
                if (cboCodigoCompra.Text == "like")
                    strSql += " and c.nrofactura like '" + txtCodigoCompra.Text + "%' ";
                if (cboCodigoCompra.Text == "path")
                    strSql += " and c.nrofactura like '%" + txtCodigoCompra.Text + "%' ";

            }


            if (cboProveedor.Text != "")
            {
                strSql += " and  p.id  =" + cboProveedor.SelectedValue;
            }


            //if (cboNumeroCaja.Text != "")
            //{
            //    strSql += " and a.numero_caja = " + cboNumeroCaja.Text;
            //} 


            strSql += " and c.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaCompraDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeCompraHasta.Text + "'))";




           // strSql += " group by f.facturaid, f.fechaalta ,f.ubicacion, f.estado, e.emp_nombre + ' ' + e.emp_apellido , c.cli_nombre + ' '+ c.cli_apellido , f.total  ";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridBuscarCliente.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridBuscarCliente.Rows.Add();
                    gridBuscarCliente[0, i].Value = dt.Rows[i]["compraid"].ToString();
                    gridBuscarCliente[1, i].Value = dt.Rows[i]["nrofactura"].ToString();
                    gridBuscarCliente[2, i].Value = dt.Rows[i]["razonsocial"].ToString();
                    gridBuscarCliente[3, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString())));
                    gridBuscarCliente[4, i].Value = dt.Rows[i]["fechaalta"].ToString();
                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridBuscarCliente.DataSource = null;
            gridBuscarCliente.Rows.Clear();
            gridBuscarCliente.Columns.Clear();
            gridBuscarCliente.Columns.Add("Compra", null);
            gridBuscarCliente.Columns.Add("Factura", null);
            gridBuscarCliente.Columns.Add("Proveedor", null);
            gridBuscarCliente.Columns.Add("Total", null);
            gridBuscarCliente.Columns.Add("Fecha", null);

        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            cboCodigoCompra.Text = "=";
            cboProveedor.Text = "";
            txtCodigoCompra.Text = "";
            dtpFechadeCompraHasta.Value = DateTime.Now;
            dtpFechaCompraDesde.Value = Convert.ToDateTime("01/01/2013");
            cboNumeroCaja.Text = "";
            cboNumeroCaja.SelectedIndex = -1;
        }

        private void txtCodigoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();

            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void frmComprasBusqueda_Load(object sender, EventArgs e)
        {

            cboCodigoCompra.Text = "=";

        }

        private void gridBuscarClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBuscarCliente.RowCount > 0)
            {
                /* if (boOtraPantalla)
                 {
                     intCodigo = Convert.ToInt32(gridBuscarClientes.CurrentRow.Cells[0].Value.ToString());
                     this.Close();
                 }
                 else
                 {*/
                ManejaCompras objManejaCompras = new ManejaCompras();
                int intCodigo = Convert.ToInt32(gridBuscarCliente.CurrentRow.Cells[0].Value.ToString());

                Compras objCompras = objManejaCompras.BuscarCompras(intCodigo);
                frmCompras objfrmCompras = new frmCompras(objCompras);
                if (frmLogin.PermiteEntrar("COMPRAS", "COMPRAS_NUEVO"))
                {
                    objfrmCompras.Show();
                    objfrmCompras.Activate();
                    CargoGrilla();
                }


                //}
            }
        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            string strSql;

            strSql = "select c.fechaalta,c.nrofactura,p.id, p.razonsocial,c.total ";
            strSql += " from compras c, dbo.Proveedores p ";
            strSql += " where c.proveedorid=p.id and c.fechabaja is null ";


            if (txtCodigoCompra.Text != "")
            {
                if (cboCodigoCompra.Text == "=")
                    strSql += " and c.nrofactura =  '" + txtCodigoCompra.Text + "')";
                if (cboCodigoCompra.Text == "like")
                    strSql += " and c.nrofactura like '" + txtCodigoCompra.Text + "%' )";
                if (cboCodigoCompra.Text == "path")
                    strSql += " and c.nrofactura like '%" + txtCodigoCompra.Text + "%' )";

            }


            if (cboProveedor.Text != "")
            {
                strSql += " and  p.id  =" + cboProveedor.SelectedValue;
            }



            strSql += " and c.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaCompraDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeCompraHasta.Text + "'))";




            // strSql += " group by f.facturaid, f.fechaalta ,f.ubicacion, f.estado, e.emp_nombre + ' ' + e.emp_apellido , c.cli_nombre + ' '+ c.cli_apellido , f.total  ";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            ManejaCompras objManejaCompras = new ManejaCompras();
            frmReportes objfrmReporte;
            objfrmReporte = new frmReportes("ReporteCompras.rdlc", objManejaCompras.ReporteDeCompras(dt),"ComprasReporte");
            objfrmReporte.Show();
        }



    }
}
