using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaMedioDePagos
    {
        public  ManejaMedioDePagos()
        {
        }

        public int GrabarMedioDePago(MedioDePago objMedioDePago )
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            spParam[0].Value = objMedioDePago.StrDescripcion;

            spParam[1] = new SqlParameter("@predeterminado", SqlDbType.Int);
            spParam[1].Value = objMedioDePago.IntPredeterminado;

            spParam[2] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[2].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Medio_Pago";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[2].Value);

        }


        public void ModificaMedioDePago(MedioDePago objMedioDePago)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objMedioDePago.IntCodigo;

            spParam[1] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            spParam[1].Value = objMedioDePago.StrDescripcion;

            spParam[2] = new SqlParameter("@predeterminado", SqlDbType.Int);
            spParam[2].Value = objMedioDePago.IntPredeterminado;

            oManejaConexiones.NombreStoredProcedure = "Upd_Medio_Pago";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }




        public void EliminaMedioDePago(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Medio_Pago";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public MedioDePago BuscarMedioDePago(int intCodigo)
        {
            MedioDePago objMedioPago = new MedioDePago();

            string strSql;
            strSql = "select mediopago, descripcion, predeterminado ";
            strSql += " from Medio_Pago where fechabaja is null and  mediopago =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objMedioPago.IntCodigo = intCodigo;
            objMedioPago.StrDescripcion = dt.Rows[0]["descripcion"].ToString();
            objMedioPago.IntPredeterminado = Convert.ToInt32(dt.Rows[0]["predeterminado"].ToString());

            return objMedioPago;
        }

    }
}
