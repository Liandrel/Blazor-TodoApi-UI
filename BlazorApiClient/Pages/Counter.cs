using BlazorApiClient.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
namespace BlazorApiClient.Pages
{
    public partial class Counter
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public TokenModel TokenInfo { get; set; }

        private bool _isLoggedIn = false;
        private HttpClient? _client;
        private string? errorMessage;

        public List<TodoModel>? Todos { get; set; }


        protected override void OnInitialized()
        {
            if (string.IsNullOrWhiteSpace(TokenInfo.Token) == false)
            {
                _isLoggedIn = true;
                _client = ClientFactory.CreateClient("api");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenInfo.Token);
            }
        }


        private async void FetchTodos()
        {
            errorMessage= string.Empty;
            try
            {
                Todos = await _client!.GetFromJsonAsync<List<TodoModel>>("Todos");
            }
            catch (Exception ex)
            {
                errorMessage= ex.Message;
            }
            await InvokeAsync(StateHasChanged);
        }

        private async void CompleteTodo(TodoModel todo)
        {
            await _client!.PutAsJsonAsync<string>($"Todos/{todo.Id}/Complete", "");
            todo.IsComplete= true;
            await InvokeAsync(StateHasChanged);

        }
    }
}
