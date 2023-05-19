using BlazorCrudDotNet7.Shared;

namespace BlazorCrudDotNet7.Client.Services.NoteService
{
    public interface INoteService
    {
        List<Note> Notes { get; set; }
        Task GetNotes();
        Task<Note?> GetNoteById(int id);
        Task CreateNote(Note note);
        Task UpdateNote(int id, Note note);
        Task DeleteNote(int id);
    }
}
