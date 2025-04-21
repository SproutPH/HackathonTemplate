using Microsoft.AspNetCore.Mvc;
using SproutHackathon.Business.LogicCollection.EmployeeBusiness;
using SproutHackathon.DataAccess.Entities;

namespace SproutHackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
     public class NotesController : ControllerBase
    {
        private readonly INoteBusiness _noteBusiness;

        public NotesController(INoteBusiness noteBusiness)
        {
            _noteBusiness = noteBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteBusiness.GetAllAsync();
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteEntity note)
        {
            var created = await _noteBusiness.AddAsync(note);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}