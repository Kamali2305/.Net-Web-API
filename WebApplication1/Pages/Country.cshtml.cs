using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.DTO;

namespace WebApplication1.Pages
{
    public class CountryModel : PageModel
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CountryModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;    
        }
        [BindProperty]
        public List<CountryDto> Countries { get; set; }
        //public async void OnGet()
        //{

        //    var httpClient = _httpClientFactory.CreateClient("WorldWebAPI");
        //    Countries = await httpClient.GetFromJsonAsync<List<CountryDto>>("api/Country");
        //}

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("WorldWebAPI");
            Countries = await httpClient.GetFromJsonAsync<List<CountryDto>>("api/Country");

            if (Countries == null)
            {
                // Handle null response, e.g., log an error, display a message to the user, etc.
            }
        }
    }
}
