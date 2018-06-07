using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Configuration;

namespace DAO
{
    /// <summary>
    /// Summary description for common
    /// </summary>
    public class common
    {
        public common()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region "GetConnexion"
        public static SqlConnection GetConnexion()
        {
            string locStrSql;
            locStrSql = System.Configuration.ConfigurationManager.ConnectionStrings["BAR"].ConnectionString;
            var connection = new SqlConnection(locStrSql);
            try
            {
                connection.Open();
                return connection;
            }
            finally
            {
                connection.Close();
            }

        }
        #endregion

        //#region "BindCbo"

        ////'carga un combo con los valores recibidos del store

        //public static void BindCbo(ListControl cbo, string spName, string fieldValue,
        //                       string fieldText, bool bPrimerValorVacio)
        //{
        //    CapaDatos.ManejaConexiones oManejaConexiones = new CapaDatos.ManejaConexiones();
        //    oManejaConexiones.NombreStoredProcedure = spName;
        //    oManejaConexiones.llenaTable();

        //    cbo.DataSource = oManejaConexiones.Table;
        //    cbo.DataTextField = fieldText;
        //    cbo.DataValueField = fieldValue;
        //    cbo.DataBind();
        //    if (bPrimerValorVacio)
        //    {
        //        cbo.Items.Insert(0, "");
        //        cbo.SelectedIndex = 0;
        //    }
        //}

        //#endregion

    }

}
