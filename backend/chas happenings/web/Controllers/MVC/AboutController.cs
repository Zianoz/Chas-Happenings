using chas_happenings.Models.Seo;
using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Controllers.MVC
{
    public class AboutController : Controller
    {

        public IActionResult About()
        {
            SeoConfig.Set(ViewBag, new SeoMeta
            {
                Title = "About Us - My Website",
                Description = "Learn more about our team and mission.",
                Keywords = "about, company, team",

                CanonicalUrl = Url.Action("About", "About", null, Request.Scheme),

                OgImage = Url.Content("~/images/og/about.jpg")
            });

            return View();
        }

    }
}
