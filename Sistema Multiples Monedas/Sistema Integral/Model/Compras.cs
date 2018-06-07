using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class Compras
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private DateTime dtFechaAlta;

        public DateTime DtFechaAlta
        {
            get { return dtFechaAlta; }
            set { dtFechaAlta = value; }
        }
        private int intProveedor;

        public int IntProveedor
        {
            get { return intProveedor; }
            set { intProveedor = value; }
        }
        private string strNroFactura;

        public string StrNroFactura
        {
            get { return strNroFactura; }
            set { strNroFactura = value; }
        }
        private decimal deTotal;

        public decimal DeTotal
        {
            get { return deTotal; }
            set { deTotal = value; }
        }
        private string strObservaciones;

        public string StrObservaciones
        {
            get { return strObservaciones; }
            set { strObservaciones = value; }
        }
        private string dtFechaBaja;

        public string DtFechaBaja
        {
            get { return dtFechaBaja; }
            set { dtFechaBaja = value; }
        }

        private int intNumeroCaja;

        public int IntNumeroCaja
        {
            get { return intNumeroCaja; }
            set { intNumeroCaja = value; }
        }


    }
}
