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
    public partial class frmCierreCajaReporte : Form
    {
        CombosStandard objCombosStandard;
        public frmCierreCajaReporte()
        {
            InitializeComponent();
            CargoCombos();
            dtpFechadeAperturaHasta.Value = DateTime.Now;
            dtpFechadeCierreHasta.Value = DateTime.Now;
        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
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

            strSql = "select c.cierrecajaid, c.fecha, c.fecha_apertura, u1.nombre_apellido as usuario_apertura, isnull(c.total,0) total,  c.fecha_cierre,u2.nombre_apellido as usuario_cierre, isnull(c.total_cierre,0) total_cierre, c.numero_caja ";
            strSql += " from Usuarios u1,Cierre_caja c LEFT JOIN Usuarios u2 ON u2.id = c.usuario_cierre ";
            strSql += " where u1.id = c.usuario_apertura ";


            if (cboNumeroCaja.Text != "")
            {
                strSql += " and c.numero_caja = " + cboNumeroCaja.Text;
            }

            if (cboEstado.Text != "")
            {
                if (cboEstado.Text == "ABIERTA")
                {
                    strSql += " and c.fecha_cierre is null ";                    
                }
                else
                {
                    strSql += " and c.fecha_cierre between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeCierreDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeCierreHasta.Text + "') +1)";

                }
            }

            strSql += " and c.fecha_apertura between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaAperturaDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeAperturaHasta.Text + "') +1)";



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
                    gridBuscarCliente[0, i].Value = dt.Rows[i]["cierrecajaid"].ToString();
                    gridBuscarCliente[1, i].Value = dt.Rows[i]["fecha"].ToString();
                    gridBuscarCliente[2, i].Value = dt.Rows[i]["numero_caja"].ToString();
                    gridBuscarCliente[3, i].Value = dt.Rows[i]["fecha_apertura"].ToString();
                    gridBuscarCliente[4, i].Value = dt.Rows[i]["usuario_apertura"].ToString();
                    gridBuscarCliente[5, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString())));
                    gridBuscarCliente[6, i].Value = dt.Rows[i]["fecha_cierre"].ToString();
                    gridBuscarCliente[7, i].Value = dt.Rows[i]["usuario_cierre"].ToString();
                    gridBuscarCliente[8, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["total_cierre"].ToString())));
                    this.gridBuscarCliente.Columns[0].Visible = false;
                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridBuscarCliente.DataSource = null;
            gridBuscarCliente.Rows.Clear();
            gridBuscarCliente.Columns.Clear();
            gridBuscarCliente.Columns.Add("ID", null);
            gridBuscarCliente.Columns.Add("Fecha", null);
            gridBuscarCliente.Columns.Add("Caja", null);
            gridBuscarCliente.Columns.Add("Fecha Apertura", null);
            gridBuscarCliente.Columns.Add("Usuario Apertura", null);
            gridBuscarCliente.Columns.Add("Total Inicio", null);
            gridBuscarCliente.Columns.Add("Fecha Cierre", null);
            gridBuscarCliente.Columns.Add("Usuario Cierre", null);
            gridBuscarCliente.Columns.Add("Total Cierre", null);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechadeCierreHasta.Value = DateTime.Now;
            dtpFechadeAperturaHasta.Value = DateTime.Now;
            dtpFechaAperturaDesde.Value = Convert.ToDateTime("01/01/2013");
            dtpFechadeCierreDesde.Value = Convert.ToDateTime("01/01/2013");
            cboNumeroCaja.Text = "";
            cboNumeroCaja.SelectedIndex = -1;
            cboEstado.Text = "";
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstado.Text == "CERRADA")
            {
                lblFechaDeCierreDesde.Visible = true;
                lblFechaDeCierreHasta.Visible = true;
                dtpFechadeCierreDesde.Visible = true;
                dtpFechadeCierreHasta.Visible = true;
            }
            else
            {
                lblFechaDeCierreDesde.Visible = false;
                lblFechaDeCierreHasta.Visible = false;
                dtpFechadeCierreDesde.Visible = false;
                dtpFechadeCierreHasta.Visible = false;
            }

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
                int intCodigo = Convert.ToInt32(gridBuscarCliente.CurrentRow.Cells[0].Value.ToString());
                frmCierreCaja objfrmCierreCaja = new frmCierreCaja(intCodigo);
                if (frmLogin.PermiteEntrar("CAJA", "CAJA_CIERRE"))
                {
                    objfrmCierreCaja.Show();
                    objfrmCierreCaja.Activate();
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
