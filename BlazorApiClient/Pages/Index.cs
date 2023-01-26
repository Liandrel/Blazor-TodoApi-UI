using BlazorApiClient.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class Index
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public TokenModel TokenInfo { get; set; }

        private AuthenticationModel login = new();
        private bool _isLoggedIn = false;


        protected override void OnInitialized()
        {
            if (string.IsNullOrWhiteSpace(TokenInfo.Token) == false)
            { 
                _isLoggedIn= true;
            }
        }


        private async void HandleValidSubmit()
        {
            var client = ClientFactory.CreateClient("api");


            var info = await client.PostAsJsonAsync<AuthenticationModel>("Authentication/token", login);

            TokenInfo.Token = await info.Content.ReadAsStringAsync();
            _isLoggedIn = true;
            await InvokeAsync(StateHasChanged);
        }

        private void LogOut()
        {
            _isLoggedIn = false;
            TokenInfo.Token = string.Empty;
        }
    }
}
