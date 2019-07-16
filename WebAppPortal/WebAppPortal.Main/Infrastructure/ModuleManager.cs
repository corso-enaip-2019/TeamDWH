using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using WebAppPortal.Contracts;
using WebAppPortal.Main.Models;

namespace WebAppPortal.Main.Infrastructure
{
    public class ModuleManager
    {

        public List<ModuleStatusModel> Modules;

        private Timer _updater;

        static ModuleManager()
        {
            Instance = new ModuleManager();
        }
        public static ModuleManager Instance { get; }

        private ModuleManager()
        {
            Modules = new List<ModuleStatusModel>();
            _updater = new Timer
            {
                Interval = 1000, 
                AutoReset = true
            };
            _updater.Elapsed += (s, e) => UpdateStatuses();
            _updater.Start();
        }

        // aggiorna gli stati di ciascun modulo
        public async void UpdateStatuses()
        {
            for (int i = 0; i < Modules.Count; i++)
            {
                try
                {
                    var moduleInfo = await GetModuleInfo(Modules[i].Url);
                    Modules[i] = new ModuleStatusModel(moduleInfo, Modules[i].Url);
                }
                catch (Exception e)
                {
                    Modules[i].IsAlive = false;
                    Modules[i].ErrorMessage = e.Message;
                }
            }
        }

        //questo metodo fa una richiesta http get al singolo modulo per verificare se è vivo e richiederne le informazioni
        public async Task<ModuleInfo> GetModuleInfo(string moduleUrl)
        {
            HttpClient client = new HttpClient(new HttpClientHandler
            {
                UseDefaultCredentials = true
            });

            var response = await client.GetAsync(moduleUrl + "api/getinfo");

            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}: {responseString}");

            return JsonConvert.DeserializeObject<ModuleInfo>(responseString);
        }
    }
}