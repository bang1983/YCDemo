using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GRUDDemo.Models;
using GRUDDemo.Services;

namespace GRUDDemo
{
    public class CreateModel : PageModel
    {
 
        private readonly IDemoCodeService _demoCodeService;

        public CreateModel(IDemoCodeService demoCodeService)
        {
 
            _demoCodeService = demoCodeService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DemoCode DemoCode { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //檢查同日期是否已有資料，若是顯示日期重複
            if (_demoCodeService.GetAll().Any(o => o.Code == DemoCode.Code))
            {
                ModelState.AddModelError("DemoCode.Code", "代碼已存在");
                return Page();
            }
 
     
            _demoCodeService.Create(DemoCode);

            return RedirectToPage("./Index");
        }
    }
}
