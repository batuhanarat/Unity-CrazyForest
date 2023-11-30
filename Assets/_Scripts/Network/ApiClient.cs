using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

namespace _Scripts
{
    public static class ApiClient
    {
        public static async Task<T> Get<T>(string endpoint)
        {
            var getRequest = HttpClient.CreateRequest(endpoint);
            getRequest.SendWebRequest();

            while (!getRequest.isDone) await Task.Delay(10);
            return JsonConvert.DeserializeObject<T>(getRequest.downloadHandler.text);
        }

        public static async Task<T> Post<T>(string endpoint, object payload)
        {
            var postRequest = HttpClient.CreateRequest(endpoint, HttpClient.RequestType.POST, payload);
            postRequest.SendWebRequest();

            while (!postRequest.isDone) await Task.Delay(10);
            return JsonConvert.DeserializeObject<T>(postRequest.downloadHandler.text);
        }
    }
}