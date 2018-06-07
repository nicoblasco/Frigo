using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Seguimiento
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private int intFacturaID;

        public int IntFacturaID
        {
            get { return intFacturaID; }
            set { intFacturaID = value; }
        }
        private DateTime dtFecha;

        public DateTime DtFecha
        {
            get { return dtFecha; }
            set { dtFecha = value; }
        }
        private int intUsuarioID;

        public int IntUsuarioID
        {
            get { return intUsuarioID; }
            set { intUsuarioID = value; }
        }

        private string strUsuario;

        public string StrUsuario
        {
            get { return strUsuario; }
            set { strUsuario = value; }
        }

        private string strEstadoDesde;

        public string StrEstadoDesde
        {
            get { return strEstadoDesde; }
            set { strEstadoDesde = value; }
        }
        private string strEstadoHasta;

        public string StrEstadoHasta
        {
            get { return strEstadoHasta; }
            set { strEstadoHasta = value; }
        }
    }
}
