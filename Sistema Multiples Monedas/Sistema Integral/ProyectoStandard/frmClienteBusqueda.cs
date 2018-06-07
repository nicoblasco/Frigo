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
    public partial class frmClienteBusqueda : Form
    {
        bool boOtraPantalla;
        public int intCodigo;

        public frmClienteBusqueda(bool boOtraPantalla, string strTexto)
        {
            InitializeComponent();
            this.boOtraPantalla = boOtraPantalla;
            txtNombre.Text = strTexto;
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
            gridBuscarClientes.DataSource = null;
            string strSql;

            strSql = "select c.cli_id,c.cli_fding,c.cli_documento,c.cli_nombre,c.cli_apellido,c.cli_direccion,c.cli_nro,lo.prov_desc ";
            strSql += " from dbo.Clientes c LEFT OUTER JOIN  dbo.Contactos_cliente o  ON c.cli_id = o.cli_id ,dbo.Localidades lo";
            strSql += " where c.loc_id=lo.loc_id and c.fechabaja is null";


            if (txtCodigo.Text != "")
            {
                strSql += " and c.cli_id " + cboCodigo.Text + txtCodigo.Text;
            }

            if (txtNombre.Text != "")
            {
                if (cboNombre.Text == "=")
                    strSql += " and  c.cli_nombre = '" + txtNombre.Text + "'";
                if (cboNombre.Text == "like")
                    strSql += " and  c.cli_nombre like '" + txtNombre.Text + "%' ";
                if (cboNombre.Text == "path")
                    strSql += " and  c.cli_nombre like '%" + txtNombre.Text + "%' ";

            }

            if (txtApellido.Text != "")
            {
                if (cboApellido.Text == "=")
                    strSql += " and  c.cli_apellido = '" + txtApellido.Text + "'";
                if (cboApellido.Text == "like")
                    strSql += " and  c.cli_apellido like '" + txtApellido.Text + "%' ";
                if (cboApellido.Text == "path")
                    strSql += " and  c.cli_apellido like '%" + txtApellido.Text + "%' ";

            }

            if (txtTelefono.Text != "")
            {
                strSql += " and  o.cc_tel = '" + txtTelefono.Text + "'";

            }

            if (txtInterno.Text != "")
            {
                strSql += " and  o.interno = '" + txtInterno.Text + "'";

            }

            if (txtDni.Text != "")
            {
                strSql += " and  c.cli_documento " + cboTipoDoc.Text + txtDni.Text;
            }
            strSql += " and c.cli_fding between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaIngresoDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeIngresoHasta.Text + "'))";
            strSql += " group by c.cli_id,c.cli_fding,c.cli_documento,c.cli_nombre,c.cli_apellido,c.cli_direccion,c.cli_nro,lo.prov_desc ";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridBuscarClientes.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridBuscarClientes.Rows.Add();
                    gridBuscarClientes[0, i].Value = dt.Rows[i]["cli_id"].ToString();
                    gridBuscarClientes[1, i].Value = dt.Rows[i]["cli_fding"].ToString();
                    gridBuscarClientes[2, i].Value = dt.Rows[i]["cli_documento"].ToString();
                    gridBuscarClientes[3, i].Value = dt.Rows[i]["cli_nombre"].ToString() + " " + dt.Rows[i]["cli_apellido"].ToString();
                    gridBuscarClientes[4, i].Value = dt.Rows[i]["cli_direccion"].ToString();
                    gridBuscarClientes[5, i].Value = dt.Rows[i]["cli_nro"].ToString();
                    gridBuscarClientes[6, i].Value = dt.Rows[i]["prov_desc"].ToString();

                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridBuscarClientes.DataSource = null;
            gridBuscarClientes.Rows.Clear();
            gridBuscarClientes.Columns.Clear();
            gridBuscarClientes.Columns.Add("ID", null);
            gridBuscarClientes.Columns.Add("Fech.Ingreso", null);
            gridBuscarClientes.Columns.Add("DNI", null);
            gridBuscarClientes.Columns.Add("Nombre y Apellido", null);
            gridBuscarClientes.Columns.Add("Direccion", null);
            gridBuscarClientes.Columns.Add("Numero", null);
            gridBuscarClientes.Columns.Add("Localidad", null);
            
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

        private void frmClienteBusqueda_Load(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboApellido.Text = "=";
            cboNombre.Text = "=";
            cboTipoDoc.Text = "=";
        }

        private void gridBuscarClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBuscarClientes.RowCount > 0)
            {
                if (boOtraPantalla)
                {
                    intCodigo = Convert.ToInt32(gridBuscarClientes.CurrentRow.Cells[0].Value.ToString());
                    this.Close();
                }
                else
                {
                    ManejaClientes objManejaClientes = new ManejaClientes();
                    int intCodigo = Convert.ToInt32(gridBuscarClientes.CurrentRow.Cells[0].Value.ToString());
                    Clientes objClientes = objManejaClientes.BuscarCliente(intCodigo);
                    frmClientes objfrmClienteAlta = new frmClientes(objClientes);
                    if (frmLogin.PermiteEntrar("CLIENTES", "CLIENTES_NUEVO"))
                    {
                        objfrmClienteAlta.Show();
                        objfrmClienteAlta.Activate();
                        CargoGrilla();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboApellido.Text = "=";
            cboNombre.Text = "=";
            cboTipoDoc.Text = "=";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtInterno.Text = "";
            txtTelefono.Text = "";
            dtpFechadeIngresoHasta.Value = DateTime.Now;
            dtpFechaIngresoDesde.Value = Convert.ToDateTime ("01/01/1980");
        }
    }
}
