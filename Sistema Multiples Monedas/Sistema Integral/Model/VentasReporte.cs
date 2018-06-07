using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class VentasReporte
    {
        private int intFacturaid;

        public int IntFacturaid
        {
            get { return intFacturaid; }
            set { intFacturaid = value; }
        }
        private DateTime dtFechaDesde;

        public DateTime DtFechaDesde
        {
            get { return dtFechaDesde; }
            set { dtFechaDesde = value; }
        }
        private DateTime dtFechaHasta;

        public DateTime DtFechaHasta
        {
            get { return dtFechaHasta; }
            set { dtFechaHasta = value; }
        }
        private DateTime dtFechaAlta;

        public DateTime DtFechaAlta
        {
            get { return dtFechaAlta; }
            set { dtFechaAlta = value; }
        }
        private string strEstado;

        public string StrEstado
        {
            get { return strEstado; }
            set { strEstado = value; }
        }
        private string strEmpleado;

        public string StrEmpleado
        {
            get { return strEmpleado; }
            set { strEmpleado = value; }
        }
        private string strCliente;

        public string StrCliente
        {
            get { return strCliente; }
            set { strCliente = value; }
        }
        private decimal intCantidad;

        public decimal IntCantidad
        {
            get { return intCantidad; }
            set { intCantidad = value; }
        }
        private string strArticulos;

        public string StrArticulos
        {
            get { return strArticulos; }
            set { strArticulos = value; }
        }
        private Int32 intDescuento;

        public Int32 IntDescuento
        {
            get { return intDescuento; }
            set { intDescuento = value; }
        }
        private decimal dePuni;

        public decimal DePuni
        {
            get { return dePuni; }
            set { dePuni = value; }
        }
        private decimal deTarjeta;

        public decimal DeTarjeta
        {
            get { return deTarjeta; }
            set { deTarjeta = value; }
        }
        private decimal deCheque;

        public decimal DeCheque
        {
            get { return deCheque; }
            set { deCheque = value; }
        }
        private decimal deCtaCte;

        public decimal DeCtaCte
        {
            get { return deCtaCte; }
            set { deCtaCte = value; }
        }
        private decimal deTotal;

        public decimal DeTotal
        {
            get { return deTotal; }
            set { deTotal = value; }
        }

        private decimal deNeto;

        public decimal DeNeto
        {
            get { return deNeto; }
            set { deNeto = value; }
        }

        private string strMedioPago;

        public string StrMedioPago
        {
            get { return strMedioPago; }
            set { strMedioPago = value; }
        }

        private int intCaja;

        public int IntCaja
        {
            get { return intCaja; }
            set { intCaja = value; }
        }

        private DateTime dtFechaPago;

        public DateTime DtFechaPago
        {
            get { return dtFechaPago; }
            set { dtFechaPago = value; }
        }

    }
}
