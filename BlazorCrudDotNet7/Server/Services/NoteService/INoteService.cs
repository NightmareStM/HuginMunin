using BlazorCrudDotNet7.Shared;

namespace BlazorCrudDotNet7.Server.Services.NoteService
{
    public interface INoteService
    {
        Task<List<Note>> GetNotes();
        Task<Note?> GetNoteById(int noteId);
        Task<Note> CreateNote(Note note);
        Task<Note?> UpdateNote(int noteId, Note note);
        Task<bool> DeleteNote(int noteId);
    }
}
