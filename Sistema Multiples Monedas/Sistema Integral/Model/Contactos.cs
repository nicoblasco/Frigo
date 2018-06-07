using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Contactos
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private int intProveedor;

        public int IntProveedor
        {
            get { return intProveedor; }
            set { intProveedor = value; }
        }


        private string strNombre;

        public string StrNombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        private string strApellido;

        public string StrApellido
        {
            get { return strApellido; }
            set { strApellido = value; }
        }

        private string strEmail;

        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        private string strPuesto;

        public string StrPuesto
        {
            get { return strPuesto; }
            set { strPuesto = value; }
        }
        private string strObservacion;

        public string StrObservacion
        {
            get { return strObservacion; }
            set { strObservacion = value; }
        }

        List<Telefonos> listTelefonos;

        public List<Telefonos> ListTelefonos
        {
            get { return listTelefonos; }
            set { listTelefonos = value; }
        }

        private int intEstado; // 1 Alta - 2 Modificado - 3 Baja

        public int IntEstado
        {
            get { return intEstado; }
            set { intEstado = value; }
        }
    }
}
