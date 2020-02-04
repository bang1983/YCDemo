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
    public class IndexModel : PageModel
    {
        private readonly GRUDDemo.Models.DemoDBContext _context;

        public IndexModel(GRUDDemo.Models.DemoDBContext context)
        {
            _context = context;
        }

        public IList<DemoCode> DemoCode { get;set; }

        public async Task OnGetAsync()
        {
            DemoCode = await _context.DemoCode.ToListAsync();
        }
    }
}
