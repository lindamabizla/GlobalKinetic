using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Common.APIcalls;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;
        public HomeController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            GenericCallsClass call = new GenericCallsClass();

            var response = call.GetAsyncCall(_appSettings.SiteURL, "api/CoinJar/GetAllCoins");

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsAsync<IEnumerable<CoinJarHeaderModel>>().Result;
                return View(data);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostCoinJar(CoinJarHeaderModel model)
        {
            if (ModelState.IsValid)
            {
                GenericCallsClass call = new GenericCallsClass();

                var response = call.PostAsJsonAsyncCall(_appSettings.SiteURL, "api/CoinJar/AddCoin", model);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Changes performed successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string error = response.ReasonPhrase;
                    TempData["Error"] = error;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["Error"] = "Provide vaild amount and volume";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public JsonResult GetAmountDetails()
        {
            GenericCallsClass call = new GenericCallsClass();

            var response = call.GetAsyncCall(_appSettings.SiteURL, "api/CoinJar/GetTotalAmount");
            var data = response.Content.ReadAsStringAsync().Result;
 
            return Json(data);
        }

        [HttpPost]
        public JsonResult RestCoin()
        {
            GenericCallsClass call = new GenericCallsClass();

            var response = call.GetAsyncCall(_appSettings.SiteURL, "api/CoinJar/Reset");
            var data = response.Content.ReadAsStringAsync().Result;

            return Json(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
