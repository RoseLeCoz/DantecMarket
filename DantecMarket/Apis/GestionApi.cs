using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DantecMarket.Modeles;
using System.Net.Http;

namespace DantecMarket.Apis 
{
    public class GestionApi
    {
        public readonly HttpClient _httpClient = new HttpClient();

        public async Task<ObservableCollection<T>> GetAllAsync<T>(string url)
        {
            try
            {
                var json = await _httpClient.GetStringAsync(Constantes.BaseApiAddress + url);
                var result = JsonConvert.DeserializeObject<List<T>>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return new ObservableCollection<T>(result);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                throw;
            }
        }
        public async Task<T> GetAllAsyncOne<T>(string url)
        {
            try
            {
                var json = await _httpClient.GetStringAsync(Constantes.BaseApiAddress + url);
                T result = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                throw;
            }
        }
        public async Task<int?> PostAsync<T>(T data, string endpoint)
        {
            var jsonString = JsonConvert.SerializeObject(data);

            try
            {
                using (var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json"))
                {
                    var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);
                    return await ProcessResponseForIdAsync(response);
                }
            }
            catch (Exception ex)
            {
                // Log exception details for debugging.
                // Log.Error(ex, "Error occurred in PostDataAndGetIdAsync");
                return null;
            }
        }
        public async Task<HttpResponseMessage> PostAsyncHttpResponse<T>(T data, string endpoint)
        {
            var jsonString = JsonConvert.SerializeObject(data);

            try
            {
                using (var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json"))
                {
                    var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);
                    return response;  // Retourne directement l'objet HttpResponseMessage
                }
            }
            catch (Exception ex)
            {
                // Log exception details for debugging.
                // Log.Error(ex, "Error occurred in PostAsync");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);  // Retourne une réponse d'erreur en cas d'exception
            }
        }
        private async Task<int?> ProcessResponseForIdAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                // Log or handle the response error as needed.
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            return int.TryParse(content, out var id) ? id : null;
        }
        public async Task<ObservableCollection<T>> GetAllAsyncByID<T>(string endpoint, string key, int value)
        {
            try
            {
                var requestData = new JObject
                {
                    [key] = value
                };

                var jsonContent = new StringContent(requestData.ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    // Log or handle the response error as needed.
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<T>>(json);
                return new ObservableCollection<T>(result);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                return null;
            }
        }
        public async Task<T> GetOneAsyncByID<T>(string endpoint, string idValue)
        {
            try
            {
                var requestData = new JObject
                {
                    ["Id"] = idValue
                };

                var jsonContent = new StringContent(requestData.ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    // Log or handle the response error as needed.
                    return default(T);
                }

                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                return default(T);
            }
        }
        public async Task<T> GetOneAsync<T>(string endpoint, T requestDataObj)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(requestDataObj);
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(Constantes.BaseApiAddress + endpoint, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle or log the error based on the response status
                    return default(T);
                }

                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return result;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                return default(T);
            }
        }



    }
}