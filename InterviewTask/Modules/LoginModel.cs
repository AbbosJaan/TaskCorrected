using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Modules
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
