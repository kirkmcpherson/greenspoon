using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenSpoon.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes
        public ActionResult FeaturedRecipe()
        {
            return View("~/Views/Renderers/Components/FeaturedRecipe.cshtml");
        }
    }
}