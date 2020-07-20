using Pueba_ASP.Data.Datos;
using Pueba_ASP.Data.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pueba_ASP.Model
{
    public class clsMunicipioModelo
    {
        public List<clsMunicipio> listar() {

            clsMunicipioDatos datos = new clsMunicipioDatos();
            return datos.listar();
        }
        public clsMunicipio listarPorId(int codigo) {

            clsMunicipioDatos datos = new clsMunicipioDatos();
            return datos.listarPorId(codigo);
        }
        public List<clsRegion> listarRegion() {

            clsMunicipioDatos datos = new clsMunicipioDatos();
            return datos.listarRegion();
        }
        public bool guardarMunicipio(int codigo, string nombre, bool estado, int codigo_R) {

            clsMunicipioDatos datos = new clsMunicipioDatos();
            int resulado = datos.guardarMunicipio(codigo, nombre,estado,codigo_R);
            if (resulado > 0) return true;return false;
        }
        public bool Actualizar(int codigo, string nombre, bool estado, int codigoR) {
            clsMunicipioDatos datos = new clsMunicipioDatos();
            int resultado =  datos.actualizarMunicipio(codigo,nombre,estado, codigoR);
            if (resultado > 0) return true; return false;
        }
        public bool EliminarMunicipio(int codigo_r, int codigo_m) {
            clsMunicipioDatos datos = new clsMunicipioDatos();
            int resultado = datos.eliminarMunicipio(codigo_r,codigo_m);
            if (resultado > 0) return true; return false;
        }
    }
}
