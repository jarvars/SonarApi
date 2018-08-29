using Newtonsoft.Json;
using SonarApi.Models;
using SonarApi.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SonarApi.Controllers
{
    public class MetricController : Controller
    {
        string BaseUrl = Resources.BASE_URL;
        string ApiUser = Resources.API_METRIC;

        // GET: Metrics
        public async Task<ActionResult> Metrics()
        {
            List<Metric> metrics = new List<Metric>();
            RootMetrics root = new RootMetrics();
            int count = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(ApiUser);
                
                if (response.IsSuccessStatusCode)
                {
                    var metricResponse = response.Content.ReadAsStringAsync().Result;
                    root = JsonConvert.DeserializeObject<RootMetrics>(metricResponse);
                    foreach (Metric metric in root.Metrics)
                    {
                        metric.row = count ++;
                        metrics.Add(metric);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(metrics);
        }

        //// GET: Metrics/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}            
    }
}
