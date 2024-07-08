using System.Text.Json;
using System.Text;
using Comm2TenderBlazor.Pages.Proposals;

namespace Comm2TenderBlazor.Helpers
{
    using Comm2TenderBlazor.Models.Dto;
    using Comm2TenderBlazor.Models.ViewModels;

    public class PagesHelper
    {
		public static async Task<List<T>> GetAllListAsync<T>(string path, HttpClient httpClient)
		{
			var listRequest = new ListRequest();

			var json = JsonSerializer.Serialize(listRequest);
			var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

			var responce = await httpClient.PostAsync(path, jsonContent);

			var content = await responce.Content.ReadAsStringAsync();

            var responseViewModel = JsonSerializer.Deserialize<ResponseViewModel<T>>(content);
            return responseViewModel.Items;

        }

        public static async Task<List<T>> SearchAsync<T>(string searchText, string path, HttpClient httpClient)
        {
            var listRequest = new ListRequest();
            listRequest.Search = searchText;

            var json = JsonSerializer.Serialize(listRequest);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await httpClient.PostAsync(path, jsonContent);

            var content = await responce.Content.ReadAsStringAsync();

            var responseViewModel = JsonSerializer.Deserialize<ResponseViewModel<T>>(content);

            return responseViewModel?.Items;
        }

        public static async Task<T> GetItemsAsync<T>(string path, HttpClient httpClient)
        {
           
            var responce = await httpClient.GetAsync(path);
            var result = await responce.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(result);
            
        }
    }
}
