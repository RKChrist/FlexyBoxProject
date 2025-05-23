using Shared.DTOs;
using System.Net.Http.Json;

namespace FlexyBoxProject.Client.Services
{
    public class ApiClient
    {
        private readonly HttpClient http;

        public ApiClient(HttpClient http)
        {
            this.http = http;
        }

        public Task<IEnumerable<ResturantDTO>?> GetRestaurantsAsync()
        {
            return http.GetFromJsonAsync<IEnumerable<ResturantDTO>>("api/restaurant");
        }

        public Task<ResturantDTO?> GetRestaurantAsync(int id)
        {
            return http.GetFromJsonAsync<ResturantDTO>($"api/restaurant/{id}");
        }

        public Task AddRestaurantAsync(ResturantDTO restaurant)
        {
            return http.PostAsJsonAsync("api/restaurant", restaurant);
        }

        public Task UpdateRestaurantAsync(int id, ResturantDTO restaurant)
        {
            return http.PutAsJsonAsync($"api/restaurant/{id}", restaurant);
        }

        public Task DeleteRestaurantAsync(int id)
        {
            return http.DeleteAsync($"api/restaurant/{id}");
        }
    }
}

