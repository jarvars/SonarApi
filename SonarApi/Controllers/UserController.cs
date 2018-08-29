using Newtonsoft.Json;
using SonarApi.Models;
using SonarApi.Properties;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SonarApi.Controllers
{
    public class UserController : Controller
    {        
        public async Task<ActionResult> Users()
        {
            List<User> users = new List<User>();
            RootUsers ro = new RootUsers();
            Paging paging = new Paging();

            var BaseUrl = Resources.BASE_URL;
            var ApiUser = Resources.API_USER;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(ApiUser);

                //var response = client.GetAsync(ApiUser).Result;                
                //var result = responseTask.Result;

                if (response.IsSuccessStatusCode)
                {
                    var userResponse = response.Content.ReadAsStringAsync().Result;
                    ro = JsonConvert.DeserializeObject<RootUsers>(userResponse);
                    foreach (User userItem in ro.users)
                    {
                        users.Add(userItem);                        
                    }
                }
                else
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(users);
        }
    }
}