using System.Text.Json;
using System.Text;

namespace Comm2TenderBlazor.Helpers
{
    using Comm2TenderBlazor.Models.Dto;
    using Comm2TenderBlazor.Models.ViewModels;

    public class ApiRequests
    {
		public static async Task<List<T>> PostAllListAsync<T>(string path, HttpClient httpClient, string token)
		{

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, path);
            
            requestMessage.Headers.Authorization
	            = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var listRequest = new ListRequest();

            var json = JsonSerializer.Serialize(listRequest);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            requestMessage.Content = jsonContent;

            var responce = await httpClient.SendAsync(requestMessage);

            var content = await responce.Content.ReadAsStringAsync();

            var responseViewModel = JsonSerializer.Deserialize<ResponseViewModel<T>>(content);
            return responseViewModel.Items;
        }

		public static async Task<List<T>> SearchAsync<T>(string searchText, string path, HttpClient httpClient, string token)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, path);

            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var listRequest = new ListRequest();
            listRequest.Search = searchText;

            var json = JsonSerializer.Serialize(listRequest);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            requestMessage.Content = jsonContent;

            var responce = await httpClient.SendAsync(requestMessage);

            if (!responce.IsSuccessStatusCode)
            {
                return new List<T>();
            }

            var content = await responce.Content.ReadAsStringAsync();

            var responseViewModel = JsonSerializer.Deserialize<ResponseViewModel<T>>(content);

            if (responseViewModel == null)
            {
                return new List<T>();
            }

            return responseViewModel.Items;
        }

        public static async Task<T> GetItemAsync<T>(string path, HttpClient httpClient, string token)
        {

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var responce = await httpClient.SendAsync(requestMessage);

            var result = await responce.Content.ReadAsStringAsync();

	        return JsonSerializer.Deserialize<T>(result);
        }

        public static async Task<bool> PostItemAsync<T>(string path, HttpClient httpClient, string token, T item)
        {

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, path);

            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(item);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            requestMessage.Content = jsonContent;

            var responce = await httpClient.SendAsync(requestMessage);

            return responce.IsSuccessStatusCode;
        }

        public static async Task<bool> PutItemAsync<T>(string path, HttpClient httpClient, string token, T item)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, path);

            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(item);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            requestMessage.Content = jsonContent;

            var responce = await httpClient.SendAsync(requestMessage);

            return responce.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteItemAsync(string path, HttpClient httpClient, string token)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, path);

            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var responce = await httpClient.SendAsync(requestMessage);

            return responce.IsSuccessStatusCode;
        }

        public static async Task<List<T>> GetAllListAsync<T>(string path, HttpClient httpClient, string token)
        {

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, path);

            requestMessage.Headers.Authorization
                = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var listRequest = new ListRequest();

            var json = JsonSerializer.Serialize(listRequest);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            requestMessage.Content = jsonContent;

            var responce = await httpClient.SendAsync(requestMessage);

            var content = await responce.Content.ReadAsStringAsync();

            var responseViewModel = JsonSerializer.Deserialize<ResponseViewModel<T>>(content);
            return responseViewModel.Items;
        }
    }
}
