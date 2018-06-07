using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SubVentaCheque
    {
        private decimal doAbona;

        public decimal DoAbona
        {
            get { return doAbona; }
            set { doAbona = value; }
        }

        private string strBanco;

        public string StrBanco
        {
            get { return strBanco; }
            set { strBanco = value; }
        }
        private string strNumero;

        public string StrNumero
        {
            get { return strNumero; }
            set { strNumero = value; }
        }

        
        private DateTime dtFechaVencimiento;

        public DateTime DtFechaVencimiento
        {
            get { return dtFechaVencimiento; }
            set { dtFechaVencimiento = value; }
        }

        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private int intIndex;

        public int IntIndex
        {
            get { return intIndex; }
            set { intIndex = value; }
        }
    }
}
