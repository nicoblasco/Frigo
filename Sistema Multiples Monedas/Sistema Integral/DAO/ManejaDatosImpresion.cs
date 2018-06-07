using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaDatosImpresion
    {
        public ManejaDatosImpresion()
        {          
        }

        public void GrabarDatosImpresion(DatosImpresion objDatosImpresion )
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[9];

            spParam[0] = new SqlParameter("@comercio", SqlDbType.NVarChar);
            spParam[0].Value = objDatosImpresion.StrComercio;

            spParam[1] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[1].Value = objDatosImpresion.StrDireccion;

            spParam[2] = new SqlParameter("@provincia", SqlDbType.NVarChar);
            spParam[2].Value = objDatosImpresion.StrProvincia;

            spParam[3] = new SqlParameter("@localidad", SqlDbType.NVarChar);
            spParam[3].Value = objDatosImpresion.StrLocalidad;

            spParam[4] = new SqlParameter("@codigointerno", SqlDbType.NVarChar);
            spParam[4].Value = objDatosImpresion.StrCodigoInterno;

            spParam[5] = new SqlParameter("@comentariolinea1", SqlDbType.NVarChar);
            spParam[5].Value = objDatosImpresion.StrComentarioLinea1;

            spParam[6] = new SqlParameter("@comentariolinea2", SqlDbType.NVarChar);
            spParam[6].Value = objDatosImpresion.StrComentarioLinea2;

            spParam[7] = new SqlParameter("@comentariolinea3", SqlDbType.NVarChar);
            spParam[7].Value = objDatosImpresion.StrComertarioLinea3;

            spParam[8] = new SqlParameter("@impresora", SqlDbType.NVarChar);
            spParam[8].Value = objDatosImpresion.StrImpresora;



            oManejaConexiones.NombreStoredProcedure = "Add_Impresion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificarDatosImpresion(DatosImpresion objDatosImpresion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[9];

            spParam[0] = new SqlParameter("@comercio", SqlDbType.NVarChar);
            spParam[0].Value = objDatosImpresion.StrComercio;

            spParam[1] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[1].Value = objDatosImpresion.StrDireccion;

            spParam[2] = new SqlParameter("@provincia", SqlDbType.NVarChar);
            spParam[2].Value = objDatosImpresion.StrProvincia;

            spParam[3] = new SqlParameter("@localidad", SqlDbType.NVarChar);
            spParam[3].Value = objDatosImpresion.StrLocalidad;

            spParam[4] = new SqlParameter("@codigointerno", SqlDbType.NVarChar);
            spParam[4].Value = objDatosImpresion.StrCodigoInterno;

            spParam[5] = new SqlParameter("@comentariolinea1", SqlDbType.NVarChar);
            spParam[5].Value = objDatosImpresion.StrComentarioLinea1;

            spParam[6] = new SqlParameter("@comentariolinea2", SqlDbType.NVarChar);
            spParam[6].Value = objDatosImpresion.StrComentarioLinea2;

            spParam[7] = new SqlParameter("@comentariolinea3", SqlDbType.NVarChar);
            spParam[7].Value = objDatosImpresion.StrComertarioLinea3;

            spParam[8] = new SqlParameter("@impresora", SqlDbType.NVarChar);
            spParam[8].Value = objDatosImpresion.StrImpresora;



            oManejaConexiones.NombreStoredProcedure = "Upd_Impresion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public DatosImpresion BuscarDatosImpresion()
        {
            DatosImpresion objDatosImpresion = new DatosImpresion();
            string strSql;
            strSql = "select  NombreComercio,Direccion,Provincia,Localidad,CodigoInterno,ComentarioLinea1,ComentarioLinea2,ComentarioLinea3,NombreImpresora ";
            strSql += " from dbo.Impresion";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt.Rows.Count > 0)
            {

                objDatosImpresion.StrComercio = dt.Rows[0]["NombreComercio"].ToString();
                objDatosImpresion.StrDireccion = dt.Rows[0]["Direccion"].ToString();
                objDatosImpresion.StrProvincia = dt.Rows[0]["Provincia"].ToString();
                objDatosImpresion.StrLocalidad = dt.Rows[0]["Localidad"].ToString();
                objDatosImpresion.StrCodigoInterno = dt.Rows[0]["CodigoInterno"].ToString();
                objDatosImpresion.StrComentarioLinea1 = dt.Rows[0]["ComentarioLinea1"].ToString();
                objDatosImpresion.StrComentarioLinea2 = dt.Rows[0]["ComentarioLinea2"].ToString();
                objDatosImpresion.StrComertarioLinea3 = dt.Rows[0]["ComentarioLinea3"].ToString();
                objDatosImpresion.StrImpresora = dt.Rows[0]["NombreImpresora"].ToString();

                return objDatosImpresion;
            }
            else
                return null;
        }

    }
}
