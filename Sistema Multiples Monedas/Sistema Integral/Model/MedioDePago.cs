using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Model
{
    public class MedioDePago
    {
        private int intCodigo;

        public int IntCodigo
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
        private string dtFechaBaja;

        public string DtFechaBaja
        {
            get { return dtFechaBaja; }
            set { dtFechaBaja = value; }
        }

        private int intPredeterminado;

        public int IntPredeterminado
        {
            get { return intPredeterminado; }
            set { intPredeterminado = value; }
        }

    }
}
