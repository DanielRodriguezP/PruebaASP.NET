using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_ASP.Web;
using Pueba_ASP.Data.Entidad;
using Pueba_ASP.Model;

namespace Prueba_ASP.Web.Controllers
{
    public class MunicipioController : Controller
    {
        clsMunicipioModelo objMunicipio = new clsMunicipioModelo();
        // GET: Municipio
        public ActionResult Index()
        {
           return View();
        }

        public JsonResult listar() {
            List<clsMunicipio> _list = objMunicipio.listar();
            var result = _list.Select(x => new clsMunicipio
            {
                Codigo_Municipio = x.Codigo_Municipio,
                Nombre_Municipio = x.Nombre_Municipio,
                Estado = x.Estado,
                Codigo_Region = x.Codigo_Region,
                Nombre_Region = x.Nombre_Region
            });
            return Json(new { data = result}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult consultarPorId(int codigo)
        {
            return Json(objMunicipio.listarPorId(codigo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult guardarMunicipio(clsMunicipio municipio) {

            return Json(objMunicipio.guardarMunicipio(municipio.Codigo_Municipio, municipio.Nombre_Municipio, municipio.Estado, municipio.Codigo_Region), JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarRegion() {
            List<clsRegion> _list = objMunicipio.listarRegion();
            var result = _list.Select(x => new clsRegion
            {
                CodigoR = x.CodigoR,
                Nombre = x.Nombre,
            });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Actualizar(clsMunicipio municipio)
        {
            return Json(objMunicipio.Actualizar(municipio.Codigo_Municipio, municipio.Nombre_Municipio, municipio.Estado, municipio.Codigo_Region), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarMunicipio(clsMunicipio datos)
        {
            var result = objMunicipio.EliminarMunicipio(datos.Codigo_Region, datos.Codigo_Municipio);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}