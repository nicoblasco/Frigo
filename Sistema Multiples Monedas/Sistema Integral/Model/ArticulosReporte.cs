using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class ArticulosReporte
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

        private int intDescuento;

        public int IntDescuento
        {
            get { return intDescuento; }
            set { intDescuento = value; }
        }


        private DateTime dtFechaBaja;

        public DateTime DtFechaBaja
        {
            get { return dtFechaBaja; }
            set { dtFechaBaja = value; }
        }

        private decimal doPrecioTotal;

public decimal DoPrecioTotal
{
  get { return doPrecioTotal; }
  set { doPrecioTotal = value; }
}

private int intCantidadTotal;

public int IntCantidadTotal
{
    get { return intCantidadTotal; }
    set { intCantidadTotal = value; }
}

private string strUnidadDeVenta;

public string StrUnidadDeVenta
{
    get { return strUnidadDeVenta; }
    set { strUnidadDeVenta = value; }
}

    }
}
