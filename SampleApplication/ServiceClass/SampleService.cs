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

namespace SampleApplicationServiceModel
{
    public class SampleService : SampleApplicationServiceModel.ISampleService
    {
        private string URL = ConfigurationManager.AppSettings["JsonUrl"].ToString();

        private List<PersonModel> fetchPets()
        {
            List<PersonModel> objData = new List<PersonModel>();
            HttpClient client = new HttpClient();
           
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                objData = JsonConvert.DeserializeObject<List<PersonModel>>(responseData);
            }

            return objData;

        }

        public ViewModel GetPets()
        {
            ViewModel objViewModel = new ViewModel();
            string genderM = ConfigurationManager.AppSettings["GenderM"].ToString();
            string genderF = ConfigurationManager.AppSettings["GenderF"].ToString(); 
            
            objViewModel.ListFemale = FilterPets(fetchPets(), genderF);
            objViewModel.ListMale = FilterPets(fetchPets(), genderM);
            return objViewModel;
        }

        private List<animalModel> FilterPets(List<PersonModel> objPets, string gender)
        {
            List<animalModel> petList = new List<animalModel>();

            objPets.RemoveAll(c => c.pets == null);

            objPets.RemoveAll(c => c.gender.ToUpper() != gender.ToUpper());

            var stageList = objPets.SelectMany(b => b.pets.Select(d => new animalModel
            {
                name = d.name,
                type = d.type
            }

                )).ToList();

            stageList.RemoveAll(x => x.type.ToUpper() != ConfigurationManager.AppSettings["PetType"].ToString().ToUpper());

            petList = stageList.OrderBy(p => p.name).ToList();

            return petList;
        }
        
    }
}
