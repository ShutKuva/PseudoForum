using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages.Topics
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ICRUDService<Topic> _crudService;

        public int Id { get; set; }

        public string Name { get; set; }

        public string Error { get; set; }

        public EditModel(ICRUDService<Topic> crudService)
        {
            _crudService = crudService;
        }

        public async Task OnGet(int id = -1)
        {
            Id = id;

            if (id != -1)
            {
                Topic topic = await _crudService.Get(id);

                Name = topic.Name;
            }
        }

        public async Task<IActionResult> OnPostAsync(int id = -1)
        {
            if (id != -1)
            {
                Topic topic = await _crudService.Get(Id);

                if (topic == null)
                {
                    return Page();
                }

                topic.Name = Name;

                await _crudService.Edit(topic);
            }
            else
            {
                Topic topic = await _crudService.Get(id);

                if (topic != null)
                {
                    return Page();
                }

                topic = new Topic() { Name = Name, AuthorId = int.Parse(User.Claims.First(claim => claim.Type == "Id").Value) };

                await _crudService.Create(topic);
            }

            return RedirectToPage("/Index");
        }
    }
}
