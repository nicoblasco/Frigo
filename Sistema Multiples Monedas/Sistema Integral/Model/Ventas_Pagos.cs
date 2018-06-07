using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Ventas_Pagos
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
        private decimal deImporte;

        public decimal DeImporte
        {
            get { return deImporte; }
            set { deImporte = value; }
        }
        private int intEstado;

        public int IntEstado
        {
            get { return intEstado; }
            set { intEstado = value; }
        }

        private int intNumeroCaja;

        public int IntNumeroCaja
        {
            get { return intNumeroCaja; }
            set { intNumeroCaja = value; }
        }
        private int intMedioPago;

        public int IntMedioPago
        {
            get { return intMedioPago; }
            set { intMedioPago = value; }
        }
    }
}
