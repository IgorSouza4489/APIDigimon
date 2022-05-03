using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVCDigimon.Controllers
{
    public class DigimonController : Controller
    {
       public static string baseUrl = "https://digimon-api.herokuapp.com/api/digimon";

        // GET: DigimonController
        public async Task<ActionResult> Index()
        {
            var digimons = await Digimons();
            return View(digimons);
        }

        [HttpGet]
        public async Task<List<Digimon>> Digimons()
        {
            // Use the access token to call a protected web API.
            var accessToken = HttpContext.Session.GetString("JWToken");
            var url = baseUrl;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string jsonStr = await client.GetStringAsync(url);

            var res = JsonConvert.DeserializeObject<List<Digimon>>(jsonStr).ToList();

            return res;

        }

        // GET: DigimonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DigimonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DigimonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DigimonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DigimonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DigimonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DigimonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
