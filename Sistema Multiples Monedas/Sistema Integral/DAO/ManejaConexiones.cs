using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DAO
{
    public class ManejaConexiones
    {
        private int _NroError = 0;
        private SqlConnection _oConn = null;
        private SqlParameter[] _spParam;
        private DataTable _table;
        private string _NombreStoredProcedure = "";

        public int NroError
        {
            get
            {
                return _NroError;
            }
        }
        public SqlParameter[] Parametros
        {
            set
            {
                _spParam = value;
            }
            get
            {
                return _spParam;
            }
        }
        public DataTable Table
        {
            get
            {
                return _table;
            }
        }
        public string NombreStoredProcedure
        {
            set
            {
                _NombreStoredProcedure = value;
            }
            get
            {
                return _NombreStoredProcedure;
            }
        }
        public void llenaTable()
        {
            try
            {
                _oConn = common.GetConnexion();
                DataSet ds = SqlHelper.ExecuteDataset(_oConn, CommandType.StoredProcedure, _NombreStoredProcedure, _spParam);//.Tables[0]
                int cant = ds.Tables.Count;
                _table = ds.Tables[0];
            }
            catch (SqlException dbEx)
            {
                _NroError = dbEx.Number;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_oConn != null)
                {
                    _oConn.Close();
                    ((IDisposable)_oConn).Dispose();
                }
            }
        }
        public void executeNonQuery()
        {
            try
            {
                _oConn = common.GetConnexion();
                SqlHelper.ExecuteNonQuery(_oConn, CommandType.StoredProcedure, _NombreStoredProcedure, _spParam);


            }
            catch (SqlException dbEx)
            {
                _NroError = dbEx.Number;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                /*  if (_oConn != null)
                  {
                      _oConn.Close();
                      ((IDisposable)_oConn).Dispose();
                  }*/
            }
        }

        public void executeScalar()
        {
            try
            {
                _oConn = common.GetConnexion();

                SqlHelper.ExecuteScalar(_oConn, CommandType.StoredProcedure, _NombreStoredProcedure, _spParam);
            }
            catch (SqlException dbEx)
            {
                _NroError = dbEx.Number;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                /*  if (_oConn != null)
                  {
                      _oConn.Close();
                      ((IDisposable)_oConn).Dispose();
                  }*/
            }

        }
        public void executeReader()
        {
            try
            {
                _oConn = common.GetConnexion();
                SqlHelper.ExecuteReader(_oConn, CommandType.StoredProcedure, _NombreStoredProcedure, _spParam);
            }
            catch (SqlException dbEx)
            {
                _NroError = dbEx.Number;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                /*  if (_oConn != null)
                  {
                      _oConn.Close();
                      ((IDisposable)_oConn).Dispose();
                  }*/
            }

        }

    }
}
