using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using SampleApplicationDataModel;
using SampleApplicationServiceModel;
using System.Configuration;

namespace SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogError _logger;
        private readonly ISampleService _sampleService;

        public HomeController(ISampleService sampleService, ILogError logger)
        {
            _sampleService = sampleService;
            _logger = logger;
        }

        public ViewResult Index()
        {
            var objModel = new ViewModel();
            try
            {
                return View(_sampleService.GetPets());
            }
            catch (Exception ex)
            {
                _logger.WriteEventLogEntry(ex.Message);
                return View(objModel);
            }
        }

        
    }
}
