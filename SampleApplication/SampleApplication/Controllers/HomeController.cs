using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using SampleApplicationDataModel;
using SampleApplicationServiceModel;


namespace SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        private ISampleService sampleService;

        public HomeController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            var viewModel = new ViewModel();
            viewModel.ListMale = sampleService.fetchPets("M");
            viewModel.ListFemale = sampleService.fetchPets("F");
            return View(viewModel);
        }
       
    }
}
