using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pueba_ASP.Data
{
    public class clsDatos
    {
        private Database baseDatos = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(GetObtenerCadenaConexion());
        public IList<DbParameter> Parametros = new List<DbParameter>();

        public void agregarParametro(string nombre, object valor) {
            DbParameter dbParameter = new SqlParameter();
            dbParameter.ParameterName = nombre;
            dbParameter.Value = valor;
            Parametros.Add(dbParameter);
        }
        public int Ejecutar(string procedimiento)
        {
            try
            {
                DbCommand comando = PrepararComando(procedimiento) as DbCommand;
                if (Parametros.Count > 0)
                {
                    foreach (DbParameter param in Parametros)
                    {
                        comando.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                }
                return baseDatos.ExecuteNonQuery(comando);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DataTable EjecutarWithDataTable(string NombreProcedimiento)
        {
            try
            {
                DbCommand comando = PrepararComando(NombreProcedimiento) as DbCommand;
                if (Parametros.Count > 0)
                {
                    foreach (DbParameter param in Parametros)
                    {
                        comando.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                }
                DataTable resultado = baseDatos.ExecuteDataSet(comando).Tables[0];
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        private static string GetObtenerCadenaConexion()
        {
            return "Data Source=(localdb)\\DESKTOP-F4JTOP;Initial Catalog=BDPrueba;Integrated Security=True";
        }

        private IDbCommand PrepararComando(string procedimiento)
        {
            DbCommand comando = baseDatos.GetStoredProcCommand(procedimiento);
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandTimeout = 1000;//int.Parse(ConfigurationManager.AppSettings["TimeoutBD"].ToString());
            return comando;
        }
    }
}
