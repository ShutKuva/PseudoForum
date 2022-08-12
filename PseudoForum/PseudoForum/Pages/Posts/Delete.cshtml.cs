using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages.Posts
{
    public class DeleteModel : PageModel
    {
        private readonly ICRUDService<Post> _postService;

        public DeleteModel(ICRUDService<Post> postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> OnGetAsync(int topicId, int id)
        {
            await _postService.Delete(id);

            return Redirect($"/Topics/Index/{topicId}");
        }
    }
}
