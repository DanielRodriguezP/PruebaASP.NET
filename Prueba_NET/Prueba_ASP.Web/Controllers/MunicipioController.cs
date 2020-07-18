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
        clsMunicipioModelo obj = new clsMunicipioModelo();
        // GET: Municipio
        public ActionResult Index()
        {
           return View();
        }
        public JsonResult listar() {
             return Json(obj.listar(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult consultarPorId(int codigo)
        {
            clsMunicipioModelo objMunicipio = new clsMunicipioModelo();
            return Json(objMunicipio.listarPorId(codigo), JsonRequestBehavior.AllowGet);
        }
        public JsonResult guardarMunicipio(clsMunicipio municipio) {
            //clsMunicipio datos = new clsMunicipio()
            //{
            //    Codigo_Municipio = municipio.Codigo_Municipio,
            //    Nombre_Municipio = municipio.Nombre_Municipio,
            //    Estado = municipio.Estado,
            //    Codigo_Region = municipio.Codigo_Region,
            //    Nombre_Region = municipio.Nombre_Region
            //};
            return Json(obj.guardarMunicipio(municipio.Codigo_Municipio, municipio.Nombre_Municipio, municipio.Estado, municipio.Codigo_Region), JsonRequestBehavior.AllowGet);
        }
        public JsonResult listarRegion() {
            clsMunicipioModelo obj = new clsMunicipioModelo();
            List<clsRegion> _list = obj.listarRegion();
            var result = _list.Select(x => new clsRegion
            {
                CodigoR = x.CodigoR,
                Nombre = x.Nombre,
            });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Actualizar(clsMunicipio municipio)
        {
            return Json(obj.Actualizar(municipio.Codigo_Municipio, municipio.Nombre_Municipio, municipio.Estado), JsonRequestBehavior.AllowGet);
        }
    }
}