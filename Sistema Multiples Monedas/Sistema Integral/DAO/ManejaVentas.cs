using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaVentas
    {

        public ManejaVentas()
        {
        }

        public int GrabarVenta(Ventas objVentas)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[17];

            spParam[0] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[0].Value = objVentas.DtFecha;

            spParam[1] = new SqlParameter("@empleadoid", SqlDbType.Int);
            spParam[1].Value = objVentas.ObjEmpleado.IntCodigo;

            spParam[2] = new SqlParameter("@clienteid", SqlDbType.Int);
            spParam[2].Value = objVentas.ObjCliente.IntCodigo;

            spParam[3] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[3].Value = objVentas.StrObservaciones;

            spParam[4] = new SqlParameter("@neto", SqlDbType.Decimal);
            spParam[4].Value = objVentas.DoNeto;

            spParam[5] = new SqlParameter("@descuento", SqlDbType.Int);
            spParam[5].Value = objVentas.DoDescuento;

            spParam[6] = new SqlParameter("@subtotal", SqlDbType.Decimal);
            spParam[6].Value = objVentas.DoSubtotal;

            spParam[7] = new SqlParameter("@iva10", SqlDbType.Decimal);
            spParam[7].Value = objVentas.DoIva105;

            spParam[8] = new SqlParameter("@iva21", SqlDbType.Decimal);
            spParam[8].Value = objVentas.DoIva21;

            spParam[9] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[9].Value = objVentas.DoTotal;

            spParam[10] = new SqlParameter("@efectivoabona", SqlDbType.Decimal);
            spParam[10].Value = objVentas.DoPago;

            spParam[11] = new SqlParameter("@efectivovuelto", SqlDbType.Decimal);
            spParam[11].Value = objVentas.ObjSubVentaEfectivo.DoVuelto;

            spParam[12] = new SqlParameter("@ctacte", SqlDbType.Decimal);
            spParam[12].Value = objVentas.DoDebe;

            spParam[13] = new SqlParameter("@estado", SqlDbType.NVarChar);
            spParam[13].Value = objVentas.StrEstado;

            spParam[14] = new SqlParameter("@ubicacion", SqlDbType.NVarChar);
            spParam[14].Value = objVentas.StrMesa;

            spParam[15] = new SqlParameter("@listaprecio", SqlDbType.NVarChar);
            spParam[15].Value = objVentas.StrListaPrecio;

            spParam[16] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[16].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Factura";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[16].Value);

        }


        public int GrabarVentaDetalle(ArticulosPorVenta objVentaDetalle, Int32 intFactura)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[8];

            spParam[0] = new SqlParameter("@facturaid", SqlDbType.Int);
            spParam[0].Value = intFactura;

            spParam[1] = new SqlParameter("@articuloid", SqlDbType.Int);
            spParam[1].Value = objVentaDetalle.ObjArticulo.IntCodigo;

            spParam[2] = new SqlParameter("@unidades", SqlDbType.Int);
            spParam[2].Value = objVentaDetalle.IntUnidades;

            spParam[3] = new SqlParameter("@cantidad", SqlDbType.Decimal);
            spParam[3].Value = objVentaDetalle.IntCantidad;

            spParam[4] = new SqlParameter("@puni", SqlDbType.Decimal);
            spParam[4].Value = objVentaDetalle.DoPrecioUnitarioConEfectivo;

            spParam[5] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[5].Value = objVentaDetalle.DoTotalConEfectivo;

            spParam[6] = new SqlParameter("@linea", SqlDbType.Int);
            spParam[6].Value = objVentaDetalle.IntLinea;

            spParam[7] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[7].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Factura_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[7].Value);

        }




        public int GrabarSeguimiento(Seguimiento objSeguimiento)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@facturaid", SqlDbType.Int);
            spParam[0].Value = objSeguimiento.IntFacturaID;

            spParam[1] = new SqlParameter("@fecha", SqlDbType.DateTime);
            spParam[1].Value = objSeguimiento.DtFecha;

            spParam[2] = new SqlParameter("@usuarioid", SqlDbType.Int);
            spParam[2].Value = objSeguimiento.IntUsuarioID;

            spParam[3] = new SqlParameter("@estadodesde", SqlDbType.NVarChar);
            spParam[3].Value = objSeguimiento.StrEstadoDesde;

            spParam[4] = new SqlParameter("@estadohasta", SqlDbType.NVarChar);
            spParam[4].Value = objSeguimiento.StrEstadoHasta;

            spParam[5] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[5].Direction = ParameterDirection.Output;

            oManejaConexiones.NombreStoredProcedure = "Add_Seguimiento";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[5].Value);

        }

        public int GrabarTarjetas(SubVentaTarjeta objTarjetas, Int32 intFactura)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[7];

            spParam[0] = new SqlParameter("@facturaid", SqlDbType.Int);
            spParam[0].Value = intFactura;

            spParam[1] = new SqlParameter("@tarjetaabona", SqlDbType.Decimal);
            spParam[1].Value = objTarjetas.DoAbona;

            spParam[2] = new SqlParameter("@tarjetanombre", SqlDbType.NVarChar);
            spParam[2].Value = objTarjetas.StrTarjeta;

            spParam[3] = new SqlParameter("@tarjetanumero", SqlDbType.NVarChar);
            spParam[3].Value = objTarjetas.StrNumero;

            spParam[4] = new SqlParameter("@tarjetacuotas", SqlDbType.NVarChar);
            spParam[4].Value = objTarjetas.StrCuotas;

            spParam[5] = new SqlParameter("@tipo", SqlDbType.NVarChar);
            spParam[5].Value = objTarjetas.StrTipo;

            spParam[6] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[6].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Tarjeta_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[6].Value);

        }


        public int GrabarCheques(SubVentaCheque objCheques, Int32 intFactura)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@facturaid", SqlDbType.Int);
            spParam[0].Value = intFactura;

            spParam[1] = new SqlParameter("@chequeabona", SqlDbType.Decimal);
            spParam[1].Value = objCheques.DoAbona;

            spParam[2] = new SqlParameter("@chequebanco", SqlDbType.NVarChar);
            spParam[2].Value = objCheques.StrBanco;

            spParam[3] = new SqlParameter("@chequenumero", SqlDbType.NVarChar);
            spParam[3].Value = objCheques.StrNumero;

            spParam[4] = new SqlParameter("@chequevenc", SqlDbType.DateTime);
            spParam[4].Value = objCheques.DtFechaVencimiento;


            spParam[5] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[5].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Cheque_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[5].Value);

        }

        public void GrabarVentasPagos(Ventas_Pagos objPagos, int intVenta)
        {

            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam5 = new SqlParameter[5];

            spParam5[0] = new SqlParameter("@ventas_id", SqlDbType.BigInt);
            spParam5[0].Value = intVenta;

            spParam5[1] = new SqlParameter("@fecha", SqlDbType.DateTime);
            spParam5[1].Value = objPagos.DtFecha;

            spParam5[2] = new SqlParameter("@importe", SqlDbType.Money);
            spParam5[2].Value = objPagos.DeImporte;

            spParam5[3] = new SqlParameter("@cierrecajaid", SqlDbType.BigInt);
            spParam5[3].Value = objPagos.IntNumeroCaja;

            spParam5[4] = new SqlParameter("@mediopago", SqlDbType.Int);
            spParam5[4].Value = objPagos.IntMedioPago;


            oManejaConexiones2.NombreStoredProcedure = "Add_Ventas_Pagos";
            oManejaConexiones2.Parametros = spParam5;
            oManejaConexiones2.executeNonQuery();

        }


        public void ModificaVentas(Ventas objVentas)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[17];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objVentas.IntCodigo;

            spParam[1] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[1].Value = objVentas.DtFecha;

            spParam[2] = new SqlParameter("@empleadoid", SqlDbType.Int);
            spParam[2].Value = objVentas.ObjEmpleado.IntCodigo;

            spParam[3] = new SqlParameter("@clienteid", SqlDbType.Int);
            spParam[3].Value = objVentas.ObjCliente.IntCodigo;

            spParam[4] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[4].Value = objVentas.StrObservaciones;

            spParam[5] = new SqlParameter("@neto", SqlDbType.Decimal);
            spParam[5].Value = objVentas.DoNeto;

            spParam[6] = new SqlParameter("@descuento", SqlDbType.Int);
            spParam[6].Value = objVentas.DoDescuento;

            spParam[7] = new SqlParameter("@subtotal", SqlDbType.Decimal);
            spParam[7].Value = objVentas.DoSubtotal;

            spParam[8] = new SqlParameter("@iva10", SqlDbType.Decimal);
            spParam[8].Value = objVentas.DoIva105;

            spParam[9] = new SqlParameter("@iva21", SqlDbType.Decimal);
            spParam[9].Value = objVentas.DoIva21;

            spParam[10] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[10].Value = objVentas.DoTotal;

            spParam[11] = new SqlParameter("@efectivoabona", SqlDbType.Decimal);
            spParam[11].Value = objVentas.DoPago;

            spParam[12] = new SqlParameter("@efectivovuelto", SqlDbType.Decimal);
            spParam[12].Value = objVentas.ObjSubVentaEfectivo.DoVuelto;

            spParam[13] = new SqlParameter("@ctacte", SqlDbType.Decimal);
            spParam[13].Value = objVentas.DoDebe;

            spParam[14] = new SqlParameter("@estado", SqlDbType.NVarChar);
            spParam[14].Value = objVentas.StrEstado;

            spParam[15] = new SqlParameter("@ubicacion", SqlDbType.NVarChar);
            spParam[15].Value = objVentas.StrMesa;

            spParam[16] = new SqlParameter("@listaprecio", SqlDbType.NVarChar);
            spParam[16].Value = objVentas.StrListaPrecio;

            oManejaConexiones.NombreStoredProcedure = "Upd_Factura";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void ModificaVentaDetalle(ArticulosPorVenta objVentaDetalle, Int32 intFactura)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[9];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objVentaDetalle.IntCodigo;

            spParam[1] = new SqlParameter("@facturaid", SqlDbType.Int);
            spParam[1].Value = intFactura;

            spParam[2] = new SqlParameter("@articuloid", SqlDbType.Int);
            spParam[2].Value = objVentaDetalle.ObjArticulo.IntCodigo;

            spParam[3] = new SqlParameter("@cantidad", SqlDbType.Decimal);
            spParam[3].Value = objVentaDetalle.IntCantidad;

            spParam[4] = new SqlParameter("@puni", SqlDbType.Decimal);
            spParam[4].Value = objVentaDetalle.DoPrecioUnitarioConEfectivo;

            spParam[5] = new SqlParameter("@descuento", SqlDbType.Int);
            spParam[5].Value = objVentaDetalle.IntDescuento;

            spParam[6] = new SqlParameter("@total", SqlDbType.Decimal);
            spParam[6].Value = objVentaDetalle.DoTotalConEfectivo;

            spParam[7] = new SqlParameter("@unidades", SqlDbType.Int);
            spParam[7].Value = objVentaDetalle.IntUnidades;

            spParam[8] = new SqlParameter("@linea", SqlDbType.Int);
            spParam[8].Value = objVentaDetalle.IntLinea;

            oManejaConexiones.NombreStoredProcedure = "Upd_Factura_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }


        public void ModificarTarjetas(SubVentaTarjeta objTarjetas)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[7];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objTarjetas.IntCodigo;

            spParam[1] = new SqlParameter("@tarjetaabona", SqlDbType.Decimal);
            spParam[1].Value = objTarjetas.DoAbona;

            spParam[2] = new SqlParameter("@tarjetanombre", SqlDbType.NVarChar);
            spParam[2].Value = objTarjetas.StrTarjeta;

            spParam[3] = new SqlParameter("@tarjetanumero", SqlDbType.NVarChar);
            spParam[3].Value = objTarjetas.StrNumero;

            spParam[4] = new SqlParameter("@tarjetacuotas", SqlDbType.NVarChar);
            spParam[4].Value = objTarjetas.StrCuotas;

            spParam[5] = new SqlParameter("@tipo", SqlDbType.NVarChar);
            spParam[5].Value = objTarjetas.StrTipo;


            oManejaConexiones.NombreStoredProcedure = "Upd_Tarjeta_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();



        }


        public void ModificarCheques(SubVentaCheque objCheques)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objCheques.IntCodigo;

            spParam[1] = new SqlParameter("@chequeabona", SqlDbType.Decimal);
            spParam[1].Value = objCheques.DoAbona;

            spParam[2] = new SqlParameter("@chequebanco", SqlDbType.NVarChar);
            spParam[2].Value = objCheques.StrBanco;

            spParam[3] = new SqlParameter("@chequenumero", SqlDbType.NVarChar);
            spParam[3].Value = objCheques.StrNumero;

            spParam[4] = new SqlParameter("@chequevenc", SqlDbType.DateTime);
            spParam[4].Value = objCheques.DtFechaVencimiento;


            oManejaConexiones.NombreStoredProcedure = "Upd_Cheque_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }


        public void ModificaVentasPagos(Ventas_Pagos objPagos)
        {

            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam5 = new SqlParameter[4];

            spParam5[0] = new SqlParameter("@ventas_pagos_id", SqlDbType.BigInt);
            spParam5[0].Value = objPagos.IntCodigo;

            spParam5[1] = new SqlParameter("@fecha", SqlDbType.DateTime);
            spParam5[1].Value = objPagos.DtFecha;

            spParam5[2] = new SqlParameter("@importe", SqlDbType.Money);
            spParam5[2].Value = objPagos.DeImporte;

            spParam5[3] = new SqlParameter("@mediopago", SqlDbType.Int);
            spParam5[3].Value = objPagos.IntMedioPago;

            oManejaConexiones2.NombreStoredProcedure = "Upd_Ventas_Pagos";
            oManejaConexiones2.Parametros = spParam5;
            oManejaConexiones2.executeNonQuery();

        }


        public void EliminaVentaDetalle(int intCodigo)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[1];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;


            oManejaConexiones.NombreStoredProcedure = "Dtl_Factura_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void EliminaTarjeta(int intCodigo)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[1];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;


            oManejaConexiones.NombreStoredProcedure = "Dtl_Tarjeta_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }


        public void EliminaCheque(int intCodigo)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[1];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;


            oManejaConexiones.NombreStoredProcedure = "Dtl_Cheque_Detalle";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }


        public void EliminaVentasPago(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Ventas_Pagos";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }


        public void VerificaModificacionVentasPagos(Ventas_Pagos objPagos, int intCodigoVenta)
        {
            //Si tiene un codigo asignado es porque el contacto ya existia
            //Tambien debo tener el cuenta la transaccion que hizo con el campo intEstado
            //para esto se debera considerar los valores (0,1,2,3) 


            if (objPagos.IntCodigo != 0)
            //El contacto ya existia
            {
                //Me fijo que hay que hacer con el contacto
                if (objPagos.IntEstado == 2)//Modifico
                {
                    ModificaVentasPagos(objPagos);
                }
                if (objPagos.IntEstado == 3)//Elimino
                {
                    EliminaVentasPago(objPagos.IntCodigo);

                }
                //sino no hago nada, todo queda como esta


            }
            else
            {
                //En este caso debe ser un alta de un contacto
                //Hay que tener en cuenta todos los estados menos el 3, que es el de baja
                if (objPagos.IntEstado != 3)
                {
                    GrabarVentasPagos(objPagos, intCodigoVenta);

                }

            }



        }

        public Ventas BuscarVentas(int intCodigo)
        {
            string strSql;
            Ventas objVentas = new Ventas();
            objVentas.ObjEmpleado = new Empleados();
            objVentas.ObjCliente = new Clientes();
            objVentas.ObjSubVentaEfectivo = new SubVentaEfectivo();
            /*objVentas.ObjSubVentaTarjeta = new SubVentaTarjeta();
            objVentas.ObjSubVentaCheque = new SubVentaCheque();*/
            objVentas.ObjSubVentaACtaCte = new SubVentaACtaCte();
            objVentas.ListTarjetasBorradas = new List<SubVentaTarjeta>();
            objVentas.ListChequesBorrados = new List<SubVentaCheque>();
            objVentas.ListPagos = new List<Ventas_Pagos>();



            strSql = "SELECT [fechaalta],[empleadoid],[clienteid],[observaciones],[neto],[descuento],[subtotal],[iva10],[iva21],[total],[efectivoabona],[efectivovuelto],[ctacte],[estado],[ubicacion], listaprecio ";
            strSql += " FROM factura where facturaid = " + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objVentas.IntCodigo = intCodigo;
            objVentas.DtFecha = Convert.ToDateTime(dt.Rows[0]["fechaalta"].ToString());
            objVentas.ObjEmpleado.IntCodigo = Convert.ToInt32(dt.Rows[0]["empleadoid"].ToString());
            objVentas.ObjCliente.IntCodigo = Convert.ToInt32(dt.Rows[0]["clienteid"].ToString());
            objVentas.StrObservaciones = dt.Rows[0]["observaciones"].ToString();
            objVentas.DoNeto = Convert.ToDecimal(dt.Rows[0]["neto"].ToString());
            objVentas.DoDescuento = Convert.ToInt32(dt.Rows[0]["descuento"].ToString());
            objVentas.DoSubtotal = Convert.ToDecimal(dt.Rows[0]["subtotal"].ToString());
            objVentas.DoIva105 = Convert.ToDecimal(dt.Rows[0]["iva10"].ToString());
            objVentas.DoIva21 = Convert.ToDecimal(dt.Rows[0]["iva21"].ToString());
            objVentas.DoTotal = Convert.ToDecimal(dt.Rows[0]["total"].ToString());
            objVentas.DoPago = Convert.ToDecimal(dt.Rows[0]["efectivoabona"].ToString());
            objVentas.ObjSubVentaEfectivo.DoVuelto = Convert.ToDecimal(dt.Rows[0]["efectivovuelto"].ToString());
            /*   objVentas.ObjSubVentaTarjeta.DoAbona = Convert.ToDecimal(dt.Rows[0]["tarjetaabona"].ToString());
               objVentas.ObjSubVentaTarjeta.StrTarjeta = dt.Rows[0]["tarjetanombre"].ToString();
               objVentas.ObjSubVentaTarjeta.StrNumero = dt.Rows[0]["tarjetanumero"].ToString();
               objVentas.ObjSubVentaTarjeta.StrCuotas = dt.Rows[0]["tarjetacuotas"].ToString();
               objVentas.ObjSubVentaCheque.DoAbona = Convert.ToDecimal(dt.Rows[0]["chequeabona"].ToString());
               objVentas.ObjSubVentaCheque.DtFechaVencimiento = Convert.ToDateTime(dt.Rows[0]["chequevenc"].ToString());
               objVentas.ObjSubVentaCheque.StrBanco = dt.Rows[0]["chequebanco"].ToString();
               objVentas.ObjSubVentaCheque.StrNumero = dt.Rows[0]["chequenumero"].ToString();*/
            objVentas.DoDebe = Convert.ToDecimal(dt.Rows[0]["ctacte"].ToString());
            objVentas.StrEstado = dt.Rows[0]["estado"].ToString();
            objVentas.StrMesa = dt.Rows[0]["ubicacion"].ToString();
            objVentas.StrListaPrecio = dt.Rows[0]["listaprecio"].ToString();


            objVentas.ListArticulosPorVenta = BuscoArticulosxVenta(objVentas.IntCodigo);
            //objVentas.ListSubVentaTarjeta = BuscoTarjetasEnVenta(objVentas.IntCodigo);
            //objVentas.ListSubVentaCheque = BuscoChequesEnVenta(objVentas.IntCodigo);
            objVentas.ListPagos = BuscoPagos(objVentas.IntCodigo);

            return objVentas;


        }

        public List<ArticulosPorVenta> BuscoArticulosxVenta(int intCodigo)
        {
            string strSql;
            ArticulosPorVenta objArticulosPorVenta;
            List<ArticulosPorVenta> listArticulosPorVenta = new List<ArticulosPorVenta>();

            strSql = "SELECT d.[detalleid],d.[articuloid],d.[cantidad],d.[puni],d.[descuento],d.[total], a.idextra, a.descripcion, d.unidades, d.linea ";
            strSql += " FROM Factura_Detalle d, dbo.Articulos a where a.id=d.articuloid and d.facturaid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objArticulosPorVenta = new ArticulosPorVenta();
                    objArticulosPorVenta.ObjArticulo = new Articulos();
                    objArticulosPorVenta.IntCodigo = Convert.ToInt32(dt2.Rows[i]["detalleid"].ToString());
                    objArticulosPorVenta.ObjArticulo.IntCodigo = Convert.ToInt32(dt2.Rows[i]["articuloid"].ToString());
                    objArticulosPorVenta.ObjArticulo.StrCodigo = dt2.Rows[i]["idextra"].ToString();
                    objArticulosPorVenta.ObjArticulo.StrDescripcion = dt2.Rows[i]["descripcion"].ToString();
                    objArticulosPorVenta.IntCantidad = Convert.ToDecimal(dt2.Rows[i]["cantidad"].ToString());
                    objArticulosPorVenta.IntUnidades = Convert.ToInt32(dt2.Rows[i]["unidades"].ToString());
                    objArticulosPorVenta.IntLinea = Convert.ToInt32(dt2.Rows[i]["linea"].ToString());

                    if (String.IsNullOrEmpty(dt2.Rows[i]["puni"].ToString()))
                        objArticulosPorVenta.DoPrecioUnitarioConEfectivo = 0;
                    else
                        objArticulosPorVenta.DoPrecioUnitarioConEfectivo = Convert.ToDecimal(dt2.Rows[i]["puni"].ToString());

                    if (String.IsNullOrEmpty(dt2.Rows[i]["descuento"].ToString()))
                        objArticulosPorVenta.IntDescuento = 0;
                    else
                        objArticulosPorVenta.IntDescuento = Convert.ToInt32(dt2.Rows[i]["descuento"].ToString());

                    if (String.IsNullOrEmpty(dt2.Rows[i]["total"].ToString()))
                        objArticulosPorVenta.DoTotalConEfectivo = 0;
                    else
                        objArticulosPorVenta.DoTotalConEfectivo = Convert.ToDecimal(dt2.Rows[i]["total"].ToString());

                    listArticulosPorVenta.Add(objArticulosPorVenta);


                }


            }
            return listArticulosPorVenta;


        }


        public List<SubVentaTarjeta> BuscoTarjetasEnVenta(int intCodigo)
        {
            string strSql;
            SubVentaTarjeta objSubVentaTarjeta;
            List<SubVentaTarjeta> listTarjetasEnVenta = new List<SubVentaTarjeta>();

            strSql = "select id,tarjetaabona,tarjetanombre,tarjetanumero,tarjetacuotas,tipo ";
            strSql += " from dbo.Tarjetas_Detalle where facturaid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {

                    objSubVentaTarjeta = new SubVentaTarjeta();
                    objSubVentaTarjeta.IntCodigo = Convert.ToInt32(dt2.Rows[i]["id"].ToString());
                    objSubVentaTarjeta.DoAbona = Convert.ToDecimal(dt2.Rows[i]["tarjetaabona"].ToString());
                    objSubVentaTarjeta.StrTarjeta = dt2.Rows[i]["tarjetanombre"].ToString();
                    objSubVentaTarjeta.StrNumero = dt2.Rows[i]["tarjetanumero"].ToString();
                    objSubVentaTarjeta.StrCuotas = dt2.Rows[i]["tarjetacuotas"].ToString();
                    objSubVentaTarjeta.StrTipo = dt2.Rows[i]["tipo"].ToString();
                    listTarjetasEnVenta.Add(objSubVentaTarjeta);


                }


            }
            return listTarjetasEnVenta;


        }


        public List<SubVentaCheque> BuscoChequesEnVenta(int intCodigo)
        {
            string strSql;
            SubVentaCheque objSubVentaCheque;
            List<SubVentaCheque> listChequesEnVenta = new List<SubVentaCheque>();

            strSql = "select id,chequeabona, chequebanco,chequenumero,chequevenc ";
            strSql += " from dbo.Cheques_Detalle where facturaid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objSubVentaCheque = new SubVentaCheque();
                    objSubVentaCheque.IntCodigo = Convert.ToInt32(dt2.Rows[i]["id"].ToString());
                    objSubVentaCheque.DoAbona = Convert.ToDecimal(dt2.Rows[i]["chequeabona"].ToString());
                    objSubVentaCheque.StrBanco = dt2.Rows[i]["chequebanco"].ToString();
                    objSubVentaCheque.StrNumero = dt2.Rows[i]["chequenumero"].ToString();
                    objSubVentaCheque.DtFechaVencimiento = Convert.ToDateTime(dt2.Rows[i]["chequevenc"].ToString());
                    listChequesEnVenta.Add(objSubVentaCheque);


                }


            }
            return listChequesEnVenta;


        }


        public List<Ventas_Pagos> BuscoPagos(int intCodigo)
        {
            string strSql;
            Ventas_Pagos objPagos;
            List<Ventas_Pagos> listPagos = new List<Ventas_Pagos>();

            strSql = "select ventas_pagos_id,ventas_id,fecha,importe, cierrecajaid, mediopago ";
            strSql += "from Ventas_Pagos where ventas_id=" + intCodigo;
            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);
            if (dt2 != null)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objPagos = new Ventas_Pagos();
                    objPagos.IntCodigo = Convert.ToInt32(dt2.Rows[i]["ventas_pagos_id"].ToString());
                    objPagos.DtFecha = Convert.ToDateTime(dt2.Rows[i]["fecha"].ToString());
                    objPagos.DeImporte = Convert.ToDecimal(dt2.Rows[i]["importe"].ToString());
                    objPagos.IntNumeroCaja = Convert.ToInt32(dt2.Rows[i]["cierrecajaid"].ToString());
                    objPagos.IntMedioPago = Convert.ToInt32(dt2.Rows[i]["mediopago"].ToString());

                    listPagos.Add(objPagos);

                }


            }
            return listPagos;
        }


        public List<Seguimiento> BuscoSeguimiento(int intCodigo)
        {
            string strSql;
            Seguimiento objSeguimiento;
            List<Seguimiento> listSeguimiento = new List<Seguimiento>();

            strSql = "select * from Seguimiento s, Usuarios u where s.usuarioid = u.id and facturaid=" + intCodigo;
            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);
            if (dt2 != null)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objSeguimiento = new Seguimiento();
                    objSeguimiento.IntCodigo = Convert.ToInt32(dt2.Rows[i]["seguimientoid"].ToString());
                    objSeguimiento.IntFacturaID = Convert.ToInt32(dt2.Rows[i]["facturaid"].ToString());
                    objSeguimiento.DtFecha = Convert.ToDateTime(dt2.Rows[i]["fecha"].ToString());
                    objSeguimiento.IntUsuarioID = Convert.ToInt32(dt2.Rows[i]["usuarioid"].ToString());
                    objSeguimiento.StrUsuario = dt2.Rows[i]["usuario"].ToString();
                    objSeguimiento.StrEstadoDesde = dt2.Rows[i]["estadodesde"].ToString();
                    objSeguimiento.StrEstadoHasta = dt2.Rows[i]["estadohasta"].ToString();

                    listSeguimiento.Add(objSeguimiento);

                }


            }
            return listSeguimiento;
        }

        public int BuscoStock(int intCodigo)
        {
            string strSql;

            strSql = " select cantidad from dbo.Factura_Detalle where detalleid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Convert.ToInt32(dt2.Rows[0]["cantidad"].ToString());


            else

                return 0;


        }

        public string BuscoEstado(int intCodigo)
        {
            string strSql;

            strSql = " select estado from dbo.Factura where facturaid = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return dt2.Rows[0]["estado"].ToString();


            else

                return null;


        }


        public List<VentasReporte> ReporteDeCantidadTotalesDeArticulos(DataTable dt)
        {
            List<VentasReporte> ListVentas = new List<VentasReporte>();
            VentasReporte objVentas;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        objVentas = new VentasReporte();

                        objVentas.IntFacturaid = Convert.ToInt32(dt.Rows[i]["facturaid"].ToString());
                        objVentas.DtFechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                        objVentas.StrEstado = dt.Rows[i]["estado"].ToString();
                        objVentas.StrEmpleado = dt.Rows[i]["empleado"].ToString();
                        objVentas.StrCliente = dt.Rows[i]["cliente"].ToString();
                        objVentas.IntCantidad = Convert.ToDecimal(dt.Rows[i]["cantidad"].ToString());
                        objVentas.DePuni = Redondeo(Convert.ToDecimal(dt.Rows[i]["efectivo"].ToString()));
                        objVentas.DeTarjeta = Redondeo(Convert.ToDecimal(dt.Rows[i]["tarjeta"].ToString()));
                        objVentas.DeCheque = Redondeo(Convert.ToDecimal(dt.Rows[i]["cheque"].ToString()));
                        objVentas.DeCtaCte = Redondeo(Convert.ToDecimal(dt.Rows[i]["Ctacte"].ToString()));
                        objVentas.DeTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString()));
                        objVentas.IntDescuento = Convert.ToInt32(dt.Rows[i]["descuento"].ToString());
                        objVentas.DeNeto = Redondeo(Convert.ToDecimal(dt.Rows[i]["neto"].ToString()));

                        ListVentas.Add(objVentas);

                    }
                }
            }
            return ListVentas;

        }



        public List<VentasReporte> ReporteDetalladoPorArticulos(DataTable dt)
        {
            List<VentasReporte> ListVentas = new List<VentasReporte>();
            VentasReporte objVentas;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        objVentas = new VentasReporte();
                        objVentas.IntFacturaid = Convert.ToInt32(dt.Rows[i]["facturaid"].ToString());
                        objVentas.DtFechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                        objVentas.StrEstado = dt.Rows[i]["estado"].ToString();
                        objVentas.StrEmpleado = dt.Rows[i]["empleado"].ToString();
                        objVentas.StrCliente = dt.Rows[i]["cliente"].ToString();
                        objVentas.IntCantidad = Convert.ToDecimal(dt.Rows[i]["cantidad"].ToString());
                        objVentas.StrArticulos = dt.Rows[i]["descripcion"].ToString();
                        objVentas.IntDescuento = Convert.ToInt32(dt.Rows[i]["descuento"].ToString());
                        objVentas.DePuni = Redondeo(Convert.ToDecimal(dt.Rows[i]["puni"].ToString()));
                        objVentas.DeTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString()));

                        ListVentas.Add(objVentas);

                    }
                }
            }
            return ListVentas;

        }

        public List<VentasReporte> ReporteDetalladoPorMedioDePago(DataTable dt)
        {
            List<VentasReporte> ListVentas = new List<VentasReporte>();
            VentasReporte objVentas;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        objVentas = new VentasReporte();
                        objVentas.IntFacturaid = Convert.ToInt32(dt.Rows[i]["facturaid"].ToString());
                        objVentas.DtFechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                        objVentas.StrEstado = dt.Rows[i]["estado"].ToString();
                        objVentas.StrEmpleado = dt.Rows[i]["empleado"].ToString();
                        objVentas.StrCliente = dt.Rows[i]["cliente"].ToString();
                       // objVentas.IntCaja = Convert.ToInt32(dt.Rows[i]["numero_caja"].ToString());
                        objVentas.StrMedioPago = dt.Rows[i]["descripcion"].ToString();
                        objVentas.DeTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString()));
                        objVentas.DtFechaPago = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());

                        ListVentas.Add(objVentas);

                    }
                }
            }
            return ListVentas;

        }

        public List<VentasReporte> ReporteTotales(DataTable dt, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<VentasReporte> ListVentas = new List<VentasReporte>();
            VentasReporte objVentas;
            decimal intCantidad = 0;
            decimal dePuni = 0;
            decimal deTarjeta = 0;
            decimal deCheque = 0;
            decimal deCtaCte = 0;
            decimal deTotal = 0;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        intCantidad += Convert.ToDecimal(dt.Rows[i]["cantidad"].ToString());
                        //dePuni += Convert.ToDecimal(dt.Rows[i]["efectivo"].ToString());
                        dePuni += Convert.ToDecimal(dt.Rows[i]["pagado"].ToString());
                        // deTarjeta += Convert.ToDecimal(dt.Rows[i]["tarjeta"].ToString());
                        //deCheque += Convert.ToDecimal(dt.Rows[i]["cheque"].ToString());
                        deCtaCte += Convert.ToDecimal(dt.Rows[i]["Ctacte"].ToString());
                        deTotal += Convert.ToDecimal(dt.Rows[i]["total"].ToString());

                    }
                    objVentas = new VentasReporte();
                    objVentas.DtFechaDesde = fechaDesde;
                    objVentas.DtFechaHasta = fechaHasta;
                    objVentas.IntCantidad = intCantidad;
                    objVentas.DePuni = Redondeo(dePuni);
                    objVentas.DeTarjeta = Redondeo(deTarjeta);
                    objVentas.DeCheque = Redondeo(deCheque);
                    objVentas.DeCtaCte = Redondeo(deCtaCte);
                    objVentas.DeTotal = Redondeo(deTotal);

                    ListVentas.Add(objVentas);
                }
            }
            return ListVentas;

        }


        public List<VentasReportePago> ReporteDePagosDevoluciones (DataTable dt)
        {
            List<VentasReportePago> ListPagos = new List<VentasReportePago>();
            VentasReportePago objPagos;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        objPagos = new VentasReportePago();

                        objPagos.StrTipo = dt.Rows[i]["tipo"].ToString();
                        objPagos.IntId = Convert.ToInt32(dt.Rows[i]["facturaid"].ToString());
                        objPagos.DtFecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                        objPagos.DeTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["importe"].ToString()));
                        ListPagos.Add(objPagos);

                    }
                }
            }
            return ListPagos;

        }


        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        public int BuscoMedioDePagoPredeterminado()
        {
            string strSql;

            strSql = " select mediopago from Medio_Pago where predeterminado=1 ";

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return Convert.ToInt32( dt2.Rows[0]["mediopago"].ToString());


            else
            {

                strSql = " select mediopago from Medio_Pago where mediopago  =( select min(mediopago) from Medio_Pago)  ";

                LlenaCombos objLlenaCombos3 = new LlenaCombos();
                DataTable dt3 = objLlenaCombos3.GetSqlDataAdapterbySql(strSql);

                if (dt3 != null)

                    return Convert.ToInt32(dt3.Rows[0]["mediopago"].ToString());
                else
                    return 0;
            }

        }


        public string BuscoNombreDeMedioDePago(int intCodigo)
        {
            string strSql;

            strSql = " select descripcion from dbo.Medio_Pago where mediopago = " + intCodigo;

            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return dt2.Rows[0]["descripcion"].ToString();


            else

                return null;


        }


        public string BuscoTotalDineroEnEfectivo(Int32 intIdCierreCaja , string strFecha)
        {
            string strSql;

            strSql = " select isnull(sum(p.importe),0) as total" ;
            strSql += " from dbo.Ventas_Pagos p,dbo.Medio_Pago m where m.mediopago = p.mediopago ";
            strSql += " and p.fecha between DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))" + " and DATEADD(D, 0, DATEDIFF(D, 0," + "'" + strFecha + "'))+1";
            strSql += " and p.cierrecajaid = " + intIdCierreCaja;
            strSql += " and m.descripcion = 'EFECTIVO'";
            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);

            if (dt2 != null)

                return dt2.Rows[0]["total"].ToString();


            else

                return "0";


        }

        public List<Ventas> BuscoFacturasConDeuda(Int32 intClienteId)
        {
            string strSql;
            Ventas objVentas;
            List<Ventas> list = new List<Ventas>();

           // 
            /*objVentas.ObjSubVentaTarjeta = new SubVentaTarjeta();
            objVentas.ObjSubVentaCheque = new SubVentaCheque();*/
           // objVentas.ObjSubVentaACtaCte = new SubVentaACtaCte();
           // objVentas.ListTarjetasBorradas = new List<SubVentaTarjeta>();
           // objVentas.ListChequesBorrados = new List<SubVentaCheque>();
           // objVentas.ListPagos = new List<Ventas_Pagos>();



            strSql = "SELECT facturaid, [fechaalta],[empleadoid],[clienteid],[observaciones],[neto],[descuento],[subtotal],[iva10],[iva21],[total],[efectivoabona],[efectivovuelto],[ctacte],[estado],[ubicacion], listaprecio ";
            strSql += " FROM factura where estado='CUMPLIDA' and ctacte>0 and clienteid = " + intClienteId;
            strSql += " order by fechaalta asc ";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        objVentas = new Ventas();
                        objVentas.ObjEmpleado = new Empleados();
                        objVentas.ObjCliente = new Clientes();
                        objVentas.ObjSubVentaEfectivo = new SubVentaEfectivo();
                        objVentas.IntCodigo = Convert.ToInt32(dt.Rows[i]["facturaid"].ToString());
                        objVentas.DtFecha = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                        objVentas.ObjEmpleado.IntCodigo = Convert.ToInt32(dt.Rows[i]["empleadoid"].ToString());
                        objVentas.ObjCliente.IntCodigo = Convert.ToInt32(dt.Rows[i]["clienteid"].ToString());
                        objVentas.StrObservaciones = dt.Rows[i]["observaciones"].ToString();
                        objVentas.DoNeto = Convert.ToDecimal(dt.Rows[i]["neto"].ToString());
                        objVentas.DoDescuento = Convert.ToInt32(dt.Rows[i]["descuento"].ToString());
                        objVentas.DoSubtotal = Convert.ToDecimal(dt.Rows[i]["subtotal"].ToString());
                        objVentas.DoIva105 = Convert.ToDecimal(dt.Rows[i]["iva10"].ToString());
                        objVentas.DoIva21 = Convert.ToDecimal(dt.Rows[i]["iva21"].ToString());
                        objVentas.DoTotal = Convert.ToDecimal(dt.Rows[i]["total"].ToString());
                        objVentas.DoPago = Convert.ToDecimal(dt.Rows[i]["efectivoabona"].ToString());
                        objVentas.ObjSubVentaEfectivo.DoVuelto = Convert.ToDecimal(dt.Rows[i]["efectivovuelto"].ToString());
                        objVentas.DoDebe = Convert.ToDecimal(dt.Rows[i]["ctacte"].ToString());
                        objVentas.StrEstado = dt.Rows[i]["estado"].ToString();
                        objVentas.StrMesa = dt.Rows[i]["ubicacion"].ToString();
                        objVentas.StrListaPrecio = dt.Rows[i]["listaprecio"].ToString();


                        //objVentas.ListArticulosPorVenta = BuscoArticulosxVenta(objVentas.IntCodigo);
                        //objVentas.ListSubVentaTarjeta = BuscoTarjetasEnVenta(objVentas.IntCodigo);
                        //objVentas.ListSubVentaCheque = BuscoChequesEnVenta(objVentas.IntCodigo);
                        //objVentas.ListPagos = BuscoPagos(objVentas.IntCodigo);
                        list.Add(objVentas);
                    }
                }
            }
            return list;
        }

    }
}
