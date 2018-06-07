
namespace Model
{
    public class Telefonos
    {
        private int intCodigo;


        private string strVinculo;


        private string strTipotel;


        private string strTel;


        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }
        public string StrVinculo
        {
            get { return strVinculo; }
            set { strVinculo = value; }
        }
        public string StrTipotel
        {
            get { return strTipotel; }
            set { strTipotel = value; }
        }

        public string StrTel
        {
            get { return strTel; }
            set { strTel = value; }
        }

        private string strInterno;

        public string StrInterno
        {
            get { return strInterno; }
            set { strInterno = value; }
        }



        private int intEstado; // 1 Alta - 2 Modificado - 3 Baja

        public int IntEstado
        {
            get { return intEstado; }
            set { intEstado = value; }
        }
    }
}
