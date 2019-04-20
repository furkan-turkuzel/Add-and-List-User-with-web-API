using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCIS.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCIS.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        BlogEntities db = new BlogEntities();
        public IHttpActionResult Get()
        {
            List<User> users = db.User.ToList();

            UserModel userList = new UserModel()
            {
                UserList = users
            };
            return Ok(userList);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody]UserModel user)
        {
            string username = user.Username;
            string password = user.Password;

            User newUser = new User()
            {
                UserName = username,
                Password = password
            };

            db.User.Add(newUser);
            db.SaveChanges();

            return Ok(username);
        }
    }
}
