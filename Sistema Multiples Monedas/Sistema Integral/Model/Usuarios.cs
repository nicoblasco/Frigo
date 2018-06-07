using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Usuarios
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        private string strUsuario;

        public string StrUsuario
        {
            get { return strUsuario; }
            set { strUsuario = value; }
        }
        private string strNombreApellido;

        public string StrNombreApellido
        {
            get { return strNombreApellido; }
            set { strNombreApellido = value; }
        }
        private int intEsAdmin;

        public int IntEsAdmin
        {
            get { return intEsAdmin; }
            set { intEsAdmin = value; }
        }
        private string strContraseña;

        public string StrContraseña
        {
            get { return strContraseña; }
            set { strContraseña = value; }
        }
    }
}
