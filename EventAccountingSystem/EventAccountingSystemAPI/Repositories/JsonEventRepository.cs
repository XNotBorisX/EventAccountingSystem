using System.Text.Json;
using System.Text.Json.Serialization;
using EventAccountingSystemAPI.Models;

namespace EventAccountingSystemAPI.Repositories;

public class JsonEventRepository : IEventRepository
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public JsonEventRepository(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<List<Event>> GetAllAsync()
    {
        if (!File.Exists(_filePath))
            return new List<Event>();
        var json = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrWhiteSpace(json))
            return new List<Event>();
        return JsonSerializer.Deserialize<List<Event>>(json, _options) ?? new List<Event>();
    }

    public async Task<Event?> GetByIdAsync(Guid id)
    {
        var events = await GetAllAsync();
        return events.FirstOrDefault(e => e.Id == id);
    }

    public async Task AddAsync(Event eventItem)
    {
        var events = await GetAllAsync();
        events.Add(eventItem);
        await SaveAllAsync(events);
    }

    public async Task UpdateAsync(Event eventItem)
    {
        var events = await GetAllAsync();
        var index = events.FindIndex(e => e.Id == eventItem.Id);
        if (index >= 0)
        {
            events[index] = eventItem;
            await SaveAllAsync(events);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var events = await GetAllAsync();
        events.RemoveAll(e => e.Id == id);
        await SaveAllAsync(events);
    }

    private async Task SaveAllAsync(List<Event> events)
    {
        var dir = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
        var json = JsonSerializer.Serialize(events, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}