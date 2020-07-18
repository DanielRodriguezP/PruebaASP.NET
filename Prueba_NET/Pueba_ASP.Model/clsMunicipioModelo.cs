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

            clsMunicipio objMunicipio = new clsMunicipio();
            clsMensajes mensaje = new clsMensajes();
            clsMunicipioDatos datos = new clsMunicipioDatos();
            List<clsMunicipio> result = datos.listar();
            try
            {
                if (result.Count > 0)
                {
                    objMunicipio.Mensaje = "Se listo el registro correctamente.";
                }
                else
                {
                    objMunicipio.Mensaje = "No se listo el registro correctamente.";
                }
            }
            catch (Exception)
            {
               objMunicipio.Mensaje = "Error al realizar la consulta, comuníquese con el administrador.";
            }
           
            return result;
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
            clsMunicipio objMunicipio = new clsMunicipio();
            clsMensajes mensaje = new clsMensajes();
            int resulado = datos.guardarMunicipio(codigo, nombre,estado,codigo_R);
            if (resulado > 0) {
                objMunicipio.Mensaje = "se guardo corectamente la informacion";
                return true;
            }
            return false;
        }
        public bool Actualizar(int codigo, string nombre, bool estado) {
            clsMunicipioDatos datos = new clsMunicipioDatos();
            int resultado =  datos.actualizarMunicipio(codigo,nombre,estado);
            if (resultado > 0) return true; return false;
        }
    }
}
