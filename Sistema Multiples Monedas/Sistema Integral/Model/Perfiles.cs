using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Perfiles
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private int intUsuario;

        public int IntUsuario
        {
            get { return intUsuario; }
            set { intUsuario = value; }
        }
        private string strModulo;

        public string StrModulo
        {
            get { return strModulo; }
            set { strModulo = value; }
        }
        private string strPantalla;

        public string StrPantalla
        {
            get { return strPantalla; }
            set { strPantalla = value; }
        }
        private string strPermiso;

        public string StrPermiso
        {
            get { return strPermiso; }
            set { strPermiso = value; }
        }
    }
}
