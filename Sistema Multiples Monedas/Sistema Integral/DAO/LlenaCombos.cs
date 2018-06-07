using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Data;


namespace DAO
{
    public class LlenaCombos
    {
        public LlenaCombos()
        {
        }
        public DataTable GetSqlDataAdapterbySql(string strSql)
        {

            try
            {

                SqlConnection objConn = common.GetConnexion();
                SqlCommand objCommand = new SqlCommand(strSql, objConn);
                SqlDataAdapter da = new SqlDataAdapter(objCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {


            }

        }

    }

}


