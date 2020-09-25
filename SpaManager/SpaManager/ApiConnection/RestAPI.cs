using Newtonsoft.Json;
using SpaManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.IO;

namespace SpaManager.ApiConnection
{
    class RestAPI
    {
        //Get HttpClient with none token
        private static HttpClient Get_HttpClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://beabeautyspazzz.azurewebsites.net/");

            client.Timeout = TimeSpan.FromSeconds(10000);

            return client;
        }

        //Get HttpClient was added token in header
        private static HttpClient Get_HttpClient_Token()
        {
            HttpClient client = new HttpClient();

            client = RestAPI.Get_HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResponse.access_token);

            return client;

        }

        //Method post send login resquest and receive response contain access token
        public static async Task<LoginResponse> PostLogin(LoginRequest request)
        {
            var login_response = new LoginResponse();
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient();
                
                    
                var response = new HttpResponseMessage();

                response =  await client.PostAsJsonAsync("/api/auth/login/manually", request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    login_response = JsonConvert.DeserializeObject<LoginResponse>(result);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return login_response;
        }

        public static async Task<bool> PostActiveOutlet(string outlet_id)
        {
            string api = "/api/outlet/" + outlet_id + "/active";
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();


                var response = new HttpResponseMessage();

                response = await client.PostAsync(api,null).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static async Task<bool> PostDeactiveOutlet(string outlet_id)
        {
            string api = "/api/outlet/" + outlet_id + "/deactive";
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();


                var response = new HttpResponseMessage();

                response = await client.PostAsync(api,null).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Method HttpDelete use to delete one service
        public static async Task<bool> PostDeleteService(DelServiceRequest request)
        {
            string api = "/api/service/" + request.service_id.ToString();
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();
                
                    
                var response = new HttpResponseMessage();

                response = await client.DeleteAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        //Method HttpDelete use to delete bed
        public static async Task<bool> PostDeleteBed(string bed_id)
        {
            string api = "/api/bed/" + bed_id;
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();


                var response = new HttpResponseMessage();

                response = await client.DeleteAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Method HttpDelete use to delete room
        public static async Task<bool> PostDeleteRoom(string room_id)
        {
            string api = "/api/Room/" + room_id;
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();


                var response = new HttpResponseMessage();

                response = await client.DeleteAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Method Post use to block/unblock one account
        public static async Task<bool> PostBlock(AccountBlock request,string title)
        {
            string url = "/api/account/" + title;
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                    

                var response = new HttpResponseMessage();

                response = await client.PostAsJsonAsync(url, request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Method Post use to delete one account
        public static async Task<bool> PostDeleteAccount(string account_id)
        {
            string url = "/api/account/" + account_id;
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();
                
                    

                var response = new HttpResponseMessage();

                response = await client.DeleteAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Method Post use to delete one outlet
        public static async Task<bool> PostDeleteOutlet(DelOutletRequest request)
        {
            
            string api = "/api/outlet/" + request.outlet_id.ToString();

            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();

                
                var response = new HttpResponseMessage();

                response = await client.DeleteAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //Method Post use to active/de-active one service
        public static async Task<bool> PostServiceHandle(DeactiveRequest request, string handle)
        {
            string api = "/api/service/" + handle;
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();
                
                var response = new HttpResponseMessage();

                response = await client.PostAsJsonAsync(api, request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //Method Get use to get all outlet
        public static async Task<List<Outlet_DTO>> GetOulet()
        {
            List<Outlet_DTO> list = new List<Outlet_DTO>();

            try
            {

                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();

                     
                var response = new HttpResponseMessage();

                response = await client.GetAsync("/api/outlet").ConfigureAwait(false);

                if(response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    list = JsonConvert.DeserializeObject<List<Outlet_DTO>>(result);

                    response.Dispose();

                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        //Method Get use to get all service
        public static async Task<List<Service_DTO>> GetService()
        {
            List<Service_DTO> list = new List<Service_DTO>();

            string token = LoginResponse.access_token;

            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.GetAsync("/api/service/all").ConfigureAwait(false);

                if(response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<Service_DTO>>(result);

                    response.Dispose();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        public static async Task<Service_DTO> GetServiceDetail(string service_id)
        {
            Service_DTO service = new Service_DTO();

            string api = "/api/service/" + service_id;
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.GetAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    service = JsonConvert.DeserializeObject<Service_DTO>(result);

                    response.Dispose();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return service;
        }

        public static async Task<List<Appointment_DTO>> GetAppointment()
        {
            List<Appointment_DTO> appt = new List<Appointment_DTO>();

            string api = "/api/appt/all";
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.GetAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    appt = JsonConvert.DeserializeObject<List<Appointment_DTO>>(result);

                    response.Dispose();

                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return appt;
        }

        //Method Get use to get all account
        public static async Task<List<User_DTO>> GetAccount()
        {
            List<User_DTO> list = new List<User_DTO>();

           
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.GetAsync("/api/account/all").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<User_DTO>>(result);

                    response.Dispose();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        //Method Get use to get all service contained in one Outlet
        public static async Task<List<Service_DTO>> GetServiceOutlet(string outlet_id)
        {
            List<Service_DTO> list = new List<Service_DTO>();

            string api = "/api/outlet/" + outlet_id+"/service";

            
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();


                var response = new HttpResponseMessage();

                response = await client.GetAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    list = JsonConvert.DeserializeObject<List<Service_DTO>>(result);

                    response.Dispose();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        //Method HttpGet use to get all room type name in database
        public static async Task<List<RoomTypeResponse>> GetRoomType()
        {
            List<RoomTypeResponse> list = new List<RoomTypeResponse>();

            string api = "/api/Room/type";

            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();


                var response = new HttpResponseMessage();

                response = await client.GetAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    list = JsonConvert.DeserializeObject<List<RoomTypeResponse>>(result);

                    response.Dispose();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        //Method Get use to get all room contained in outlet
        public static async Task<List<Room_DTO>> GetRoom(string outlet_id)
        {
            List<Room_DTO> list = new List<Room_DTO>();

            string api = "/api/outlet/" + outlet_id + "/room";

           
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.GetAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    list = JsonConvert.DeserializeObject<List<Room_DTO>>(result);

                    response.Dispose();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        //Method Get use to get all bed contained in the room
        public static async Task<List<Bed_DTO>> GetBed(string room_id)
        {
            List<Bed_DTO> list = new List<Bed_DTO>();

            string api = "/api/room/" + room_id + "/bed";

            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.GetAsync(api).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    list = JsonConvert.DeserializeObject<List<Bed_DTO>>(result);

                    response.Dispose();
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }
        
        //Method Post use to create one service
        public static async Task<bool> CreateService(ServiceResquest request)
        {
            
            try
            {
                HttpClient client = new HttpClient();

                client = RestAPI.Get_HttpClient_Token();
                
                MultipartFormDataContent form = new MultipartFormDataContent();


                form.Add(new StreamContent(new MemoryStream(request.filePhoto)), "file", Path.GetFileName(request.pathPhoto));
                form.Add(new StringContent(request.service_name), "service_name");
                form.Add(new StringContent(request.service_description), "service_description");
                form.Add(new StringContent(request.service_duration), "service_duration");
                form.Add(new StringContent(request.service_transit), "service_transit");
                form.Add(new StringContent(request.service_cost), "service_cost");
                
                var response = new HttpResponseMessage();

                response = await client.PostAsync("/api/service", form);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
            
        }

        //Method Post use to create one outlet
        public static async Task<bool> CreateOutlet(OutletRequest request)
        {
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();
         
                MultipartFormDataContent form = new MultipartFormDataContent();

                form.Add(new StreamContent(new MemoryStream(request.filePhoto)), "file", Path.GetFileName(request.pathPhoto));
                form.Add(new StringContent(request.outletName), "outlet_name");
                form.Add(new StringContent(request.outletAddress), "outlet_address");
                   

                var response = new HttpResponseMessage();

                response = await client.PostAsync("/api/outlet", form);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> CreateRoom(RoomRequest request)
        {
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.PostAsJsonAsync("/api/Room", request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> CreateBed(BedRequest request)
        {
            try
            {
                HttpClient client = new HttpClient();
                client = RestAPI.Get_HttpClient_Token();

                var response = new HttpResponseMessage();

                response = await client.PostAsJsonAsync("/api/bed", request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
