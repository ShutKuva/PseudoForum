using Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Post : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public int? AuthorId { get; set; }
        public User? Author { get; set; }

        public int? TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}
