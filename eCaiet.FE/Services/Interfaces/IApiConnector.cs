using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eCaiet.FE.Services.Interfaces
{
    public interface IApiConnector
    {
        IApiConnector ConnnectToHost(string host);
        Task<HttpStatusCode> DeleteAsync(string path, AuthenticationHeaderValue auth = null);
        Task<T> GetAsync<T>(string path, AuthenticationHeaderValue auth = null);
        Task PostAsync(string path, AuthenticationHeaderValue auth = null);
        Task PostAsync<TInput>(string path, TInput obj, AuthenticationHeaderValue auth = null);
        Task<TResult> PostAsync<TResult, TInput>(string path, TInput obj, AuthenticationHeaderValue auth = null);
        Task<TResult> PostAsync<TResult>(string path, AuthenticationHeaderValue auth = null);
        Task<HttpStatusCode> PutAsync<T>(string path, T obj, AuthenticationHeaderValue auth = null);
        Task<TResult> PutAsync<TResult, TInput>(string path, TInput obj, AuthenticationHeaderValue auth = null);
    }
}