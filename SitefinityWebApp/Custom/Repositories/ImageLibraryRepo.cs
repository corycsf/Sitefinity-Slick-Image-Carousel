using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Libraries.Model;

namespace SitefinityWebApp.Data
{
    public static class ImageLibraryRepo
    {
        public static List<HomepageCarouselModel> GetHomepageCarouselItems(Guid imageGalleryID)
        {

            var rawItems = App.WorkWith().Images()
                .Where(i => i.Album.Id == imageGalleryID).Published()
                .OrderBy(i => i.Ordinal).Get().ToList();

            Func<Image, string, string> _getStringValue = (image, val) => image.GetValue(val)?.ToString() ?? string.Empty;

            List<HomepageCarouselModel> retval = rawItems.Select(item => new HomepageCarouselModel
            {
                ItemSummary = _getStringValue(item, "ItemSummary"),
                ItemTitle = _getStringValue(item, "ItemTitle"),
                ImageUrl = item.Url,
                PageLink = _getStringValue(item, "PageLink"),
                AltText = _getStringValue(item, "AlternativeText")

            }).ToList();

            return retval;

        }
    }
}