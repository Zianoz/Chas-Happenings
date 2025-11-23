namespace chas_happenings.Models.Seo
{
    public class SeoMeta
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;

        // Open Graph (social sharing)
        public string OgTitle { get; set; } = string.Empty;
        public string OgDescription { get; set; } = string.Empty;
        public string OgImage { get; set; } = string.Empty;
        public string OgType { get; set; } = "website";

    }
}
