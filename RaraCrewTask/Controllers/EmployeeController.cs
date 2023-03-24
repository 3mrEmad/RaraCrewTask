using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaraCrewTask.Business;
using RaraCrewTask.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaraCrewTask.Controllers
{
    public class EmployeeController : Controller
    {

        businessLogic logic = new businessLogic();


   public async Task<IActionResult> Index()
   {
     using var client = new HttpClient();
     string URL = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
     var result = await client.GetAsync(URL);  
     var EmployeeData = result.Content.ReadAsStringAsync().Result;
     var model = JsonConvert.DeserializeObject<List<Employee>>(EmployeeData) ;       
     var emps = logic.FilterEmployeesByName(model);
            ViewBag.res = emps.OrderByDescending(e => e.TimeWorked);
     return View();

    }



       public async Task<IActionResult> DispalyChart()
        {
       using var client = new HttpClient();
       string URL = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
       var result = await client.GetAsync(URL);
       var EmployeeData = result.Content.ReadAsStringAsync().Result;
       var model = JsonConvert.DeserializeObject<List<Employee>>(EmployeeData);
       var emps = logic.FilterEmployeesByName(model);
       return View(emps);

        }

    }
}
