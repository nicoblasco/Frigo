using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Monedas
    {

        private Int32 intCodigo;

        public Int32 IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private string strDescripcion;

        public string StrDescripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }
        private decimal deCotizacion;

        public decimal DeCotizacion
        {
            get { return deCotizacion; }
            set { deCotizacion = value; }
        }

    }
}
