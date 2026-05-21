using EventAccountingSystemAPI.Models;

namespace EventAccountingSystemAPI.Repositories;

public interface IEventRepository
{
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(Guid id);
    Task AddAsync(Event eventItem);
    Task UpdateAsync(Event eventItem);
    Task DeleteAsync(Guid id);
}