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
        private ISampleService sampleService;
        private ILogError logger;        
        private string genderM = ConfigurationManager.AppSettings["GenderM"].ToString();
        private string genderF = ConfigurationManager.AppSettings["GenderF"].ToString();

        public HomeController(ISampleService sampleService, ILogError logger)
        {
            this.sampleService = sampleService;
            this.logger = logger;
        }

        public ViewResult Index()
        {
            ViewModel objModel = new ViewModel();
            try
            {
                return View(sampleService.GetPets());
            }
            catch (Exception ex)
            {
                logger.WriteEventLogEntry(ex.Message);
                return View(objModel);
            }
        }

        
    }
}
