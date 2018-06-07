using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaDevoluciones
    {
        public ManejaDevoluciones()
        {
        }

        public int GrabarDevolucion(Devoluciones objDevolucion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[9];

            spParam[0] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[0].Value = objDevolucion.DtFecha;

            spParam[1] = new SqlParameter("@empleadoid", SqlDbType.Int);
            spParam[1].Value = objDevolucion.ObjEmpleado.IntCodigo;

            spParam[2] = new SqlParameter("@clienteid", SqlDbType.Int);
            spParam[2].Value = objDevolucion.ObjCliente.IntCodigo;

            spParam[3] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[3].Value = objDevolucion.StrObservaciones;

            spParam[4] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[4].Value = objDevolucion.DoTotal;

            spParam[5] = new SqlParameter("@estado", SqlDbType.NVarChar);
            spParam[5].Value = objDevolucion.StrEstado;

            spParam[6] = new SqlParameter("@listaprecio", SqlDbType.NVarChar);
            spParam[6].Value = objDevolucion.StrListaPrecio;

            spParam[7] = new SqlParameter("@cierrecajaid", SqlDbType.BigInt);
            spParam[7].Value = objDevolucion.IntNumeroCaja;

            spParam[8] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[8].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Devolucion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[8].Value);

        }


        public int GrabarVentaDetalle(ArticulosPorDevolucion objDevolucionDetalle, Int32 intDevolucion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@devolucionid", SqlDbType.Int);
            spParam[0].Value = intDevolucion;

            spParam[1] = new SqlParameter("@articuloid", SqlDbType.Int);
            spParam[1].Value = objDevolucionDetalle.ObjArticulo.IntCodigo;

            spParam[2] = new SqlParameter("@cantidad", SqlDbType.Int);
            spParam[2].Value = objDevolucionDetalle.IntCantidad;

            spParam[3] = new SqlParameter("@puni", SqlDbType.Decimal);
            spParam[3].Value = objDevolucionDetalle.DoPrecioUnitarioConEfectivo;

            spParam[4] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[4].Value = objDevolucionDetalle.DoTotalConEfectivo;



            spParam[5] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[5].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Devoluciones_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[5].Value);

        }

        public void ModificaDevolucion(Devoluciones objDevolucion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[8];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.Int);
            spParam[0].Value = objDevolucion.IntCodigo;

            spParam[1] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[1].Value = objDevolucion.DtFecha;

            spParam[2] = new SqlParameter("@empleadoid", SqlDbType.Int);
            spParam[2].Value = objDevolucion.ObjEmpleado.IntCodigo;

            spParam[3] = new SqlParameter("@clienteid", SqlDbType.Int);
            spParam[3].Value = objDevolucion.ObjCliente.IntCodigo;

            spParam[4] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[4].Value = objDevolucion.StrObservaciones;

            spParam[5] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[5].Value = objDevolucion.DoTotal;

            spParam[6] = new SqlParameter("@estado", SqlDbType.NVarChar);
            spParam[6].Value = objDevolucion.StrEstado;

            spParam[7] = new SqlParameter("@listaprecio", SqlDbType.NVarChar);
            spParam[7].Value = objDevolucion.StrListaPrecio;

            oManejaConexiones.NombreStoredProcedure = "Upd_Devolucion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

        }


        public void ModificaVentaDetalle(ArticulosPorDevolucion objDevolucionDetalle, Int32 intDevolucion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objDevolucionDetalle.IntCodigo;

            spParam[1] = new SqlParameter("@devolucionid", SqlDbType.BigInt);
            spParam[1].Value = intDevolucion;

            spParam[2] = new SqlParameter("@articuloid", SqlDbType.BigInt);
            spParam[2].Value = objDevolucionDetalle.ObjArticulo.IntCodigo;

            spParam[3] = new SqlParameter("@cantidad", SqlDbType.BigInt);
            spParam[3].Value = objDevolucionDetalle.IntCantidad;

            spParam[4] = new SqlParameter("@puni", SqlDbType.Decimal);
            spParam[4].Value = objDevolucionDetalle.DoPrecioUnitarioConEfectivo;

            spParam[5] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[5].Value = objDevolucionDetalle.DoTotalConEfectivo;


            oManejaConexiones.NombreStoredProcedure = "Upd_Devoluciones_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

        }

        public void EliminaDevolucionesDetalle(int intCodigo)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[1];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;


            oManejaConexiones.NombreStoredProcedure = "Dtl_Devoluciones_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }


        public Devoluciones BuscarDevoluciones(int intCodigo)
        {
            string strSql;

            Devoluciones objDevoluciones = new Devoluciones();
            objDevoluciones.ObjEmpleado = new Empleados();
            objDevoluciones.ObjCliente = new Clientes();

            strSql = "SELECT d.devolucionid,d.fechaalta,d.empleadoid,d.clienteid,d.observaciones,d.total,d.estado,d.listaprecio, isnull(d.cierrecajaid,0) cierrecajaid  ";
            strSql += " FROM Devoluciones d where d.devolucionid =  " + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objDevoluciones.IntCodigo = intCodigo;
            objDevoluciones.DtFecha = Convert.ToDateTime(dt.Rows[0]["fechaalta"].ToString());
            objDevoluciones.ObjEmpleado.IntCodigo = Convert.ToInt32(dt.Rows[0]["empleadoid"].ToString());
            objDevoluciones.ObjCliente.IntCodigo = Convert.ToInt32(dt.Rows[0]["clienteid"].ToString());
            objDevoluciones.StrObservaciones = dt.Rows[0]["observaciones"].ToString();
            objDevoluciones.DoTotal = Convert.ToDecimal(dt.Rows[0]["total"].ToString());
            objDevoluciones.StrEstado = dt.Rows[0]["estado"].ToString();
            objDevoluciones.StrListaPrecio = dt.Rows[0]["listaprecio"].ToString();
            objDevoluciones.IntNumeroCaja = Convert.ToInt32(dt.Rows[0]["cierrecajaid"].ToString());

            objDevoluciones.ListArticulosPorDevolucion = BuscoArticulosxDevolucion(objDevoluciones.IntCodigo);

            return objDevoluciones;


        }

        public List<ArticulosPorDevolucion> BuscoArticulosxDevolucion(int intCodigo)
        {
            string strSql;
            ArticulosPorDevolucion objArticulosPorDevolucion;
            List<ArticulosPorDevolucion> listArticulosPorDevolucion = new List<ArticulosPorDevolucion>();

            strSql = "SELECT d.[detalleid],d.[articuloid],d.[cantidad],d.[puni],d.[total], a.idextra, a.descripcion ";
            strSql += " FROM Devoluciones_Detalle d, dbo.Articulos a where a.id=d.articuloid and d.devolucionid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objArticulosPorDevolucion = new ArticulosPorDevolucion();
                    objArticulosPorDevolucion.ObjArticulo = new Articulos();
                    objArticulosPorDevolucion.IntCodigo = Convert.ToInt32(dt2.Rows[i]["detalleid"].ToString());
                    objArticulosPorDevolucion.ObjArticulo.IntCodigo = Convert.ToInt32(dt2.Rows[i]["articuloid"].ToString());
                    objArticulosPorDevolucion.ObjArticulo.StrCodigo = dt2.Rows[i]["idextra"].ToString();
                    objArticulosPorDevolucion.ObjArticulo.StrDescripcion = dt2.Rows[i]["descripcion"].ToString();
                    objArticulosPorDevolucion.IntCantidad = Convert.ToInt32(dt2.Rows[i]["cantidad"].ToString());
                    objArticulosPorDevolucion.DoPrecioUnitarioConEfectivo = Convert.ToDecimal(dt2.Rows[i]["puni"].ToString());
                    objArticulosPorDevolucion.DoTotalConEfectivo = Convert.ToDecimal(dt2.Rows[i]["total"].ToString());
                    listArticulosPorDevolucion.Add(objArticulosPorDevolucion);


                }


            }
            return listArticulosPorDevolucion;


        }


        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        public string BuscoEstado(int intCodigo)
        {
            string strSql;

            strSql = " select estado from dbo.Devoluciones where devolucionid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return dt2.Rows[0]["estado"].ToString();


            else

                return null;


        }
    }
}
