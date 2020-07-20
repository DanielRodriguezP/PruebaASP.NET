using Pueba_ASP.Data.Entidad;
using Pueba_ASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_ASP.Web.Controllers
{
    public class RegionController : Controller
    {
        clsRegionModelo objRegion = new clsRegionModelo();

        // GET: Region
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Municipio
        public JsonResult listar()
        {
            List<clsRegion> _list = objRegion.listar();
            var result = _list.Select(x => new clsRegion
            {
                CodigoR = x.CodigoR,
                Nombre = x.Nombre,
                CodigoM = x.CodigoM,
                NombreM = x.NombreM
            });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult consultarPorId(int codigo)
        {
            return Json(objRegion.listarPorId(codigo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult guardarRegion(clsRegion region)
        {
            return Json(objRegion.guardarRegion(region.Nombre, region.CodigoM), JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarMunicipio()
        {
            List<clsMunicipio> _list = objRegion.listarMunicipio();
            var result = _list.Select(x => new clsMunicipio
            {
                Codigo_Municipio = x.Codigo_Municipio,
                Nombre_Municipio = x.Nombre_Municipio,
            });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Actualizar(clsRegion region)
        {
            return Json(objRegion.actualizarRegion(region.CodigoR, region.Nombre, region.CodigoM), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarRegion(clsRegion region)
        {
            var result = objRegion.EliminarRegion(region.CodigoR, region.CodigoM);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}