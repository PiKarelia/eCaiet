using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using eCaiet.FE.Services.Interfaces;

namespace eCaiet.FE.Services.Managers
{
    public class ApiConnector : IApiConnector
    {

        private readonly HttpClient _client;

        public ApiConnector()
        {
            _client = new HttpClient();
        }

        public IApiConnector ConnnectToHost(string host)
        {
            _client.BaseAddress = new Uri(host);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return this;
        }

        public async Task<T> GetAsync<T>(string path, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            var res = await _client.GetAsync(path);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsAsync<T>();
        }

        public async Task<TResult> PostAsync<TResult, TInput>(string path, TInput obj, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            var res = await _client.PostAsJsonAsync(path, obj);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsAsync<TResult>();
        }

        public async Task PostAsync<TInput>(string path, TInput obj, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            (await _client.PostAsJsonAsync(path, obj)).EnsureSuccessStatusCode();
        }

        public async Task<TResult> PostAsync<TResult>(string path, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            var res = await _client.PostAsync(path, new StringContent(string.Empty));
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsAsync<TResult>();
        }

        public async Task PostAsync(string path, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            await _client.PostAsync(path, new StringContent(string.Empty));
        }

        public async Task<TResult> PutAsync<TResult, TInput>(string path, TInput obj, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            var res = await _client.PutAsJsonAsync(path, obj);
            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsAsync<TResult>();
        }

        public async Task<HttpStatusCode> PutAsync<T>(string path, T obj, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            return (await _client.PutAsJsonAsync(path, obj)).StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(string path, AuthenticationHeaderValue auth = null)
        {
            if (auth != null)
                _client.DefaultRequestHeaders.Authorization = auth;
            return (await _client.DeleteAsync(path)).StatusCode;
        }
    }
}
