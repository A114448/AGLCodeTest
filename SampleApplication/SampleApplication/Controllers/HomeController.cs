using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using SampleApplicationDataModel;
using SampleApplicationServiceModel;
using System.Configuration;
using NLog;

namespace SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        private ISampleService sampleService;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public string genderM = ConfigurationManager.AppSettings["GenderM"].ToString();            
        public string genderF = ConfigurationManager.AppSettings["GenderF"].ToString(); 

        public HomeController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        public ViewResult Index()
        {
            var viewModel = new ViewModel();            

            try
            {
                viewModel.ListMale = sampleService.fetchPets(genderM);
                viewModel.ListFemale = sampleService.fetchPets(genderF);
                
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.Message);
            }

            return View(viewModel);
        }

       
    }
}
