using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly ICRUDService<Post> _postService;

        [BindProperty]
        public string Text { get; set; }

        public EditModel(ICRUDService<Post> postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> OnPostAsync(int topicId, int id)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                Post post = await _postService.Get(id);

                post.Text = Text;

                await _postService.Edit(post);
            }

            return RedirectToPage($"/Topics/Index", new { id = topicId });
        }
    }
}
