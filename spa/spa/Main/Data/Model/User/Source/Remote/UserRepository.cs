using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserRepository : IUserDataSource
    {
        private UserRepository userRemote;

        private static UserRepository instance;
        private UserService userService;

        private UserRepository(UserService userService)
        {
            this.userService = userService;
        }
        private UserRepository(UserRepository userRemote)
        {
            this.userRemote = userRemote;
        }
        public static UserRepository GetInstance(UserService userService)
        {
            if (instance == null)
            {
                instance = new UserRepository(userService);
            }
            return instance;
        }

        public Dictionary<int, string> Login(User user, bool isLoginBySocial)
        {
            var response = isLoginBySocial ? userService.LoginSocial(user.fbToken) : userService.LoginManual(user);
            //var response = userService.LoginManual(user);
            Dictionary<int, string> resp = new Dictionary<int, string>();
            string message = "";
            try
            {
                response.Wait();
                int statusCode = string.IsNullOrEmpty(response.Result.token) ? 400 : 200;
                message = response.Result.token;
                resp.Add(statusCode, message);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                if (e.Message.Contains("400"))
                    resp.Add(400, message);
                else
                    resp.Add(500, message);
                return resp;
            }
        }

        public Dictionary<int, string> Register(User user, bool isSignupBySocial)
        {
            var response = isSignupBySocial ? userService.LoginSocial(user.fbToken) : userService.RegisterManual(user);
            Dictionary<int, string> resp = new Dictionary<int, string>();
            string message = "";

            try
            {
                response.Wait();

                message = response.Result.token;
                int statusCode;
                if (response.Result.message.Contains("successful"))
                {
                    statusCode = 200;
                }
                else
                {
                    statusCode = 400;
                    message += ",Username exists";
                }

                resp.Add(statusCode, message);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                int statusCode = e.Message.Contains("failed") ? 400 : 500;

                resp.Add(statusCode, message);
                return resp;
            }
        }

        public Dictionary<int, string> Verify(User user)
        {
            var response = userService.Verify(user);
            Dictionary<int, string> resp = new Dictionary<int, string>();
            string token = "";
            try
            {
                response.Wait();
                token = response.Result.token;
                //int statusCode = string.IsNullOrEmpty(token) ? 500 : 200;
                //if (statusCode == 200)
                //    token = content;
                resp.Add(200, token);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                if (e.Message.Contains("401"))
                    resp.Add(401, token);
                else
                    resp.Add(500, token);
                return resp;
            }
        }

        public User GetProfile(string token)
        {
            var response = userService.GetProfile(token);
            try
            {
                response.Wait();
                User user = new User(response.Result);
                return user;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                return null;
            }
        }

        public HealthInfor GetHealthInformation(string token)
        {
            var response = userService.GetHealthInfor(token);
            //string token = "";

            try
            {
                response.Wait();
                HealthInfor healthInfor = new HealthInfor(response.Result);
                return healthInfor;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                return null;
            }
        }

        public Dictionary<int, string> UpdateHealthInformation(HealthInfor user, string token)
        {
            var response = userService.UpdateHealthInfor(user, token);
            Dictionary<int, string> resp = new Dictionary<int, string>();

            try
            {
                response.Wait();
                return resp;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                resp.Add(500, token);
                return resp;
            }
        }
    }
}
