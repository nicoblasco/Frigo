using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaPerfiles
    {
        public  ManejaPerfiles()
        {

        }

        public int GrabarPerfiles(Perfiles objPerfiles)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@usuario_id", SqlDbType.BigInt);
            spParam[0].Value = objPerfiles.IntUsuario;

            spParam[1] = new SqlParameter("@modulo", SqlDbType.NVarChar);
            spParam[1].Value = objPerfiles.StrModulo;

            spParam[2] = new SqlParameter("@pantalla", SqlDbType.NVarChar);
            spParam[2].Value = objPerfiles.StrPantalla;

            spParam[3] = new SqlParameter("@permiso", SqlDbType.NVarChar);
            spParam[3].Value = objPerfiles.StrPermiso;

            spParam[4] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[4].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Perfiles";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[4].Value);

        }

        public void ModificarPerfiles(Perfiles objPerfiles)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objPerfiles.IntCodigo;

            spParam[1] = new SqlParameter("@usuario_id", SqlDbType.BigInt);
            spParam[1].Value = objPerfiles.IntUsuario;

            spParam[2] = new SqlParameter("@modulo", SqlDbType.NVarChar);
            spParam[2].Value = objPerfiles.StrModulo;

            spParam[3] = new SqlParameter("@pantalla", SqlDbType.NVarChar);
            spParam[3].Value = objPerfiles.StrPantalla;

            spParam[4] = new SqlParameter("@permiso", SqlDbType.NVarChar);
            spParam[4].Value = objPerfiles.StrPermiso;


            oManejaConexiones.NombreStoredProcedure = "Upd_Perfiles";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

        }
        public void EliminaPerfil(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Perfiles";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Perfiles BuscarPerfil (int intCodigo)
        {
            string strSql;
            Perfiles objPerfiles = new Perfiles();

            strSql = "select id, usuarioid,modulo,pantalla,permiso ";
            strSql += " FROM Perfiles where id = " + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objPerfiles.IntCodigo = intCodigo;
            objPerfiles.IntUsuario = Convert.ToInt32(dt.Rows[0]["usuarioid"].ToString());
            objPerfiles.StrModulo = dt.Rows[0]["modulo"].ToString();
            objPerfiles.StrPantalla =dt.Rows[0]["pantalla"].ToString();
            objPerfiles.StrPermiso = dt.Rows[0]["permiso"].ToString();

            return objPerfiles;


        }

        public bool ExistePerfil(int intUsuarioId, string strModulo, string strPantalla)
        {
            string strSql;
            Perfiles objPerfiles = new Perfiles();

            //Si selecciona Modulo y Pantalla Todas
                //Me basta con saber si tiene un permiso cargado
            if (strModulo=="TODOS" && strPantalla =="TODAS")
            {
                strSql = "select count(*) as cantidad";
                strSql += " FROM Perfiles where usuarioid = " + intUsuarioId;

            }
            else if (strPantalla == "TODAS")
            //Si selecciona Pantalla Todas
            //Me basta con saber si tiene un permiso cargado para ese modulo
            {
                strSql = "select count(*) as cantidad";
                strSql += " FROM Perfiles where usuarioid = " + intUsuarioId;
                strSql += " AND modulo = '" + strModulo + "'";
            }
            else
            {
                strSql = "select count(*) as cantidad";
                strSql += " FROM Perfiles where usuarioid = " + intUsuarioId;
                strSql += " AND modulo = '" + strModulo + "'";
                strSql += " AND pantalla = '" + strPantalla + "'";
            }
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

        public void EliminaPerfil(int intUsuarioId, string strModulo, string strPantalla)
        {
            string strSql;
            Perfiles objPerfiles = new Perfiles();

            //Si selecciona Modulo y Pantalla Todas
            //Me basta con saber si tiene un permiso cargado
            if (strModulo == "TODOS" && strPantalla == "TODAS")
            {
                strSql = "delete";
                strSql += " FROM Perfiles where usuarioid = " + intUsuarioId;

            }
            else if (strPantalla == "TODAS")
            //Si selecciona Pantalla Todas
            //Me basta con saber si tiene un permiso cargado para ese modulo
            {
                strSql = "delete";
                strSql += " FROM Perfiles where usuarioid = " + intUsuarioId;
                strSql += " AND modulo = '" + strModulo + "'";
            }
            else
            {
                strSql = "delete";
                strSql += " FROM Perfiles where usuarioid = " + intUsuarioId;
                strSql += " AND modulo = '" + strModulo + "'";
                strSql += " AND pantalla = '" + strPantalla + "'";
            }
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

        }

        public DataTable obtenerTodasLasPanallas(string strModulo, string strPantalla)
        {
            string strSql;
            if (strModulo=="TODOS" && strPantalla =="TODAS")
            {
                strSql = "select cc_valor1,cc_valor2 ";
                strSql += " from dbo.Diccionario where dd_parametro= 'PANTALLAS'";
                strSql += " and cc_valor1 <> 'TODOS' ";
                strSql += " and cc_valor2 <> 'TODAS' ";
            }
            else
            //Si selecciona Pantalla Todas
            //Me basta con saber si tiene un permiso cargado para ese modulo
            {
                strSql = "select cc_valor1,cc_valor2 ";
                strSql += " from dbo.Diccionario where dd_parametro= 'PANTALLAS'";
                strSql += " and cc_valor2 <> 'TODAS' ";
                strSql += " and cc_valor1 = '" + strModulo + "'";
            }

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            return dt;

        }

        public List<Perfiles> BuscarPerfil(string strUsuario)
        {
            string strSql;
            Perfiles objPerfiles;
            List<Perfiles> objListPerfiles = new List<Perfiles>();

            strSql = "select id, usuarioid,modulo,pantalla,permiso ";
            strSql += "  from Perfiles where usuarioid = (select id from usuarios where usuario='" + strUsuario.Trim().ToUpper() + "')";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt2 = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objPerfiles = new Perfiles();
                    objPerfiles.IntCodigo = Convert.ToInt32(dt2.Rows[i]["id"].ToString());
                    objPerfiles.IntUsuario = Convert.ToInt32(dt2.Rows[i]["usuarioid"].ToString());
                    objPerfiles.StrModulo = dt2.Rows[i]["modulo"].ToString();
                    objPerfiles.StrPantalla = dt2.Rows[i]["pantalla"].ToString();
                    objPerfiles.StrPermiso = dt2.Rows[i]["permiso"].ToString();
                    objListPerfiles.Add(objPerfiles);
                }


            }
            return objListPerfiles;


        }
    }
}
