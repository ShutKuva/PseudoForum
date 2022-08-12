using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICRUDService<Topic> _topicService;

        public IEnumerable<Topic> TopicList { get; set; }

        public IndexModel(ICRUDService<Topic> topicService)
        {
            _topicService = topicService;
        }

        public async Task OnGetAsync()
        {
            TopicList = await _topicService.GetAll();
        }
    }
}