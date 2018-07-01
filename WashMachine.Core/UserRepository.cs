using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WashMachine.Core.Models;

namespace WashMachine.Core
{
    public class UserRepository : IUserRepository
    {
        private static String DB_NAME = "washmachinedb";
        private static String COLLECTION_NAME = "users";
        private static String API_KEY = "Vl7CbpNc3ssDbu4GB-LeH2xlIpRlyX8u";
        private static String BASE_URL = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{COLLECTION_NAME}?apiKey={API_KEY}";

        public async Task AddUser(User user)
        {
            using(var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    BASE_URL,
                    new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetStringAsync(BASE_URL);
                var users = JsonConvert.DeserializeObject<List<User>>(response);
                var user = users.FirstOrDefault(i => i.Email.Equals(email));
                return user;
            }
        }
    }
}
