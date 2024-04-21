using System;
using System.Text.Json;

namespace Articium.Utils
{
    public static class HttpResponseMessageJsonSerializer
    {
        public static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Response status code: {response.StatusCode}");
            }

            string contentString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(contentString);
        }
    }
}

