using Microsoft.AspNetCore.Mvc;
using MVCSession01.Models;

namespace MVCSession01.Controllers
{
    [Route("test")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region Action

        #region Get Products
        //Routing=>BaiseUrl/products/GetProducts
        [HttpGet]
        public JsonResult GetProducts()
        {
            var products = new List<product>() {
            new(){Id=10,Name="Laptop"},
            new(){Id=11,Name="Name"}
            };
            return Json(products);
        }
        #endregion
        #region GetProductsById
        [HttpGet]
        public IActionResult GetProductsById(int Id)
        {
            if (Id < 0)
                return BadRequest();
            else if (Id == 0)
                return RedirectToAction(nameof(Index));
            else if (Id > 10)
                return NotFound();
            else
                return Json(new product() { Id = 11, Name = "Mopile" });
        }
        #endregion
        #region Redirect
        [HttpGet]
        public IActionResult RedirectAction()
        {
            return Redirect("https://docs.google.com/presentation/d/1ZlvjWbt915O8pfymc-9NB4CHOKnzYYWJ/edit?slide=id.p3#slide=id.p3");
        }
        #endregion
        #region Files
        [HttpGet]
        public IActionResult fileAction()
        {
            byte[] filebytes = System.IO.File.ReadAllBytes("wwwroot/files/MVC.pdf");
            return File(filebytes, "app/pdf", "intro.pdf");
        }
        #endregion
        #endregion
        #region Routing
        [HttpGet("json")]
        public IActionResult JsonAction()
        {
            return Json("Hello from json Action");
        }
        [HttpGet("productcode/{code:int}")]
        public IActionResult GetproductByCode(int code)
        {
            return Json(new product { Id = 12, Name = "product01" });
        }
        #endregion
        #region Model Binding
        [HttpGet]
        public IActionResult Search(ProductFilter filter)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetById([FromQuery]int id, [FromQuery(Name ="id2")]int otherId)
        {
            return Json(new { source = "Query", id, otherId });
        }
        #endregion
    }
}
