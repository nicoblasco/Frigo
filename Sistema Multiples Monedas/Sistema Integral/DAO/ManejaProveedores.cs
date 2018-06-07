using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace DAO
{
    public class ManejaProveedores
    {
        ManejaContactoProveedores objManejaContactoProveedores;
        public ManejaProveedores ()
        {
        }

        public int GrabarProveedores(Proveedores objProveedores)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[22];

            spParam[0] = new SqlParameter("@documentoid", SqlDbType.Int);
            spParam[0].Value = objProveedores.IntDocumento;

            spParam[1] = new SqlParameter("@documento", SqlDbType.NVarChar);
            spParam[1].Value = objProveedores.StrDocumento;

            spParam[2] = new SqlParameter("@razonsocial", SqlDbType.NVarChar);
            spParam[2].Value = objProveedores.StrRazonSocial;

            spParam[3] = new SqlParameter("@fding", SqlDbType.DateTime);
            spParam[3].Value = objProveedores.DtFechadeIngreso;

            spParam[4] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[4].Value = objProveedores.StrDirecccion;

            spParam[5] = new SqlParameter("@depto", SqlDbType.NVarChar);
            spParam[5].Value = objProveedores.StrDepto;

            spParam[6] = new SqlParameter("@piso", SqlDbType.NVarChar);
            spParam[6].Value = objProveedores.StrPiso;

            spParam[7] = new SqlParameter("@nro", SqlDbType.NVarChar);
            spParam[7].Value = objProveedores.StrNro;

            spParam[8] = new SqlParameter("@localidad", SqlDbType.Int);
            spParam[8].Value = objProveedores.IntLocalidad;

            spParam[9] = new SqlParameter("@provincia", SqlDbType.Int);
            spParam[9].Value = objProveedores.IntProvincia;

            spParam[10] = new SqlParameter("@pais", SqlDbType.Int);
            spParam[10].Value = objProveedores.IntPais;

            spParam[11] = new SqlParameter("@mail", SqlDbType.NVarChar);
            spParam[11].Value = objProveedores.StrEmail;

            spParam[12] = new SqlParameter("@url", SqlDbType.NVarChar);
            spParam[12].Value = objProveedores.StrUrl;

            spParam[13] = new SqlParameter("@lunes", SqlDbType.Bit);
            spParam[13].Value = objProveedores.BoLunes;

            spParam[14] = new SqlParameter("@martes", SqlDbType.Bit);
            spParam[14].Value = objProveedores.BoMartes;

            spParam[15] = new SqlParameter("@miercoles", SqlDbType.Bit);
            spParam[15].Value = objProveedores.BoMiercoles;

            spParam[16] = new SqlParameter("@jueves", SqlDbType.Bit);
            spParam[16].Value = objProveedores.BoJueves;

            spParam[17] = new SqlParameter("@viernes", SqlDbType.Bit);
            spParam[17].Value = objProveedores.BoViernes;

            spParam[18] = new SqlParameter("@sabado", SqlDbType.Bit);
            spParam[18].Value = objProveedores.BoViernes;

            spParam[19] = new SqlParameter("@domingo", SqlDbType.Bit);
            spParam[19].Value = objProveedores.BoDomingo;

            spParam[20] = new SqlParameter("@servicios", SqlDbType.NVarChar);
            spParam[20].Value = objProveedores.StrServicio;

            spParam[21] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[21].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Proveedores";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[21].Value);

        }


        public void GrabarContactoProveedores(Telefonos objTelefono, int intCodigoProveedor)
        {

            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam5 = new SqlParameter[5];

            spParam5[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam5[0].Value = intCodigoProveedor;

            spParam5[1] = new SqlParameter("@vinculo", SqlDbType.NVarChar);
            spParam5[1].Value = objTelefono.StrVinculo;

            spParam5[2] = new SqlParameter("@tipotel", SqlDbType.NVarChar);
            spParam5[2].Value = objTelefono.StrTipotel;

            spParam5[3] = new SqlParameter("@telefono", SqlDbType.NVarChar);
            spParam5[3].Value = objTelefono.StrTel;

            spParam5[4] = new SqlParameter("@interno", SqlDbType.NVarChar);
            spParam5[4].Value = objTelefono.StrInterno;

            oManejaConexiones2.NombreStoredProcedure = "Add_Contactos_Proveedores";
            oManejaConexiones2.Parametros = spParam5;
            oManejaConexiones2.executeNonQuery();

        }

        public void ModificaProveedores(Proveedores objProveedores)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[22];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objProveedores.IntCodigo;

            spParam[1] = new SqlParameter("@documentoid", SqlDbType.Int);
            spParam[1].Value = objProveedores.IntDocumento;

            spParam[2] = new SqlParameter("@documento", SqlDbType.NVarChar);
            spParam[2].Value = objProveedores.StrDocumento;

            spParam[3] = new SqlParameter("@razonsocial", SqlDbType.NVarChar);
            spParam[3].Value = objProveedores.StrRazonSocial;

            spParam[4] = new SqlParameter("@fding", SqlDbType.DateTime);
            spParam[4].Value = objProveedores.DtFechadeIngreso;

            spParam[5] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[5].Value = objProveedores.StrDirecccion;

            spParam[6] = new SqlParameter("@depto", SqlDbType.NVarChar);
            spParam[6].Value = objProveedores.StrDepto;

            spParam[7] = new SqlParameter("@piso", SqlDbType.NVarChar);
            spParam[7].Value = objProveedores.StrPiso;

            spParam[8] = new SqlParameter("@nro", SqlDbType.NVarChar);
            spParam[8].Value = objProveedores.StrNro;

            spParam[9] = new SqlParameter("@localidad", SqlDbType.Int);
            spParam[9].Value = objProveedores.IntLocalidad;

            spParam[10] = new SqlParameter("@provincia", SqlDbType.Int);
            spParam[10].Value = objProveedores.IntProvincia;

            spParam[11] = new SqlParameter("@pais", SqlDbType.Int);
            spParam[11].Value = objProveedores.IntPais;

            spParam[12] = new SqlParameter("@mail", SqlDbType.NVarChar);
            spParam[12].Value = objProveedores.StrEmail;

            spParam[13] = new SqlParameter("@url", SqlDbType.NVarChar);
            spParam[13].Value = objProveedores.StrUrl;

            spParam[14] = new SqlParameter("@lunes", SqlDbType.Bit);
            spParam[14].Value = objProveedores.BoLunes;

            spParam[15] = new SqlParameter("@martes", SqlDbType.Bit);
            spParam[15].Value = objProveedores.BoMartes;

            spParam[16] = new SqlParameter("@miercoles", SqlDbType.Bit);
            spParam[16].Value = objProveedores.BoMiercoles;

            spParam[17] = new SqlParameter("@jueves", SqlDbType.Bit);
            spParam[17].Value = objProveedores.BoJueves;

            spParam[18] = new SqlParameter("@viernes", SqlDbType.Bit);
            spParam[18].Value = objProveedores.BoViernes;

            spParam[19] = new SqlParameter("@sabado", SqlDbType.Bit);
            spParam[19].Value = objProveedores.BoSabado;

            spParam[20] = new SqlParameter("@domingo", SqlDbType.Bit);
            spParam[20].Value = objProveedores.BoDomingo;

            spParam[21] = new SqlParameter("@servicios", SqlDbType.NVarChar);
            spParam[21].Value = objProveedores.StrServicio;

            oManejaConexiones.NombreStoredProcedure = "Upd_Proveedores";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }
        public void VerificaModificacionContactoProveedores(Telefonos objTelefonoPersonal, int intCodigoProveedores)
        {
            //Si tiene un codigo asignado es porque el contacto ya existia
            //Tambien debo tener el cuenta la transaccion que hizo con el campo intEstado
            //para esto se debera considerar los valores (0,1,2,3) 


            if (objTelefonoPersonal.IntCodigo != 0)
            //El contacto ya existia
            {
                //Me fijo que hay que hacer con el contacto
                if (objTelefonoPersonal.IntEstado == 2)//Modifico
                {
                    ModificacioContactoProveedor(objTelefonoPersonal);
                }
                if (objTelefonoPersonal.IntEstado == 3)//Elimino
                {
                    EliminaContactoProveedor(objTelefonoPersonal);

                }
                //sino no hago nada, todo queda como esta


            }
            else
            {
                //En este caso debe ser un alta de un contacto
                //Hay que tener en cuenta todos los estados menos el 3, que es el de baja
                if (objTelefonoPersonal.IntEstado != 3)
                {
                    GrabarContactoProveedores(objTelefonoPersonal, intCodigoProveedores);

                }

            }



        }

        public void VerificaModificacionContactos(Contactos objContactos, int intCodigoProveedores)
        {
            //Si tiene un codigo asignado es porque el contacto ya existia
            //Tambien debo tener el cuenta la transaccion que hizo con el campo intEstado
            //para esto se debera considerar los valores (0,1,2,3) 

            objManejaContactoProveedores = new ManejaContactoProveedores();

            if (objContactos.IntCodigo != 0)
            //El contacto ya existia
            {
                //Me fijo que hay que hacer con el contacto
                if (objContactos.IntEstado == 2)//Modifico
                {
                    objManejaContactoProveedores.ModificaContactos(objContactos);

                }
                if (objContactos.IntEstado == 3)//Elimino
                {
                    objManejaContactoProveedores.EliminaContactos(objContactos.IntCodigo);

                }
                //sino no hago nada, todo queda como esta


            }
            else
            {
                //En este caso debe ser un alta de un contacto
                //Hay que tener en cuenta todos los estados menos el 3, que es el de baja
                if (objContactos.IntEstado != 3)
                {
                  objContactos.IntCodigo=   objManejaContactoProveedores.GrabarContactos(objContactos);

                }

            }



        }

        public void ModificacioContactoProveedor(Telefonos objTelefonoPersonal)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[5];

            spParam[0] = new SqlParameter("@idcontacto", SqlDbType.BigInt);
            spParam[0].Value = objTelefonoPersonal.IntCodigo;

            spParam[1] = new SqlParameter("@vinculo", SqlDbType.NVarChar);
            spParam[1].Value = objTelefonoPersonal.StrVinculo;

            spParam[2] = new SqlParameter("@tipotel", SqlDbType.NVarChar);
            spParam[2].Value = objTelefonoPersonal.StrTipotel;

            spParam[3] = new SqlParameter("@telefono", SqlDbType.NVarChar);
            spParam[3].Value = objTelefonoPersonal.StrTel;

            spParam[4] = new SqlParameter("@interno", SqlDbType.NVarChar);
            spParam[4].Value = objTelefonoPersonal.StrInterno;

            oManejaConexiones.NombreStoredProcedure = "Upd_Contactos_Proveedores";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void EliminaContactoProveedor(Telefonos objTelefonoPersonal)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@idcontacto", SqlDbType.BigInt);
            spParam2[0].Value = objTelefonoPersonal.IntCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Contactos_Proveedores";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public void EliminaProveedores(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Proveedores";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Proveedores BuscarProveedores(int intCodigo)
        {
            Proveedores objProveedores = new Proveedores();
            string strSql;
            strSql = "SELECT doc_id,documento,razonsocial,fding,direccion,depto,piso,nro,loc_id,prov_id,pais,mail,url,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo, servicios, fechabaja ";
            strSql += "  FROM Proveedores where id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            objProveedores.IntCodigo = intCodigo;
            objProveedores.IntDocumento = Convert.ToInt32(dt.Rows[0]["doc_id"].ToString());
            objProveedores.StrDocumento = dt.Rows[0]["documento"].ToString();
            objProveedores.StrRazonSocial = dt.Rows[0]["razonsocial"].ToString();
            objProveedores.DtFechadeIngreso = Convert.ToDateTime(dt.Rows[0]["fding"].ToString());
            objProveedores.StrDirecccion = dt.Rows[0]["direccion"].ToString();
            objProveedores.StrDepto = dt.Rows[0]["depto"].ToString();
            objProveedores.StrPiso = dt.Rows[0]["piso"].ToString();
            objProveedores.StrNro = dt.Rows[0]["nro"].ToString();
            objProveedores.IntLocalidad = Convert.ToInt32(dt.Rows[0]["loc_id"].ToString());
            objProveedores.IntProvincia = Convert.ToInt32(dt.Rows[0]["prov_id"].ToString());
            objProveedores.IntPais = Convert.ToInt32(dt.Rows[0]["pais"].ToString());
            objProveedores.StrEmail = dt.Rows[0]["mail"].ToString();
            objProveedores.StrUrl = dt.Rows[0]["url"].ToString();
            objProveedores.BoLunes = Convert.ToBoolean(dt.Rows[0]["Lunes"].ToString());
            objProveedores.BoMartes = Convert.ToBoolean(dt.Rows[0]["Martes"].ToString());
            objProveedores.BoMiercoles = Convert.ToBoolean(dt.Rows[0]["Miercoles"].ToString());
            objProveedores.BoJueves = Convert.ToBoolean(dt.Rows[0]["Jueves"].ToString());
            objProveedores.BoViernes = Convert.ToBoolean(dt.Rows[0]["Viernes"].ToString());
            objProveedores.BoSabado = Convert.ToBoolean(dt.Rows[0]["Sabado"].ToString());
            objProveedores.BoDomingo = Convert.ToBoolean(dt.Rows[0]["Domingo"].ToString());
            objProveedores.StrServicio = dt.Rows[0]["servicios"].ToString();
            objProveedores.DtFechaBaja = Convert.ToString( dt.Rows[0]["fechabaja"].ToString());

            objProveedores.ListTelefonos = BuscoTelefonosProveedores(objProveedores.IntCodigo);
            objProveedores.ListContactos = BuscoContactos(objProveedores.IntCodigo);

            return objProveedores;
        }

        public List<Telefonos> BuscoTelefonosProveedores(int intCodigo)
        {
            string strSql;
            Telefonos objTelefonos;
            List<Telefonos> listTelefonos = new List<Telefonos>();
            strSql = "select cc_id,cc_vinculo,cc_tipotel,cc_tel, interno ";
            strSql += "from dbo.Contactos_proveedores where cli_id=" + intCodigo;
            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);
            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objTelefonos = new Telefonos();
                    objTelefonos.IntCodigo = Convert.ToInt32(dt2.Rows[i]["cc_id"].ToString());
                    objTelefonos.StrVinculo = dt2.Rows[i]["cc_vinculo"].ToString();
                    objTelefonos.StrTipotel = dt2.Rows[i]["cc_tipotel"].ToString();
                    objTelefonos.StrTel = dt2.Rows[i]["cc_tel"].ToString();
                    objTelefonos.StrInterno = dt2.Rows[i]["interno"].ToString();
                    listTelefonos.Add(objTelefonos);

                }


            }
            return listTelefonos;
        }

        public List<Contactos> BuscoContactos(int intCodigo)
        {
            string strSql;
            Contactos objContactos;
            List<Contactos> listContactos = new List<Contactos>();
            strSql = "SELECT id,nombre,apellido,mail,puesto,observaciones ";
            strSql += "  FROM Contactos where prov_id =" + intCodigo;
            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);
            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objContactos = new Contactos();
                    objContactos.IntCodigo = Convert.ToInt32(dt2.Rows[i]["id"].ToString());
                    objContactos.IntProveedor = intCodigo;
                    objContactos.StrNombre = dt2.Rows[i]["nombre"].ToString();
                    objContactos.StrApellido = dt2.Rows[i]["apellido"].ToString();
                    objContactos.StrEmail = dt2.Rows[i]["mail"].ToString();
                    objContactos.StrPuesto = dt2.Rows[i]["puesto"].ToString();
                    objContactos.StrObservacion = dt2.Rows[i]["observaciones"].ToString();
                    objContactos.ListTelefonos = BuscoTelefonosContactos(objContactos.IntCodigo);
                    listContactos.Add(objContactos);

                }


            }
            return listContactos;
        }

        public List<Telefonos> BuscoTelefonosContactos(int intCodigo)
        {
            string strSql;
            Telefonos objTelefonos;
            List<Telefonos> listTelefonos = new List<Telefonos>();
            strSql = "select cc_id,cc_vinculo,cc_tipotel,cc_tel, interno ";
            strSql += "from dbo.Contactos_Contactos where cli_id=" + intCodigo;
            LlenaCombos objLlenaCombos2 = new LlenaCombos();
            DataTable dt2 = objLlenaCombos2.GetSqlDataAdapterbySql(strSql);
            if (dt2 != null)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    objTelefonos = new Telefonos();
                    objTelefonos.IntCodigo = Convert.ToInt32(dt2.Rows[i]["cc_id"].ToString());
                    objTelefonos.StrVinculo = dt2.Rows[i]["cc_vinculo"].ToString();
                    objTelefonos.StrTipotel = dt2.Rows[i]["cc_tipotel"].ToString();
                    objTelefonos.StrTel = dt2.Rows[i]["cc_tel"].ToString();
                    objTelefonos.StrInterno = dt2.Rows[i]["interno"].ToString();
                    listTelefonos.Add(objTelefonos);

                }


            }
            return listTelefonos;
        }

    }
}
