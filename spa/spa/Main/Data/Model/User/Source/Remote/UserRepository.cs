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
            var response = isLoginBySocial ? userService.LoginSocial(user) : userService.LoginManual(user);
            //var response = userService.LoginManual(user);
            Dictionary<int, string> resp = new Dictionary<int, string>();
            string message = "";
            try
            {
                response.Wait();
                int statusCode = string.IsNullOrEmpty(response.Result.token) ? 404 : 200;
                message = response.Result.token;
                resp.Add(statusCode, message);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                if (e.Message.Contains("404"))
                    resp.Add(404, message);
                else
                    resp.Add(500, message);
                return resp;
            }
        }

        public Dictionary<int, string> Register(User user, bool isSignupBySocial)
        {
            var response = isSignupBySocial ? userService.RegisterSocial(user) : userService.RegisterManual(user);
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

        public Dictionary<int, string> ProvideInfor(UserInfor userInfo)
        {
            var response = userService.ProvideInfor(userInfo);
            Dictionary<int, string> resp = new Dictionary<int, string>();
            string token = "";

            try
            {
                response.Wait();
                token = response.Result.token;
                int statusCode = string.IsNullOrEmpty(token) ? 500 : 200;
                //if (statusCode == 200)
                //    token = content;
                resp.Add(statusCode, token);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                resp.Add(500, token);
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
                int statusCode = string.IsNullOrEmpty(token) ? 500 : 200;
                //if (statusCode == 200)
                //    token = content;
                resp.Add(statusCode, token);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                resp.Add(500, token);
                return resp;
            }
        }
    }
}
