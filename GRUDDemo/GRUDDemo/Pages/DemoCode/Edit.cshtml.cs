using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GRUDDemo.Models;

namespace GRUDDemo
{
    public class EditModel : PageModel
    {
        private readonly GRUDDemo.Models.DemoDBContext _context;

        public EditModel(GRUDDemo.Models.DemoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DemoCode DemoCode { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DemoCode = await _context.DemoCode.FirstOrDefaultAsync(m => m.ID == id);

            if (DemoCode == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DemoCode).State = EntityState.Modified;
 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemoCodeExists(DemoCode.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DemoCodeExists(Guid id)
        {
            return _context.DemoCode.Any(e => e.ID == id);
        }
    }
}
