using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages.Topics
{
    public class IndexModel : PageModel
    {
        private readonly ICRUDService<Topic> _topicService;
        private readonly ICRUDService<Post> _postService;

        public Topic Topic { get; set; }

        public string Text { get; set; }

        public IndexModel(ICRUDService<Topic> topicService, ICRUDService<Post> postService)
        {
            _topicService = topicService;
            _postService = postService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Topic topic = await _topicService.Get(id);

            if (topic == null)
            {
                return RedirectToPage("/Index");
            }

            Topic = topic;

            return Page();
        }
    }
}
