using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class ComprasReporte
    {
        private DateTime dtFecha;

        public DateTime DtFecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }
        private string strNroFactura;

        public string StrNroFactura
        {
            get { return strNroFactura; }
            set { strNroFactura = value; }
        }
        private int intProveedorId;

        public int IntProveedorId
        {
            get { return intProveedorId; }
            set { intProveedorId = value; }
        }
        private string strProveedor;

        public string StrProveedor
        {
            get { return strProveedor; }
            set { strProveedor = value; }
        }
        private decimal deTotal;

        public decimal DeTotal
        {
            get { return deTotal; }
            set { deTotal = value; }
        }
    }
}
