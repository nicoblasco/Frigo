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
    public partial class frmVentasBusqueda : Form
    {
        CombosStandard objCombosStandard;

        public frmVentasBusqueda()
        {
            InitializeComponent();
            CargoCombos();
            dtpFechadeVentaHasta.Value = DateTime.Now;

        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarEmpleados(cboVendedor,null);
            objCombosStandard.CargarClientes(cboCliente,null);
            objCombosStandard.CargarDiccionario(cboUbicacion, "UBICACION");
            objCombosStandard.CargarMedioDePago(cboMedioPago);
            objCombosStandard.CargarNumeroCaja(cboNumeroCaja);
            cboMedioPago.SelectedIndex = -1;
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
            
            gridBuscarClientes.DataSource = null;
            string strSql;

            strSql = "select f.facturaid, f.fechaalta ,f.ubicacion, f.estado, e.emp_nombre + ' ' + e.emp_apellido as empleado, c.cli_nombre + ' '+ c.cli_apellido as cliente, f.total ";
            strSql += " from dbo.Factura f, dbo.Empleados e, dbo.Clientes c LEFT OUTER JOIN  dbo.Contactos_cliente o  ON c.cli_id = o.cli_id  ";
            strSql += " where f.empleadoid= e.emp_id and f.clienteid = c.cli_id ";


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

            if (cboUbicacion.Text != "")
            {
                strSql += " and  f.ubicacion = '" + cboUbicacion.Text + "'";
            }

            if (txtTelefono.Text != "")
            {
                strSql += " and  o.cc_tel = '" + txtTelefono.Text + "'";

            }

            if (txtInterno.Text != "")
            {
                strSql += " and  o.interno = '" + txtInterno.Text + "'";

            }

            strSql += " and f.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaVentaDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeVentaHasta.Text + "')+1)";


            if (txtCodigoArticulo.Text != "")
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
                strSql += " and " + cboMedioPago.SelectedValue + " in (select p.mediopago from dbo.Ventas_Pagos p where f.facturaid = p.ventas_id) ";
            } 
            
            if (cboNumeroCaja.Text != "")
            {
                strSql += " and "+  cboNumeroCaja.Text +" in (select a.numero_caja from dbo.Ventas_Pagos p, Cierre_caja a where f.facturaid = p.ventas_id and a.cierrecajaid = p.cierrecajaid) " ;
            } 




            strSql += " group by f.facturaid, f.fechaalta ,f.ubicacion, f.estado, e.emp_nombre + ' ' + e.emp_apellido , c.cli_nombre + ' '+ c.cli_apellido , f.total  ";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridBuscarClientes.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridBuscarClientes.Rows.Add();
                    gridBuscarClientes[0, i].Value = dt.Rows[i]["facturaid"].ToString();
                    gridBuscarClientes[1, i].Value = dt.Rows[i]["fechaalta"].ToString();
                    gridBuscarClientes[2, i].Value = dt.Rows[i]["ubicacion"].ToString();
                    gridBuscarClientes[3, i].Value = dt.Rows[i]["estado"].ToString();
                    gridBuscarClientes[4, i].Value = dt.Rows[i]["empleado"].ToString();
                    gridBuscarClientes[5, i].Value = dt.Rows[i]["cliente"].ToString();
                    gridBuscarClientes[6, i].Value = Convert.ToString(Redondeo( Convert.ToDecimal( dt.Rows[i]["total"].ToString())));
                    if (dt.Rows[i]["estado"].ToString()=="CUMPLIDA")                    
                        gridBuscarClientes.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;
                    if (dt.Rows[i]["estado"].ToString() == "PENDIENTE")
                        gridBuscarClientes.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    if (dt.Rows[i]["estado"].ToString() == "CANCELADA")
                        gridBuscarClientes.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridBuscarClientes.DataSource = null;
            gridBuscarClientes.Rows.Clear();
            gridBuscarClientes.Columns.Clear();
            gridBuscarClientes.Columns.Add("Factura", null);
            gridBuscarClientes.Columns.Add("Fecha", null);
            gridBuscarClientes.Columns.Add("Ubicacion", null);
            gridBuscarClientes.Columns.Add("Estado", null);
            gridBuscarClientes.Columns.Add("Empleado", null);
            gridBuscarClientes.Columns.Add("Cliente", null);
            gridBuscarClientes.Columns.Add("Total", null);
            //this.gridBuscarClientes.Columns[8].Visible = false;
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
            txtDescripcionArticulo.Text="";
            cboEstado.Text = "";
            cboFaltaDePago.Text = "";
            cboUbicacion.Text = "";
            txtTelefono.Text = "";
            txtInterno.Text = "";
            dtpFechadeVentaHasta.Value = DateTime.Now;
            dtpFechaVentaDesde.Value = Convert.ToDateTime("01/01/1980");
            cboMedioPago.Text = "";
            cboMedioPago.SelectedIndex =- 1;
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

        private void txtCodigoArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();
        }

        private void frmVentasBusqueda_Load(object sender, EventArgs e)
        {
            cboCodigoArticulo.Text = "=";
            cboCodigoVenta.Text = "=";
            cboDescripcionArticulo.Text = "=";
        }

        private void gridBuscarClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBuscarClientes.RowCount > 0)
            {
               /* if (boOtraPantalla)
                {
                    intCodigo = Convert.ToInt32(gridBuscarClientes.CurrentRow.Cells[0].Value.ToString());
                    this.Close();
                }
                else
                {*/
                    ManejaVentas objManejaVentas = new ManejaVentas();
                    int intCodigo = Convert.ToInt32(gridBuscarClientes.CurrentRow.Cells[0].Value.ToString());

                    Ventas objVentas = objManejaVentas.BuscarVentas(intCodigo);
                    frmVentas objfrmVentas = new frmVentas(objVentas);
                    if (frmLogin.PermiteEntrar("VENTAS", "VENTA_NUEVA"))
                    {
                        objfrmVentas.Show();
                        objfrmVentas.Activate();
                        CargoGrilla();
                    }

                        

                //}
            }
        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }
    }
}
