using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaCierreDeCaja
    {
        public ManejaCierreDeCaja()
        {
        }

        public int GrabarCierreDeCaja(CierreDeCaja objCierreDeCaja)
        {

            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[0].Value = objCierreDeCaja.DeTotal;

            spParam[1] = new SqlParameter("@fecha", SqlDbType.DateTime);
            spParam[1].Value = objCierreDeCaja.DtFecha;

            spParam[2] = new SqlParameter("@numero_caja", SqlDbType.Int);
            spParam[2].Value = objCierreDeCaja.IntNumeroCaja;

            spParam[3] = new SqlParameter("@usuario_apertura", SqlDbType.BigInt);
            spParam[3].Value = objCierreDeCaja.IntUsuarioApertura;

            spParam[4] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[4].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_CierreCaja";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[4].Value);

        }

        public void ModificaCierreDeCaja(CierreDeCaja objCierreDeCaja)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[4];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objCierreDeCaja.IntCodigo;

            spParam[1] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[1].Value = objCierreDeCaja.DeTotal;

            spParam[2] = new SqlParameter("@fecha", SqlDbType.DateTime);
            spParam[2].Value = objCierreDeCaja.DtFecha;

            spParam[3] = new SqlParameter("@usuario_apertura", SqlDbType.BigInt);
            spParam[3].Value = objCierreDeCaja.IntUsuarioApertura;

            oManejaConexiones.NombreStoredProcedure = "Upd_CierreCaja";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void ModificaCierreDeCaja_Cierre(CierreDeCaja objCierreDeCaja)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objCierreDeCaja.IntCodigo;

            spParam[1] = new SqlParameter("@total_cierre", SqlDbType.Decimal);
            spParam[1].Value = objCierreDeCaja.DeTotalCierre;

            spParam[2] = new SqlParameter("@usuario_cierre", SqlDbType.BigInt);
            spParam[2].Value = objCierreDeCaja.IntUsuarioCierre;

            oManejaConexiones.NombreStoredProcedure = "Upd_CierreCaja_cierre";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }


        public CierreDeCaja DineroInicial(Int32 intIdCierreCaja)
        {
            string strSql;
            CierreDeCaja objCierreDeCaja = new CierreDeCaja();
            strSql = " select cierrecajaid,total, fecha from dbo.Cierre_Caja ";
            strSql += " WHERE cierrecajaid =" + intIdCierreCaja;
            //strSql += " where fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2.Rows.Count != 0)
            {
                objCierreDeCaja.IntCodigo = Convert.ToInt32(dt2.Rows[0]["cierrecajaid"].ToString());
                objCierreDeCaja.DeTotal = Redondeo(Convert.ToDecimal(dt2.Rows[0]["total"].ToString()));
                objCierreDeCaja.DtFecha = Convert.ToDateTime(dt2.Rows[0]["fecha"].ToString());

                return objCierreDeCaja;
            }
            else
            {
                return null;
            }

        }

        public decimal TotalCierreDeCaja(Int32 intIdCierreCaja)
        {
            string strSql;

            strSql = " select isnull(sum(total),0) as suma from dbo.Cierre_Caja ";
            strSql += " WHERE cierrecajaid =" + intIdCierreCaja;
           // strSql += " and fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Redondeo(Convert.ToDecimal(dt2.Rows[0]["suma"].ToString()));


            else

                return 0;


        }


        public decimal TotalVentaEnEfectivo(Int32 intIdCierreCaja)
        {
            string strSql;

            //strSql = " select isnull(sum(f.efectivoabona-efectivovuelto),0) suma from dbo.Factura f where f.estado='CUMPLIDA' ";
            strSql = " select isnull(sum(p.importe),0) suma from dbo.Factura f,Ventas_Pagos p where f.facturaid = p.ventas_id  and f.estado='CUMPLIDA' ";
            //strSql += " and p.fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";
            strSql += " AND p.cierrecajaid =" + intIdCierreCaja;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Redondeo(Convert.ToDecimal(dt2.Rows[0]["suma"].ToString()));


            else

                return 0;


        }

        public decimal TotalCtaCte(Int32 intIdCierreCaja)
        {
            string strSql;

            strSql = " select isnull(sum(f.ctacte),0) suma from dbo.Factura f, Ventas_Pagos p where f.estado='CUMPLIDA' ";
            strSql += " and p.ventas_id=f.facturaid and p.cierrecajaid=" + intIdCierreCaja;
            //strSql += " and f.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Redondeo(Convert.ToDecimal(dt2.Rows[0]["suma"].ToString()));


            else

                return 0;


        }


        //public decimal TotalVentaConTarjeta(Int32 intIdCierreCaja)
        //{
        //    string strSql;

        //    strSql = " select isnull(sum(tarjetaabona),0) as suma from dbo.Factura f, dbo.Tarjetas_Detalle d where f.facturaid=d.facturaid and f.estado='CUMPLIDA' ";
        //    strSql += " and f.fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";
        //    LlenaCombos objLlenaCombos2 = new LlenaCombos();
        //    DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

        //    if (dt2 != null)

        //        return Redondeo(Convert.ToDecimal(dt2.Rows[0]["suma"].ToString()));


        //    else

        //        return 0;


        //}


        public decimal TotalCompraEnEfectivo(Int32 intIdCierreCaja)
        {
            string strSql;

            strSql = " select isnull(sum(total),0) as suma from Compras where fechabaja is null ";
            strSql += " AND cierrecajaid =" + intIdCierreCaja;
            //strSql += " and fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Redondeo(Convert.ToDecimal(dt2.Rows[0]["suma"].ToString()));


            else

                return 0;


        }


        public decimal TotalDevoluciones(Int32 intIdCierreCaja)
        {
            string strSql;

            strSql = " select isnull(sum(total),0) as suma from Devoluciones where estado='CUMPLIDA' ";
            strSql += " AND cierrecajaid =" + intIdCierreCaja;
            //strSql += " and fechaalta between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "')+1)";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Redondeo(Convert.ToDecimal(dt2.Rows[0]["suma"].ToString()));


            else

                return 0;


        }


        public bool ValidaEsInicioDeCaja(int intNumeroCaja)
        {
            string strSql;


            strSql = " select fecha_cierre from Cierre_caja where cierrecajaid in ( ";
            strSql += " select max(cierrecajaid) from Cierre_Caja where numero_caja = " + intNumeroCaja + " ) ";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);


            if (dt2 != null)
            {
                if (dt2.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }


        public bool ValidaCajaAbierta(int intNumeroCaja)
        {
            string strSql;
            string strFecha;

            strSql = " select fecha_cierre from Cierre_caja where cierrecajaid in ( ";
            strSql += " select max(cierrecajaid) from Cierre_Caja where numero_caja = " + intNumeroCaja + " ) ";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)
            {
                if (dt2.Rows.Count > 0)
                {
                    strFecha = dt2.Rows[0]["fecha_cierre"].ToString();
                    if (String.IsNullOrEmpty(strFecha))
                        return true; //La Caja quedo Abierta
                    else
                        return false;
                }
                else
                    return true;
            }
            else

                return true;
        }


        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }


        public Int32 getCierreCajaId(int intNumeroCaja)
        {
            string strSql;


            strSql = " select cierrecajaid from Cierre_Caja";
            strSql += " where fecha_cierre is null and numero_caja = " + intNumeroCaja;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);


            if (dt2 != null)
            {
                if (dt2.Rows.Count > 0)
                {
                    return Convert.ToInt32( dt2.Rows[0]["cierrecajaid"].ToString()) ;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool ValidaFechaAperturaCierreCaja(int intNumeroCaja)
        {
            string strSql;


            strSql = " select DATEADD(D, 0, DATEDIFF(D, 0,fecha_apertura)) fecha_apertura ";
            strSql += " from Cierre_caja where cierrecajaid = " + intNumeroCaja;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);


            if (dt2 != null)
            {
                if (dt2.Rows.Count > 0)
                {
                    if (Convert.ToDateTime(dt2.Rows[0]["fecha_apertura"].ToString()) != DateTime.Today)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
