using Newtonsoft.Json;
using SitefinityWebApp.Data;
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "HomepageCarousel", Title = "Homepage Carousel", SectionName = "MVC")]
    public class HomepageCarouselController : Controller
    {
        // GET: HomepageCarousel
        public string ImageGalleryId { get; set; }
        private Guid _imageGalleryId;
        public ActionResult Index()
        {
            List<HomepageCarouselModel> model = GetModel();
            return View(model);
        }
        private List<HomepageCarouselModel> GetModel()
        {
            List<HomepageCarouselModel> model = new List<HomepageCarouselModel>();
            if (!ImageGalleryId.IsNullOrEmpty())
            {
                _imageGalleryId = new Guid(ImageGalleryId);
                model = ImageLibraryRepo.GetHomepageCarouselItems(_imageGalleryId);
            }
            return model;
        }
    }
}