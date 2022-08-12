using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly ICRUDService<Post> _postService;

        public CreateModel(ICRUDService<Post> postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> OnPostAsync(int id, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Post post = new Post() { Text = text, AuthorId = int.Parse(User.FindFirst("Id").Value), TopicId = id };

                await _postService.Create(post);
            }

            return Redirect($"~/Topics/Index/{id}");
        }
    }
}
