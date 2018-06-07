using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class VentasReportePago
    {
        private string strTipo;

        public string StrTipo
        {
            get { return strTipo; }
            set { strTipo = value; }
        }
        private Int32 intId;

        public Int32 IntId
        {
            get { return intId; }
            set { intId = value; }
        }
        private DateTime dtFecha;

        public DateTime DtFecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }
        private decimal deTotal;

        public decimal DeTotal
        {
            get { return deTotal; }
            set { deTotal = value; }
        }
    }
}
