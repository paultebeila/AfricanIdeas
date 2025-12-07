using AfricanIdeas.Models;
using System.Net.Http.Json;

namespace AfricanIdeas.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public StudentDto LoggedInUser { get; private set; }

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Login(string username, string password)
        {
            var request = new LoginRequest { Username = username, Password = password };

            var response = await _http.PostAsJsonAsync("api/auth/login", request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            LoggedInUser = await response.Content.ReadFromJsonAsync<StudentDto>();
            return true;
        }

        public async Task<bool> Register(string username, string password)
        {
            var request = new RegisterRequest { Username = username, Password = password };
            var response = await _http.PostAsJsonAsync("api/auth/register", request);

            return response.IsSuccessStatusCode;
        }
    }
}
