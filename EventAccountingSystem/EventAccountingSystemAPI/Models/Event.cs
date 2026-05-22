using System;
using System.Text.Json.Serialization;

namespace EventAccountingSystemAPI.Models;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime EventDate { get; set; } = DateTime.Now.AddDays(7);
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [JsonIgnore]
    private EventStatus _status = EventStatus.Planned;

    public string Status
    {
        get => _status.ToString();
        set
        {
            if (Enum.TryParse<EventStatus>(value, out var parsed))
                _status = parsed;
        }
    }

    public string Type { get; set; } = "Conference";

    public void ChangeStatus(EventStatus newStatus)
    {
        _status = newStatus;
    }
}