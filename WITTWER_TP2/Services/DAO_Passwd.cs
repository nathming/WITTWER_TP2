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

using System.Security.Cryptography;
using System.IO;

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
        
        
        /**********************/
        /** cryptionpassword **/
        /**********************/


        public static byte[] Encrypt(string simpletext/*, byte[] key, byte[] iv*/)
        {
            byte[] EncryptKey = new byte[16] //we will be using the same key and the same inisialisation vector for all the program, because my database wasn't meant to recive these params
            {
                0x01, 0x02, 0x03, 0x04,
                0x05, 0x06, 0x07, 0x08,
                0x09, 0x0A, 0x0B, 0x0C,
                0x0D, 0x0E, 0x0F, 0x10
            };

            byte[] EncryptIv = new byte[16]
            {
                0x11, 0x12, 0x13, 0x14,
                0x15, 0x16, 0x17, 0x18,
                0x19, 0x1A, 0x1B, 0x1C,
                0x1D, 0x1E, 0x1F, 0x20
            };

            byte[] cipheredtext;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(EncryptKey, EncryptIv);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(simpletext);
                        }

                        cipheredtext = memoryStream.ToArray();
                    }
                }
            }
            return cipheredtext;
        }


        public static string Decrypt(byte[] cipheredtext/*, byte[] key, byte[] iv*/)
        {

            byte[] EncryptKey_ = new byte[16] //we will be using the same key and the same inisialisation vector for all the program, because my database wasn't meant to recive these params
            {
                0x01, 0x02, 0x03, 0x04,
                0x05, 0x06, 0x07, 0x08,
                0x09, 0x0A, 0x0B, 0x0C,
                0x0D, 0x0E, 0x0F, 0x10
            };

            byte[] EncryptIv_ = new byte[16]
            {
                0x11, 0x12, 0x13, 0x14,
                0x15, 0x16, 0x17, 0x18,
                0x19, 0x1A, 0x1B, 0x1C,
                0x1D, 0x1E, 0x1F, 0x20
            };

            string simpletext = String.Empty;
            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(EncryptKey_, EncryptIv_);
                using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            simpletext = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return simpletext;
        }

        /****************/


        public async Task<bool> AddItemAsync(string appName, string appPassword, string appUsername /*, string UserId *** because we have only the current user we will stay with the user one in the dtb */)
        {
            using (var client = new HttpClient())
            {
                var data = new
                {
                    AppName = appName,
                    AppPassword = appPassword,
                    AppUsername = appUsername,
                    Icon = "",
                    UserId = 1
                };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                client.Timeout = TimeSpan.FromSeconds(1);
                HttpResponseMessage response = await client.PostAsync("https://wittwer.alwaysdata.net/AddApp", content); //the app is added in the dtb but the app doesn't contunue to run

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return true;
                }

                return false;
                
            }

            
        }


        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = applist.Where((AppModel arg) => arg.Id == id).FirstOrDefault();
            applist.Remove(oldItem);

            return await Task.FromResult(true);
        }


    }
}
