using Pueba_ASP.Data.Entidad;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json; 

namespace Pueba_ASP.Data.Datos
{
    public class clsMunicipioDatos
    {
        public List<clsMunicipio> listar() {
            clsDatos datos = new clsDatos();
            DataTable resultado = datos.EjecutarWithDataTable("USP_LISTAR_MUNICIPIO");

            List<clsMunicipio> objMunicipio = new List<clsMunicipio>();
            using (DataTable table = resultado) {
                if (table.Rows.Count > 0)
                {
                    objMunicipio = (from item in table.AsEnumerable()
                                    select new clsMunicipio
                                    {
                                        Codigo_Municipio = item.Field<int>("MUNICIPIO"),
                                        Nombre_Municipio = item.Field<string>("NOMBRE_MUNICIPIO").ToString(),
                                        Estado = item.Field<bool>("ESTADO"),
                                        Codigo_Region = item.Field<int>("REGION"),
                                        Nombre_Region = item.Field<string>("NOMBRE_REGION").ToString()
                                    }).ToList();
                }
            }
            return objMunicipio;
        }
        public clsMunicipio listarPorId(int codigo) {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo", codigo);
            DataTable resultado = datos.EjecutarWithDataTable("USP_LISTAR_MUNICIPIO_ID ");
            clsMunicipio objMunicipio = new clsMunicipio();

            using (DataTable table = resultado) {
                if (table.Rows.Count > 0) {
                    objMunicipio.Codigo_Municipio = (int)table.Rows[0]["CODIGO_MUNICIPIO"];
                    objMunicipio.Nombre_Municipio = table.Rows[0]["NOMBRE_MUNICIPIO"].ToString();
                    objMunicipio.Estado = (bool)table.Rows[0]["ESTADO"];
                }
            };
            return objMunicipio;
        }
        public int eliminarMunicipio(int codigo_r, int codigo_m) {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo_r", codigo_r);
            datos.agregarParametro("@codigo_m", codigo_m);
            int resultado = datos.Ejecutar("USP_ELIMINARMUNICIPIO");
            return resultado;
        }
        public int guardarMunicipio(int codigo, string nombre, bool estado, int codigo_R) {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo", codigo);
            datos.agregarParametro("@nombre", nombre);
            datos.agregarParametro("@estado", estado);
            datos.agregarParametro("@region", codigo_R);
            int resultado = datos.Ejecutar("USP_INSERTARMUNICIPIO");
            return resultado;
        }
        public int actualizarMunicipio(int codigo, string nombre, bool estado) {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo", codigo);
            datos.agregarParametro("@nombre", nombre);
            datos.agregarParametro("@estado", estado);
            int resultado = datos.Ejecutar("USP_EDITARMUNICIPIO");
            return resultado;
        }

        public List<clsRegion> listarRegion() {
            clsDatos datos = new clsDatos();
            DataTable resultado = datos.EjecutarWithDataTable("USP_LISTARREGION");
            List<clsRegion> objMunicipio = new List<clsRegion>();
            using (DataTable table = resultado)
            {
                if (table.Rows.Count > 0)
                {
                    objMunicipio = (from item in table.AsEnumerable()
                                    select new clsRegion
                                    {
                                        CodigoR = item.Field<int>("CODIGO_REGION"),
                                        Nombre = item.Field<string>("NOMBRE_REGION").ToString()
                                    }).ToList();
                }
            }
            return objMunicipio;
        }
    }
}

