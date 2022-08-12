using Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public List<Topic>? Topics { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
