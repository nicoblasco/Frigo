using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaClientes
    {

        public ManejaClientes()
        {
        }
        public int GrabarClientes(Clientes objCliente)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[16];

            spParam[0] = new SqlParameter("@documentoid", SqlDbType.Int);
            spParam[0].Value = objCliente.IntDocumento;

            spParam[1] = new SqlParameter("@documento", SqlDbType.NVarChar);
            spParam[1].Value = objCliente.StrDocumento;

            spParam[2] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            spParam[2].Value = objCliente.StrNombre;

            spParam[3] = new SqlParameter("@apellido", SqlDbType.NVarChar);
            spParam[3].Value = objCliente.StrApellido;

            spParam[4] = new SqlParameter("@fdnac", SqlDbType.DateTime);
            spParam[4].Value = objCliente.DtFechadeNac;

            spParam[5] = new SqlParameter("@fding", SqlDbType.DateTime);
            spParam[5].Value = objCliente.DtFechadeIngreso;

            spParam[6] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[6].Value = objCliente.StrDirecccion;

            spParam[7] = new SqlParameter("@depto", SqlDbType.NVarChar);
            spParam[7].Value = objCliente.StrDepto;

            spParam[8] = new SqlParameter("@piso", SqlDbType.NVarChar);
            spParam[8].Value = objCliente.StrPiso;

            spParam[9] = new SqlParameter("@nro", SqlDbType.NVarChar);
            spParam[9].Value = objCliente.StrNro;

            spParam[10] = new SqlParameter("@localidad", SqlDbType.Int);
            spParam[10].Value = objCliente.IntLocalidad;

            spParam[11] = new SqlParameter("@provincia", SqlDbType.Int);
            spParam[11].Value = objCliente.IntProvincia;

            spParam[12] = new SqlParameter("@pais", SqlDbType.Int);
            spParam[12].Value = objCliente.IntPais;

            spParam[13] = new SqlParameter("@mail", SqlDbType.NVarChar);
            spParam[13].Value = objCliente.StrEmail;

            spParam[14] = new SqlParameter("@predeterminado", SqlDbType.Bit);
            spParam[14].Value = objCliente.BoPredeterminado;

            spParam[15] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[15].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Cliente";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[15].Value);

        }


        public void GrabarContactoCliente(Telefonos objTelefono, int intCodigoCliente)
        {

            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam5 = new SqlParameter[5];

            spParam5[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam5[0].Value = intCodigoCliente;

            spParam5[1] = new SqlParameter("@vinculo", SqlDbType.NVarChar);
            spParam5[1].Value = objTelefono.StrVinculo;

            spParam5[2] = new SqlParameter("@tipotel", SqlDbType.NVarChar);
            spParam5[2].Value = objTelefono.StrTipotel;

            spParam5[3] = new SqlParameter("@telefono", SqlDbType.NVarChar);
            spParam5[3].Value = objTelefono.StrTel;

            spParam5[4] = new SqlParameter("@interno", SqlDbType.NVarChar);
            spParam5[4].Value = objTelefono.StrInterno;

            oManejaConexiones2.NombreStoredProcedure = "Add_Contactos_Clientes";
            oManejaConexiones2.Parametros = spParam5;
            oManejaConexiones2.executeNonQuery();

        }

        public void ModificaClientes(Clientes objCliente)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[16];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objCliente.IntCodigo;

            spParam[1] = new SqlParameter("@documentoid", SqlDbType.Int);
            spParam[1].Value = objCliente.IntDocumento;

            spParam[2] = new SqlParameter("@documento", SqlDbType.NVarChar);
            spParam[2].Value = objCliente.StrDocumento;

            spParam[3] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            spParam[3].Value = objCliente.StrNombre;

            spParam[4] = new SqlParameter("@apellido", SqlDbType.NVarChar);
            spParam[4].Value = objCliente.StrApellido;

            spParam[5] = new SqlParameter("@fdnac", SqlDbType.DateTime);
            spParam[5].Value = objCliente.DtFechadeNac;

            spParam[6] = new SqlParameter("@fding", SqlDbType.DateTime);
            spParam[6].Value = objCliente.DtFechadeIngreso;

            spParam[7] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[7].Value = objCliente.StrDirecccion;

            spParam[8] = new SqlParameter("@depto", SqlDbType.NVarChar);
            spParam[8].Value = objCliente.StrDepto;

            spParam[9] = new SqlParameter("@piso", SqlDbType.NVarChar);
            spParam[9].Value = objCliente.StrPiso;

            spParam[10] = new SqlParameter("@nro", SqlDbType.NVarChar);
            spParam[10].Value = objCliente.StrNro;

            spParam[11] = new SqlParameter("@localidad", SqlDbType.Int);
            spParam[11].Value = objCliente.IntLocalidad;

            spParam[12] = new SqlParameter("@provincia", SqlDbType.Int);
            spParam[12].Value = objCliente.IntProvincia;

            spParam[13] = new SqlParameter("@pais", SqlDbType.Int);
            spParam[13].Value = objCliente.IntPais;

            spParam[14] = new SqlParameter("@mail", SqlDbType.NVarChar);
            spParam[14].Value = objCliente.StrEmail;

            spParam[15] = new SqlParameter("@predeterminado", SqlDbType.Bit);
            spParam[15].Value = objCliente.BoPredeterminado;

            oManejaConexiones.NombreStoredProcedure = "Upd_Cliente";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }
        public void VerificaModificacionContactoCliente(Telefonos objTelefonoPersonal, int intCodigoCliente)
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
                    ModificacioContactoCliente(objTelefonoPersonal);
                }
                if (objTelefonoPersonal.IntEstado == 3)//Elimino
                {
                    EliminaContactoCliente(objTelefonoPersonal);

                }
                //sino no hago nada, todo queda como esta


            }
            else
            {
                //En este caso debe ser un alta de un contacto
                //Hay que tener en cuenta todos los estados menos el 3, que es el de baja
                if (objTelefonoPersonal.IntEstado != 3)
                {
                    GrabarContactoCliente(objTelefonoPersonal, intCodigoCliente);

                }

            }



        }

        public void ModificacioContactoCliente(Telefonos objTelefonoPersonal)
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

            oManejaConexiones.NombreStoredProcedure = "Upd_Contactos_Clientes";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void EliminaContactoCliente(Telefonos objTelefonoPersonal)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@idcontacto", SqlDbType.BigInt);
            spParam2[0].Value = objTelefonoPersonal.IntCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Contactos_Clientes";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public void EliminaCliente(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Cliente";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Clientes BuscarCliente(int intCodigo)
        {
            Clientes objClientes = new Clientes();
            string strSql;
            strSql = "select doc_id,cli_documento,cli_nombre,cli_apellido,cli_fdnac,cli_fding,cli_direccion,cli_depto,cli_piso,cli_nro,loc_id,prov_id,pais,cli_mail, predeterminado, fechabaja";
            strSql += " from dbo.Clientes where cli_id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            objClientes.IntCodigo = intCodigo;
            objClientes.IntDocumento = Convert.ToInt32(dt.Rows[0]["doc_id"].ToString());
            objClientes.StrDocumento = dt.Rows[0]["cli_documento"].ToString();
            objClientes.StrNombre = dt.Rows[0]["cli_nombre"].ToString();
            objClientes.StrApellido = dt.Rows[0]["cli_apellido"].ToString();
            objClientes.DtFechadeNac = Convert.ToDateTime(dt.Rows[0]["cli_fdnac"].ToString());
            objClientes.DtFechadeIngreso = Convert.ToDateTime(dt.Rows[0]["cli_fding"].ToString());
            objClientes.StrDirecccion = dt.Rows[0]["cli_direccion"].ToString();
            objClientes.StrDepto = dt.Rows[0]["cli_depto"].ToString();
            objClientes.StrPiso = dt.Rows[0]["cli_piso"].ToString();
            objClientes.StrNro = dt.Rows[0]["cli_nro"].ToString();
            objClientes.IntLocalidad = Convert.ToInt32(dt.Rows[0]["loc_id"].ToString());
            objClientes.IntProvincia = Convert.ToInt32(dt.Rows[0]["prov_id"].ToString());
            objClientes.IntPais = Convert.ToInt32(dt.Rows[0]["pais"].ToString());
            objClientes.StrEmail = dt.Rows[0]["cli_mail"].ToString();
            objClientes.BoPredeterminado = Convert.ToBoolean(dt.Rows[0]["predeterminado"].ToString());
            objClientes.DtFechaBaja = Convert.ToString(dt.Rows[0]["fechabaja"].ToString());

            objClientes.ListTelefonos = BuscoTelefonosCliente(objClientes.IntCodigo);

            return objClientes;
        }

        public List<Telefonos> BuscoTelefonosCliente(int intCodigo)
        {
            string strSql;
            Telefonos objTelefonos;
            List<Telefonos> listTelefonos = new List<Telefonos>();
            strSql = "select cc_id,cc_vinculo,cc_tipotel,cc_tel, interno ";
            strSql += "from dbo.Contactos_cliente where cli_id=" + intCodigo;
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

        public Decimal CalcularDeudaCliente(int intCodigo)
        {
            string strSql;
            strSql = "select isnull(sum(ctacte),0) as suma from factura where estado='CUMPLIDA' and clienteid = " + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);
            if (dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0]["suma"].ToString());
            else
                return 0;

        }

        public bool ClienteDadoDeBaja(int intCodigo)
        {
            Clientes objClientes = new Clientes();
            string strSql;
            strSql = "select  fechabaja";
            strSql += " from dbo.Clientes where cli_id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt != null)
                if (string.IsNullOrEmpty(dt.Rows[0]["fechabaja"].ToString()))
                    return false;
                else
                    return true;
            else
                return false;
        }

    }
}
