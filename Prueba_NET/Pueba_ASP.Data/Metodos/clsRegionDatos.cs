using Pueba_ASP.Data.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pueba_ASP.Data.Metodos
{
    public class clsRegionDatos
    {
        public List<clsRegion> listar()
        {
            clsDatos datos = new clsDatos();
            DataTable resultado = datos.EjecutarWithDataTable("USP_LISTAR_REGION");

            List<clsRegion> objRegion = new List<clsRegion>();
            using (DataTable table = resultado)
            {
                if (table.Rows.Count > 0)
                {
                    objRegion = (from item in table.AsEnumerable()
                                    select new clsRegion
                                    {
                                        CodigoR = item.Field<int>("REGION"),
                                        Nombre = item.Field<string>("NOMBRE_REGION").ToString(),
                                        CodigoM = item.Field<int>("MUNICIPIO"),
                                        NombreM = item.Field<string>("NOMBRE_MUNICIPIO"),
                                        
                                    }).ToList();
                }
            }
            return objRegion;
        }
        public clsRegion listarPorId(int codigo)
        {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo", codigo);
            DataTable resultado = datos.EjecutarWithDataTable("USP_LISTAR_REGION_ID ");
            clsRegion objRegion = new clsRegion();

            using (DataTable table = resultado)
            {
                if (table.Rows.Count > 0)
                {
                    objRegion.CodigoR = (int)table.Rows[0]["CODIGO_REGION"];
                    objRegion.Nombre = table.Rows[0]["NOMBRE_REGION"].ToString();
                }
            };
            return objRegion;
        }
        public int eliminarRegion(int codigo_r, int codigo_m)
        {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo_r", codigo_r);
            datos.agregarParametro("@codigo_m", codigo_m);
            int resultado = datos.Ejecutar("USP_ELIMINARREGION");
            return resultado;
        }
        public int guardarRegion(string nombre, int codigoM)
        {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@nombre", nombre);
            datos.agregarParametro("@municipio", codigoM);
            int resultado = datos.Ejecutar("USP_INSERTAREGION");
            return resultado;
        }
        public int actualizarRegion(int codigo, string nombre, int codigoM)
        {
            clsDatos datos = new clsDatos();
            datos.agregarParametro("@codigo", codigo);
            datos.agregarParametro("@nombre", nombre);
            datos.agregarParametro("@codigoM", codigoM);
            int resultado = datos.Ejecutar("USP_EDITARREGION");
            return resultado;
        }

        public List<clsMunicipio> listarMunicipio()
        {
            clsDatos datos = new clsDatos();
            DataTable resultado = datos.EjecutarWithDataTable("USP_LISTARMUNICIPIO");
            List<clsMunicipio> objMunicipio = new List<clsMunicipio>();
            using (DataTable table = resultado)
            {
                if (table.Rows.Count > 0)
                {
                    objMunicipio = (from item in table.AsEnumerable()
                                    select new clsMunicipio
                                    {
                                        Codigo_Municipio = item.Field<int>("CODIGO_MUNICIPIO"),
                                        Nombre_Municipio = item.Field<string>("NOMBRE_MUNICIPIO").ToString()
                                    }).ToList();
                }
            }
            return objMunicipio;
        }
    }
}
