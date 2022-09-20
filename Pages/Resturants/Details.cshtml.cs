using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturant_App.Core;
using Resturant_App.Data;

namespace Resturant_App.Pages.Resturants
{
    public class DetailsModel : PageModel
    {
        private readonly IResturantData resturantData;
        public Resturant Resturant { get; set; }

        public DetailsModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.GetById(resturantId);

            if(Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
