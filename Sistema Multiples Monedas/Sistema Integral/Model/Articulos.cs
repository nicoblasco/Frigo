using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Articulos
    {
        private int intCodigo;

        public int IntCodigo
        {
            get { return intCodigo; }
            set { intCodigo = value; }
        }

        private string strCodigo;

        public string StrCodigo
        {
            get { return strCodigo; }
            set { strCodigo = value; }
        }
        private DateTime dtFechaAlta;

        public DateTime DtFechaAlta
        {
            get { return dtFechaAlta; }
            set { dtFechaAlta = value; }
        }

        private string strDescripcion;

        public string StrDescripcion
        {
            get { return strDescripcion; }
            set { strDescripcion = value; }
        }

        private int intProveedor;

        public int IntProveedor
        {
            get { return intProveedor; }
            set { intProveedor = value; }
        }
        private string strRubro;

        public string StrRubro
        {
            get { return strRubro; }
            set { strRubro = value; }
        }
        private string strMarca;

        public string StrMarca
        {
            get { return strMarca; }
            set { strMarca = value; }
        }
        private string strUbicacion;

        public string StrUbicacion
        {
            get { return strUbicacion; }
            set { strUbicacion = value; }
        }
        private int intstock;

        public int Intstock
        {
            get { return intstock; }
            set { intstock = value; }
        }
        private int intstockminimo;

        public int Intstockminimo
        {
            get { return intstockminimo; }
            set { intstockminimo = value; }
        }
        private decimal doCosto;

        public decimal DoCosto
        {
            get { return doCosto; }
            set { doCosto = value; }
        }
        private decimal doGanancia;

        public decimal DoGanancia
        {
            get { return doGanancia; }
            set { doGanancia = value; }
        }
        private decimal doIva;

        public decimal DoIva
        {
            get { return doIva; }
            set { doIva = value; }
        }
        private decimal doPrecioEfectivo;

        public decimal DoPrecioEfectivo
        {
            get { return doPrecioEfectivo; }
            set { doPrecioEfectivo = value; }
        }
        private decimal doPrecioTarjeta;

        public decimal DoPrecioTarjeta
        {
            get { return doPrecioTarjeta; }
            set { doPrecioTarjeta = value; }
        }

        private string dtFechaBaja;

        public string DtFechaBaja
        {
            get { return dtFechaBaja; }
            set { dtFechaBaja = value; }
        }

        private string strImagen;

        public string StrImagen
        {
            get { return strImagen; }
            set { strImagen = value; }
        }

        private decimal doPrecioLista2;

        public decimal DoPrecioLista2
        {
            get { return doPrecioLista2; }
            set { doPrecioLista2 = value; }
        }
        private decimal doPrecioLista3;

        public decimal DoPrecioLista3
        {
            get { return doPrecioLista3; }
            set { doPrecioLista3 = value; }
        }

        private string strDescrCorta;

        public string StrDescrCorta
        {
            get { return strDescrCorta; }
            set { strDescrCorta = value; }
        }


        private Int32 intMoneda;

        public Int32 IntMoneda
        {
            get { return intMoneda; }
            set { intMoneda = value; }
        }

        private string strUnidadDeVenta;

        public string StrUnidadDeVenta
        {
            get { return strUnidadDeVenta; }
            set { strUnidadDeVenta = value; }
        }
    }
}
