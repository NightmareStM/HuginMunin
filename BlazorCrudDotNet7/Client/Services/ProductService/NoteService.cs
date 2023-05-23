using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorCrudDotNet7.Client.Services.NoteService
{
    public class NoteService : INoteService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public NoteService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// crea una nuova nota nel DB
        /// </summary>
        /// <param name="note">campo nota da implementare nel DB</param>
        /// <returns></returns>
        public async Task CreateNote(Note note)
        {
            await _http.PostAsJsonAsync("api/note", note);

            _navigationManger.NavigateTo($"note");
        }

        /// <summary>
        /// Elimina una determinata nota dal DB
        /// </summary>
        /// <param name="id">id della nota da eliminare</param>
        /// <returns></returns>
        public async Task DeleteNote(int id)
        {
            var result = await _http.DeleteAsync($"api/note/{id}");
            _navigationManger.NavigateTo("note");//notes
        }

        /// <summary>
        /// prende una determinata nota dal DB
        /// </summary>
        /// <param name="id">id della nota da recuperare dal DB</param>
        /// <returns>
        /// ritorna la nota selezionata in caso di presenza nel DB, altrimenti null
        /// </returns>
        public async Task<Note?> GetNoteById(int id)
        {
            var result = await _http.GetAsync($"api/note/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Note>();
            }
            return null;
        }

        /// <summary>
        /// prende tutte le note dal DB
        /// </summary>
        /// <returns>
        /// ritorna tutte le note all'interno di se stesso
        /// </returns>
        public async Task GetNotes()
        {
            var result = await _http.GetFromJsonAsync<List<Note>>("api/note");
            if (result is not null)
                Notes = result;
        }

        /// <summary>
        /// aggiorna una nota specifica nel DB
        /// </summary>
        /// <param name="id">id della nota da modificare</param>
        /// <param name="note">nota con tutti i campi da rimpiazzare</param>
        /// <returns></returns>
        public async Task UpdateNote(int id, Note note)
        {
            await _http.PutAsJsonAsync($"api/note/{id}", note);
            _navigationManger.NavigateTo($"/read/{id}");
        }
    }
}
