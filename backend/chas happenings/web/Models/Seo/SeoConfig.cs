using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Models.Seo
{
    public static class SeoConfig
    {
        // Default SEO metadata
        public static SeoMeta Default = new SeoMeta
        {
            Title = "Chas Happenings--An app with all events",
            Description = "Your central hub for all events and activities at Chas Academy",
            Keywords = "asp.net core, mvc, web app",
            OgTitle = "Chas Happenings--An app with all events",
            OgDescription = "Your central hub for all events and activities at Chas Academy",
            OgImage = "/images/seo/default-og.jpg",
            OgType = "website",
            CanonicalUrl = null
        };

        // Store SEO for the current request
        public static void Set(dynamic viewBag, SeoMeta meta)
        {
            viewBag.SeoMeta = meta;
        }

        // Merge defaults with page-specific metadata
        public static SeoMeta GetMerged(dynamic viewBag)
        {
            var custom = viewBag.SeoMeta as SeoMeta ?? new SeoMeta();
            return new SeoMeta
            {
                Title = custom.Title ?? Default.Title,
                Description = custom.Description ?? Default.Description,
                Keywords = custom.Keywords ?? Default.Keywords,
                OgTitle = custom.OgTitle ?? custom.Title ?? Default.OgTitle,
                OgDescription = custom.OgDescription ?? custom.Description ?? Default.OgDescription,
                OgImage = custom.OgImage ?? Default.OgImage,
                OgType = custom.OgType ?? Default.OgType,
                CanonicalUrl = custom.CanonicalUrl ?? Default.CanonicalUrl
            };
        }
    }
}

