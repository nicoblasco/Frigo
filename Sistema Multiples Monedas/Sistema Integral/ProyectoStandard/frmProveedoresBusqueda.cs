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
    public partial class frmProveedoresBusqueda : Form
    {
        bool boOtraPantalla;
        public int intCodigo;
        CombosStandard objCombosStandard;

        public frmProveedoresBusqueda(bool boOtraPantalla, string strTexto)
        {
            InitializeComponent();
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarDiccionario(cboServicios, "PRODUCTOS/SERVICIOS");
            cboServicios.SelectedIndex = -1;
            this.boOtraPantalla = boOtraPantalla;
            txtRazonSocial.Text = strTexto;
            dtpFechadeIngresoHasta.Value = DateTime.Now;

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
            gridBuscarProveedores.DataSource = null;
            string strSql;

            strSql = "select c.id,c.fding,c.documento,c.razonsocial,c.direccion,c.nro,lo.prov_desc, servicios ";
            strSql += " from dbo.Proveedores c,dbo.Localidades lo";
            strSql += " where c.loc_id=lo.loc_id and fechabaja is null";


            if (txtCodigo.Text != "")
            {
                strSql += " and c.id " + cboCodigo.Text + txtCodigo.Text;
            }

            if (txtRazonSocial.Text != "")
            {
                if (cboRazonSocial.Text == "=")
                    strSql += " and  c.razonsocial = '" + txtRazonSocial.Text + "'";
                if (cboRazonSocial.Text == "like")
                    strSql += " and  c.razonsocial like '" + txtRazonSocial.Text + "%' ";
                if (cboRazonSocial.Text == "path")
                    strSql += " and  c.razonsocial like '%" + txtRazonSocial.Text + "%' ";

            }

            if (cboServicios.Text != "")
            {
                    strSql += " and  c.servicios = '" + cboServicios.Text + "'";

            }

            if (txtDni.Text != "")
            {
                strSql += " and  c.cli_documento " + cboTipoDoc.Text + txtDni.Text;
            }
            strSql += " and c.fding between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaIngresoDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeIngresoHasta.Text + "'))";

            if (ckLunes.Checked == true)
            {
                strSql += " and  c.lunes = 1 ";
            }
            /*else
            {
                strSql += " and  c.lunes = 0 ";
            }*/

            if (ckMartes.Checked == true)
            {
                strSql += " and  c.martes = 1 ";
            }
            /*else
            {
                strSql += " and  c.martes = 0 ";
            }*/

            if (ckMiercoles.Checked == true)
            {
                strSql += " and  c.miercoles = 1 ";
            }
            /*else
            {
                strSql += " and  c.miercoles = 0 ";
            }*/


            if (ckJueves.Checked == true)
            {
                strSql += " and  c.jueves = 1 ";
            }
            /*else
            {
                strSql += " and  c.jueves = 0 ";
            }*/

            if (ckViernes.Checked == true)
            {
                strSql += " and  c.viernes = 1 ";
            }
            /*else
            {
                strSql += " and  c.viernes = 0 ";
            }*/

            if (ckSabado.Checked == true)
            {
                strSql += " and  c.sabado = 1 ";
            }
            /*else
            {
                strSql += " and  c.sabado = 0 ";
            }*/
            if (ckDomingo.Checked == true)
            {
                strSql += " and  c.domingo = 1 ";
            }
            /*else
            {
                strSql += " and  c.domingo = 0 ";
            }
            */

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridBuscarProveedores.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridBuscarProveedores.Rows.Add();
                    gridBuscarProveedores[0, i].Value = dt.Rows[i]["id"].ToString();
                    gridBuscarProveedores[1, i].Value = dt.Rows[i]["fding"].ToString();
                    gridBuscarProveedores[2, i].Value = dt.Rows[i]["documento"].ToString();
                    gridBuscarProveedores[3, i].Value = dt.Rows[i]["razonsocial"].ToString();
                    gridBuscarProveedores[4, i].Value = dt.Rows[i]["direccion"].ToString();
                    gridBuscarProveedores[5, i].Value = dt.Rows[i]["nro"].ToString();
                    gridBuscarProveedores[6, i].Value = dt.Rows[i]["prov_desc"].ToString();
                    gridBuscarProveedores[7, i].Value = dt.Rows[i]["servicios"].ToString();

                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridBuscarProveedores.DataSource = null;
            gridBuscarProveedores.Rows.Clear();
            gridBuscarProveedores.Columns.Clear();
            gridBuscarProveedores.Columns.Add("ID", null);
            gridBuscarProveedores.Columns.Add("Fech.Ingreso", null);
            gridBuscarProveedores.Columns.Add("DNI", null);
            gridBuscarProveedores.Columns.Add("Razon Social", null);
            gridBuscarProveedores.Columns.Add("Direccion", null);
            gridBuscarProveedores.Columns.Add("Nro  ", null);
            gridBuscarProveedores.Columns.Add("Localidad", null);
            gridBuscarProveedores.Columns.Add("Servicio", null);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();

            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void dtpFechaIngresoDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Buscar();
        }

        private void frmProveedoresBusqueda_Load(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboRazonSocial.Text = "=";
            cboTipoDoc.Text = "=";
            if (!(String.IsNullOrEmpty(txtRazonSocial.Text)))
                Buscar();
        }

        private void gridBuscarProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBuscarProveedores.RowCount > 0)
            {
                if (boOtraPantalla)
                {
                    intCodigo = Convert.ToInt32(gridBuscarProveedores.CurrentRow.Cells[0].Value.ToString());
                    this.Close();
                }
                else
                {
                    ManejaProveedores objManejaProveedores = new ManejaProveedores();
                    int intCodigo = Convert.ToInt32(gridBuscarProveedores.CurrentRow.Cells[0].Value.ToString());
                    Proveedores objProveedores = objManejaProveedores.BuscarProveedores(intCodigo);
                    frmProveedores objFrmProveedores = new frmProveedores(objProveedores);
                    if (frmLogin.PermiteEntrar("PROVEEDORES", "PROVEEDORES_NUEVO"))
                    {
                        objFrmProveedores.Show();
                        objFrmProveedores.Activate();
                        CargoGrilla();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboRazonSocial.Text = "=";
            cboTipoDoc.Text = "=";
            txtCodigo.Text = "";
            txtRazonSocial.Text = "";
            txtDni.Text = "";
            cboServicios.Text = "";
            cboServicios.SelectedIndex = -1;
            dtpFechadeIngresoHasta.Value = DateTime.Now;
            dtpFechaIngresoDesde.Value = Convert.ToDateTime("01/01/1980");
            ckDomingo.Checked = false;
            ckJueves.Checked = false;
            ckLunes.Checked = false;
            ckMartes.Checked = false;
            ckMiercoles.Checked = false;
            ckSabado.Checked = false;
            ckViernes.Checked = false;
            
        }



    }
}
