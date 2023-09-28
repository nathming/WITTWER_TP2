using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WITTWER_TP2.Models;

using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace WITTWER_TP2.Services
{
    public class DAO_Passwd : ConfidentModel
    {

        readonly List<AppModel> applist;

        public DAO_Passwd() 
        {
            applist = new List<AppModel>();

        }

        public async Task<List<AppModel>> GetAllApp()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://wittwer.alwaysdata.net/getAllApp");
            if (response.IsSuccessStatusCode)
            {
                var AppListReturn = await response.Content.ReadAsStringAsync();
                List<AppModel> result = JsonConvert.DeserializeObject<List<AppModel>>(AppListReturn);

                return result;
            }
            else
            {
                return null;
            }
        }
        //sur add bien mettee foreign kex a 1

        public async Task<IEnumerable<AppModel>> AddAppTaskFunction(string appname, string username, string password, int UserId)
        {
            UserId = 1;
            HttpClient client = new HttpClient();

            return null;
        }



        public async Task<bool> AddItemAsync(AppModel app)
        {
            applist.Add(app);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = applist.Where((AppModel arg) => arg.Id == id).FirstOrDefault();
            applist.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<AppModel>> GetAppModel(bool forceRefresh = false)
        {
            return await Task.FromResult(applist);
        }
    }
}
