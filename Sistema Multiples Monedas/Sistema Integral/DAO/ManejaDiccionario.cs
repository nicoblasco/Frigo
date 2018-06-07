using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaDiccionario
    {
        public ManejaDiccionario()
        {
        }
        public int GrabarDiccionario(Diccionario objDiccionario)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@parametro", SqlDbType.NVarChar);
            spParam[0].Value = objDiccionario.StrParametro;

            spParam[1] = new SqlParameter("@numero1", SqlDbType.BigInt);
            spParam[1].Value = objDiccionario.IntNumero1;

            spParam[2] = new SqlParameter("@valor1", SqlDbType.NVarChar);
            spParam[2].Value = objDiccionario.StrValor1;

            spParam[3] = new SqlParameter("@numero2", SqlDbType.BigInt);
            spParam[3].Value = objDiccionario.IntNumero2;

            spParam[4] = new SqlParameter("@valor2", SqlDbType.NVarChar);
            spParam[4].Value = objDiccionario.StrValor2;

            spParam[5] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[5].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Diccionario";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[5].Value);



        }

        public void ModificaDiccionario(Diccionario objDiccionario, int intCodigo)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;

            spParam[1] = new SqlParameter("@numero1", SqlDbType.BigInt);
            spParam[1].Value = objDiccionario.IntNumero1;

            spParam[2] = new SqlParameter("@valor1", SqlDbType.NVarChar);
            spParam[2].Value = objDiccionario.StrValor1;

            spParam[3] = new SqlParameter("@numero2", SqlDbType.BigInt);
            spParam[3].Value = objDiccionario.IntNumero2;

            spParam[4] = new SqlParameter("@valor2", SqlDbType.NVarChar);
            spParam[4].Value = objDiccionario.StrValor2;

            oManejaConexiones.NombreStoredProcedure = "Upd_Diccionario";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

        }

        public void EliminaDiccionario(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Diccionario";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }


        public Diccionario BuscarDiccionario(int intCodigo)
        {
            Diccionario objDiccionario = new Diccionario();
            string strSql;
            strSql = "SELECT dd_parametro,dd_numero1 ,cc_valor1,dd_numero2,cc_valor2 ";
            strSql += " FROM Diccionario where  dd_id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            objDiccionario.IntCodigo = intCodigo;
            objDiccionario.StrParametro = dt.Rows[0]["dd_parametro"].ToString();
            objDiccionario.StrValor1 = dt.Rows[0]["cc_valor1"].ToString();
            objDiccionario.StrValor2 = dt.Rows[0]["cc_valor2"].ToString();
            objDiccionario.IntNumero1 = Convert.ToInt32(dt.Rows[0]["dd_numero1"].ToString());
            objDiccionario.IntNumero2 = Convert.ToInt32(dt.Rows[0]["dd_numero2"].ToString());

            return objDiccionario;

        }
        public string BuscarValor(string strParametro )
        {
            string strSql;
            strSql = "SELECT cc_valor1 ";
            strSql += " FROM Diccionario where  dd_parametro = '" + strParametro + "'";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            return dt.Rows[0]["cc_valor1"].ToString();

        }

        public bool ExisteDiccionario(string strParametro, string strValor)
        {
            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from dbo.Diccionario where dd_parametro = '" + strParametro + "'";
            strSql += " and cc_valor1= '" + strValor + "'";
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
