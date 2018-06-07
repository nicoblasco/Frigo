using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaArticulos
    {
        public ManejaArticulos()
        {
        }

        public int GrabarArticulos(Articulos objArticulos)
        {
            Int32 intCodigoExtra;
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[21];

            spParam[0] = new SqlParameter("@codigoextra", SqlDbType.NVarChar);
            spParam[0].Value = objArticulos.StrCodigo;

            spParam[1] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[1].Value = objArticulos.DtFechaAlta;

            spParam[2] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            spParam[2].Value = objArticulos.StrDescripcion;

            spParam[3] = new SqlParameter("@proveedor", SqlDbType.Int);
            spParam[3].Value = objArticulos.IntProveedor;

            spParam[4] = new SqlParameter("@rubro", SqlDbType.NVarChar);
            spParam[4].Value = objArticulos.StrRubro;

            spParam[5] = new SqlParameter("@marca", SqlDbType.NVarChar);
            spParam[5].Value = objArticulos.StrMarca;

            spParam[6] = new SqlParameter("@ubicacion", SqlDbType.NVarChar);
            spParam[6].Value = objArticulos.StrUbicacion;

            spParam[7] = new SqlParameter("@stock", SqlDbType.Int);
            spParam[7].Value = objArticulos.Intstock;

            spParam[8] = new SqlParameter("@stockminimo", SqlDbType.Int);
            spParam[8].Value = objArticulos.Intstockminimo;

            spParam[9] = new SqlParameter("@costo", SqlDbType.Decimal);
            spParam[9].Value = objArticulos.DoCosto;

            spParam[10] = new SqlParameter("@ganancia", SqlDbType.Decimal);
            spParam[10].Value = objArticulos.DoGanancia;

            spParam[11] = new SqlParameter("@iva", SqlDbType.Decimal);
            spParam[11].Value = objArticulos.DoIva;

            spParam[12] = new SqlParameter("@precioefectivo", SqlDbType.Decimal);
            spParam[12].Value = objArticulos.DoPrecioEfectivo;

            spParam[13] = new SqlParameter("@preciotarjeta", SqlDbType.Decimal);
            spParam[13].Value = objArticulos.DoPrecioTarjeta;

            //spParam[14] = new SqlParameter("@contenido", SqlDbType.NVarChar);
            //spParam[14].Value = objArticulos.StrContenido;

            //spParam[15] = new SqlParameter("@medida", SqlDbType.NVarChar);
            //spParam[15].Value = objArticulos.StrUnidadMedida;

            spParam[14] = new SqlParameter("@imagen", SqlDbType.NVarChar);
            spParam[14].Value = objArticulos.StrImagen;

            spParam[15] = new SqlParameter("@preciolista2", SqlDbType.Decimal);
            spParam[15].Value = objArticulos.DoPrecioLista2;

            spParam[16] = new SqlParameter("@preciolista3", SqlDbType.Decimal);
            spParam[16].Value = objArticulos.DoPrecioLista3;

            spParam[17] = new SqlParameter("@desccorta", SqlDbType.NVarChar);
            spParam[17].Value = objArticulos.StrDescrCorta;

            spParam[18] = new SqlParameter("@moneda", SqlDbType.BigInt);
            spParam[18].Value = objArticulos.IntMoneda;

            spParam[19] = new SqlParameter("@unidaddeventa", SqlDbType.NVarChar);
            spParam[19].Value = objArticulos.StrUnidadDeVenta;

            spParam[20] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[20].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Articulos";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            if (string.IsNullOrEmpty(objArticulos.StrCodigo))
            {
                intCodigoExtra = Convert.ToInt32(spParam[20].Value);
                objArticulos.IntCodigo = Convert.ToInt32(spParam[20].Value);

                //Primero debo verificar que el id extra no exista, sino le voy sumando 1 hasta q no exista

                while (ExisteCodigoExtra (Convert.ToString( intCodigoExtra)))
                {
                    intCodigoExtra = intCodigoExtra +1;
                    
                }
                objArticulos.StrCodigo = Convert.ToString(intCodigoExtra);

                ModificaArticulos(objArticulos);
            }

            return Convert.ToInt32(spParam[20].Value);



        }


        private bool ExisteCodigoExtra (string strCodigo)
        {
            string strSql;
            strSql = "select count(1) as cantidad from Articulos";
            strSql += " where fechabaja is null and idextra =" + strCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            try
            {
                if (dt.Rows.Count > 0)
                    if (dt.Rows[0]["cantidad"].ToString() == "0")
                        return false;
                    else
                        return true;
                else
                    return false;
            }
            catch 
            {

                return false;
            }

        }




        public void ModificaArticulos(Articulos objArticulos)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[21];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objArticulos.IntCodigo;

            spParam[1] = new SqlParameter("@codigoextra", SqlDbType.NVarChar);
            spParam[1].Value = objArticulos.StrCodigo;

            spParam[2] = new SqlParameter("@fechaalta", SqlDbType.DateTime);
            spParam[2].Value = objArticulos.DtFechaAlta;

            spParam[3] = new SqlParameter("@descripcion", SqlDbType.NVarChar);
            spParam[3].Value = objArticulos.StrDescripcion;

            spParam[4] = new SqlParameter("@proveedor", SqlDbType.Int);
            spParam[4].Value = objArticulos.IntProveedor;

            spParam[5] = new SqlParameter("@rubro", SqlDbType.NVarChar);
            spParam[5].Value = objArticulos.StrRubro;

            spParam[6] = new SqlParameter("@marca", SqlDbType.NVarChar);
            spParam[6].Value = objArticulos.StrMarca;

            spParam[7] = new SqlParameter("@ubicacion", SqlDbType.NVarChar);
            spParam[7].Value = objArticulos.StrUbicacion;

            spParam[8] = new SqlParameter("@stock", SqlDbType.Int);
            spParam[8].Value = objArticulos.Intstock;

            spParam[9] = new SqlParameter("@stockminimo", SqlDbType.Int);
            spParam[9].Value = objArticulos.Intstockminimo;

            spParam[10] = new SqlParameter("@costo", SqlDbType.Decimal);
            spParam[10].Value = objArticulos.DoCosto;

            spParam[11] = new SqlParameter("@ganancia", SqlDbType.Decimal);
            spParam[11].Value = objArticulos.DoGanancia;

            spParam[12] = new SqlParameter("@iva", SqlDbType.Decimal);
            spParam[12].Value = objArticulos.DoIva;

            spParam[13] = new SqlParameter("@precioefectivo", SqlDbType.Decimal);
            spParam[13].Value = objArticulos.DoPrecioEfectivo;

            spParam[14] = new SqlParameter("@preciotarjeta", SqlDbType.Decimal);
            spParam[14].Value = objArticulos.DoPrecioTarjeta;

            //spParam[15] = new SqlParameter("@contenido", SqlDbType.NVarChar);
            //spParam[15].Value = objArticulos.StrContenido;

            //spParam[16] = new SqlParameter("@medida", SqlDbType.NVarChar);
            //spParam[16].Value = objArticulos.StrUnidadMedida;

            spParam[15] = new SqlParameter("@imagen", SqlDbType.NVarChar);
            spParam[15].Value = objArticulos.StrImagen;

            spParam[16] = new SqlParameter("@preciolista2", SqlDbType.Decimal);
            spParam[16].Value = objArticulos.DoPrecioLista2;

            spParam[17] = new SqlParameter("@preciolista3", SqlDbType.Decimal);
            spParam[17].Value = objArticulos.DoPrecioLista3;

            spParam[18] = new SqlParameter("@desccorta", SqlDbType.NVarChar);
            spParam[18].Value = objArticulos.StrDescrCorta;

            spParam[19] = new SqlParameter("@moneda", SqlDbType.BigInt);
            spParam[19].Value = objArticulos.IntMoneda;

            spParam[20] = new SqlParameter("@unidaddeventa", SqlDbType.NVarChar);
            spParam[20].Value = objArticulos.StrUnidadDeVenta;

            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }


        public void ModificaStock(int intCodigo, int intStock, string strOperacion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;

            spParam[1] = new SqlParameter("@cantidad", SqlDbType.Int);
            spParam[1].Value = intStock;

            spParam[2] = new SqlParameter("@operacion", SqlDbType.NVarChar);
            spParam[2].Value = strOperacion;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Stock";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaStockDevolucion(int intCodigo, int intStock, string strOperacion)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = intCodigo;

            spParam[1] = new SqlParameter("@cantidad", SqlDbType.Int);
            spParam[1].Value = intStock;

            spParam[2] = new SqlParameter("@operacion", SqlDbType.NVarChar);
            spParam[2].Value = strOperacion;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Stock_Devolucion";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaStockMasivo(String strCodigo, int intStock)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@cantidad", SqlDbType.Int);
            spParam[1].Value = intStock;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Stock_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }


        public void ModificaPorcentajeMasivo(String strCodigo, decimal dePorcentaje )
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@porcentaje", SqlDbType.Money);
            spParam[1].Value = dePorcentaje;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Porcentaje_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }
        //Actualiza el costo y calcula el precio
        public void ModificaPrecioMasivo(String strCodigo, decimal dePrecio)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[3];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@precio", SqlDbType.Money );
            spParam[1].Value = dePrecio;

            spParam[2] = new SqlParameter("@preciounitario", SqlDbType.Money);
            spParam[2].Value = getPrecioUnitarioCalculado(strCodigo, dePrecio);

            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Precio_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }
        //Actualiza el precio
        public void ModificaPrecioL1Masivo(String strCodigo, decimal dePrecio)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@preciolista1", SqlDbType.Money);
            spParam[1].Value = dePrecio;

            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_PrecioL1_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaPrecioL2Masivo(String strCodigo, decimal dePrecio)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@preciolista2", SqlDbType.Money);
            spParam[1].Value = dePrecio;

            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_PrecioL2_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaPrecioL3Masivo(String strCodigo, decimal dePrecio)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@preciolista3", SqlDbType.Money);
            spParam[1].Value = dePrecio;

            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_PrecioL3_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }




        public void ModificaUbicacionMasivo(String strCodigo, string strUbicacion )
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@ubicacion", SqlDbType.NVarChar);
            spParam[1].Value = strUbicacion;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Ubicacion_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaDescripcionCortaMasivo(String strCodigo, string strDescCorta)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@desccorta", SqlDbType.NVarChar);
            spParam[1].Value = strDescCorta;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Desccorta_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }


        public void ModificaDescripcionLargaMasivo(String strCodigo, string strDescLarga)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@desclarga", SqlDbType.NVarChar);
            spParam[1].Value = strDescLarga;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Descclarga_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaRubroMasivo(String strCodigo, string strRubro)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@rubro", SqlDbType.NVarChar);
            spParam[1].Value = strRubro;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Rubro_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaMarcaMasivo(String strCodigo, string strMarca)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@marca", SqlDbType.NVarChar);
            spParam[1].Value = strMarca;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Marca_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaProveedorMasivo(String strCodigo, Int32 intProveedor)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigo;

            spParam[1] = new SqlParameter("@proveedor", SqlDbType.BigInt);
            spParam[1].Value = intProveedor;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Proveedor_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void ModificaCodigoMasivo(String strCodigoViejo, string strCodigoNuevo)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[2];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.NVarChar);
            spParam[0].Value = strCodigoViejo;

            spParam[1] = new SqlParameter("@codigonuevo", SqlDbType.NVarChar);
            spParam[1].Value = strCodigoNuevo;


            oManejaConexiones.NombreStoredProcedure = "Upd_Articulos_Codigo_Masivo";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }

        public void EliminaArticulos(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Articulos";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Articulos BuscarArticulos(int intCodigo)
        {
            Articulos objArticulos = new Articulos();
            string strSql;
            strSql = "select idextra,fechaalta,descripcion, proveedor,rubro,marca,ubicacion,stock,stockminimo,costo,ganancia,iva,precioefectivo,preciotarjeta, fechabaja,imagen, preciolista2, preciolista3, desccorta, monedaid, unidaddeventa";
            strSql += " from dbo.Articulos where id =" + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objArticulos.IntCodigo = intCodigo;
            objArticulos.StrCodigo = dt.Rows[0]["idextra"].ToString();
            objArticulos.DtFechaAlta = Convert.ToDateTime(dt.Rows[0]["fechaalta"].ToString());
            objArticulos.StrDescripcion = dt.Rows[0]["descripcion"].ToString();
            objArticulos.IntProveedor = Convert.ToInt32(dt.Rows[0]["proveedor"].ToString());
            objArticulos.StrRubro = dt.Rows[0]["rubro"].ToString();
            objArticulos.StrMarca = dt.Rows[0]["marca"].ToString();
            objArticulos.StrUbicacion = dt.Rows[0]["ubicacion"].ToString();
            objArticulos.Intstock = Convert.ToInt32(dt.Rows[0]["stock"].ToString());
            objArticulos.Intstockminimo = Convert.ToInt32(dt.Rows[0]["stockminimo"].ToString());
            objArticulos.DoCosto = Convert.ToDecimal(dt.Rows[0]["costo"].ToString());
            objArticulos.DoGanancia = Convert.ToDecimal(dt.Rows[0]["ganancia"].ToString());
            objArticulos.DoIva = Convert.ToDecimal(dt.Rows[0]["iva"].ToString());
            objArticulos.DoPrecioEfectivo = Convert.ToDecimal(dt.Rows[0]["precioefectivo"].ToString());
            objArticulos.DoPrecioTarjeta = Convert.ToDecimal(dt.Rows[0]["preciotarjeta"].ToString());
            objArticulos.DtFechaBaja = Convert.ToString(dt.Rows[0]["fechabaja"].ToString());
            //objArticulos.StrContenido = dt.Rows[0]["contenido"].ToString();
            //objArticulos.StrUnidadMedida = dt.Rows[0]["medida"].ToString();
            objArticulos.StrImagen = dt.Rows[0]["imagen"].ToString();
            if (!String.IsNullOrEmpty(dt.Rows[0]["preciolista2"].ToString()))
                objArticulos.DoPrecioLista2 = Convert.ToDecimal(dt.Rows[0]["preciolista2"].ToString());
            else
                objArticulos.DoPrecioLista2 = 0;
            if (!String.IsNullOrEmpty(dt.Rows[0]["preciolista2"].ToString()))
                objArticulos.DoPrecioLista3 = Convert.ToDecimal(dt.Rows[0]["preciolista3"].ToString());
            else
                objArticulos.DoPrecioLista3 = 0;

            objArticulos.StrDescrCorta = dt.Rows[0]["desccorta"].ToString();
            if (String.IsNullOrEmpty(dt.Rows[0]["monedaid"].ToString()))
                objArticulos.IntMoneda = 1;
            else
                objArticulos.IntMoneda = Convert.ToInt32( dt.Rows[0]["monedaid"].ToString());

            objArticulos.StrUnidadDeVenta = dt.Rows[0]["unidaddeventa"].ToString();

            return objArticulos;
        }

        public Articulos BuscarArticulosPorCodigoExtra(string strCodigo, bool boEsVenta)
        {
            Articulos objArticulos = new Articulos();
            string strSql;
            bool boEsXBalanzaElectronica;

            boEsXBalanzaElectronica = false;
            if (strCodigo == "")
                return objArticulos;

            //Verifico si el codigo de barra pertenece a la balanza electronica

            /*   if (strCodigo.Substring(0, 2).Trim() == "20" && strCodigo.Trim().Length == 13) //Los dos primeros digitos tienen que se 20 y el ancho del codigo de barra tiene que ser de 12 digitos
               {
                   boEsXBalanzaElectronica = true;
                   //Reemplazo la busqueda,
                   //El codigo de barra se conforma de la siguiente manera
                   //20PPPPIIIIIIX

                   //20- Codigo Identificatorio. 2Digitos
                   //P- Codigo PLU . 4Digitos
                   //I-Importe. 6Digitos
                   //X-Digito Control. 1Digito

                   //Ejemplo:
                   //2000010003006
                   //Es un producto de almacen
                   strSql = "select id,fechaalta,descripcion, proveedor,rubro,marca,ubicacion,stock,stockminimo,costo,ganancia,iva,precioefectivo,preciotarjeta,fechabaja";
                   strSql += " from dbo.Articulos where fechabaja is null and SUBSTRING(idextra,1,6) = '" + strCodigo.Substring(0, 6) + "'";
               }
               else
               {*/
            //Es un producto de almacen
            strSql = "select id,fechaalta,descripcion, proveedor,rubro,marca,ubicacion,stock,stockminimo,costo,ganancia,iva,precioefectivo,preciotarjeta,fechabaja, imagen, preciolista2, preciolista3, desccorta, isnull(monedaid,1) monedaid, unidaddeventa";
            strSql += " from dbo.Articulos where fechabaja is null and idextra = '" + strCodigo + "'";
            //  }
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);


            if (dt.Rows.Count > 0)
            {
                objArticulos.IntCodigo = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                objArticulos.StrCodigo = strCodigo;
                objArticulos.DtFechaAlta = Convert.ToDateTime(dt.Rows[0]["fechaalta"].ToString());
                objArticulos.StrDescripcion = dt.Rows[0]["descripcion"].ToString();
                objArticulos.IntProveedor = Convert.ToInt32(dt.Rows[0]["proveedor"].ToString());
                objArticulos.StrRubro = dt.Rows[0]["rubro"].ToString();
                objArticulos.StrMarca = dt.Rows[0]["marca"].ToString();
                objArticulos.StrUbicacion = dt.Rows[0]["ubicacion"].ToString();
                objArticulos.Intstock = Convert.ToInt32(dt.Rows[0]["stock"].ToString());
                objArticulos.Intstockminimo = Convert.ToInt32(dt.Rows[0]["stockminimo"].ToString());
                objArticulos.DoCosto = Convert.ToDecimal(dt.Rows[0]["costo"].ToString());
                objArticulos.DoGanancia = Convert.ToDecimal(dt.Rows[0]["ganancia"].ToString());
                objArticulos.DoIva = Convert.ToDecimal(dt.Rows[0]["iva"].ToString());
                if (boEsXBalanzaElectronica && boEsVenta)
                {
                    //Si es un producto de balanza electronica y ademas estoy en una venta
                    objArticulos.DoPrecioEfectivo = GetPrecioCodigoDeBarra(strCodigo);
                }
                else
                {
                    objArticulos.DoPrecioEfectivo = Convert.ToDecimal(dt.Rows[0]["precioefectivo"].ToString());
                }
                objArticulos.DoPrecioTarjeta = Convert.ToDecimal(dt.Rows[0]["preciotarjeta"].ToString());
                objArticulos.DtFechaBaja = dt.Rows[0]["fechabaja"].ToString();
                //objArticulos.StrContenido = dt.Rows[0]["contenido"].ToString();
                //objArticulos.StrUnidadMedida = dt.Rows[0]["medida"].ToString();
                objArticulos.StrImagen = dt.Rows[0]["imagen"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["preciolista2"].ToString()))
                    objArticulos.DoPrecioLista2 = Convert.ToDecimal(dt.Rows[0]["preciolista2"].ToString());
                else
                    objArticulos.DoPrecioLista2 = 0;
                if (!String.IsNullOrEmpty(dt.Rows[0]["preciolista2"].ToString()))
                    objArticulos.DoPrecioLista3 = Convert.ToDecimal(dt.Rows[0]["preciolista3"].ToString());
                else
                    objArticulos.DoPrecioLista3 = 0;

                objArticulos.StrDescrCorta = dt.Rows[0]["desccorta"].ToString();
                objArticulos.IntMoneda = Convert.ToInt32(dt.Rows[0]["monedaid"].ToString());
                objArticulos.StrUnidadDeVenta = dt.Rows[0]["unidaddeventa"].ToString();
            }
            return objArticulos;
        }


        private decimal GetPrecioCodigoDeBarra(string strCodigoDeBarra)
        {
            decimal deVariable=0;
            string strPrecio;
            //Obtengo el precio del codigo de barra de la balanza electronica
            //El codigo de barra se conforma de la siguiente manera
            //20PPPPIIIIIIX

            //20- Codigo Identificatorio. 2Digitos
            //P- Codigo PLU . 4Digitos
            //I-Importe. 6Digitos
            //X-Digito Control. 1Digito

            //Ejemplo:
            //2000010003006



            strPrecio = strCodigoDeBarra.Substring(6, 4) + "," + strCodigoDeBarra.Substring(10, 2);
            return Convert.ToDecimal(String.Format("{0:0,0#}", strPrecio));

        }

        public bool ArticuloDadoDeBaja(int intCodigo)
        {
            string strSql;
            strSql = "select fechabaja";
            strSql += " from dbo.Articulos where id = " + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                if (string.IsNullOrEmpty(dt.Rows[0]["fechabaja"].ToString()))
                    return false;
                else
                    return true;
            else
                return false;
        }

        public List<ArticulosReporte> ReporteDeArticulos(DataTable dt)
        {
            List<ArticulosReporte> ListArticulos = new List<ArticulosReporte>();
            ArticulosReporte objArticulos;
            //if (dt !=null)
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    objArticulos = new ArticulosReporte();
                    objArticulos.StrCodigo = dt.Rows[i]["idextra"].ToString(); ;
                    objArticulos.StrDescripcion = dt.Rows[i]["descripcion"].ToString();
                    objArticulos.StrRubro = dt.Rows[i]["rubro"].ToString();
                    objArticulos.StrMarca = dt.Rows[i]["marca"].ToString();
                    objArticulos.StrUbicacion = dt.Rows[i]["ubicacion"].ToString();
                    objArticulos.Intstock = Convert.ToInt32(dt.Rows[i]["stock"].ToString());
                    objArticulos.DoPrecioEfectivo = Redondeo(Convert.ToDecimal(dt.Rows[i]["precioefectivo"].ToString()));
                    objArticulos.IntCantidadTotal = Convert.ToInt32(dt.Rows[i]["cantidad"].ToString());
                    objArticulos.DoPrecioTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString()));
                    objArticulos.StrUnidadDeVenta = dt.Rows[i]["unidaddeventa"].ToString();

                    ListArticulos.Add(objArticulos);

                }
            }
            return ListArticulos;

        }

        public List<ArticulosReporteGral> ReporteDeArticulosGral(DataTable dt)
        {
            List<ArticulosReporteGral> ListArticulos = new List<ArticulosReporteGral>();
            ArticulosReporteGral objArticulos;
            //if (dt !=null)
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    objArticulos = new ArticulosReporteGral();

                    objArticulos.StrIdExtra = dt.Rows[i]["idextra"].ToString();
                    objArticulos.StrDescripcion = dt.Rows[i]["descripcion"].ToString();
                    objArticulos.DtpFechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                    objArticulos.StrRubro = dt.Rows[i]["rubro"].ToString();
                    objArticulos.StrMarca = dt.Rows[i]["marca"].ToString();
                    objArticulos.StrStock = dt.Rows[i]["stock"].ToString();
                    objArticulos.StrCosto = Convert.ToString( Redondeo( Convert.ToDecimal( dt.Rows[i]["costo"].ToString())));
                    objArticulos.StrPrecio = Convert.ToString( Redondeo( Convert.ToDecimal( dt.Rows[i]["precioefectivo"].ToString())));
                    objArticulos.StrProveedor = dt.Rows[i]["razonsocial"].ToString();
                    objArticulos.StrStockMinimo = dt.Rows[i]["stockminimo"].ToString();
                    objArticulos.StrUbicacion = dt.Rows[i]["ubicacion"].ToString();
                    objArticulos.StrGanancia =dt.Rows[i]["ganancia"].ToString();
                    objArticulos.StrPrecioLista2 = Convert.ToString( Redondeo( Convert.ToDecimal( dt.Rows[i]["preciolista2"].ToString())));
                    objArticulos.StrPrecioLista3 = Convert.ToString(Redondeo(Convert.ToDecimal(dt.Rows[i]["preciolista3"].ToString())));
                    objArticulos.StrMoneda = dt.Rows[i]["moneda"].ToString();
                    objArticulos.StrUnidadDeVenta = dt.Rows[i]["unidaddeventa"].ToString();

                    ListArticulos.Add(objArticulos);

                }
            }
            return ListArticulos;

        }


        public List<ArticulosReporte> ReporteDeArticulosVenta (DataTable dt)
        {
            List<ArticulosReporte> ListArticulos = new List<ArticulosReporte>();
            ArticulosReporte objArticulos;
            //if (dt !=null)
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    objArticulos = new ArticulosReporte();

                    objArticulos.IntCodigo = Convert.ToInt32(dt.Rows[i]["facturaid"].ToString());
                    objArticulos.DtFechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString()); 
                    objArticulos.StrCodigo = dt.Rows[i]["idextra"].ToString(); ;
                    objArticulos.StrDescripcion = dt.Rows[i]["descripcion"].ToString();
                    objArticulos.StrRubro = dt.Rows[i]["rubro"].ToString();
                    objArticulos.StrMarca = dt.Rows[i]["marca"].ToString();
                    objArticulos.StrUbicacion = dt.Rows[i]["ubicacion"].ToString();
                    objArticulos.Intstock = Convert.ToInt32(dt.Rows[i]["stock"].ToString());
                    objArticulos.DoPrecioEfectivo = Redondeo(Convert.ToDecimal(dt.Rows[i]["precioefectivo"].ToString()));
                    objArticulos.IntDescuento = Convert.ToInt32(dt.Rows[i]["descuento"].ToString());
                    objArticulos.IntCantidadTotal = Convert.ToInt32(dt.Rows[i]["cantidad"].ToString());
                    objArticulos.DoPrecioTotal = Redondeo(Convert.ToDecimal(dt.Rows[i]["total"].ToString()));
                    objArticulos.StrUnidadDeVenta = dt.Rows[i]["unidaddeventa"].ToString();
                    ListArticulos.Add(objArticulos);

                }
            }
            return ListArticulos;

        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }


        public bool ExisteArticulo(string strCodigo)
        {
            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from dbo.Articulos where fechabaja is null and idextra ='" + strCodigo + "'";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                if (dt.Rows[0]["cantidad"].ToString() == "0")
                    return false;
                else
                    return true;
            else
                return false;
        }

        public bool ExisteProveedor(string strCodigo)
        {

            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from dbo.Proveedores where id =" + strCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                if (dt.Rows[0]["cantidad"].ToString() == "0")
                    return false;
                else
                    return true;
            else
                return false;
        }

        public bool ExisteMoneda(string strCodigo)
        {

            string strSql;
            strSql = "select count(*) as cantidad";
            strSql += " from dbo.Monedas where monedaid =" + strCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                if (dt.Rows[0]["cantidad"].ToString() == "0")
                    return false;
                else
                    return true;
            else
                return false;
        }

        public Int32 CantidadDeStock(int intCodigo)
        {

            string strSql;
            strSql = "select stock";
            strSql += " from dbo.Articulos where id =" + intCodigo;

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                return Convert.ToInt32((dt.Rows[0]["stock"].ToString()));
            else
                return 0;
        }

        private decimal getPrecioUnitarioCalculado(string strCodigo, decimal deCosto)
        {

            string strSql;
            string strCosto = Convert.ToString(deCosto);


            strSql = "select " + strCosto.Replace(",", ".") + " + (" + strCosto.Replace(",", ".") + "* ganancia)/100 as calculo";
            strSql += " from dbo.Articulos where idextra ='" + strCodigo + "'";

            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            //if (dt != null)
            if (dt.Rows.Count > 0)
                return Redondeo(Convert.ToDecimal((dt.Rows[0]["calculo"].ToString())));
            else
                return 0;
        }

    }

}

