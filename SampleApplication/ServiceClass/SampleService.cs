using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using SampleApplicationDataModel;
using Newtonsoft.Json;
using System.Configuration;
using NLog;

namespace SampleApplicationServiceModel
{
    public class SampleService : SampleApplicationServiceModel.ISampleService
    {
        public string URL = ConfigurationManager.AppSettings["JsonUrl"].ToString();
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public List<animalModel> fetchPets(string gender)
        {
            List<animalModel> objFinal = new List<animalModel>();
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(URL);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(URL).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    objFinal = GetPets(responseData, gender);

                }

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Info, ex.Message); 
            }

            return objFinal;

        }

        public List<animalModel> GetPets(string jsonData, string gender)
        {
            List<animalModel> petList = new List<animalModel>();
            try
            {
                List<PersonModel> obj = JsonConvert.DeserializeObject<List<PersonModel>>(jsonData);
                string genderM = ConfigurationManager.AppSettings["GenderM"].ToString();
                string genderF = ConfigurationManager.AppSettings["GenderF"].ToString(); 
                obj.RemoveAll(c => c.pets == null);
                if (gender == genderM)
                {
                    obj.RemoveAll(c => c.gender.ToUpper() != genderM.ToUpper());
                }
                else
                {
                    obj.RemoveAll(c => c.gender.ToUpper() != genderF.ToUpper());
                }

                var stageList = obj.SelectMany(b => b.pets.Select(d => new animalModel
                {
                    name = d.name,
                    type = d.type
                }

                    )).ToList();

                stageList.RemoveAll(x => x.type.ToUpper() != ConfigurationManager.AppSettings["PetType"].ToString().ToUpper());
                petList = stageList.OrderBy(p => p.name).ToList();


            }
            catch (Exception ex)
            {

                logger.Log(LogLevel.Info, ex.Message); 
            }
            return petList;
        }
    }
}
