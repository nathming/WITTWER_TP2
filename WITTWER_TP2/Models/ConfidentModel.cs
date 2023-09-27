using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace WITTWER_TP2.Models
{

    public class ConfidentModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AppModel
    {
        public string Id { get; set; }
        public string AppName { get; set; }
        public string Icon { get; set; }
        public string AppPassword { get; set; }
        public string AppUsername { get; set; }
        public string UserId { get; set; }
    }



    
}
