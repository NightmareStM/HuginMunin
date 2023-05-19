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

        public async Task CreateNote(Note note)
        {
            await _http.PostAsJsonAsync("api/note", note);

            _navigationManger.NavigateTo($"note");
        }

        public async Task DeleteNote(int id)
        {
            var result = await _http.DeleteAsync($"api/note/{id}");
            _navigationManger.NavigateTo("note");//notes
        }

        public async Task<Note?> GetNoteById(int id)
        {
            var result = await _http.GetAsync($"api/note/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Note>();
            }
            return null;
        }

        public async Task GetNotes()
        {
            var result = await _http.GetFromJsonAsync<List<Note>>("api/note");
            if (result is not null)
                Notes = result;
        }

        public async Task UpdateNote(int id, Note note)
        {
            await _http.PutAsJsonAsync($"api/note/{id}", note);
            _navigationManger.NavigateTo($"/read/{id}");
        }
    }
}
