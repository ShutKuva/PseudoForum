using Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }

        public int? AuthorId { get; set; }
        public User? Author { get; set; }

        public List<Post>? Posts { get; set; }
    }
}
