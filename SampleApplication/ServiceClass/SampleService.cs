using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SampleApplicationDataModel;

namespace SampleApplicationServiceModel
{
    public class SampleService : SampleApplicationServiceModel.ISampleService
    {
        private readonly string _url = ConfigurationManager.AppSettings["JsonUrl"];

        public ViewModel GetPets()
        {
            ViewModel objViewModel = new ViewModel();
            string genderM = ConfigurationManager.AppSettings["GenderM"].ToString();
            string genderF = ConfigurationManager.AppSettings["GenderF"].ToString(); 
            
            objViewModel.ListFemale = FilterPets(fetchPets(), genderF);
            objViewModel.ListMale = FilterPets(fetchPets(), genderM);
            return objViewModel;
        }

        private List<PersonModel> fetchPets()
        {
            List<PersonModel> objData = new List<PersonModel>();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(_url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                objData = JsonConvert.DeserializeObject<List<PersonModel>>(responseData);
            }

            return objData;

        }

        private List<AnimalModel> FilterPets(List<PersonModel> objPets, string gender)
        {
            objPets.RemoveAll(c => c.Pets == null);

            objPets.RemoveAll(c => c.Gender.ToUpper() != gender.ToUpper());

            var stageList = objPets.SelectMany(b => b.Pets.Select(d => new AnimalModel
            {
                Name = d.Name,
                Type = d.Type
            }

                )).ToList();

            stageList.RemoveAll(x => x.Type.ToUpper() != ConfigurationManager.AppSettings["PetType"].ToString().ToUpper());

            return stageList.OrderBy(p => p.Name).ToList();

        }
        
    }
}
