using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;



namespace DAO
{
    public class ManejaCompras
    {
        public ManejaCompras()
        {
        }

        public int GrabarCompras(Compras objCompras)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[7];

            spParam[0] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[0].Value = objCompras.DtFechaAlta;

            spParam[1] = new SqlParameter("@proveedorid", SqlDbType.Int);
            spParam[1].Value = objCompras.IntProveedor;

            spParam[2] = new SqlParameter("@nrofactura", SqlDbType.NVarChar);
            spParam[2].Value = objCompras.StrNroFactura;

            spParam[3] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[3].Value = objCompras.DeTotal;

            spParam[4] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[4].Value = objCompras.StrObservaciones;

            spParam[5] = new SqlParameter("@cierrecajaid", SqlDbType.BigInt);
            spParam[5].Value = objCompras.IntNumeroCaja;

            spParam[6] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[6].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Compras";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[6].Value);

        }


        public void ModificaCompras(Compras objCompras)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objCompras.IntCodigo;

            spParam[1] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[1].Value = objCompras.DtFechaAlta;

            spParam[2] = new SqlParameter("@proveedorid", SqlDbType.Int);
            spParam[2].Value = objCompras.IntProveedor;

            spParam[3] = new SqlParameter("@nrofactura", SqlDbType.NVarChar);
            spParam[3].Value = objCompras.StrNroFactura;

            spParam[4] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[4].Value = objCompras.DeTotal;

            spParam[5] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[5].Value = objCompras.StrObservaciones;

            oManejaConexiones.NombreStoredProcedure = "Upd_Compras";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }




        public void EliminaCompras(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Compras";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Compras BuscarCompras(int intCodigo)
        {
            Compras objCompras = new Compras();

            string strSql;
            strSql = "select c.fechaalta,c.proveedorid,c.nrofactura,c.total,c.observaciones,c.fechabaja, isnull( a.numero_caja,0) as numero_caja ";
            //strSql += " from compras c, Cierre_Caja a where c.cierrecajaid=a.cierrecajaid and compraid =" + intCodigo;            
            strSql += " from compras c left join Cierre_Caja a on c.cierrecajaid=a.cierrecajaid and compraid =" + intCodigo;            
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objCompras.IntCodigo = intCodigo;
            objCompras.DtFechaAlta = Convert.ToDateTime(dt.Rows[0]["fechaalta"].ToString());
            objCompras.IntProveedor = Convert.ToInt32(dt.Rows[0]["proveedorid"].ToString());
            objCompras.StrNroFactura = dt.Rows[0]["nrofactura"].ToString();
            objCompras.DeTotal = Convert.ToDecimal(dt.Rows[0]["total"].ToString());
            objCompras.StrObservaciones = dt.Rows[0]["observaciones"].ToString();
            objCompras.DtFechaBaja =dt.Rows[0]["fechabaja"].ToString();
            objCompras.IntNumeroCaja = Convert.ToInt32(dt.Rows[0]["numero_caja"].ToString());

            return objCompras;
        }



        public List<ComprasReporte> ReporteDeCompras(DataTable dt)
        {
            List<ComprasReporte> ListCompras = new List<ComprasReporte>();
            ComprasReporte objCompras;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {

                        objCompras = new ComprasReporte();



                        objCompras.DtFecha = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                        objCompras.StrNroFactura = dt.Rows[i]["nrofactura"].ToString();
                        objCompras.IntProveedorId = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                        objCompras.StrProveedor = dt.Rows[i]["razonsocial"].ToString();
                        objCompras.DeTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString()));


                        ListCompras.Add(objCompras);


                    }
                }
            }
            return ListCompras;

        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }
 
        /*

        public bool ProveedorDadoDeBaja(int intCodigo)
        {
            Clientes objClientes = new Clientes();
            string strSql;
            strSql = "select  fechabaja";
            strSql += " from dbo.Proveedores where id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt != null)
                if (string.IsNullOrEmpty(dt.Rows[0]["fechabaja"].ToString()))
                    return false;
                else
                    return true;
            else
                return false;
        }
        */
    }
}


