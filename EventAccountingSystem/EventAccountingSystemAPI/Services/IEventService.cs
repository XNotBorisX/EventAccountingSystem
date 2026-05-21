using EventAccountingSystemAPI.Models;

namespace EventAccountingSystemAPI.Services;

public interface IEventService
{
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(Guid id);
    Task<Event> CreateAsync(Event eventItem);
    Task<bool> UpdateAsync(Guid id, Event eventItem);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ChangeStatusAsync(Guid id, EventStatus status);
}