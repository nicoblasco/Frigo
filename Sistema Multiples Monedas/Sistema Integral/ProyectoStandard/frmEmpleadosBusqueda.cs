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
    public partial class frmEmpleadosBusqueda : Form
    {
        bool boOtraPantalla;
        public int intCodigo;
        public frmEmpleadosBusqueda(bool boOtraPantalla, string strTexto)
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
            gridBuscarEmpleados.DataSource = null;
            string strSql;

            strSql = "select c.emp_id,c.emp_fding,c.emp_documento,c.emp_nombre,c.emp_apellido,c.emp_direccion,c.emp_nro,lo.prov_desc ";
            strSql += " from dbo.Empleados c,dbo.Localidades lo";
            strSql += " where c.loc_id=lo.loc_id and c.fechabaja is null";


            if (txtCodigo.Text != "")
            {
                strSql += " and c.emp_id " + cboCodigo.Text + txtCodigo.Text;
            }

            if (txtNombre.Text != "")
            {
                if (cboNombre.Text == "=")
                    strSql += " and  c.emp_nombre = '" + txtNombre.Text + "'";
                if (cboNombre.Text == "like")
                    strSql += " and  c.emp_nombre like '" + txtNombre.Text + "%' ";
                if (cboNombre.Text == "path")
                    strSql += " and  c.emp_nombre like '%" + txtNombre.Text + "%' ";

            }

            if (txtApellido.Text != "")
            {
                if (cboApellido.Text == "=")
                    strSql += " and  c.emp_apellido = '" + txtApellido.Text + "'";
                if (cboApellido.Text == "like")
                    strSql += " and  c.emp_apellido like '" + txtApellido.Text + "%' ";
                if (cboApellido.Text == "path")
                    strSql += " and  c.emp_apellido like '%" + txtApellido.Text + "%' ";

            }

            if (txtDni.Text != "")
            {
                strSql += " and  c.emp_documento " + cboTipoDoc.Text + txtDni.Text;
            }
            strSql += " and c.emp_fding between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaIngresoDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeIngresoHasta.Text + "'))";


            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridBuscarEmpleados.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridBuscarEmpleados.Rows.Add();
                    gridBuscarEmpleados[0, i].Value = dt.Rows[i]["emp_id"].ToString();
                    gridBuscarEmpleados[1, i].Value = dt.Rows[i]["emp_fding"].ToString();
                    gridBuscarEmpleados[2, i].Value = dt.Rows[i]["emp_documento"].ToString();
                    gridBuscarEmpleados[3, i].Value = dt.Rows[i]["emp_nombre"].ToString() + " " + dt.Rows[i]["emp_apellido"].ToString();
                    gridBuscarEmpleados[4, i].Value = dt.Rows[i]["emp_direccion"].ToString();
                    gridBuscarEmpleados[5, i].Value = dt.Rows[i]["emp_nro"].ToString();
                    gridBuscarEmpleados[6, i].Value = dt.Rows[i]["prov_desc"].ToString();

                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridBuscarEmpleados.DataSource = null;
            gridBuscarEmpleados.Rows.Clear();
            gridBuscarEmpleados.Columns.Clear();
            gridBuscarEmpleados.Columns.Add("ID", null);
            gridBuscarEmpleados.Columns.Add("Fech.Ingreso", null);
            gridBuscarEmpleados.Columns.Add("DNI", null);
            gridBuscarEmpleados.Columns.Add("Nombre y Apellido", null);
            gridBuscarEmpleados.Columns.Add("Direccion", null);
            gridBuscarEmpleados.Columns.Add("Nro  ", null);
            gridBuscarEmpleados.Columns.Add("Localidad", null);
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

        private void frmEmpleadosBusqueda_Load(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboApellido.Text = "=";
            cboNombre.Text = "=";
            cboTipoDoc.Text = "=";
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
            dtpFechadeIngresoHasta.Value = DateTime.Now;
            dtpFechaIngresoDesde.Value = Convert.ToDateTime("01/01/1980");
        }

        private void gridBuscarEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBuscarEmpleados.RowCount > 0)
            {
                if (boOtraPantalla)
                {
                    intCodigo = Convert.ToInt32(gridBuscarEmpleados.CurrentRow.Cells[0].Value.ToString());
                    this.Close();
                }
                else
                {
                    ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
                    int intCodigo = Convert.ToInt32(gridBuscarEmpleados.CurrentRow.Cells[0].Value.ToString());
                    Empleados objEmpleados = objManejaEmpleados.BuscarEmpleados(intCodigo);
                    frmEmpleados objfrmEmpleados = new frmEmpleados(objEmpleados);
                    if (frmLogin.PermiteEntrar("EMPLEADOS", "EMPLEADOS_ALTA"))
                    {
                        objfrmEmpleados.Show();
                        objfrmEmpleados.Activate();
                        CargoGrilla();
                    }
                }
            }
        }


    }
}
