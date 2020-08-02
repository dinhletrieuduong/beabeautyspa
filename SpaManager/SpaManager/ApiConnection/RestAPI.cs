using Newtonsoft.Json;
using SpaManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpaManager.ApiConnection
{
    class RestAPI
    {
        public static async Task<LoginResponse> PostLogin(LoginRequest request)
        {
            var login_response = new LoginResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://beabeauty.azurewebsites.net/");
                    client.Timeout = TimeSpan.FromSeconds(10000);

                    var response = new HttpResponseMessage();

                    response = await client.PostAsJsonAsync("/api/auth/register/manually", request).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        login_response = JsonConvert.DeserializeObject<LoginResponse>(result);

                        response.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return login_response;
        }
    }
}
