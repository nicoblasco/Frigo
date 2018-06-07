using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class ManejaUsuarios
    {
        public  ManejaUsuarios()
        {
        }
        public int GrabarUsuarios( Usuarios objUsuario)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            spParam[0].Value = objUsuario.StrUsuario;

            spParam[1] = new SqlParameter("@nombre_apellido", SqlDbType.NVarChar);
            spParam[1].Value = objUsuario.StrNombreApellido;

            spParam[2] = new SqlParameter("@es_admin", SqlDbType.Int);
            spParam[2].Value = objUsuario.IntEsAdmin;


            spParam[3] = new SqlParameter("@contraseña", SqlDbType.NVarChar);
            spParam[3].Value = objUsuario.StrContraseña;

            spParam[4] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[4].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Usuarios";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[4].Value);

        }

        public void ModificarUsuarios(Usuarios objUsuario)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objUsuario.IntCodigo;

            spParam[1] = new SqlParameter("@usuario", SqlDbType.NVarChar);
            spParam[1].Value = objUsuario.StrUsuario;

            spParam[2] = new SqlParameter("@nombre_apellido", SqlDbType.NVarChar);
            spParam[2].Value = objUsuario.StrNombreApellido;

            spParam[3] = new SqlParameter("@es_admin", SqlDbType.Int);
            spParam[3].Value = objUsuario.IntEsAdmin;

            spParam[4] = new SqlParameter("@contraseña", SqlDbType.NVarChar);
            spParam[4].Value = objUsuario.StrContraseña;


            oManejaConexiones.NombreStoredProcedure = "Upd_Usuarios";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

        }
        public void EliminaUsuario(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Usuarios";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Usuarios BuscarUsuario(int intCodigo)
        {
            string strSql;
            Usuarios objUsuarios = new Usuarios();



            strSql = "select id, usuario, nombre_apellido, es_admin, contraseña ";
            strSql += " FROM Usuarios where id = " + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objUsuarios.IntCodigo = intCodigo;
            objUsuarios.StrUsuario = dt.Rows[0]["usuario"].ToString();
            objUsuarios.StrNombreApellido = dt.Rows[0]["nombre_apellido"].ToString();
            objUsuarios.IntEsAdmin = Convert.ToInt32(dt.Rows[0]["es_admin"].ToString());
            objUsuarios.StrContraseña = dt.Rows[0]["contraseña"].ToString();

            return objUsuarios;


        }

        public bool ExisteUsuario(string strUsuario)
        {

            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from dbo.Usuarios where usuario ='" + strUsuario + "'";

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

        public Usuarios ExisteUsuarioContraseña(string strUsuario, string strContraseña)
        {
            string strSql;
            strSql = "select id, usuario, nombre_apellido, es_admin, contraseña";
            strSql += " from dbo.Usuarios where usuario ='" + strUsuario + "'";
            strSql += " and contraseña = '" + strContraseña + "'";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
            {
                Usuarios objUsuarios = new Usuarios();
                objUsuarios.IntCodigo = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                objUsuarios.StrUsuario = dt.Rows[0]["usuario"].ToString();
                objUsuarios.StrNombreApellido = dt.Rows[0]["nombre_apellido"].ToString();
                objUsuarios.IntEsAdmin = Convert.ToInt32(dt.Rows[0]["es_admin"].ToString());
                objUsuarios.StrContraseña = dt.Rows[0]["contraseña"].ToString();
                return objUsuarios;
            }
            else
                return null;
        }
    }
}
