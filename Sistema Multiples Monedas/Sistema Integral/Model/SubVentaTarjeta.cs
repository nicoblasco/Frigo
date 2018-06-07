using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SubVentaTarjeta
    {
        private decimal doAbona;

        public decimal DoAbona
        {
            get { return doAbona; }
            set { doAbona = value; }
        }

        private string strTarjeta;

        public string StrTarjeta
        {
            get { return strTarjeta; }
            set { strTarjeta = value; }
        }
        private string strNumero;

        public string StrNumero
        {
            get { return strNumero; }
            set { strNumero = value; }
        }
        private string strCuotas;

        public string StrCuotas
        {
            get { return strCuotas; }
            set { strCuotas = value; }
        }

        private string strTipo;

        public string StrTipo
        {
            get { return strTipo; }
            set { strTipo = value; }
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
