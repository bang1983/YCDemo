using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GRUDDemo.Models;

namespace GRUDDemo
{
    public class DetailsModel : PageModel
    {
        private readonly GRUDDemo.Models.DemoDBContext _context;

        public DetailsModel(GRUDDemo.Models.DemoDBContext context)
        {
            _context = context;
        }

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
    }
}
