
using FlexyBoxProject.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared.DTOs;
using Shared.ViewModels;
using System.Text.Json;

namespace FlexyBoxProject.Client.Pages
{
    public partial class Resturant
    {
        public ApiClient Client { get; set; }
        public ResturantDTO? ResturantDTO { get; set; }

        [Parameter]
        public int Id { get; set; }

        private bool Liked { get; set; }

        List<TimeSlotRange> ranges;


        public Resturant(ApiClient httpClient)
        {
            Client = httpClient;


        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ResturantDTO = await Client.GetRestaurantAsync(Id);

                foreach(var range in ResturantDTO.Openings)
                {
                    range.timeSlotRanges = TimeSlotHelper.GetTimeSlotRanges(range.Days).ToList();
                }


                // Defer JS interop until after render (avoids static prerender errors)
                UserId = await JS.InvokeAsync<string>("localStorage.getItem", "userId");
                if (string.IsNullOrEmpty(UserId))
                {
                    UserId = Guid.NewGuid().ToString();
                    await JS.InvokeVoidAsync("localStorage.setItem", "userId", UserId);
                }
                var likedJson = await JS.InvokeAsync<string>("localStorage.getItem", "likedRestaurants");
                if (!string.IsNullOrEmpty(likedJson))
                {
                    try
                    {
                        var list = JsonSerializer.Deserialize<List<int>>(likedJson);
                        if (list != null) LikedRestaurants = list.ToHashSet();
                        if (LikedRestaurants.Contains(ResturantDTO.Id)){
                            ResturantDTO.Liked = true;
                            Liked = true;
                        }
                        else
                        {
                            Liked = false;
                        }
                    }
                    catch { }
                }
                Console.WriteLine(ResturantDTO.Liked);

                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
