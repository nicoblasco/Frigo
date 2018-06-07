using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Proveedores
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private int intDocumento;

        public int IntDocumento
        {
            get { return intDocumento; }
            set { intDocumento = value; }
        }
        private string strDocumento;

        public string StrDocumento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }
        private string strRazonSocial;

        public string StrRazonSocial
        {
            get { return strRazonSocial; }
            set { strRazonSocial = value; }
        }

        private DateTime dtFechadeIngreso;

        public DateTime DtFechadeIngreso
        {
            get { return dtFechadeIngreso; }
            set { dtFechadeIngreso = value; }
        }

        private string strDirecccion;

        public string StrDirecccion
        {
            get { return strDirecccion; }
            set { strDirecccion = value; }
        }
        private string strDepto;

        public string StrDepto
        {
            get { return strDepto; }
            set { strDepto = value; }
        }
        private string strPiso;

        public string StrPiso
        {
            get { return strPiso; }
            set { strPiso = value; }
        }
        private string strNro;

        public string StrNro
        {
            get { return strNro; }
            set { strNro = value; }
        }
        private int intProvincia;

        public int IntProvincia
        {
            get { return intProvincia; }
            set { intProvincia = value; }
        }
        private int intLocalidad;

        public int IntLocalidad
        {
            get { return intLocalidad; }
            set { intLocalidad = value; }
        }

        private int intPais;

        public int IntPais
        {
            get { return intPais; }
            set { intPais = value; }
        }


        List<Telefonos> listTelefonos;

        public List<Telefonos> ListTelefonos
        {
            get { return listTelefonos; }
            set { listTelefonos = value; }
        }
        private string strEmail;

        public string StrEmail
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        private string strUrl;

        public string StrUrl
        {
            get { return strUrl; }
            set { strUrl = value; }
        }

        private bool boLunes;

        public bool BoLunes
        {
            get { return boLunes; }
            set { boLunes = value; }
        }
        private bool boMartes;

        public bool BoMartes
        {
            get { return boMartes; }
            set { boMartes = value; }
        }
        private bool boMiercoles;

        public bool BoMiercoles
        {
            get { return boMiercoles; }
            set { boMiercoles = value; }
        }
        private bool boJueves;

        public bool BoJueves
        {
            get { return boJueves; }
            set { boJueves = value; }
        }
        private bool boViernes;

        public bool BoViernes
        {
            get { return boViernes; }
            set { boViernes = value; }
        }
        private bool boSabado;

        public bool BoSabado
        {
            get { return boSabado; }
            set { boSabado = value; }
        }
        private bool boDomingo;

        public bool BoDomingo
        {
            get { return boDomingo; }
            set { boDomingo = value; }
        }

        private string strServicio;

        public string StrServicio
        {
            get { return strServicio; }
            set { strServicio = value; }
        }

        List<Contactos> listContactos;

        public List<Contactos> ListContactos
        {
            get { return listContactos; }
            set { listContactos = value; }
        }

        private string dtFechaBaja;

        public string DtFechaBaja
        {
            get { return dtFechaBaja; }
            set { dtFechaBaja = value; }
        }
    }
}
