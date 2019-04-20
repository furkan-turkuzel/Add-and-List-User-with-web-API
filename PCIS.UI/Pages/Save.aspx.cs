using Newtonsoft.Json;
using PCIS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCIS.UI.Pages
{
    public partial class Save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                lblBilgi.Text = "Bütün alanları doldurmanız gerekmektedir.";
            }
            else
            {
                UserModel user = new UserModel();
                user.Username = txtUsername.Text;
                user.Password = txtPassword.Text;

                var response = SendUserAsync(user);

                //lblBilgi.Text = "";
                //lblBilgi.Text = response.ToString();
            }
        }

        public static async Task<string> SendUserAsync(UserModel user)
        {
            using (var client = new HttpClient())
            {
                string message = null;
                var myContent = JsonConvert.SerializeObject(user);
                var content = new StringContent(myContent, Encoding.UTF8, "application/json");

                client.BaseAddress = new Uri("http://localhost:49679/");
                HttpResponseMessage response = await client.PostAsync("api/Default/", content).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    if (result == null)
                    {
                        message = "User bilgisi gönderilemedi.";
                    }
                    else
                    {
                        message = "User bilgisi başarıyla gönderildi.";
                    }
                }

                return message;
            }
        }
    }
}