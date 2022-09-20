using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_App.Core;
using Resturant_App.Data;

namespace Resturant_App.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;

        public Resturant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            Resturant = resturantData.GetById(resturantId);

            if(Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
