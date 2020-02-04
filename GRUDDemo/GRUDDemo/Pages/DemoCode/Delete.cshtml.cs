using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GRUDDemo.Models;
using GRUDDemo.Services;

namespace GRUDDemo
{
    public class DeleteModel : PageModel
    {
        private readonly IDemoCodeService _demoCodeService;

        public DeleteModel(IDemoCodeService demoCodeService)
        {

            _demoCodeService = demoCodeService;
        }

        [BindProperty]
        public DemoCode DemoCode { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemoCode = _demoCodeService.Get(id.Value);

            if (DemoCode == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemoCode = _demoCodeService.Get(id.Value);

            if (DemoCode != null)
            {
                _demoCodeService.Delete(DemoCode);
            }

            return RedirectToPage("./Index");
        }
    }
}
