using FlexyBoxProject.Client.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace FlexyBoxProject.Client.Pages
{
    public partial class Home
    {
        public ApiClient Client { get; set; }

        public Home(ApiClient httpClient)
        {
            Client = httpClient;
        }
    }
}
