using BlazorCrudDotNet7.Server.Services.NoteService;
using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<List<Note>> GetNotes()
        {
            return await _noteService.GetNotes();
        }

        [HttpGet("{id}")]
        public async Task<Note?> GetNoteById(int id)
        {
            return await _noteService.GetNoteById(id);
        }

        [HttpPost]
        public async Task<Note?> CreateNote(Note note)
        {
            return await _noteService.CreateNote(note);
        }

        [HttpPut("{id}")]
        public async Task<Note?> UpdateNote(int id, Note note)
        {
            return await _noteService.UpdateNote(id, note);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteNote(int id)
        {
            return await _noteService.DeleteNote(id);
        }
    }
}
