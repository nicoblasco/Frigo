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
    public partial class frmArticulosBusqueda : Form
    {
        CombosStandard objCombosStandard;
        bool boOtraPantalla;
        public string strCodigo;
        public bool boImagenMode;
        const int COL_BORRADO = 1;


        public frmArticulosBusqueda(bool boOtraPantalla)
        {
            InitializeComponent();
            CargoCombos();
            this.boOtraPantalla = boOtraPantalla;
            dtpFechadeIngresoHasta.Value = DateTime.Now;
            if (boOtraPantalla == false)
                btnImagenMode.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            CargoGrilla();

        }

        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarProveedores(cboProveedor, null);
            objCombosStandard.CargarDiccionario(cboRubro, "RUBRO");
            objCombosStandard.CargarDiccionario(cboMarca, "SUBRUBRO");
        }

        private DataTable ArmoSql()
        {
            string strSql;

            strSql = "select a.id,idextra,a.descripcion, fechaalta, rubro, marca, stock,costo, precioefectivo, preciotarjeta, razonsocial,stockminimo, ubicacion, ganancia, preciolista2, preciolista3, m.descripcion as moneda, unidaddeventa ";
            strSql += " from dbo.Articulos a LEFT OUTER JOIN dbo.Proveedores  P  ON a.proveedor = P.id, Monedas m where a.fechabaja is null and isnull(a.monedaid,1) = m.monedaid ";



            if (txtCodigo.Text != "")
            {
                /*   if (txtCodigo.Text.Substring(0, 2).Trim() == "20" && txtCodigo.Text.Trim().Length == 13) //Los dos primeros digitos tienen que se 20 y el ancho del codigo de barra tiene que ser de 12 digitos
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
                   {*/
                if (cboCodigo.Text == "=")
                    strSql += " and  a.idextra = '" + txtCodigo.Text + "'";
                if (cboCodigo.Text == "like")
                    strSql += " and  a.idextra like '" + txtCodigo.Text + "%' ";
                if (cboCodigo.Text == "path")
                    strSql += " and  a.idextra like '%" + txtCodigo.Text + "%' ";
                //}
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

            strSql += " and a.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechaIngresoDesde.Text + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + dtpFechadeIngresoHasta.Text + "'))";

            strSql += " Order by a.idextra asc";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            return dt;
        }

        private void CargoGrilla()
        {
            gridBuscarArticulos.DataSource = null;
            DataTable dt = ArmoSql();

            gridBuscarArticulos.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridBuscarArticulos.Rows.Add();
                    gridBuscarArticulos[0, i].Value = dt.Rows[i]["id"].ToString();
                    gridBuscarArticulos[2, i].Value = dt.Rows[i]["idextra"].ToString();
                    gridBuscarArticulos[3, i].Value = dt.Rows[i]["descripcion"].ToString();
                    gridBuscarArticulos[4, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["precioefectivo"].ToString())));
                    if (!String.IsNullOrEmpty(dt.Rows[i]["preciolista2"].ToString()))
                        gridBuscarArticulos[5, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["preciolista2"].ToString())));
                    if (!String.IsNullOrEmpty(dt.Rows[i]["preciolista3"].ToString()))
                        gridBuscarArticulos[6, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["preciolista3"].ToString())));
                    gridBuscarArticulos[7, i].Value = dt.Rows[i]["ubicacion"].ToString();
                    gridBuscarArticulos[8, i].Value = dt.Rows[i]["fechaalta"].ToString();
                    gridBuscarArticulos[9, i].Value = dt.Rows[i]["rubro"].ToString();
                    gridBuscarArticulos[10, i].Value = dt.Rows[i]["marca"].ToString();
                    gridBuscarArticulos[11, i].Value = dt.Rows[i]["stock"].ToString();
                    gridBuscarArticulos[12, i].Value = dt.Rows[i]["preciotarjeta"].ToString();
                    gridBuscarArticulos[13, i].Value = dt.Rows[i]["razonsocial"].ToString();
                    gridBuscarArticulos[14, i].Value = dt.Rows[i]["stockminimo"].ToString();
                    gridBuscarArticulos[15, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["costo"].ToString())));
                    gridBuscarArticulos[16, i].Value = dt.Rows[i]["moneda"].ToString();
                    gridBuscarArticulos[17, i].Value = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["ganancia"].ToString())));
                    gridBuscarArticulos[18, i].Value = dt.Rows[i]["unidaddeventa"].ToString();

                    //if (Convert.ToInt32(dt.Rows[i]["stock"].ToString()) < 1) //Sin Stock
                    //    gridBuscarArticulos.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    //if (Convert.ToInt32(dt.Rows[i]["stock"].ToString()) > 0 && Convert.ToInt32(dt.Rows[i]["stock"].ToString()) <= Convert.ToInt32(dt.Rows[i]["stockminimo"].ToString())) //Con Stock Min
                    //    gridBuscarArticulos.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                    //if (Convert.ToInt32(dt.Rows[i]["stock"].ToString()) > Convert.ToInt32(dt.Rows[i]["stockminimo"].ToString())) // Con Stock
                    //    gridBuscarArticulos.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;

                }
            }

        }


        private void CargoTituloGrilla()
        {
            int j = 0;
            gridBuscarArticulos.DataSource = null;
            gridBuscarArticulos.Rows.Clear();
            gridBuscarArticulos.Columns.Clear();
            gridBuscarArticulos.Columns.Add("ID", null); //0
            gridBuscarArticulos.Columns[j++].ReadOnly = true;

            //Agrego columna con Check
            DataGridViewCheckBoxColumn checkColumnBorrado = new DataGridViewCheckBoxColumn();
            checkColumnBorrado.Name = "Borrar?";
            checkColumnBorrado.HeaderText = "Borrar?";
            checkColumnBorrado.Width = 40;
            checkColumnBorrado.ReadOnly = false;
            gridBuscarArticulos.Columns.Add(checkColumnBorrado);
            gridBuscarArticulos.Columns[j++].ReadOnly = false;

            gridBuscarArticulos.Columns.Add("ID ", null);//2 -Este es el id extra
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Descripcion", null);//3
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("PRECIO", null);//4 precio en efectivo
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Precio L2", null);//5 precio en efectivo
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Precio L3", null);//6 precio en efectivo
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Ubicación", null);//7
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Fecha Alta", null);//8
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Rubro", null);//9
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("SubRubro", null);//10
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Stock", null); //11
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("P.Tarjeta", null); //12
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Proveedor", null); //13
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("StockMinimo", null); //14
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Costo", null); //15
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("Moneda", null); //16
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("% Ganancia", null); //17
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            gridBuscarArticulos.Columns.Add("% Unidad Vta", null); //18
            gridBuscarArticulos.Columns[j++].ReadOnly = true;
            this.gridBuscarArticulos.Columns[0].Visible = false;
            this.gridBuscarArticulos.Columns[8].Visible = false;
            this.gridBuscarArticulos.Columns[12].Visible = false; //
            this.gridBuscarArticulos.Columns[14].Visible = false; //

            this.gridBuscarArticulos.Columns[2].Width = 60;
            this.gridBuscarArticulos.Columns[3].Width = 420;
            this.gridBuscarArticulos.Columns[4].Width = 70;
            this.gridBuscarArticulos.Columns[5].Width = 70;
            this.gridBuscarArticulos.Columns[6].Width = 70;
            this.gridBuscarArticulos.Columns[11].Width = 40;

            this.gridBuscarArticulos.Columns[13].Width = 80;
            this.gridBuscarArticulos.Columns[14].Width = 80;

            if (!frmLogin.isAdmin)
            {
                gridBuscarArticulos.Columns[1].Visible = false;
            }
          
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboDescripcion.Text = "path";
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
            dtpFechadeIngresoHasta.Value = DateTime.Now;
            dtpFechaIngresoDesde.Value = Convert.ToDateTime("01/01/1980");
            ckSeleccionarTodos.Checked = false;


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

        private void frmArticulosBusqueda_Load(object sender, EventArgs e)
        {
            cboCodigo.Text = "=";
            cboDescripcion.Text = "path";
            cboStock.Text = "=";
            cboUbicacion.Text = "=";

            if (frmLogin.isAdmin)
            {
                btnBorrar.Visible = true;
                ckSeleccionarTodos.Visible = true;
            }
            else
            {
                btnBorrar.Visible = false;
                ckSeleccionarTodos.Visible = false;
            }

        }

        private void gridBuscarArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridBuscarArticulos.RowCount > 0)
            {
                if (boOtraPantalla)
                {
                    strCodigo = Convert.ToString(gridBuscarArticulos.CurrentRow.Cells[2].Value.ToString());
                    this.Close();
                }
                else
                {
                    ManejaArticulos objManejaArticulos = new ManejaArticulos();
                    int intCodigo = Convert.ToInt32(gridBuscarArticulos.CurrentRow.Cells[0].Value.ToString());
                    Articulos objArticulos = objManejaArticulos.BuscarArticulos(intCodigo);
                    frmArticulos objfrmArticulos = new frmArticulos(objArticulos);
                    if (frmLogin.PermiteEntrar("ARTICULOS", "ARTICULOS_ALTA"))
                    {
                        objfrmArticulos.Show();
                        objfrmArticulos.Activate();
                        CargoGrilla();
                    }
                }
            }
        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private void btnImagenMode_Click(object sender, EventArgs e)
        {
            boImagenMode = true;
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = ArmoSql();
            ManejaArticulos objManejaArticulos = new ManejaArticulos();
            frmReportes objfrmReporte;
            objfrmReporte = new frmReportes("ReporteArticulos.rdlc", objManejaArticulos.ReporteDeArticulosGral(dt), "ArticulosReporteGral");
            objfrmReporte.Show();
        }

        private void ckSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridBuscarArticulos.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[COL_BORRADO];
                if (ckSeleccionarTodos.Checked)
                    chk.Value = true;
                else
                    chk.Value = false;
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 selRow = 0;
            int intBorrados = 0;
            string message;
            string caption = "Mensaje";
            ManejaArticulos objManejoArticulos = new ManejaArticulos();
            message = "Desea Borrar los articulos seleccionados?";

            if (gridBuscarArticulos != null)
                if (gridBuscarArticulos.Rows.Count > 0)
                {
                    //Recorro los tildados para borrar
                    for (int i = 0; i <= Convert.ToInt32(gridBuscarArticulos.Rows.Count) - 1; i++)
                    {
                        if (Convert.ToBoolean(gridBuscarArticulos[COL_BORRADO, i].Value) == true)
                        {
                            intBorrados++;
                            if (intBorrados == 1)// Si encuentro borrados pregunto si quiere borrar
                            {
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;
                                result = MessageBox.Show(message, caption, buttons);

                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    int intCodigo = Convert.ToInt32(gridBuscarArticulos[0, i].Value.ToString());
                                    objManejoArticulos.EliminaArticulos(intCodigo);
                                }
                                else
                                    return;

                            }
                            else
                            {
                                int intCodigo = Convert.ToInt32(gridBuscarArticulos[0, i].Value.ToString());
                                objManejoArticulos.EliminaArticulos(intCodigo);
                            }
                        }
                    }
                    if (gridBuscarArticulos.SelectedCells.Count > 0)
                    {
                        selRow = gridBuscarArticulos.CurrentCell.RowIndex;
                    }
                    CargoGrilla();
                    if ((gridBuscarArticulos.Rows.Count - 1) > selRow)
                    {
                        gridBuscarArticulos.ClearSelection();
                        gridBuscarArticulos.CurrentCell = gridBuscarArticulos[COL_BORRADO, selRow];
                    }
                }
        
        }
    }
}
