using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaContactoProveedores
    {
        public ManejaContactoProveedores()
        {
        }


        public int GrabarContactos(Contactos objContactos)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[7];

            spParam[0] = new SqlParameter("@prov_id", SqlDbType.BigInt);
            spParam[0].Value = objContactos.IntProveedor;

            spParam[1] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            spParam[1].Value = objContactos.StrNombre;

            spParam[2] = new SqlParameter("@apellido", SqlDbType.NVarChar);
            spParam[2].Value = objContactos.StrApellido;

            spParam[3] = new SqlParameter("@mail", SqlDbType.NVarChar);
            spParam[3].Value = objContactos.StrEmail;

            spParam[4] = new SqlParameter("@puesto", SqlDbType.NVarChar);
            spParam[4].Value = objContactos.StrPuesto;

            spParam[5] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[5].Value = objContactos.StrObservacion;

            spParam[6] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[6].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Contactos";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[6].Value);

        }


        public void GrabarContactoContactos(Telefonos objTelefono, int intCodigoContacto)
        {

            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam5 = new SqlParameter[5];

            spParam5[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam5[0].Value = intCodigoContacto;

            spParam5[1] = new SqlParameter("@vinculo", SqlDbType.NVarChar);
            spParam5[1].Value = objTelefono.StrVinculo;

            spParam5[2] = new SqlParameter("@tipotel", SqlDbType.NVarChar);
            spParam5[2].Value = objTelefono.StrTipotel;

            spParam5[3] = new SqlParameter("@telefono", SqlDbType.NVarChar);
            spParam5[3].Value = objTelefono.StrTel;

            spParam5[4] = new SqlParameter("@interno", SqlDbType.NVarChar);
            spParam5[4].Value = objTelefono.StrInterno;

            oManejaConexiones2.NombreStoredProcedure = "Add_Contactos_Contactos";
            oManejaConexiones2.Parametros = spParam5;
            oManejaConexiones2.executeNonQuery();

        }

        public void ModificaContactos(Contactos objContactos)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[6];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objContactos.IntProveedor;

            spParam[1] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            spParam[1].Value = objContactos.StrNombre;

            spParam[2] = new SqlParameter("@apellido", SqlDbType.NVarChar);
            spParam[2].Value = objContactos.StrApellido;

            spParam[3] = new SqlParameter("@mail", SqlDbType.NVarChar);
            spParam[3].Value = objContactos.StrEmail;

            spParam[4] = new SqlParameter("@puesto", SqlDbType.NVarChar);
            spParam[4].Value = objContactos.StrPuesto;

            spParam[5] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[5].Value = objContactos.StrObservacion;


            oManejaConexiones.NombreStoredProcedure = "Upd_Contactos";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }
        public void VerificaModificacionContactoProveedores(Telefonos objTelefonoPersonal, int intCodigoContactos)
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
                    ModificacioContactoContactos(objTelefonoPersonal);
                }
                if (objTelefonoPersonal.IntEstado == 3)//Elimino
                {
                    EliminaContactoContactos(objTelefonoPersonal);

                }
                //sino no hago nada, todo queda como esta


            }
            else
            {
                //En este caso debe ser un alta de un contacto
                //Hay que tener en cuenta todos los estados menos el 3, que es el de baja
                if (objTelefonoPersonal.IntEstado != 3)
                {
                    GrabarContactoContactos(objTelefonoPersonal, intCodigoContactos);

                }

            }



        }

        public void ModificacioContactoContactos(Telefonos objTelefonoPersonal)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[4];

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

            oManejaConexiones.NombreStoredProcedure = "Upd_Contactos_Contactos";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void EliminaContactoContactos (Telefonos objTelefonoPersonal)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@idcontacto", SqlDbType.BigInt);
            spParam2[0].Value = objTelefonoPersonal.IntCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Contactos_Contactos";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public void EliminaContactos(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Contactos";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Contactos BuscarContactos(int intCodigo)
        {
            Proveedores objProveedores = new Proveedores();
            Contactos objContactos = new Contactos();
            string strSql;
            strSql = "SELECT prov_id,nombre,apellido,mail,puesto,observaciones ";
            strSql += "  FROM Contactos where id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            objContactos.IntCodigo = intCodigo;
            objContactos.IntProveedor = Convert.ToInt32(dt.Rows[0]["prov_id"].ToString());
            objContactos.StrNombre = dt.Rows[0]["nombre"].ToString();
            objContactos.StrApellido = dt.Rows[0]["apellido"].ToString();
            objContactos.StrEmail = dt.Rows[0]["mail"].ToString();
            objContactos.StrPuesto = dt.Rows[0]["puesto"].ToString();
            objContactos.StrObservacion = dt.Rows[0]["observaciones"].ToString();

            objContactos.ListTelefonos = BuscoTelefonosContactos(objContactos.IntCodigo);

            return objContactos;
        }

        public List<Telefonos> BuscoTelefonosContactos(int intCodigo)
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
                    objTelefonos.StrTel = dt2.Rows[i]["interno"].ToString();
                    listTelefonos.Add(objTelefonos);

                }


            }
            return listTelefonos;
        }

    }
}

