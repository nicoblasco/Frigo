using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaConfiguraciones
    {
        public ManejaConfiguraciones()
        {
        }

        public int GrabarConfiguracion(Configuraciones objConfiguracion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[4];

            spParam[0] = new SqlParameter("@nombre_pc", SqlDbType.NVarChar);
            spParam[0].Value = objConfiguracion.StrNombrePc;

            spParam[1] = new SqlParameter("@numero_caja", SqlDbType.Int);
            spParam[1].Value = objConfiguracion.IntNumeroCaja;

            spParam[2] = new SqlParameter("@nombreimpresora", SqlDbType.NVarChar);
            spParam[2].Value = objConfiguracion.StrNombreImpresora;


            spParam[3] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[3].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Configuracion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[3].Value);
        }

        public void ModificarConfiguracion(Configuraciones objConfiguracion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objConfiguracion.IntCodigo;

            spParam[1] = new SqlParameter("@numero_caja", SqlDbType.NVarChar);
            spParam[1].Value = objConfiguracion.IntNumeroCaja;

            spParam[2] = new SqlParameter("@nombreimpresora", SqlDbType.NVarChar);
            spParam[2].Value = objConfiguracion.StrNombreImpresora;



            oManejaConexiones.NombreStoredProcedure = "Upd_Configuracion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public Configuraciones BuscarConfiguracion( string strNombrePc)
        {
            Configuraciones objConfiguracion = new Configuraciones();
            string strSql;
            strSql = "select  conf_id,nombre_pc,numero_caja,NombreImpresora ";
            strSql += " from dbo.Configuraciones ";
            strSql += " WHERE nombre_pc = ('" + strNombrePc + "')";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt.Rows.Count > 0)
            {
                objConfiguracion.IntCodigo = Convert.ToInt32(dt.Rows[0]["conf_id"].ToString());
                objConfiguracion.StrNombrePc = dt.Rows[0]["nombre_pc"].ToString();
                objConfiguracion.IntNumeroCaja = Convert.ToInt32(dt.Rows[0]["numero_caja"].ToString());
                objConfiguracion.StrNombreImpresora = dt.Rows[0]["NombreImpresora"].ToString();


                return objConfiguracion;
            }
            else
                return null;
        }

        public bool ExisteNumeroDeCaja(string strCodigo, string strNombrePc)
        {

            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from Configuraciones where numero_caja =" + strCodigo;
            strSql += " And nombre_pc not in ('" + strNombrePc + "')";

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
