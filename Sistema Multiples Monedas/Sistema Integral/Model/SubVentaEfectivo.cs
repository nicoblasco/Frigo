using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SubVentaEfectivo
    {
        private decimal doAbona;

        public decimal DoAbona
        {
            get { return doAbona; }
            set { doAbona = value; }
        }
        private decimal doVuelto;

        public decimal DoVuelto
        {
            get { return doVuelto; }
            set { doVuelto = value; }
        }
    }
}
