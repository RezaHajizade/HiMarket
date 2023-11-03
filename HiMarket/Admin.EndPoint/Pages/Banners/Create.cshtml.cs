using Application.Banners;
using Infrastructure.ChaceHelpers;
using Infrastructure.ExternalApi.ImageServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;

namespace Admin.EndPoint.Pages.Banners
{
    public class CreateModel : PageModel
    {
        private readonly IBannersService banners;
        private readonly IImageUploadService imageUploadService;
        private readonly IDistributedCache _cache;

        public CreateModel(IBannersService banners,
            IImageUploadService imageUploadService,
            IDistributedCache distributedCache)
        {
            this.banners = banners;
            this.imageUploadService = imageUploadService;
            _cache = distributedCache;
        }

        [BindProperty]
        public BannerDto Banner { get; set; }
        [BindProperty]
        public IFormFile BannerImage { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            //Upload
            var result = imageUploadService.Upload(new List<IFormFile> { BannerImage });
            if(result.Count > 0)
            {
                Banner.Image = result.FirstOrDefault();
                banners.AddBanner(Banner);

                _cache.Remove(CacheHelper.GenerateHomePageCacheKey());
            }
            return RedirectToPage("Index");
        }
    }
}
