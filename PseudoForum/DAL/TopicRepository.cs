using Core;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TopicRepository : GenericRepository<Topic>
    {
        public TopicRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext.Set<Topic>()
                .Include(t => t.Posts)
                .ThenInclude(p => p.Author);
        }

        public override Task<Topic> Get(int id)
        {
            return Task.Run(() => _dbContext.Set<Topic>()
                .Include(t => t.Posts)
                .ThenInclude(p => p.Author)
                .FirstOrDefault(t => t.Id == id));
        }
    }
}
