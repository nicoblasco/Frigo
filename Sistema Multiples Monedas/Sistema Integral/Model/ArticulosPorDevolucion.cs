using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ArticulosPorDevolucion
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

        private int intCantidad;

        public int IntCantidad
        {
            get { return intCantidad; }
            set { intCantidad = value; }
        }


        private decimal doPrecioUnitarioConEfectivo;

        public decimal DoPrecioUnitarioConEfectivo
        {
            get { return doPrecioUnitarioConEfectivo; }
            set { doPrecioUnitarioConEfectivo = value; }
        }

        private decimal doTotalConEfectivo;

        public decimal DoTotalConEfectivo
        {
            get { return doTotalConEfectivo; }
            set { doTotalConEfectivo = value; }
        }

    }
}
