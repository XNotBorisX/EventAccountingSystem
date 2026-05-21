using System.Net.Http.Json;
using EventAccountingSystemAPI.Models;

namespace EventAccountingSystemUI;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(string baseAddress)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(baseAddress);
    }

    public async Task<List<Event>> GetEventsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Event>>("api/events") ?? new List<Event>();
    }

    public async Task<HttpResponseMessage> CreateEventAsync(Event eventItem)
    {
        return await _httpClient.PostAsJsonAsync("api/events", eventItem);
    }

    public async Task<HttpResponseMessage> UpdateEventAsync(Guid id, Event eventItem)
    {
        return await _httpClient.PutAsJsonAsync($"api/events/{id}", eventItem);
    }

    public async Task<HttpResponseMessage> DeleteEventAsync(Guid id)
    {
        return await _httpClient.DeleteAsync($"api/events/{id}");
    }
}