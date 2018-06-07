using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaMonedas
    {
        public ManejaMonedas()
        {
        }

        public int GrabarMoneda(Monedas objMoneda)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            spParam[0].Value = objMoneda.StrDescripcion;

            spParam[1] = new SqlParameter("@cotizacion", SqlDbType.Decimal);
            spParam[1].Value = objMoneda.DeCotizacion;

            spParam[2] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[2].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Monedas";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[2].Value);
        }

        public void ModificarMoneda(Monedas objMoneda)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objMoneda.IntCodigo;

            spParam[1] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            spParam[1].Value = objMoneda.StrDescripcion;

            spParam[2] = new SqlParameter("@cotizacion", SqlDbType.Decimal);
            spParam[2].Value = objMoneda.DeCotizacion;



            oManejaConexiones.NombreStoredProcedure = "Upd_Monedas";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        
        }


        public void EliminaMoneda(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Monedas";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Monedas BuscarMoneda(Int32 intMoneda)
        {
            Monedas objMoneda = new Monedas();
            string strSql;
            strSql = "select descripcion, cotizacion ";
            strSql += " from Monedas where monedaid="+ intMoneda;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt.Rows.Count > 0)
            {
                objMoneda.IntCodigo = intMoneda;
                objMoneda.StrDescripcion = dt.Rows[0]["descripcion"].ToString();
                objMoneda.DeCotizacion = Convert.ToDecimal(dt.Rows[0]["cotizacion"].ToString());

                return objMoneda;
            }
            else
                return null;
        }

        public bool TieneArticulosAsociados (Int32 intCodigo)
        {

            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from dbo.Articulos where monedaid =" + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                if (dt.Rows[0]["cantidad"].ToString() == "0")
                    return false;
                else
                    return true;
            else
                return false;
        }


    }
}
