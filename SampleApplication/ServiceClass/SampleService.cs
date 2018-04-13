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
        
        //List<animal> animalInfoFemale = new List<animal>();

        public List<animal> fetchPets(string gender)
        {
            List<animal> objFinal = new List<animal>();
            //IEnumerable<animal> objList;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                List<Person> obj = JsonConvert.DeserializeObject<List<Person>>(responseData);
                objFinal = FilterList(obj, gender);
                //objList = objFinal.OrderBy(x => x.name).ToList().AsEnumerable();
                //FilterListFemale(obj);

                //Person owner_list = new Person();
                //obj.RemoveAll(c => c.pets == null);

                //var flatList = obj.SelectMany(b => b.pets.Select(p => new animal
                //{
                    
                //    name = p.name,
                //    type = p.type
                //}

                //    )).ToList();
                //flatList.RemoveAll(c => c.type.ToUpper() != ConfigurationManager.AppSettings["PetType"].ToString().ToUpper());
                //owner_list.pets = flatList.OrderBy(c => c.name).ToList();
                //return owner_list; 
            }
            return objFinal;
        }


        private List<animal> FilterList(List<Person> objPerson, string s)
        {
            List<animal> animalInfo = new List<animal>();
            foreach (Person person in objPerson)
            {
                if (person.pets != null)
                {
                    foreach (animal animal in person.pets)
                    {
                        if (animal.type.ToUpper() == ConfigurationManager.AppSettings["PetType"].ToString().ToUpper())
                        {
                            if (s == "M")
                            {
                                if (person.gender.ToUpper() == ConfigurationManager.AppSettings["Gender1"].ToString().ToUpper())
                                    animalInfo.Add(animal);
                            }
                            else
                            {
                                if (person.gender.ToUpper() == ConfigurationManager.AppSettings["Gender2"].ToString().ToUpper())
                                    animalInfo.Add(animal);
                            }

                        }

                    }

                }
            }
            return animalInfo;
        }

    

    }
}
