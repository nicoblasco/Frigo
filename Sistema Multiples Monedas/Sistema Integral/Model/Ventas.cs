using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Ventas
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private DateTime dtFecha;

        public DateTime DtFecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }

        private Empleados objEmpleado;

        public Empleados ObjEmpleado
        {
            get { return objEmpleado; }
            set { objEmpleado = value; }
        }

        private Clientes objCliente;

        public Clientes ObjCliente
        {
            get { return objCliente; }
            set { objCliente = value; }
        }

        private string strObservaciones;

        public string StrObservaciones
        {
            get { return strObservaciones; }
            set { strObservaciones = value; }
        }

        List<ArticulosPorVenta> listArticulosPorVenta;

        public List<ArticulosPorVenta> ListArticulosPorVenta
        {
            get { return listArticulosPorVenta; }
            set { listArticulosPorVenta = value; }
        }

        private decimal doNeto;

        public decimal DoNeto
        {
            get { return doNeto; }
            set { doNeto = value; }
        }
        private int doDescuento;

        public int DoDescuento
        {
            get { return doDescuento; }
            set { doDescuento = value; }
        }
        private decimal doSubtotal;

        public decimal DoSubtotal
        {
            get { return doSubtotal; }
            set { doSubtotal = value; }
        }
        private decimal doIva21;

        public decimal DoIva21
        {
            get { return doIva21; }
            set { doIva21 = value; }
        }
        private decimal doIva105;

        public decimal DoIva105
        {
            get { return doIva105; }
            set { doIva105 = value; }
        }
        private decimal doTotal;

        public decimal DoTotal
        {
            get { return doTotal; }
            set { doTotal = value; }
        }

        SubVentaEfectivo objSubVentaEfectivo;

        public SubVentaEfectivo ObjSubVentaEfectivo
        {
            get { return objSubVentaEfectivo; }
            set { objSubVentaEfectivo = value; }
        }


        SubVentaACtaCte objSubVentaACtaCte;

        public SubVentaACtaCte ObjSubVentaACtaCte
        {
            get { return objSubVentaACtaCte; }
            set { objSubVentaACtaCte = value; }
        }

        private string strEstado;

        public string StrEstado
        {
            get { return strEstado; }
            set { strEstado = value; }
        }

        private List<SubVentaTarjeta> listSubVentaTarjeta;

        public List<SubVentaTarjeta> ListSubVentaTarjeta
        {
            get { return listSubVentaTarjeta; }
            set { listSubVentaTarjeta = value; }
        }
        private List<SubVentaCheque> listSubVentaCheque;

        public List<SubVentaCheque> ListSubVentaCheque
        {
            get { return listSubVentaCheque; }
            set { listSubVentaCheque = value; }
        }

        private List<SubVentaTarjeta> listTarjetasBorradas;

        public List<SubVentaTarjeta> ListTarjetasBorradas
        {
            get { return listTarjetasBorradas; }
            set { listTarjetasBorradas = value; }
        }
        private List<SubVentaCheque> listChequesBorrados;

        public List<SubVentaCheque> ListChequesBorrados
        {
            get { return listChequesBorrados; }
            set { listChequesBorrados = value; }
        }

        private List<Ventas_Pagos> listPagos;

        public List<Ventas_Pagos> ListPagos
        {
            get { return listPagos; }
            set { listPagos = value; }
        }


        private string strMesa;

        public string StrMesa
        {
            get { return strMesa; }
            set { strMesa = value; }
        }

        private decimal doPago;

        public decimal DoPago
        {
            get { return doPago; }
            set { doPago = value; }
        }
        private decimal doDebe;

        public decimal DoDebe
        {
            get { return doDebe; }
            set { doDebe = value; }
        }

        private string strListaPrecio;

        public string StrListaPrecio
        {
            get { return strListaPrecio; }
            set { strListaPrecio = value; }
        }



    }
}
