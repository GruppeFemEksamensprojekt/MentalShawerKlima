using ModelLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MentalShowerConsumer
{
    public class Worker
    {
        string URI = "https://localhost:44367/api/IndoorClimate";
        public async void Start()
        {
            Console.WriteLine(string.Join("\n", GetAllDataAsync().Result));
            int id;
            while (true)
            {
                Console.WriteLine("Vælg ID:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(await GetDataById(id));

            }
        }

        public async Task<IList<SensorDataModel>> GetAllDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI);
                IList<SensorDataModel> cList = JsonConvert.DeserializeObject<IList<SensorDataModel>>(content);
                return cList;
            }
        }

        public async Task<SensorDataModel> GetDataById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync($"{URI}/{id}");
                SensorDataModel data = JsonConvert.DeserializeObject<SensorDataModel>(content);
                return data;
            }
        }







    }
}
