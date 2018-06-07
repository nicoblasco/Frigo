using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ManejaEmpleados
    {
        public ManejaEmpleados()
        {
        }
        public int GrabarEmpleados(Empleados objEmpleados)
        {

            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[19];

            spParam[0] = new SqlParameter("@documentoid", SqlDbType.Int);
            spParam[0].Value = objEmpleados.IntDocumento;

            spParam[1] = new SqlParameter("@documento", SqlDbType.NVarChar);
            spParam[1].Value = objEmpleados.StrDocumento;

            spParam[2] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            spParam[2].Value = objEmpleados.StrNombre;

            spParam[3] = new SqlParameter("@apellido", SqlDbType.NVarChar);
            spParam[3].Value = objEmpleados.StrApellido;

            spParam[4] = new SqlParameter("@fdnac", SqlDbType.DateTime);
            spParam[4].Value = objEmpleados.DtFechadeNac;

            spParam[5] = new SqlParameter("@fding", SqlDbType.DateTime);
            spParam[5].Value = objEmpleados.DtFechadeIngreso;

            spParam[6] = new SqlParameter("@fdegr", SqlDbType.NVarChar);
            spParam[6].Value = objEmpleados.DtFechadeEgreso;

            spParam[7] = new SqlParameter("@nacionalidad", SqlDbType.NVarChar);
            spParam[7].Value = objEmpleados.StrNacionalidad;

            spParam[8] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[8].Value = objEmpleados.StrDirecccion;

            spParam[9] = new SqlParameter("@depto", SqlDbType.NVarChar);
            spParam[9].Value = objEmpleados.StrDepto;

            spParam[10] = new SqlParameter("@piso", SqlDbType.NVarChar);
            spParam[10].Value = objEmpleados.StrPiso;

            spParam[11] = new SqlParameter("@nro", SqlDbType.NVarChar);
            spParam[11].Value = objEmpleados.StrNro;

            spParam[12] = new SqlParameter("@localidad", SqlDbType.Int);
            spParam[12].Value = objEmpleados.IntLocalidad;

            spParam[13] = new SqlParameter("@provincia", SqlDbType.Int);
            spParam[13].Value = objEmpleados.IntProvincia;

            spParam[14] = new SqlParameter("@cuit", SqlDbType.NVarChar);
            spParam[14].Value = objEmpleados.StrCuit;

            spParam[15] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[15].Value = objEmpleados.StrObservaciones;

            spParam[16] = new SqlParameter("@predeterminado", SqlDbType.Bit);
            spParam[16].Value = objEmpleados.BoPredeterminado;

            spParam[17] = new SqlParameter("@idusuario", SqlDbType.Int);
            spParam[17].Value = objEmpleados.IntUser;

            spParam[18] = new SqlParameter("@codigo", SqlDbType.BigInt);
            //spParam2[18].Value = c.StrVinculo.ToString();
            spParam[18].Direction = ParameterDirection.Output;


            oManejaConexiones.NombreStoredProcedure = "Add_Empleados";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();

            return Convert.ToInt32(spParam[18].Value);

        }


        public void GrabarContactoEmpleados(Telefonos objTelefono, int intCodigoEmpleado)
        {

            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam5 = new SqlParameter[5];

            spParam5[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam5[0].Value = intCodigoEmpleado;

            spParam5[1] = new SqlParameter("@vinculo", SqlDbType.NVarChar);
            spParam5[1].Value = objTelefono.StrVinculo;

            spParam5[2] = new SqlParameter("@tipotel", SqlDbType.NVarChar);
            spParam5[2].Value = objTelefono.StrTipotel;

            spParam5[3] = new SqlParameter("@telefono", SqlDbType.NVarChar);
            spParam5[3].Value = objTelefono.StrTel;

            spParam5[4] = new SqlParameter("@interno", SqlDbType.NVarChar);
            spParam5[4].Value = objTelefono.StrInterno;

            oManejaConexiones2.NombreStoredProcedure = "Add_Contactos_Empleados";
            oManejaConexiones2.Parametros = spParam5;
            oManejaConexiones2.executeNonQuery();

        }

        public void ModificaEmpleados(Empleados objEmpleados)
        {
            ManejaConexiones oManejaConexiones = new ManejaConexiones();
            SqlParameter[] spParam = new SqlParameter[19];

            spParam[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam[0].Value = objEmpleados.IntCodigo;

            spParam[1] = new SqlParameter("@documentoid", SqlDbType.Int);
            spParam[1].Value = objEmpleados.IntDocumento;

            spParam[2] = new SqlParameter("@documento", SqlDbType.NVarChar);
            spParam[2].Value = objEmpleados.StrDocumento;

            spParam[3] = new SqlParameter("@nombre", SqlDbType.NVarChar);
            spParam[3].Value = objEmpleados.StrNombre;

            spParam[4] = new SqlParameter("@apellido", SqlDbType.NVarChar);
            spParam[4].Value = objEmpleados.StrApellido;

            spParam[5] = new SqlParameter("@fdnac", SqlDbType.DateTime);
            spParam[5].Value = objEmpleados.DtFechadeNac;

            spParam[6] = new SqlParameter("@fding", SqlDbType.DateTime);
            spParam[6].Value = objEmpleados.DtFechadeIngreso;

            spParam[7] = new SqlParameter("@fdegr", SqlDbType.NVarChar);
            spParam[7].Value = objEmpleados.DtFechadeEgreso;

            spParam[8] = new SqlParameter("@nacionalidad", SqlDbType.NVarChar);
            spParam[8].Value = objEmpleados.StrNacionalidad;

            spParam[9] = new SqlParameter("@direccion", SqlDbType.NVarChar);
            spParam[9].Value = objEmpleados.StrDirecccion;

            spParam[10] = new SqlParameter("@depto", SqlDbType.NVarChar);
            spParam[10].Value = objEmpleados.StrDepto;

            spParam[11] = new SqlParameter("@piso", SqlDbType.NVarChar);
            spParam[11].Value = objEmpleados.StrPiso;

            spParam[12] = new SqlParameter("@nro", SqlDbType.NVarChar);
            spParam[12].Value = objEmpleados.StrNro;

            spParam[13] = new SqlParameter("@localidad", SqlDbType.Int);
            spParam[13].Value = objEmpleados.IntLocalidad;

            spParam[14] = new SqlParameter("@provincia", SqlDbType.Int);
            spParam[14].Value = objEmpleados.IntProvincia;

            spParam[15] = new SqlParameter("@cuit", SqlDbType.NVarChar);
            spParam[15].Value = objEmpleados.StrCuit;

            spParam[16] = new SqlParameter("@observaciones", SqlDbType.NVarChar);
            spParam[16].Value = objEmpleados.StrObservaciones;

            spParam[17] = new SqlParameter("@predeterminado", SqlDbType.Bit);
            spParam[17].Value = objEmpleados.BoPredeterminado;

            spParam[18] = new SqlParameter("@idusuario", SqlDbType.Int);
            spParam[18].Value = objEmpleados.IntUser;


            oManejaConexiones.NombreStoredProcedure = "Upd_Empleados";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();


        }
        public void VerificaModificacionContactoEmpleados(Telefonos objTelefonoPersonal, int intCodigoEmpleados)
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
                    ModificacioContactoEmpleados(objTelefonoPersonal);
                }
                if (objTelefonoPersonal.IntEstado == 3)//Elimino
                {
                    EliminaContactoEmpleados(objTelefonoPersonal);

                }
                //sino no hago nada, todo queda como esta


            }
            else
            {
                //En este caso debe ser un alta de un contacto
                //Hay que tener en cuenta todos los estados menos el 3, que es el de baja
                if (objTelefonoPersonal.IntEstado != 3)
                {
                    GrabarContactoEmpleados(objTelefonoPersonal, intCodigoEmpleados);

                }

            }



        }

        public void ModificacioContactoEmpleados(Telefonos objTelefonoPersonal)
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

            oManejaConexiones.NombreStoredProcedure = "Upd_Contactos_Empleados";
            oManejaConexiones.Parametros = spParam;
            oManejaConexiones.executeNonQuery();
        }

        public void EliminaContactoEmpleados(Telefonos objTelefonoPersonal)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@idcontacto", SqlDbType.BigInt);
            spParam2[0].Value = objTelefonoPersonal.IntCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Contactos_Empleados";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public void EliminaEmpleados(int intCodigo)
        {
            ManejaConexiones oManejaConexiones2 = new ManejaConexiones();
            SqlParameter[] spParam2 = new SqlParameter[1];

            spParam2[0] = new SqlParameter("@codigo", SqlDbType.BigInt);
            spParam2[0].Value = intCodigo;

            oManejaConexiones2.NombreStoredProcedure = "Dtl_Empleados";
            oManejaConexiones2.Parametros = spParam2;
            oManejaConexiones2.executeNonQuery();
        }

        public Empleados BuscarEmpleados(int intCodigo)
        {
            Empleados objEmpleados = new Empleados();
            string strSql;
            strSql = "SELECT doc_id,emp_documento,emp_nombre,emp_apellido,emp_fdnac,emp_fding,emp_fdegr,emp_nacionalidad,emp_direccion,emp_depto,emp_piso,emp_nro,loc_id,prov_id,emp_cuit,emp_observaciones, predeterminado, fechabaja,usuario";
            strSql += " from dbo.Empleados where emp_id =" + intCodigo;
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            objEmpleados.IntCodigo = intCodigo;
            objEmpleados.IntDocumento = Convert.ToInt32(dt.Rows[0]["doc_id"].ToString());
            objEmpleados.StrDocumento = dt.Rows[0]["emp_documento"].ToString();
            objEmpleados.StrNombre = dt.Rows[0]["emp_nombre"].ToString();
            objEmpleados.StrApellido = dt.Rows[0]["emp_apellido"].ToString();
            objEmpleados.DtFechadeNac = Convert.ToDateTime(dt.Rows[0]["emp_fdnac"].ToString());
            objEmpleados.DtFechadeIngreso = Convert.ToDateTime(dt.Rows[0]["emp_fding"].ToString());
            objEmpleados.DtFechadeEgreso = Convert.ToString(dt.Rows[0]["emp_fdegr"].ToString());
            objEmpleados.StrNacionalidad = dt.Rows[0]["emp_nacionalidad"].ToString();
            objEmpleados.StrDirecccion = dt.Rows[0]["emp_direccion"].ToString();
            objEmpleados.StrDepto = dt.Rows[0]["emp_depto"].ToString();
            objEmpleados.StrPiso = dt.Rows[0]["emp_piso"].ToString();
            objEmpleados.StrNro = dt.Rows[0]["emp_nro"].ToString();
            objEmpleados.IntLocalidad = Convert.ToInt32(dt.Rows[0]["loc_id"].ToString());
            objEmpleados.IntProvincia = Convert.ToInt32(dt.Rows[0]["prov_id"].ToString());
            objEmpleados.StrCuit = dt.Rows[0]["emp_cuit"].ToString();
            objEmpleados.StrObservaciones = dt.Rows[0]["emp_observaciones"].ToString();
            objEmpleados.ListTelefonos = BuscoTelefonosEmpleados(objEmpleados.IntCodigo);
            objEmpleados.BoPredeterminado = Convert.ToBoolean(dt.Rows[0]["predeterminado"].ToString());
            objEmpleados.DtFechaBaja = Convert.ToString(dt.Rows[0]["fechabaja"].ToString());
            if (dt.Rows[0]["usuario"].ToString() != "")
                objEmpleados.IntUser = Convert.ToInt32(dt.Rows[0]["usuario"].ToString());
            
            return objEmpleados;
        }

        public List<Telefonos> BuscoTelefonosEmpleados(int intCodigo)
        {
            string strSql;
            Telefonos objTelefonos;
            List<Telefonos> listTelefonos = new List<Telefonos>();
            strSql = "select cc_id,cc_vinculo,cc_tipotel,cc_tel, interno ";
            strSql += "from dbo.Contactos_empleados where cli_id=" + intCodigo;
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

        public bool EmpleadoDadoDeBaja(int intCodigo)
        {
            Empleados objEmpleados = new Empleados();
            string strSql;
            strSql = "SELECT  fechabaja";
            strSql += " from dbo.Empleados where emp_id =" + intCodigo;
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

