using EventAccountingSystemAPI.Models;
using EventAccountingSystemAPI.Repositories;

namespace EventAccountingSystemAPI.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _repository;

    public EventService(IEventRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Event>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Event?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public async Task<Event> CreateAsync(Event eventItem)
    {
        if (string.IsNullOrWhiteSpace(eventItem.Title))
            throw new ArgumentException("Название мероприятия обязательно");
        await _repository.AddAsync(eventItem);
        return eventItem;
    }

    public async Task<bool> UpdateAsync(Guid id, Event eventItem)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return false;
        eventItem.Id = id;
        await _repository.UpdateAsync(eventItem);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return false;
        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<bool> ChangeStatusAsync(Guid id, EventStatus status)
    {
        var eventItem = await _repository.GetByIdAsync(id);
        if (eventItem is null) return false;
        eventItem.ChangeStatus(status);
        await _repository.UpdateAsync(eventItem);
        return true;
    }
}