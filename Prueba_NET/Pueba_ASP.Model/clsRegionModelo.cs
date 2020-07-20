using Pueba_ASP.Data.Entidad;
using Pueba_ASP.Data.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pueba_ASP.Model
{
    public class clsRegionModelo
    {
        public List<clsRegion> listar()
        {
            clsRegionDatos datos = new clsRegionDatos();
            return datos.listar();
        }
        public clsRegion listarPorId(int codigo)
        {
            clsRegionDatos datos = new clsRegionDatos();
            return datos.listarPorId(codigo);
        }
        public List<clsMunicipio> listarMunicipio()
        {
            clsRegionDatos datos = new clsRegionDatos();
            return datos.listarMunicipio();
        }
        public bool guardarRegion(string nombre, int codigoM)
        {
            clsRegionDatos datos = new clsRegionDatos();
            int resultado = datos.guardarRegion(nombre, codigoM);
            if (resultado > 0) return true; return false;

        }
        public bool actualizarRegion(int codigo, string nombre, int codigoM)
        {
            clsRegionDatos datos = new clsRegionDatos();
            int resultado = datos.actualizarRegion(codigo, nombre, codigoM);
            if (resultado > 0) return true; return false;
        }
        public bool EliminarRegion(int codigo_r, int codigo_m)
        {
            clsRegionDatos datos = new clsRegionDatos();
            int resultado = datos.eliminarRegion(codigo_r, codigo_m);
            if (resultado > 0) return true; return false;
        }
    }
}
