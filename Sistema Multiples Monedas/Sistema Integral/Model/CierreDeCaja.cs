using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CierreDeCaja
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private decimal deTotal;

        public decimal DeTotal
        {
            get { return deTotal; }
            set { deTotal = value; }
        }
        private DateTime dtFecha;

        public DateTime DtFecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }

        private DateTime dtFechaApertura;

        public DateTime DtFechaApertura
        {
            get { return dtFechaApertura; }
            set { dtFechaApertura = value; }
        }
        private string dtFechaCierre;

        public string DtFechaCierre
        {
            get { return dtFechaCierre; }
            set { dtFechaCierre = value; }
        }
        private int intNumeroCaja;

        public int IntNumeroCaja
        {
            get { return intNumeroCaja; }
            set { intNumeroCaja = value; }
        }
        private decimal deTotalCierre;

        public decimal DeTotalCierre
        {
            get { return deTotalCierre; }
            set { deTotalCierre = value; }
        }
        private Int32 intUsuarioApertura;

        public Int32 IntUsuarioApertura
        {
            get { return intUsuarioApertura; }
            set { intUsuarioApertura = value; }
        }
        private Int32 intUsuarioCierre;

        public Int32 IntUsuarioCierre
        {
            get { return intUsuarioCierre; }
            set { intUsuarioCierre = value; }
        }


    }
}
