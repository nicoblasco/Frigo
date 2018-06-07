using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Devoluciones
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

        private Empleados objEmpleado;

        public Empleados ObjEmpleado
        {
            get { return objEmpleado; }
            set { objEmpleado = value; }
        }

        private Clientes objCliente;

        public Clientes ObjCliente
        {
            get { return objCliente; }
            set { objCliente = value; }
        }

        private string strObservaciones;

        public string StrObservaciones
        {
            get { return strObservaciones; }
            set { strObservaciones = value; }
        }

        List<ArticulosPorDevolucion> listArticulosPorDevolucion;

        public List<ArticulosPorDevolucion> ListArticulosPorDevolucion
        {
            get { return listArticulosPorDevolucion; }
            set { listArticulosPorDevolucion = value; }
        }


        private decimal doTotal;

        public decimal DoTotal
        {
            get { return doTotal; }
            set { doTotal = value; }
        }


        private string strEstado;

        public string StrEstado
        {
            get { return strEstado; }
            set { strEstado = value; }
        }


        private string strListaPrecio;

        public string StrListaPrecio
        {
            get { return strListaPrecio; }
            set { strListaPrecio = value; }
        }

        private int intNumeroCaja;

        public int IntNumeroCaja
        {
            get { return intNumeroCaja; }
            set { intNumeroCaja = value; }
        }
    }
}
