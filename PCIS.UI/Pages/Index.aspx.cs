using Newtonsoft.Json;
using PCIS.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCIS.UI.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = await GetUsersAsync();
            GridView1.DataBind();
        }

        public static async Task<List<User>> GetUsersAsync()
        {
            UserModel userList = null;
            List<User> users = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:49679");
            HttpResponseMessage response = await client.GetAsync("api/Default");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                userList = JsonConvert.DeserializeObject<UserModel>(result);

                users = userList.UserList;
            }

            return users;
        }

    }
}