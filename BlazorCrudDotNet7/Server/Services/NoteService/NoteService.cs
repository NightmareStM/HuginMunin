using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Services.NoteService
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task<Note> CreateNote(Note note)
        {
            _context.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeleteNote(int noteId)
        {
            var dbNote = await _context.Notes.FindAsync(noteId);
            if (dbNote == null)
            {
                return false;
            }

            _context.Remove(dbNote);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Note?> GetNoteById(int noteId)
        {
            var dbNote = await _context.Notes.FindAsync(noteId);
            return dbNote;
        }

        public async Task<List<Note>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note?> UpdateNote(int noteId, Note note)
        {
            var dbNote = await _context.Notes.FindAsync(noteId);
            if (dbNote != null)
            {
                dbNote.Title = note.Title;
                dbNote.Description = note.Description;
                dbNote.Tag = note.Tag;
                dbNote.Update = note.Update;

                await _context.SaveChangesAsync();
            }

            return dbNote;
        }
    }
}
