using BLL.Abstractions;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PseudoForum.Pages.Topics
{
    public class DeleteModel : PageModel
    {
        private readonly ICRUDService<Topic> _crudService;

        public DeleteModel(ICRUDService<Topic> crudService)
        {
            _crudService = crudService;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _crudService.Delete(id);

            return RedirectToPage("/Index");
        }
    }
}
