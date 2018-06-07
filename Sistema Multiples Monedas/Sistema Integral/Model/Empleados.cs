using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Empleados
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
        private DateTime dtFechadeNac;

        public DateTime DtFechadeNac
        {
            get { return dtFechadeNac; }
            set { dtFechadeNac = value; }
        }
        private DateTime dtFechadeIngreso;

        public DateTime DtFechadeIngreso
        {
            get { return dtFechadeIngreso; }
            set { dtFechadeIngreso = value; }
        }

        private string dtFechadeEgreso;

        public string DtFechadeEgreso
        {
            get { return dtFechadeEgreso; }
            set { dtFechadeEgreso = value; }
        }



        private string strNacionalidad;

        public string StrNacionalidad
        {
            get { return strNacionalidad; }
            set { strNacionalidad = value; }
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

        private string strCuit;

        public string StrCuit
        {
            get { return strCuit; }
            set { strCuit = value; }
        }

        private string strObservaciones;

        public string StrObservaciones
        {
            get { return strObservaciones; }
            set { strObservaciones = value; }
        }

        private string dtFechaBaja;

        public string DtFechaBaja
        {
            get { return dtFechaBaja; }
            set { dtFechaBaja = value; }
        }


        private bool boPredeterminado;

        public bool BoPredeterminado
        {
            get { return boPredeterminado; }
            set { boPredeterminado = value; }
        }

        private int intUser;

        public int IntUser
        {
            get { return intUser; }
            set { intUser = value; }
        }


    }
}
