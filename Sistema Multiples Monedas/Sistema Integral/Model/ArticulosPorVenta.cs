using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ArticulosPorVenta
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }



        Articulos objArticulo;

        public Articulos ObjArticulo
        {
            get { return objArticulo; }
            set { objArticulo = value; }
        }

        private decimal intCantidad;

        public decimal IntCantidad
        {
            get { return intCantidad; }
            set { intCantidad = value; }
        }

        private int intUnidades;

        public int IntUnidades
        {
            get { return intUnidades; }
            set { intUnidades = value; }
        }

        private decimal doPrecioUnitarioConTarjeta;

        public decimal DoPrecioUnitarioConTarjeta
        {
            get { return doPrecioUnitarioConTarjeta; }
            set { doPrecioUnitarioConTarjeta = value; }
        }

        private decimal doPrecioUnitarioConEfectivo;

        public decimal DoPrecioUnitarioConEfectivo
        {
            get { return doPrecioUnitarioConEfectivo; }
            set { doPrecioUnitarioConEfectivo = value; }
        }


        private int intDescuento;

        public int IntDescuento
        {
            get { return intDescuento; }
            set { intDescuento = value; }
        }
        private decimal doTotalConEfectivo;

        public decimal DoTotalConEfectivo
        {
            get { return doTotalConEfectivo; }
            set { doTotalConEfectivo = value; }
        }

        private decimal doTotalConTarjeta;

        public decimal DoTotalConTarjeta
        {
            get { return doTotalConTarjeta; }
            set { doTotalConTarjeta = value; }
        }

        private int intLinea;

        public int IntLinea
        {
            get { return intLinea; }
            set { intLinea = value; }
        }

    }
}
