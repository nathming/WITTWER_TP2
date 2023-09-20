using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WITTWER_TP2.Models;

namespace WITTWER_TP2.Services
{
    public class DAO_Passwd : ConfidentModel
    {

        readonly List<AppModel> applist;

        public DAO_Passwd() 
        {
            /* temporary data */
            applist = new List<AppModel>()
            {
                new AppModel { Id = "0", AppName = "First item", Icon="This is an item description.", AppPassword="passwd1", AppUsername="username1" },
                new AppModel { Id = "1", AppName = "Second item", Icon="This is an item description.", AppPassword="passwd2", AppUsername="username2" },
                new AppModel { Id = "2", AppName = "Third item", Icon="This is an item description.", AppPassword="passwd3", AppUsername="username3" },
                new AppModel { Id = "3", AppName = "Fourth item", Icon="This is an item description.", AppPassword="passwd4", AppUsername="username4" },
                new AppModel { Id = "4", AppName = "Fifth item", Icon="This is an item description.", AppPassword="passwd5", AppUsername="username5" },
                new AppModel { Id = "4", AppName = "Sixth item", Icon="This is an item description.", AppPassword="passwd6", AppUsername="usernam60" }
            };
            /*****************/
            
        }

        public async Task<IEnumerable<AppModel>> GetAppModel(bool forceRefresh = false)
        {
            return await Task.FromResult(applist);
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

    }
}
