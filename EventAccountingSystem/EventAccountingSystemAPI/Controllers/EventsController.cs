using Microsoft.AspNetCore.Mvc;
using EventAccountingSystemAPI.Models;
using EventAccountingSystemAPI.Services;

namespace EventAccountingSystemAPI.Controllers;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly IEventService _service;

    public EventsController(IEventService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Event>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Event>> GetById(Guid id)
    {
        var eventItem = await _service.GetByIdAsync(id);
        if (eventItem is null)
            return NotFound();
        return Ok(eventItem);
    }

    [HttpPost]
    public async Task<ActionResult<Event>> Create(Event eventItem)
    {
        var created = await _service.CreateAsync(eventItem);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Event eventItem)
    {
        var updated = await _service.UpdateAsync(id, eventItem);
        if (!updated)
            return NotFound();
        return NoContent();
    }

    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id, [FromBody] string statusString)
    {
        if (string.IsNullOrWhiteSpace(statusString))
            return BadRequest("Статус не может быть пустым");

        // Преобразуем строку в Enum EventStatus
        EventStatus status = statusString switch
        {
            "InProgress" => EventStatus.InProgress,
            "Completed" => EventStatus.Completed,
            "Canceled" => EventStatus.Canceled,
            "Planned" => EventStatus.Planned,
            _ => EventStatus.Planned
        };

        var changed = await _service.ChangeStatusAsync(id, status);
        if (!changed)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}