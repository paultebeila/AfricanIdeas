using AfricanIdeas.Models;
using System.Net.Http.Json;

namespace AfricanIdeas.Services
{
    public class CourseService
    {
        private readonly HttpClient _http;

        public CourseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CourseDto>> GetAllCourses()
        {
            return await _http.GetFromJsonAsync<List<CourseDto>>("api/courses");
        }

        public async Task<List<CourseDto>> GetCoursesForStudent(int studentId)
        {
            return await _http.GetFromJsonAsync<List<CourseDto>>($"api/courses/student/{studentId}");
        }

        public async Task<bool> Enroll(int studentId, int courseId)
        {
            var response = await _http.PostAsync(
                $"api/courses/{courseId}/enroll/{studentId}", null);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Unenroll(int studentId, int courseId)
        {
            var response = await _http.DeleteAsync(
                $"api/courses/{courseId}/unenroll/{studentId}");

            return response.IsSuccessStatusCode;
        }
    }
}
