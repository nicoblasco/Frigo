using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;

namespace DAO
{
    public class CombosStandard
    {



        public void CargarPaises(ComboBox combo)
        {
            string strSql;
            strSql = "select pais_id, pais_desc from dbo.paises ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "pais_id";
            combo.DisplayMember = "pais_desc";



        }



        public void CargarProvincias(ComboBox combo, object paisSelectedValue)
        {
            //Cargo el combo de provincias
            string strSql;
            strSql = "select prov_id, prov_desc from dbo.Provincias where pais_id= " + paisSelectedValue;
            strSql += "order by 2";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "prov_id";
            combo.DisplayMember = "prov_desc";
            combo.Text = "AMBA";
        }

        public void CargarProvincias(ComboBox combo)
        {
            //Cargo el combo de provincias
            string strSql;
            strSql = "select prov_id, prov_desc from dbo.Provincias";
            strSql += " order by 2";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "prov_id";
            combo.DisplayMember = "prov_desc";
            combo.Text = "AMBA";
        }



        public void CargarLocalidades(ComboBox combo, object porvinciaSelectedValue)
        {
            string strSql;
            strSql = "select loc_id, prov_desc from dbo.Localidades where prov_id =" + porvinciaSelectedValue;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "loc_id";
            combo.DisplayMember = "prov_desc";
            combo.Text = "FLORENCIO VARELA";

        }

        public void CargarTipoDocumento(ComboBox combo)
        {
            string strSql;
            strSql = "select doc_id,doc_desc from dbo.Documentos ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "doc_id";
            combo.DisplayMember = "doc_desc";
        }

        public void CargarMedioDePago(ComboBox combo)
        {
            string strSql;
            strSql = "select mediopago, descripcion from  dbo.Medio_Pago where fechabaja is null";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "mediopago";
            combo.DisplayMember = "descripcion";
        }

        public void CargarNumeroCaja(ComboBox combo)
        {
            string strSql;
            strSql = "select distinct(numero_caja) numerocaja from dbo.Configuraciones";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "numerocaja";
            combo.DisplayMember = "numerocaja";
        }



        public void CargarDiccionario(ComboBox combo, string strDescripcion)
        {
            string strSql;
            strSql = "select dd_id,cc_valor1 from dbo.Diccionario where dd_parametro= '" + strDescripcion + "' order by cc_valor1";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "dd_id";
            combo.DisplayMember = "cc_valor1";

            combo.Text = "";
            combo.SelectedIndex = -1;
        }

        public void CargarProveedores(ComboBox combo, string strValor)
        {
            string strSql;
            strSql = "select id,razonsocial from Proveedores where fechabaja is null";
            if (!string.IsNullOrEmpty(strValor))
                strSql += " union select id,razonsocial from Proveedores where id =" + strValor;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "id";
            combo.DisplayMember = "razonsocial";

            combo.Text = "";
            combo.SelectedIndex = -1;
        }


        public void CargarEmpleados(ComboBox combo, string strValor)
        {
            string strSql;

            strSql = "select emp_id,convert(varchar, emp_id) + ' - '+  emp_nombre + ' ' + emp_apellido as nombre, predeterminado from dbo.Empleados where fechabaja is null ";
            if (!string.IsNullOrEmpty(strValor))
                strSql += " union select emp_id,convert(varchar, emp_id) + ' - '+  emp_nombre + ' ' + emp_apellido as nombre, predeterminado from dbo.Empleados where emp_id = " + strValor;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "emp_id";
            combo.DisplayMember = "nombre";


            combo.Text = "";
            combo.SelectedIndex = -1;

        }



        public void CargarClientes(ComboBox combo, string strValor)
        {
            string strSql;

            strSql = "select cli_id, convert(varchar, cli_id) + ' - '+  cli_nombre + ' ' + cli_apellido as nombre,predeterminado from clientes where fechabaja is null ";
            if (!string.IsNullOrEmpty(strValor))
                strSql += " union select cli_id, convert(varchar, cli_id) + ' - '+  cli_nombre + ' ' + cli_apellido as nombre,predeterminado from clientes where cli_id = " + strValor;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "cli_id";
            combo.DisplayMember = "nombre";

            combo.Text = "";
            combo.SelectedIndex = -1;


        }

        public void CargarUsuarios(ComboBox combo)
        {
            string strSql;

            strSql = "select id, usuario from Usuarios where es_admin=0 ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "id";
            combo.DisplayMember = "usuario";

            combo.Text = "";
            combo.SelectedIndex = -1;


        }


        public void CargarUsuariosConAdmin(ComboBox combo)
        {
            string strSql;

            strSql = "select id, usuario from Usuarios ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "id";
            combo.DisplayMember = "usuario";

            combo.Text = "";
            combo.SelectedIndex = -1;


        }


        public void CargarParametrizaciones(ComboBox combo)
        {
            string strSql;

            strSql = "select distinct(dd_parametro) as parametro from dbo.Diccionario ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.DisplayMember = "parametro";


        }

        public void CargarEmpleadosConPredeterminado(ComboBox combo)
        {
            string strSql;
            bool boPredeterminado = false;
            strSql = "select emp_id,convert(varchar, emp_id) + ' - '+  emp_nombre + ' ' + emp_apellido as nombre, predeterminado from dbo.Empleados where fechabaja is null ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "emp_id";
            combo.DisplayMember = "nombre";

            //Aca tengo q recorrer y buscar el predeterminado

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    if (Convert.ToBoolean(dt.Rows[i]["predeterminado"].ToString()))
                    {
                        combo.Text = dt.Rows[i]["nombre"].ToString();
                        combo.SelectedValue = Convert.ToInt32(dt.Rows[i]["emp_id"].ToString());
                        boPredeterminado = true;
                        break;
                    }


                }
            }

            if (boPredeterminado == false)
            {
                combo.Text = "";
                combo.SelectedIndex = -1;
            }

        }

        public void CargarEmpleadosConSuUsuario(ComboBox combo, int UserId)
        {
            string strSql;
            bool boPredeterminado = false;
            strSql = "select emp_id,convert(varchar, emp_id) + ' - '+  emp_nombre + ' ' + emp_apellido as nombre, usuario from dbo.Empleados where fechabaja is null ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "emp_id";
            combo.DisplayMember = "nombre";

            //Aca tengo q recorrer y buscar el que sea su usuario

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    if (!String.IsNullOrEmpty(dt.Rows[i]["usuario"].ToString()))
                    {
                        if (Convert.ToInt32(dt.Rows[i]["usuario"].ToString()) == UserId)
                        {
                            combo.Text = dt.Rows[i]["nombre"].ToString();
                            combo.SelectedValue = Convert.ToInt32(dt.Rows[i]["emp_id"].ToString());
                            boPredeterminado = true;
                            break;
                        }

                    }
                }
            }

            if (boPredeterminado == false)
            {
                combo.Text = "";
                combo.SelectedIndex = -1;
            }
        }

        public void CargarClientesConPredeterminado(ComboBox combo)
        {
            string strSql;
            bool boPredeterminado = false;
            strSql = "select cli_id, convert(varchar, cli_id) + ' - '+  cli_nombre + ' ' + cli_apellido as nombre,predeterminado from clientes where fechabaja is null ";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "cli_id";
            combo.DisplayMember = "nombre";

            //Aca tengo q recorrer y buscar el predeterminado

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    if (Convert.ToBoolean(dt.Rows[i]["predeterminado"].ToString()))
                    {
                        combo.Text = dt.Rows[i]["nombre"].ToString();
                        combo.SelectedValue = Convert.ToInt32(dt.Rows[i]["cli_id"].ToString());
                        boPredeterminado = true;
                        break;
                    }


                }
            }

            if (boPredeterminado == false)
            {
                combo.Text = "";
                combo.SelectedIndex = -1;
            }

        }

        public void CargarImpresoras(ComboBox combo)
        {
            PrinterSettings impresora = new PrinterSettings();
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                impresora.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                /*if (impresora.IsDefaultPrinter)
                    return PrinterSettings.InstalledPrinters[i].ToString();*/
                combo.Items.Add(PrinterSettings.InstalledPrinters[i].ToString());
            }
            //return String.Empty;

        }

        public void CargarDiccionarioValor2(ComboBox combo, string strParametro, string strValor1)
        {
            string strSql;
            strSql = "select dd_id,cc_valor2 from dbo.Diccionario where dd_parametro= '" + strParametro + "' and cc_valor1 = '" + strValor1 + "' order by cc_valor1";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "dd_id";
            combo.DisplayMember = "cc_valor2";

            combo.Text = "";
            combo.SelectedIndex = -1;
            combo.Text = "TODAS";
        }

        public void CargarTotalesDeVentasPorMedioDePago(ListBox combo, int intNumeroCaja, string strFecha)
        {
            string strSql;

            strSql = "select m.mediopago, m.descripcion +' - $'+   LTrim(Str( sum(p.importe),10,2)) as descripcion from dbo.Ventas_Pagos p,dbo.Medio_Pago m ";
            strSql += " where m.mediopago = p.mediopago";
            strSql += " and p.fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))+1";
            strSql += " and p.cierrecajaid = " + intNumeroCaja;
            strSql += " group by m.mediopago, m.descripcion ";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "mediopago";
            combo.DisplayMember = "descripcion";
        }


        public void CargarMonedas(ComboBox combo)
        {
            string strSql;

            strSql = "select monedaid, descripcion ";
            strSql += " from Monedas";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            combo.DataSource = dt;
            combo.ValueMember = "monedaid";
            combo.DisplayMember = "descripcion";
        }
    }
}
