using BlazorCrudDotNet7.Shared;

namespace BlazorCrudDotNet7.Client.Services.NoteService
{
    public interface INoteService
    {
        List<Note> Notes { get; set; }
        
        /// <summary>
        /// prende tutte le note dal DB
        /// </summary>
        /// <returns>
        /// ritorna tutte le note all'interno di se stesso
        /// </returns>
        Task GetNotes();

        /// <summary>
        /// prende una determinata nota dal DB
        /// </summary>
        /// <param name="id">id della nota da recuperare dal DB</param>
        /// <returns>
        /// ritorna la nota selezionata in caso di presenza nel DB, altrimenti null
        /// </returns>
        Task<Note?> GetNoteById(int id);

        /// <summary>
        /// crea una nuova nota nel DB
        /// </summary>
        /// <param name="note">campo nota da implementare nel DB</param>
        /// <returns></returns>
        Task CreateNote(Note note);

        /// <summary>
        /// aggiorna una nota specifica nel DB
        /// </summary>
        /// <param name="id">id della nota da modificare</param>
        /// <param name="note">nota con tutti i campi da rimpiazzare</param>
        /// <returns></returns>
        Task UpdateNote(int id, Note note);

        /// <summary>
        /// Elimina una determinata nota dal DB
        /// </summary>
        /// <param name="id">id della nota da eliminare</param>
        /// <returns></returns>
        Task DeleteNote(int id);
    }
}
