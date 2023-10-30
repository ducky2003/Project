
namespace Project.Utilities
{
    public class Functions
    {
        public static string TitleSlugGenerator(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }
    }
}
