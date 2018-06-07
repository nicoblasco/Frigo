using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Configuraciones
    {
        private Int32 intCodigo;

        public Int32 IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private string strNombrePc;

        public string StrNombrePc
        {
            get { return strNombrePc; }
            set { strNombrePc = value; }
        }
        private int intNumeroCaja;

        public int IntNumeroCaja
        {
            get { return intNumeroCaja; }
            set { intNumeroCaja = value; }
        }
        private string strNombreImpresora;

        public string StrNombreImpresora
        {
            get { return strNombreImpresora; }
            set { strNombreImpresora = value; }
        }
    }
}
